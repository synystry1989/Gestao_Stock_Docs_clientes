
using iText.Layout;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TeleBerço.Datasets;
using TeleBerço.Datasets.DsDocumentosTableAdapters;



namespace TeleBerço
{
    public partial class FrmDados : Form
    {
        public enum TipoDados
        {
            Clientes,
            Produtos,
            Documentos,
            Marcas,
            Categorias,
            Fornecedores,
            Stock,
            Movimentos
        }

        // Datasets
        private DsClientes dsClientes = new DsClientes();
        private DsProdutos dsArtigos = new DsProdutos();
        private DsDocumentos dsDocumentos = new DsDocumentos();
        private CabecDocumentoTableAdapter cabec = new CabecDocumentoTableAdapter();


        public DataRow RowSelecionada { get; private set; }
        public TipoDados tipoDadosAtual { get; set; }
        private DataView dataViewAtual;

        public FrmDados()
        {
            InitializeComponent();

        }

        #region funcoes

        public void MostrarTabelaDados(string tabela)
        {
            switch (tabela)
            {
                case "DsClientes":
                    tipoDadosAtual = TipoDados.Clientes;
                    CarregarClientes();
                    break;
                case "DsArtigos":
                    tipoDadosAtual = TipoDados.Produtos;
                    CarregarCategorias();
                    CarregarMarcas();
                    CarregarProdutos();
                    break;
                case "DsDocumentos":
                    tipoDadosAtual = TipoDados.Documentos;
                    CarregarDocumentos();
                    break;
                case "DsCategorias":
                    tipoDadosAtual = TipoDados.Categorias;
                    CarregarCategorias();
                    break;
                case "DsMarcas":
                    tipoDadosAtual = TipoDados.Marcas;
                    CarregarMarcas();
                    break;
                case "DsFornecedores":
                    tipoDadosAtual = TipoDados.Fornecedores;
                    CarregarFornecedores();

                    break;

            }

            ConfigurarDataGridView();
            ConfigurarControles();
            ShowDialog();
        }

        private void PesquisarFornecedores(string nome)
        {

            dataViewAtual.RowFilter = $"Nome LIKE '%{nome}%' OR Morada LIKE '%{nome}%' OR Site LIKE '%{nome}%' OR Contato LIKE '%{nome}%' OR FornecedorID LIKE '%{nome}%'";
        }

        private void PesquisarClientes(string nome)
        {

            dataViewAtual.RowFilter = $"Nome LIKE '%{nome}%' OR Email LIKE '%{nome}%' OR Telefone LIKE '%{nome}%' OR CodCl LIKE '%{nome}%'";

        }


        private void PesquisarProdutos(string termo)
        {

            dataViewAtual.RowFilter = $"NomeProduto LIKE '%{termo}%' OR Marca LIKE '%{termo}%' OR Categoria LIKE '%{termo}%'OR IMEI LIKE '%{termo}%' OR Tipo LIKE '%{termo}%' OR CodPr LIKE '%{termo}%' OR Observacao LIKE '%{termo}%'";
        }



        private void PesquisarDocumentosPorCliente(string cliente)
        {

            // Primeiro, tenta filtrar pelo nome do cliente
            dataViewAtual.RowFilter = $"NomeCliente LIKE '%{cliente}%'";

            // Se não encontrar, tenta buscar pelo código do cliente
            if (dataViewAtual.Count == 0)
            {
                string codCliente = dsClientes.Clientes.AsEnumerable()
                    .FirstOrDefault(c => c.Nome.Equals(cliente, StringComparison.OrdinalIgnoreCase))?.CodCl;

                if (!string.IsNullOrEmpty(codCliente))
                {
                    dataViewAtual.RowFilter = $"Cliente = '{codCliente}'";
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }
        private void AplicarFiltro(string campo, string valor)
        {
            switch (tipoDadosAtual)
            {
                case TipoDados.Produtos:
                    if (campo == "Categoria" || campo == "Marca" || campo == "Tipo")
                    {
                        dataViewAtual.RowFilter = $"{campo} = '{valor}'";
                    }
                    break;

                case TipoDados.Documentos:
                    if (campo == "Tipo Doc")
                    {
                        string campo1 = "TipoDocumento";
                        string valorF = dsDocumentos.TipoDocumentos.Where(x => x.Descricao == valor).Select(x => x.CodDoc).First();
                        dataViewAtual.RowFilter = $"{campo1}  = '{valorF}'";
                    }
                    else if (campo == "Estado")
                    {
                        dataViewAtual.RowFilter = $"{campo} = '{valor}'";
                    }
                    break;
                case TipoDados.Fornecedores:
                    if (campo == "Categoria")
                    {
                        dataViewAtual.RowFilter = $"{campo}  = '{valor}'";
                    }
                    break;
            }
        }

        private void AplicarFiltroPorDatas(DateTime dataInicio, DateTime dataFim)
        {
            string campoData = cbFiltro.SelectedItem.ToString().Replace(" ", "");
            dataViewAtual.RowFilter = $"{campoData} >= '{dataInicio:yyyy-MM-dd}' AND {campoData} <= '{dataFim:yyyy-MM-dd}'";
        }

        private void AplicarFiltroPorData(DateTime data)
        {
            string campoData = cbFiltro.SelectedItem.ToString().Replace(" ", "");
            dataViewAtual.RowFilter = $"{campoData} = '{data:yyyy-MM-dd}'";
        }

        private void EditarFornecedores(object sender, EventArgs e)
        {
            try
            {
                FrmClientes frm = new FrmClientes
                {
                    RowSelecionada = RowSelecionada,
                };
                frm.tipoDadosAtual = FrmClientes.TipoDados.Fornecedores;
                frm.ShowDialog();
                btnRefresh_Click_1(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar Fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditarCliente(object sender, EventArgs e)
        {
            try
            {
                FrmClientes frmClientes = new FrmClientes
                {
                    RowSelecionada = RowSelecionada
                };
                frmClientes.tipoDadosAtual = FrmClientes.TipoDados.Clientes;
                frmClientes.ShowDialog();
                btnRefresh_Click_1(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditarProduto(object sender, EventArgs e)
        {
            try
            {
                FrmProdutos frmProdutos = new FrmProdutos
                {
                    RowSelecionada = RowSelecionada
                };
                frmProdutos.ShowDialog();
                btnRefresh_Click_1(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AdicionarFornecedor(object sender, EventArgs e)
        {
            try
            {
                FrmClientes frmClientes = new FrmClientes();
                frmClientes.tipoDadosAtual = FrmClientes.TipoDados.Fornecedores;
                frmClientes.ShowDialog();
                btnRefresh_Click_1(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AdicionarCliente(object sender, EventArgs e)
        {
            try
            {
                FrmClientes frmClientes = new FrmClientes();
                frmClientes.tipoDadosAtual = FrmClientes.TipoDados.Clientes;
                frmClientes.ShowDialog();
                btnRefresh_Click_1(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void AdicionarCategoria(object sender, EventArgs e)
        {
            try
            {
                FrmCat_Marca frm = new FrmCat_Marca();
                frm.tipoDadosAtual = FrmCat_Marca.TipoDados.Categorias;
                frm.ShowDialog();
                btnRefresh_Click_1(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void AdicionarMarca(object sender, EventArgs e)
        {
            try
            {
                FrmCat_Marca frm = new FrmCat_Marca();
                frm.tipoDadosAtual = FrmCat_Marca.TipoDados.Marcas;
                frm.ShowDialog();
                btnRefresh_Click_1(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditarCat(object sender, EventArgs e)
        {
            try
            {
                FrmCat_Marca frm = new FrmCat_Marca
                {
                    RowSelecionada = RowSelecionada,
                };
                frm.tipoDadosAtual = FrmCat_Marca.TipoDados.Categorias;
                frm.ShowDialog();
                btnRefresh_Click_1(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditarMarca(object sender, EventArgs e)
        {
            try
            {
                FrmCat_Marca frm = new FrmCat_Marca
                {
                    RowSelecionada = RowSelecionada
                };
                frm.tipoDadosAtual = FrmCat_Marca.TipoDados.Marcas;
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AdicionarProduto(object sender, EventArgs e)
        {
            try
            {
                FrmProdutos frmProdutos = new FrmProdutos();
                frmProdutos.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
        #region Metodos

        private void ConfigurarControles()
        {
            try
            {
                // Configura os controles de filtro e pesquisa com base no tipo de dados atual
                cbFiltro.Items.Clear();
                cbOrdenar.Items.Clear();
                txtPesquisa.Text = string.Empty;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;

                switch (tipoDadosAtual)
                {
                    case TipoDados.Clientes:
                        cbOrdenar.Enabled = false;
                        break;
                    case TipoDados.Categorias:
                    case TipoDados.Marcas:
                        cbOrdenar.Enabled = false;
                        txtPesquisa.Enabled = false;
                        btnAplicar.Enabled = false;
                        BtnOk.Enabled = false;
                        break;
                    case TipoDados.Produtos:
                        cbOrdenar.Enabled = true;
                        cbOrdenar.Items.AddRange(new string[] { "Categoria", "Marca", "Tipo" });
                        break;

                    case TipoDados.Documentos:
                        cbOrdenar.Enabled = true;
                        cbOrdenar.Items.AddRange(new string[] { "Data", "Tipo Doc", "Estado" });
                        break;
                    case TipoDados.Fornecedores:
                        cbOrdenar.Enabled = true;
                        cbOrdenar.Items.AddRange(new string[] { "Categoria" });
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro nas configurações iniciais: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void ConfigurarDataGridView()
        {
            try
            {
                DgridDados.AutoGenerateColumns = false;
                switch (tipoDadosAtual)
                {
                    case TipoDados.Clientes:
                        DgridDados.Columns["CodCl"].HeaderText = "Código ";
                        DgridDados.Columns["Nome"].HeaderText = "Cliente ";
                        DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
                        {
                            Name = "colBotao",
                            HeaderText = "Contatar",
                            Text = "Novo",
                            UseColumnTextForButtonValue = true
                        };
                        DgridDados.Columns.Add(btnColumn);
                        break;

                    case TipoDados.Produtos:

                        DgridDados.Columns["Marcas"].Visible = false;
                        DgridDados.Columns["Categorias"].Visible = false;
                        DgridDados.Columns["Marca"].DisplayIndex = 1;
                        DgridDados.Columns["Categoria"].DisplayIndex = 2;

                        DgridDados.Columns["NomeProduto"].HeaderText = "Produto";
                        DgridDados.Columns["CodPr"].HeaderText = "Codigo";
                        DgridDados.Columns["PrecoCusto"].HeaderText = "Custo ";
                        DgridDados.Columns["PreçoVenda"].HeaderText = "Venda ";

                        DgridDados.Columns["PrecoCusto"].DefaultCellStyle.Format = "F2";
                        DgridDados.Columns["PreçoVenda"].DefaultCellStyle.Format = "F2";

                        break;

                    case TipoDados.Documentos:

                        DgridDados.Columns["Id"].Visible = false;
                        DgridDados.Columns["Cliente"].Visible = false;
                        DgridDados.Columns["Fornecedor"].Visible = false;
                        DgridDados.Columns["Desconto"].Visible = false;
                        DgridDados.Columns["TipoDesconto"].Visible = false;
                        DgridDados.Columns["TipoDocumento"].Visible = false;
                        DgridDados.Columns["Total"].DefaultCellStyle.Format = "F2";


                        DgridDados.Columns["NomeCliente"].HeaderText = "Emitido a";
                        DgridDados.Columns["DescricaoDoc"].HeaderText = "Documento";

                        DgridDados.Columns["NrDocumento"].HeaderText = "Nº";
                        DgridDados.Columns["DataRececao"].HeaderText = "Data Emissão";
                        DgridDados.Columns["DataEntrega"].HeaderText = "Previsão Entrega";
                        DgridDados.Columns["Observacoes"].Visible = false;
                        DgridDados.Columns["CodProduto"].Visible = false;

                        DataGridViewButtonColumn btnColumn2 = new DataGridViewButtonColumn
                        {
                            Name = "colBotao",
                            HeaderText = "Enviar",
                            Text = "Documento",
                            DisplayIndex = 7,
                            UseColumnTextForButtonValue = true
                        };
                        DgridDados.Columns.Add(btnColumn2);
                        DgridDados.Columns["NomeCliente"].DisplayIndex = 3;
                        DgridDados.Columns["DescricaoDoc"].DisplayIndex = 1;


                        break;

                    case TipoDados.Fornecedores:

                        DgridDados.Columns["Categoria"].Visible = false;
                        DgridDados.Columns["FornecedorID"].HeaderText = "Codigo";
                        DgridDados.Columns["Nome"].HeaderText = "Fornecedor";
                        DgridDados.Columns["NomeCategoria"].HeaderText = "Categoria";
                        DgridDados.Columns["NomeCategoria"].DisplayIndex = 2;
                        DataGridViewButtonColumn btnColumn1 = new DataGridViewButtonColumn
                        {
                            Name = "colBotao",
                            HeaderText = "Contatar",
                            Text = "Novo",
                            DisplayIndex = 6,
                            UseColumnTextForButtonValue = true
                        };
                        DgridDados.Columns.Add(btnColumn1);


                        break;

                    case TipoDados.Categorias:
                        DgridDados.Columns["CodCat"].HeaderText = "Codigo";
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro nas configuracoes iniciais: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CarregarClientes()
        {
            try
            {
                dsClientes.CarregaClientes();
                dataViewAtual = new DataView(dsClientes.Clientes);
                DgridDados.DataSource = dataViewAtual;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CarregarFornecedores()
        {
            try
            {
                dsClientes.CarregaFornecedores();
                AdicionarDetalheFornecedor();
                dataViewAtual = new DataView(dsClientes.Fornecedores);
                DgridDados.DataSource = dataViewAtual;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CarregarProdutos()
        {
            try
            {
                dsArtigos.CarregaArtigos();
                AdicionarDetalhesProdutos();
                dataViewAtual = new DataView(dsArtigos.Produtos);
                DgridDados.DataSource = dataViewAtual;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar Produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CarregarDocumentos()
        {
            try
            {
                dsDocumentos.CarregaTipoDoc();
                dsDocumentos.CarregarDocumentos();
                AdicionarNomeClientesAosDocumentos();
                dataViewAtual = new DataView(dsDocumentos.CabecDocumento);
                DgridDados.DataSource = dataViewAtual;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar Documentos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CarregarCategorias()
        {
            try
            {
                dsArtigos.CarregaCategorias();
                dataViewAtual = new DataView(dsArtigos.Categorias);
                DgridDados.DataSource = dataViewAtual;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar Categorias: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CarregarMarcas()
        {
            try
            {
                dsArtigos.CarregarMarcas();

                dataViewAtual = new DataView(dsArtigos.Marcas);
                DgridDados.DataSource = dataViewAtual;

            }
            catch
            {
                MessageBox.Show("Erro ao carregar Marcas", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void AdicionarDetalheFornecedor()
        {

            foreach (DataRow row in dsClientes.Fornecedores.Rows)
            {
                // Preenche a coluna Categoria
                if (row["Categoria"] != DBNull.Value)
                    row["NomeCategoria"] = dsArtigos.DaNomeCategoria(row["Categoria"].ToString());
            }
        }

        private void AdicionarDetalhesProdutos()
        {
            // Adiciona colunas de Marca e Categoria se não existirem
            try
            {
                foreach (DataRow row in dsArtigos.Produtos.Rows)
                {
                    // Preenche a coluna Marca
                    if (row["Marcas"] != DBNull.Value)
                        row["Marca"] = dsArtigos.DaNomeMarca((int)row["Marcas"]);

                    // Preenche a coluna Categoria
                    if (row["Categorias"] != DBNull.Value)
                        row["Categoria"] = dsArtigos.DaNomeCategoria(row["Categorias"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar Marcas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AdicionarNomeClientesAosDocumentos()
        {
            // Adiciona a coluna NomeCliente se não existir


            foreach (DataRow row in dsDocumentos.CabecDocumento.Rows)
            {
                if (row["Cliente"] != DBNull.Value)
                {
                    // Preenche a coluna NomeCliente
                    if (row["Cliente"].ToString() != "CL000")
                    {
                        row["NomeCliente"] = dsClientes.CarregaNomeCliente(row["Cliente"].ToString());
                    }
                    else
                    {
                        row["NomeCliente"] = dsClientes.CarregaNomeFornecedor(row["Fornecedor"].ToString());
                    }
                }

                if (row["TipoDocumento"] != DBNull.Value)
                {
                    row["DescricaoDoc"] = dsDocumentos.TipoDocumentos.Where(x => x.CodDoc == row["TipoDocumento"].ToString()).Select(x => x.Descricao).First();
                }
            }
        }

        private void SelecionarLinhaAtual()
        {
            try
            {
                if (DgridDados.CurrentRow != null && DgridDados.CurrentRow.DataBoundItem != null)
                {
                    RowSelecionada = ((DataRowView)DgridDados.CurrentRow.DataBoundItem).Row;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region Logica
        private void DgridDados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelecionarLinhaAtual();
                if (RowSelecionada != null)
                {
                    DialogResult = DialogResult.OK;
                }

                e.Handled = true;
            }

        }

        private void cbOrdenar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cbFiltro.Items.Clear();

            if (cbOrdenar.SelectedItem == null) return;

            btnAplicar.Enabled = true;

            string campo = cbOrdenar.SelectedItem.ToString();

            switch (tipoDadosAtual)
            {
                case TipoDados.Produtos:
                    if (campo == "Categoria")
                    {
                        dsArtigos.CarregaCategorias();
                        var categorias = dsArtigos.Categorias.AsEnumerable().Select(c => c.Nome).ToArray();
                        cbFiltro.Items.AddRange(categorias);
                    }
                    else if (campo == "Marca")
                    {
                        dsArtigos.CarregarMarcas();
                        var marcas = dsArtigos.Marcas.AsEnumerable().Select(m => m.Nome).ToArray();
                        cbFiltro.Items.AddRange(marcas);
                    }
                    else if (campo == "Tipo")
                    {
                        cbFiltro.Items.AddRange(new string[] { "Cliente", "Reparaçao", "Venda" }); // Ajuste conforme necessário
                    }
                    break;

                case TipoDados.Documentos:
                    if (campo == "Data")
                    {
                        cbFiltro.Items.AddRange(new string[] { "Data Rececao", "Data Entrega", });
                        // Ajuste conforme necessário
                        dateTimePicker2.Visible = true; dateTimePicker1.Visible = true; label5.Visible = true;
                        btnAplicar.Enabled = false;
                    }
                    else if (campo == "Tipo Doc")
                    {
                        dsDocumentos.CarregaTipoDoc();
                        var tiposDoc = dsDocumentos.TipoDocumentos.AsEnumerable().Select(t => t.Descricao).ToArray();
                        cbFiltro.Items.AddRange(tiposDoc);
                    }
                    else if (campo == "Estado")
                    {
                        cbFiltro.Items.AddRange(new string[] { "Enviado", "Lançada", "Recebida", "Aceite", "Em Preparação", "Em Pagamento", "Rejeitado", "Anulada", "Finalizada", "Cancelada", "Numerario", "Artigo", }); // Ajuste conforme necessário
                    }


                    break;

                case TipoDados.Fornecedores:
                    if (campo == "Categoria")
                    {
                        dsArtigos.CarregaCategorias();
                        var categorias = dsArtigos.Categorias.AsEnumerable().Select(c => c.Nome).ToArray();
                        cbFiltro.Items.AddRange(categorias);
                    }
                    break;
            }

            cbFiltro.Enabled = cbFiltro.Items.Count > 0;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                AplicarFiltroPorData(dateTimePicker2.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Pesquisar, " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (dateTimePicker2.Value > dateTimePicker1.Value)
                {
                    MessageBox.Show("A data inicial não pode ser maior que a data final.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AplicarFiltroPorDatas(dateTimePicker2.Value, dateTimePicker1.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Pesquisar, " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgridDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tipoDadosAtual == TipoDados.Clientes || tipoDadosAtual == TipoDados.Fornecedores)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == DgridDados.Columns["colBotao"].Index)
                {
                    panelMsg.Visible = true;

                }
            }

            else if (tipoDadosAtual == TipoDados.Documentos)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == DgridDados.Columns["colBotao"].Index)
                {
                    string a = cabec.EmailCliente(DgridDados.CurrentRow.Cells["Cliente"].Value.ToString());
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("@Teleberço 2017", "synystry1989@gmail.com"));
                    message.To.Add(new MailboxAddress(DgridDados.CurrentRow.Cells["NomeCliente"].Value.ToString(), a));
                    message.Subject = "TeleBerço 2017";

                    string ambienteDeTrabalho = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    string documento = DgridDados.CurrentRow.Cells["TipoDocumento"].Value.ToString() + $"{DgridDados.CurrentRow.Cells["NrDocumento"].Value:000}";
                    string caminhoArquivoPDF = $@"{ambienteDeTrabalho}\{DgridDados.CurrentRow.Cells["NomeCliente"].Value.ToString().Replace(" ", "_")}_{documento}.pdf";


                    var bodyBuilder = new BodyBuilder
                    {
                        TextBody = "Documento"
                        // Se quiser HTML: HtmlBody = "<h1>Exemplo</h1>"
                    };

                    if (File.Exists(caminhoArquivoPDF))
                    {
                        // Adiciona o arquivo como anexo
                        bodyBuilder.Attachments.Add(caminhoArquivoPDF);
                    }
                    else
                    {
                        Console.WriteLine("Arquivo não encontrado: " + caminhoArquivoPDF);
                    }

                    // Define o corpo da mensagem
                    message.Body = bodyBuilder.ToMessageBody();


                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                        client.Authenticate("synystry1989@gmail.com", "tczp pohk rfto vfcz");
                        client.Send(message);
                        client.Disconnect(true);
                    }

                    MessageBox.Show("E-mail enviado com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void chWhats_CheckedChanged(object sender, EventArgs e)
        {
            if (chWhats.Checked)
            {
                chEmail.Checked = false;
                lblMsg.Enabled = true;
                btnEnviar.Enabled = true;

            }
            else if (chEmail.Checked)
            {
                chWhats.Checked = false;
                lblMsg.Enabled = true;
                btnEnviar.Enabled = true;
            }
            else
            {
                btnEnviar.Enabled = false;
                lblMsg.Enabled = false;
            }


        }

        private void chEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chWhats.Checked)
            {
                chEmail.Checked = false;
                lblMsg.Enabled = true;
                btnEnviar.Enabled = true;

            }
            else if (chEmail.Checked)
            {
                chWhats.Checked = false;
                lblMsg.Enabled = true;
                btnEnviar.Enabled = true;
            }
            else
            {
                btnEnviar.Enabled = false;
                lblMsg.Enabled = false;
            }
        }


        private void DgridDados_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelecionarLinhaAtual();
            if (RowSelecionada != null)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelMsg.Visible = false;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtPesquisa.Text)) && (cbFiltro.Text == ""))
            {
                // Se o texto for apagado, recarrega os dados originais
                btnRefresh_Click_1(sender, e);
            }
        }

        #endregion
        #region Buttons


        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {

                if (chEmail.Checked)
                {
                    string email = string.Empty;
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("@Teleberço 2017", "synystry1989@gmail.com"));


                    message.Subject = "TeleBerço 2017";

                    var bodyBuilder = new BodyBuilder
                    {
                        TextBody = lblMsg.Text
                        // Se quiser HTML: HtmlBody = "<h1>Exemplo</h1>"
                    };
                    message.Body = bodyBuilder.ToMessageBody();

                    if (tipoDadosAtual == TipoDados.Clientes)
                    {
                        email = DgridDados.CurrentRow.Cells["Email"].Value.ToString();
                        message.To.Add(new MailboxAddress(DgridDados.CurrentRow.Cells["Nome"].Value.ToString(), email));
                    }
                    else if (tipoDadosAtual == TipoDados.Fornecedores)
                    {

                        email = DgridDados.CurrentRow.Cells["Morada"].Value.ToString();
                        message.To.Add(new MailboxAddress(DgridDados.CurrentRow.Cells["Nome"].Value.ToString(), email));
                    }


                    MessageBox.Show("E-mail enviado com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else if (chWhats.Checked)
                {
                    string nr = string.Empty;

                    if (tipoDadosAtual == TipoDados.Clientes)
                    {
                        nr = DgridDados.CurrentRow.Cells["Telefone"].Value.ToString();
                    }
                    else if (tipoDadosAtual == TipoDados.Fornecedores)
                    {
                        nr = DgridDados.CurrentRow.Cells["Contato"].Value.ToString();
                    }

                    string mensagem = lblMsg.Text;

                    string url = $"https://wa.me//{nr}?text={Uri.EscapeDataString(mensagem)}";

                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                chWhats.Checked = false;
                chEmail.Checked = false;
                panelMsg.ResetText();
                panelMsg.Visible = false;

            }
            catch { }
        }

        private void BtnOk_Click_1(object sender, EventArgs e)
        {
            SelecionarLinhaAtual();
            this.Close();
        }

        private void BtnEditar_Click_1(object sender, EventArgs e)
        {
            SelecionarLinhaAtual();

            if (RowSelecionada != null)
            {
                switch (tipoDadosAtual)
                {
                    case TipoDados.Documentos:

                        this.Close();
                        break;

                    case TipoDados.Clientes:
                        EditarCliente(sender, e);
                        break;
                    case TipoDados.Produtos:
                        EditarProduto(sender, e);
                        break;
                    case TipoDados.Categorias:
                        EditarCat(sender, e);
                        break;
                    case TipoDados.Marcas:
                        EditarMarca(sender, e);
                        break;
                    case TipoDados.Fornecedores:
                        EditarFornecedores(sender, e);
                        break;

                }
            }
        }

        private void BtnAdicionar_Click_1(object sender, EventArgs e)
        {
            switch (tipoDadosAtual)
            {
                case TipoDados.Clientes:
                    AdicionarCliente(sender, e);
                    break;
                case TipoDados.Fornecedores:
                    AdicionarFornecedor(sender, e);
                    break;
                case TipoDados.Produtos:
                    AdicionarProduto(sender, e);
                    break;
                case TipoDados.Categorias:
                    AdicionarCategoria(sender, e);
                    break;
                case TipoDados.Marcas:
                    AdicionarMarca(sender, e);
                    break;

            }
        }

        //selecionar na grid com enter
      
        //pesquisar entre datas pressionar enter

        private void btnAplicar_Click_1(object sender, EventArgs e)
        {
            if (cbOrdenar.SelectedItem == null || cbFiltro.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um campo e um valor para filtrar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string campo = cbOrdenar.SelectedItem.ToString();
            string valor = cbFiltro.SelectedItem.ToString();

            AplicarFiltro(campo, valor);
        }


        private void BtnSair_Click_1(object sender, EventArgs e)
        {
            try
            {
                RowSelecionada = null;
                DialogResult = DialogResult.Cancel;
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao encerrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            // Limpa filtros e recarrega os dados
            txtPesquisa.Text = string.Empty;
            cbOrdenar.Text = "";
            cbFiltro.Text = "";

            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;


            switch (tipoDadosAtual)
            {
                case TipoDados.Clientes:
                    CarregarClientes();
                    break;
                case TipoDados.Produtos:
                    CarregarProdutos();
                    break;
                case TipoDados.Documentos:
                    CarregarDocumentos();
                    break;
                case TipoDados.Categorias:

                    CarregarCategorias();
                    break;
                case TipoDados.Marcas:

                    CarregarMarcas();
                    break;
                case TipoDados.Fornecedores:

                    CarregarFornecedores();
                    break;
            }

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPesquisa.Text))
                {
                    MessageBox.Show("Por favor, insira um termo para pesquisa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (tipoDadosAtual)
                {
                    case TipoDados.Clientes:
                        PesquisarClientes(txtPesquisa.Text);
                        break;
                    case TipoDados.Fornecedores:
                        PesquisarFornecedores(txtPesquisa.Text);
                        break;

                    case TipoDados.Produtos:
                        PesquisarProdutos(txtPesquisa.Text);
                        break;

                    case TipoDados.Documentos:
                        PesquisarDocumentosPorCliente(txtPesquisa.Text);
                        break;
                    case TipoDados.Categorias:

                        break;
                }
            }
            catch { }
        }


    }
    #endregion
}


















