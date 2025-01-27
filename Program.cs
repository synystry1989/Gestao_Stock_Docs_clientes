using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace TeleBerço
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {


            // Criar o banco de dados antes de carregar o formulário principal
            try
            {
                ConfigurarBancoDados(Environment.MachineName); // Aqui o nome do servidor é o nome do computador
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar o banco de dados: {ex.Message}");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }

        public static void ConfigurarBancoDados(string nomeServidor)
        {
            // Caminho do script SQL na pasta Resources
            string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Gestao&Stock_TB2017.sql");
            string nomeBanco = "DB_TeleBerco2017";
            // Verificar se o arquivo existe
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException("O arquivo Gestao&Stock_TB2017.sql não foi encontrado na pasta Resources.");
            }

            try
            {
                // String de conexão ao banco 'master' para criação do banco de dados
                string masterConnectionString = $"Server={nomeServidor};Database=master;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

                // Ler o script SQL
                string script = File.ReadAllText(scriptPath);

                // Dividir o script com base no "GO"
                string[] commands = script.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                using (SqlConnection connection = new SqlConnection(masterConnectionString))
                {
                    connection.Open();

                    foreach (var command in commands)
                    {
                        if (!string.IsNullOrWhiteSpace(command))
                        {
                            using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                            {
                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }

                Console.WriteLine("Banco de dados configurado com sucesso!");


                // Atualizar a string de conexão para o banco recém-criado
                AtualizarStringConexao(nomeServidor,nomeBanco);

                string scriptDados = @"
            USE DB_Teleberco2017;

            -- Criar a tabela TipoDocumentos
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TipoDocumentos')
            BEGIN
                CREATE TABLE TipoDocumentos (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nome NVARCHAR(50) NOT NULL,
                    Descricao NVARCHAR(255) NOT NULL
                );
            END;

            -- Inserir os valores na tabela TipoDocumentos
            INSERT INTO TipoDocumentos (Nome, Descricao)
            VALUES 
                ('FTC', 'Fatura Cliente'),
                ('NDC', 'Nota Devolução Cliente'),
                ('NDF', 'Nota Devolução Fornecedor'),
                ('EDC', 'Encomenda de Cliente'),
                ('EDF', 'Encomenda de Fornecedor'),
                ('ORC', 'Orçamento');
        ";


                // String de conexão ao banco DB_Teleberco2017
                string connectionString = $"Server={nomeServidor};Database={nomeBanco};Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(scriptDados, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Tabela TipoDocumentos criada e registros inseridos com sucesso!");
            }


            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao configurar o banco de dados: {ex.Message}");
                throw;
            }
        }

        private static void AtualizarStringConexao(string nomeServidor, string nomeBanco)
        {
            // Nome fixo do banco de dados criado
            

            // Nova string de conexão com o banco de dados criado
            string novaStringConexao = $"Server={nomeServidor};Database={nomeBanco};Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

            // Caminho do arquivo de configuração do aplicativo
            string configPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

            try
            {
                // Carregar o arquivo de configuração
                var configDoc = new System.Xml.XmlDocument();
                configDoc.Load(configPath);

                // Procurar a seção connectionStrings
                var connectionStringsNode = configDoc.SelectSingleNode("configuration/connectionStrings");
                if (connectionStringsNode != null)
                {
                    foreach (System.Xml.XmlNode node in connectionStringsNode.ChildNodes)
                    {
                        if (node.Attributes["name"].Value == "MinhaBaseLocal") // Nome da conexão no config
                        {
                            node.Attributes["connectionString"].Value = novaStringConexao;
                            break;
                        }
                    }

                    // Salvar o arquivo de configuração atualizado
                    configDoc.Save(configPath);

                    Console.WriteLine("String de conexão atualizada com sucesso!");
                }
                else
                {
                    throw new Exception("Seção 'connectionStrings' não encontrada no arquivo de configuração.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar a string de conexão: {ex.Message}");
                throw;
            }
        }
    }
}
