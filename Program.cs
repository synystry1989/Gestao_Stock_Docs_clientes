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

            // Verificar se o arquivo de script existe
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException("O arquivo Gestao&Stock_TB2017.sql não foi encontrado na pasta Resources.");
            }

            try
            {
                // String de conexão ao banco 'master' para criação do banco de dados
                string masterConnectionString = $"Server={nomeServidor};Database=master;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

                // Verificar se o banco de dados já existe
                if (!BancoDeDadosExiste(nomeServidor, nomeBanco))
                {
                    // Ler o script SQL para criar o banco
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

                    MessageBox.Show($"Banco de dados {nomeBanco} configurado com sucesso!");

                    // Atualizar a string de conexão para o banco recém-criado
                    AtualizarStringConexao(nomeServidor, nomeBanco);
                }
                

                // Verificar se a tabela TipoDocumentos está vazia e inserir os dados, se necessário
                InserirDadosSeNecessario(nomeServidor, nomeBanco);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao configurar o banco de dados: {ex.Message}");
                throw;
            }
        }

        private static bool BancoDeDadosExiste(string nomeServidor, string nomeBanco)
        {
            string connectionString = $"Server={nomeServidor};Database=master;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            string query = $"SELECT database_id FROM sys.databases WHERE name = '{nomeBanco}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    return result != null;
                }
            }
        }

        private static void InserirDadosSeNecessario(string nomeServidor, string nomeBanco)
        {
            // String de conexão ao banco DB_Teleberco2017
            string connectionString = $"Server={nomeServidor};Database={nomeBanco};Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

            // Consultar se a tabela TipoDocumentos está vazia
            string query = "SELECT COUNT(*) FROM TipoDocumentos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    if (count == 0)
                    {
                        // A tabela está vazia, inserir os dados
                        string scriptDados = @"
                    INSERT INTO TipoDocumentos (CodDoc, Descricao)
                    VALUES 
                        ('FTC', 'Fatura Cliente'),
                        ('NDC', 'Nota Devolução Cliente'),
                        ('NDF', 'Nota Devolução Fornecedor'),
                        ('EDC', 'Encomenda de Cliente'),
                        ('EDF', 'Encomenda de Fornecedor'),
                        ('ORC', 'Orçamento');
                ";

                        using (SqlCommand insertCommand = new SqlCommand(scriptDados, connection))
                        {
                            insertCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Registros inseridos com sucesso!");
                    }
                 
                }
            }
        }

        private static void AtualizarStringConexao(string nomeServidor, string nomeBanco)
        {
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

                    MessageBox.Show("String de conexão atualizada com sucesso!");
                }
                else
                {
                    throw new Exception("Seção 'connectionStrings' não encontrada no arquivo de configuração.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar a string de conexão: {ex.Message}");
                throw;
            }
        }
 

    }
}
