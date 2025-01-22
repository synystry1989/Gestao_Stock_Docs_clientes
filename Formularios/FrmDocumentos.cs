using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TeleBerço.Datasets;
using TeleBerço.Properties;
using static TeleBerço.Datasets.DsClientes;
using static TeleBerço.Datasets.DsDocumentos;
using static TeleBerço.Datasets.DsProdutos;

namespace TeleBerço
{
    public partial class FrmDocumentos : Form
    {
        // Datasets e TableAdapters
        private DsClientes dsClientes = new DsClientes();
        DsStock dsStock = new DsStock();
        public string tipoDoc { get; set; } = string.Empty;
        public int nrDoc { get; set; }

        private int lockedTextLength = 0;

        // Variáveis de controle
        private PrintDocument printDocument = new PrintDocument();


        public FrmDocumentos()
        {
            InitializeComponent();
        }
        private void FrmDocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarDadosIniciais();

                if (dsDocumentos.TipoDocumentos.FindByCodDoc(tipoDoc) != null)
                {
                    TxtCodigoDoc.Text = tipoDoc;
                    NrDoc.Text = nrDoc.ToString();
                    tsImprimir_Click_1(sender, e);
                    this.Close();
                }
                else if (tipoDoc.Contains("AM"))
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o formulário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Metodos

        private void CarregarDadosIniciais()
        {
            try
            {
                dsProdutos.CarregaCategorias();
                dsProdutos.CarregarMarcas();
                dsDocumentos.CarregaTipoDoc();
                TxtCodigoDoc.Text = string.Empty;
                txtCat.Text = string.Empty;
                txtMarca.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PreencheDocumento(string tipoDoc, int nrDoc)
        {
            try
            {
                var rowPesquisada = dsDocumentos.PesquisaDocumento(tipoDoc, nrDoc);

                if (rowPesquisada.Cliente != string.Empty)
                {
                    DesabilitarBotoes();
                    // Preencher dados do produto associado
                    if (!rowPesquisada.IsNull("CodProduto"))
                    {
                        var produtoRow = dsProdutos.PesquisarArtigo(rowPesquisada.CodProduto);
                        if (produtoRow.CodPr != dsProdutos.DaProxCodArtigo())
                        {
                            txtEquipNome.Text = produtoRow.NomeProduto;
                            txtCat.Text = dsProdutos.DaNomeCategoria(produtoRow.Categorias).ToString();
                            txtMarca.Text = dsProdutos.DaNomeMarca(produtoRow.Marcas);
                            txtImei.Text = produtoRow.IMEI;

                        }
                    }  // Preencher dados do cliente associado fiz a distincao entre cliente e fornecedor ao atribuir o pre preenchimento das siglas correspondentes na mudanca da descricao do documento
                    if (rowPesquisada.Cliente != "CL000")
                    {
                        var clienteRow = dsClientes.PesquisaCliente(rowPesquisada.Cliente);

                        if (clienteRow.CodCl != dsClientes.DaProxNrCliente())
                        {
                            TxtCodigoCl.Text = clienteRow.CodCl;
                            TxtNomeCl.Text = clienteRow.Nome;
                            TxtTelefone.Text = clienteRow.Telefone;
                            TxtEmail.Text = clienteRow.Email;
                        }
                    }
                    else if (rowPesquisada.Fornecedor != "FN000")
                    {
                        var clienteRow = dsClientes.PesquisaFornecedor(rowPesquisada.Fornecedor);

                        if (clienteRow.FornecedorID != dsClientes.DaProxNrFornecedor())
                        {
                            TxtCodigoCl.Text = clienteRow.FornecedorID;
                            TxtNomeCl.Text = clienteRow.Nome;
                            TxtTelefone.Text = clienteRow.Contato;
                            TxtEmail.Text = clienteRow.Site;
                            txtMorada.Text = clienteRow.Morada;
                            cbCategoria.SelectedValue = clienteRow.Categoria;
                        }
                    }
                    //limpo produto aqui e nao no fim pois uso as informacoes dos produtos para preencher as observacoes no documento
                    LimparProduto();
                    // Preencher dados do documento
                    if (rowPesquisada.TipoDesconto == "Euro")
                    {
                        cBoxEuro.Checked = true;
                    }
                    if (rowPesquisada.TipoDesconto == "Percent")
                    {
                        cBoxPercent.Checked = true;
                    }
                    else
                    {
                        cBoxEuro.Checked = false;
                        cBoxPercent.Checked = false;
                    }
                    DataMod.Value = rowPesquisada.DataRececao;
                    dateTimePicker1.Value = rowPesquisada.DataEntrega;
                    txtTotal.Text = rowPesquisada.Total.ToString("F2");
                    txtObservacoes.Text = rowPesquisada.Observacoes;
                    string textoBloqueado = txtObservacoes.Text;

                    // 3) Guardar quantos caracteres tem o texto inicial
                    lockedTextLength = textoBloqueado.Length;

                    txtEstado.Text = rowPesquisada.Estado;
                    txtDesconto.Text = rowPesquisada.Desconto.ToString();

                    if (rowPesquisada.TipoDesconto == "Euro")
                    {
                        cBoxEuro.Checked = true;
                    }
                    else if (rowPesquisada.TipoDesconto == "Percent")
                    {
                        cBoxPercent.Checked = true;
                    }
                    else
                    {
                        cBoxEuro.Checked = false; cBoxPercent.Checked = false;
                    }
                    // Carregar linhas do documento
                    dsDocumentos.CarregaLinhas(rowPesquisada.ID);
                    AdicionarDescricoesPr();

                    txtEstado.Enabled = true;
                    tsGravarDoc.Enabled = true;
                }
                else
                {
                    NrDoc.Text = dsDocumentos.DaNrDocSeguinte(tipoDoc).ToString();
                    HabilitarBotoes();

                    AtribuirDescriçaoCodCl();
                    LimparProduto();
                    LimparRodape();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher documento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PrepararCliente()
        {
            TxtCodigoCl.Text = dsClientes.DaProxNrCliente();
            HabilitarCliente();
            LimparCliente();
        }

        public void PreencheCliente()
        {
            var clienteRow = dsClientes.PesquisaCliente(TxtCodigoCl.Text);

            if (clienteRow.Nome != string.Empty)
            {
                TxtNomeCl.Text = clienteRow.Nome;
                TxtTelefone.Text = clienteRow.Telefone;
                TxtEmail.Text = clienteRow.Email;
                DesabiblitarCliente();
            }
            else
            {
                PrepararCliente();
            }
        }

        public void PreencherFornecedor()
        {
            var fornecedorRow = dsClientes.PesquisaFornecedor(TxtCodigoCl.Text);

            if (fornecedorRow.Nome != string.Empty)
            {
                TxtNomeCl.Text = fornecedorRow.Nome;
                TxtTelefone.Text = fornecedorRow.Contato;
                TxtEmail.Text = fornecedorRow.Site;
                txtMorada.Text = fornecedorRow.Morada;
                cbCategoria.Text = dsProdutos.DaNomeCategoria(fornecedorRow.Categoria);
                DesabiblitarFornecedor();
            }
            else
            {
                PrepararFornecedor();
            }
        }

        public void PrepararFornecedor()
        {
            TxtCodigoCl.Text = dsClientes.DaProxNrFornecedor();
            dsProdutos.CarregaCategorias();
            dsProdutos.CarregarMarcas();
            HabilitarFornecedor();
            LimparFornecedor();
        }

        private void AtribuirDescriçaoCodCl()
        {
            if (TxtDescricaoDoc.Text.Contains("Fornecedor"))
            {
                LimparFornecedor();
                HabilitarFornecedor();

                TxtCodigoCl.Text = "FN";
            }
            else if (TxtDescricaoDoc.Text.Contains("Cliente"))
            {
                LimparCliente();
                HabilitarCliente();

                TxtCodigoCl.Text = "CL";
            }
            else
            {
                TxtCodigoCl.Text = "CL";
                LimparCliente();
                HabilitarCliente();
            }
        }

        public void AtualizarEstoqueAoSalvarDocumento()
        {

            // Obter o tipo do documento
            tipoDoc = dsDocumentos.CabecDocumento[0].TipoDocumento;
            nrDoc = dsDocumentos.CabecDocumento[0].NrDocumento;
            string codDoc = tipoDoc + nrDoc.ToString("000");


            // Iterar sobre a ListaProdutos associada ao documento
            foreach (ListaProdutosRow produto in dsDocumentos.ListaProdutos.Rows)
            {
                // Apenas processar linhas que não foram excluídas
                if (produto.RowState != DataRowState.Deleted)
                {
                    //variavel para identificar se o produto e existente ou criado 
                    bool novo = false;

                    dsStock.PesquisarStock(produto.Produto, ref novo);
                    dsStock.AtualizarStock(produto.Produto, produto.Quantidade, tipoDoc, codDoc);
                }
            }

        }

        private void AplicarDesconto()
        {
            try
            {
                if ((txtDesconto.Enabled) && (decimal.TryParse(txtTotal.Text, out decimal total) && decimal.TryParse(txtDesconto.Text, out decimal desconto)))
                {

                    if (cBoxEuro.Checked)
                    {
                        total -= desconto;
                        cBoxPercent.Checked = false;
                        cBoxPercent.Enabled = false;
                        txtTotal.Text = total.ToString("F2");
                    }

                    else if (cBoxPercent.Checked)
                    {
                        total -= (total * (desconto / 100));
                        cBoxEuro.Enabled = false;
                        cBoxEuro.Checked = false;
                        txtTotal.Text = total.ToString("F2");
                    }
                    else
                    {
                        cBoxEuro.Enabled = true;
                        cBoxPercent.Enabled = true;
                        CalcularTotalDocumento();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar desconto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirSelecaoForn()
        {
            try
            {
                FrmDados frmDados = new FrmDados();
                frmDados.MostrarTabelaDados("DsFornecedores");

                if (frmDados.RowSelecionada is FornecedoresRow clienteRow)
                {
                    TxtCodigoCl.Text = clienteRow.FornecedorID;
                    TxtNomeCl.Text = clienteRow.Nome;
                    TxtTelefone.Text = clienteRow.Contato;
                    TxtEmail.Text = clienteRow.Site;
                    txtMorada.Text = clienteRow.Morada;
                    cbCategoria.Text = dsProdutos.DaNomeCategoria(clienteRow.Categoria);

                    HabilitarFornecedor();
                    TxtNomeCl.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirSelecaoProdutos()
        {
            try
            {
                FrmDados frmDados = new FrmDados();
                frmDados.MostrarTabelaDados("DsArtigos");

                if (frmDados.RowSelecionada is ProdutosRow produtoRow)
                {
                    txtEquipNome.Text = produtoRow.NomeProduto;
                    txtCat.Text = dsProdutos.DaNomeCategoria(produtoRow.Categorias).ToString();
                    txtMarca.Text = dsProdutos.DaNomeMarca(produtoRow.Marcas);
                    txtImei.Text = produtoRow.IMEI;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirSelecaoClientes()
        {
            try
            {
                FrmDados frmDados = new FrmDados();
                frmDados.MostrarTabelaDados("DsClientes");

                if (frmDados.RowSelecionada is ClientesRow clienteRow)
                {
                    TxtCodigoCl.Text = clienteRow.CodCl;
                    TxtNomeCl.Text = clienteRow.Nome;
                    TxtTelefone.Text = clienteRow.Telefone;
                    TxtEmail.Text = clienteRow.Email;
                    HabilitarCliente();
                    // permito que sejam alterados para fatura ou documento na impressao o numero ou email por via de algum inconveniente ou mudança inesperada mas nunca o nome
                    TxtNomeCl.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirSelecaoDocumentos()
        {
            try
            {
                FrmDados frmDados = new FrmDados();
                frmDados.MostrarTabelaDados("DsDocumentos");

                if (frmDados.RowSelecionada is CabecDocumentoRow docRow)
                {
                    TxtCodigoDoc.Text = docRow.TipoDocumento;
                    //desnecessario mas como algumas situacoes nao carregou a descricao mais vale manter
                    TxtDescricaoDoc.Text = docRow.DescricaoDoc;
                    NrDoc.Text = docRow.NrDocumento.ToString();
                    //n seria necessario fazer o preenche doc na teoria pois ao mudar o nr doc ele preenche mas pode acontecer de ao carregar um doc o nr deste ser igual ao ja existente no nr doc txt 
                    PreencheDocumento(docRow.TipoDocumento, docRow.NrDocumento);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar documento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstadoDoc()
        {
            if (TxtCodigoDoc.Text.Contains("OR"))
            {
                txtEstado.Items.Clear();
                txtEstado.Items.AddRange(new string[] { "Enviado", "Aceite", "Rejeitado" });
            }
            else if (TxtCodigoDoc.Text.Contains("FT"))
            {
                txtEstado.Items.Clear();
                txtEstado.Items.AddRange(new string[] { "Em Pagamento", "Anulada","Finalizada" });
            }
            else if (TxtCodigoDoc.Text.Equals("EDC"))
            {
                txtEstado.Items.Clear();
                txtEstado.Items.AddRange(new string[] { "Em Preparação", "Cancelada", "Finalizada" });
            }
            else if (TxtCodigoDoc.Text.Equals("EDF"))
            {
                txtEstado.Items.Clear();
                txtEstado.Items.AddRange(new string[] { "Lançada", "Cancelada", "Aceite", "Recebida" });
            }
            else if (TxtCodigoDoc.Text.Contains("ND"))
            {
                txtEstado.Items.Clear();
                txtEstado.Items.AddRange(new string[] { "Numerario", "Artigo", "Cancelada" });
            }
        }

        private void CalcularTotalDocumento()
        {
            try
            {
                decimal soma = 0;

                foreach (DataGridViewRow linha in DgridArtigos.Rows)
                {
                    if (linha.Cells["totalDataGridViewTextBoxColumn"].Value != null)
                    {
                        soma += Convert.ToDecimal(linha.Cells["totalDataGridViewTextBoxColumn"].Value);
                    }
                }
                txtTotal.Text = soma.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao calcular total: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarDescricoesPr()
        {
            try
            {
                foreach (DataGridViewRow linha in DgridArtigos.Rows)
                {
                    // Preenche a coluna Marca
                    if (linha.Cells["Marca"].Value != DBNull.Value)
                    {
                        linha.Cells["NomeMarca"].Value = dsProdutos.DaNomeMarca(int.Parse(linha.Cells["Marca"].Value.ToString()));
                    }
                    // Preenche a coluna Categoria
                    if (linha.Cells["Categoria"].Value != DBNull.Value)
                    {
                        linha.Cells["NomeCategoria"].Value = dsProdutos.DaNomeCategoria(linha.Cells["Categoria"].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar descricao: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidaPreenchimentoCliente()
        {
            return !string.IsNullOrWhiteSpace(TxtCodigoCl.Text) &&
                   !string.IsNullOrWhiteSpace(TxtNomeCl.Text) &&
                   !string.IsNullOrWhiteSpace(TxtTelefone.Text);
        }
        private bool ValidaPreenchimentoFornecedor()
        {
            return !string.IsNullOrWhiteSpace(TxtCodigoCl.Text) &&
                   !string.IsNullOrWhiteSpace(TxtNomeCl.Text) &&
                   !string.IsNullOrWhiteSpace(TxtTelefone.Text) &&
                   !string.IsNullOrWhiteSpace(cbCategoria.Text);
        }

        private bool ValidaPreenchimentoDocumento()
        {
            if (dsDocumentos.CabecDocumento[0].TipoDocumento.Contains("Fornecedor"))
            {
                ValidaPreenchimentoFornecedor();
            }
            else
            {
                ValidaPreenchimentoCliente();
            }

            return !string.IsNullOrWhiteSpace(TxtCodigoDoc.Text) &&
                   !string.IsNullOrWhiteSpace(NrDoc.Text) &&
                   !string.IsNullOrWhiteSpace(TxtDescricaoDoc.Text) &&
                   !string.IsNullOrWhiteSpace(txtEstado.Text);
        }

        private bool ValidaPreenchimentoProdutos()
        {
            return !string.IsNullOrWhiteSpace(txtCat.Text) &&
                   !string.IsNullOrWhiteSpace(txtMarca.Text) &&
                   !string.IsNullOrWhiteSpace(txtEquipNome.Text) &&
                   !string.IsNullOrWhiteSpace(TxtCusto.Text);
        }

        private void LimparRodape()
        {
            dateTimePicker1.Value = DateTime.Now;
            txtTotal.Text = "0";
            txtObservacoes.Text = string.Empty;
            txtEstado.Text = string.Empty;
            cBoxEuro.Checked = false;
            cBoxPercent.Checked = false;
            txtDesconto.Text = "0";

        }
        private void LimparTipoDoc()
        {
            NrDoc.Text = "0";
            TxtCodigoDoc.Text = string.Empty;
            TxtDescricaoDoc.Text = string.Empty;
            DataMod.Value = DateTime.Now;
        }

        private void LimparFormulario()
        {
            LimparTipoDoc();
            LimparCliente();
            txtMorada.Text = string.Empty;
            cbCategoria.Text = string.Empty;
            TxtCodigoCl.Text = string.Empty;

            LimparProduto();
            LimparRodape();
            dsClientes.Clientes.Clear();
            dsDocumentos.CabecDocumento.Clear();
            dsDocumentos.ListaProdutos.Clear();
        }

        private void LimparCliente()
        {
            TxtNomeCl.Text = "Nome";
            TxtTelefone.Text = "Telefone";
            TxtEmail.Text = "Email";
        }

        private void LimparFornecedor()
        {
            TxtNomeCl.Text = "Nome";
            TxtTelefone.Text = "Telefone";
            TxtEmail.Text = "site";
            txtMorada.Text = "Morada";
            cbCategoria.Text = string.Empty;
        }

        private void DesabiblitarFornecedor()
        {

            TxtNomeCl.Enabled = false;
            TxtEmail.Enabled = false;
            cbCategoria.Enabled = false;
        }

        private void DesabiblitarCliente()
        {
            TxtTelefone.Enabled = false;
            TxtNomeCl.Enabled = false;
            TxtEmail.Enabled = false;
        }

        private void HabilitarCliente()
        {
            label10.Visible = true;
            lblFornecedor.Visible = false;
            txtMorada.Visible = false;
            cbCategoria.Visible = false;
            TxtNomeCl.Enabled = true;
            TxtTelefone.Enabled = true;
            TxtEmail.Enabled = true;
        }

        private void HabilitarFornecedor()
        {
            label10.Visible = false;
            lblFornecedor.Visible = true;
            txtMorada.Visible = true;
            cbCategoria.Visible = true;
            TxtEmail.Enabled = true;
            txtMorada.Enabled = true;
            TxtTelefone.Enabled = true;
            cbCategoria.Enabled = true;
            TxtNomeCl.Enabled = true;
        }

        private void DesabilitarProduto()
        {
            txtCat.Enabled = false;
            txtEquipNome.Enabled = false;
            txtImei.Enabled = false;
            txtMarca.Enabled = false;
            txtObservacoes.Enabled = false;
            txtTipoPr.Enabled = false;
            btnGravarPr.Enabled = false;
            TxtPreco.Visible = false;
            TxtCusto.Visible = false;
            txtTipoPr.Visible = false;
            LblStock.Visible = false;
            LblPreco.Visible = false;
            label16.Visible = false;
            lblQtd.Visible = false;
            txtQtd.Visible = false;
            txtQtd.Enabled = false;
        }

        private void HabilitarProduto()
        {
            txtEquipNome.Enabled = true;
            txtCat.Enabled = true;
            txtMarca.Enabled = true;
            txtImei.Enabled = true;
            txtObservacoes.Enabled = true;
            txtTipoPr.Enabled = true;
            btnGravarPr.Enabled = true;
            TxtPreco.Visible = true;
            TxtCusto.Visible = true;
            txtTipoPr.Visible = true;
            LblStock.Visible = true;
            LblPreco.Visible = true;
            label16.Visible = true;
            lblQtd.Visible = true;
            txtQtd.Visible = true;
            txtQtd.Enabled = true;
        }

        private void LimparProduto()
        {
            txtEquipNome.Text = string.Empty;
            txtCat.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtImei.Text = string.Empty;
            txtObservacoes.Text = string.Empty;
        }

        private void DesabilitarBotoes()
        {
            BtnNovo.Enabled = false;
            BtnEliminar.Enabled = false;
            btnAbrirPr.Enabled = false;
            btnGravarPr.Enabled = false;
            tsGravarDoc.Enabled = false;
            txtDesconto.Enabled = false;
            dateTimePicker1.Enabled = false;
            btnAbrirCliente.Enabled = false;
            btnAbrirPr.Enabled = false;
            txtEstado.Enabled = false;
            DgridArtigos.Enabled = false;
            BtnGravarCliente.Enabled = false;
            cBoxEuro.Enabled = false;
            cBoxPercent.Enabled = false;

        }

        private void HabilitarBotoes()
        {
            BtnNovo.Enabled = true;
            BtnEliminar.Enabled = true;
            btnAbrirCliente.Enabled = true;
            tsGravarDoc.Enabled = true;
            btnAbrirPr.Enabled = true;
            tsImprimir.Enabled = true;
            btnAbrirCliente.Enabled = true;
            dateTimePicker1.Enabled = true;
            txtEstado.Enabled = true;
            txtObservacoes.Enabled = true;
            txtDesconto.Enabled = true;
            cBoxEuro.Enabled = true;
            cBoxPercent.Enabled = true;
            DgridArtigos.Enabled = true;
        }


        #endregion

        #region Logica

        private void TxtCodigoDoc_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                AbrirSelecaoDocumentos();

            }
        }

        private void TxtCodigoDoc_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (TxtCodigoDoc.Text != string.Empty)
                {
                    var tipoRow = dsDocumentos.TipoDocumentos.FindByCodDoc(TxtCodigoDoc.Text);

                    if (tipoRow != null)
                    {
                        TxtDescricaoDoc.Text = tipoRow.Descricao;
                        NrDoc.Text = dsDocumentos.DaNrDocSeguinte(TxtCodigoDoc.Text).ToString();
                        HabilitarBotoes();
                        dsDocumentos.ListaProdutos.Clear();
                        LimparProduto();
                        LimparRodape();
                        EstadoDoc();
                        AtribuirDescriçaoCodCl();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar tipo de documento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtCodigoCl_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                if (TxtCodigoCl.Text.Contains("FN"))
                {
                    AbrirSelecaoForn();
                }
                else
                {
                    AbrirSelecaoClientes();
                }
            }
        }

        private void TxtCodigoCl_Leave_1(object sender, EventArgs e)
        {
            try
            {
                if (TxtCodigoCl.Text.Contains("CL"))
                {
                    PreencheCliente();
                }
                else if (TxtCodigoCl.Text.Contains("FN"))
                {
                    PreencherFornecedor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void NrDoc_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            PreencheDocumento(TxtCodigoDoc.Text, int.Parse(NrDoc.Text));
        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {

            if (txtDesconto.Text != "0" && txtDesconto.Text != string.Empty)
            {
                AplicarDesconto();
            }
            else if (txtDesconto.Enabled)
            {
                CalcularTotalDocumento();
            }

        }

        private void cBoxEuro_CheckedChanged_1(object sender, EventArgs e)
        {
            AplicarDesconto();
        }

        private void cBoxPercent_CheckedChanged_1(object sender, EventArgs e)
        {
            AplicarDesconto();
        }


        private void DgridArtigos_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (DgridArtigos.Rows[e.RowIndex].Cells["precoUntDataGridViewTextBoxColumn"].Value != null &&
                    DgridArtigos.Rows[e.RowIndex].Cells["quantidadeDataGridViewTextBoxColumn"].Value != null)
                {

                    decimal precoUnitario = Convert.ToDecimal(DgridArtigos.Rows[e.RowIndex].Cells["precoUntDataGridViewTextBoxColumn"].Value);
                    decimal quantidade = Convert.ToDecimal(DgridArtigos.Rows[e.RowIndex].Cells["quantidadeDataGridViewTextBoxColumn"].Value);
                    decimal totalLinha = precoUnitario * quantidade;
                    DgridArtigos.Rows[e.RowIndex].Cells["totalDataGridViewTextBoxColumn"].Value = Math.Round(totalLinha, 2);
                }
                CalcularTotalDocumento();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar linha: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgridArtigos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DgridArtigos.Enabled)
            {
                bool novo = false;
                if (TxtCodigoDoc.Text == "FTC" || TxtCodigoDoc.Text == "NDF")
                {

                    foreach (DataGridViewRow linha in DgridArtigos.Rows)
                    {
                        var produto = dsStock.PesquisarStock(linha.Cells["produtoDataGridViewTextBoxColumn"].Value.ToString(), ref novo);
                        // Preenche a coluna Marca
                        if (int.Parse(linha.Cells["quantidadeDataGridViewTextBoxColumn"].Value.ToString()) > produto.Quantidade)
                        {
                            MessageBox.Show($"Não existe essa quantidade em stock. Tem apenas {produto.Quantidade} disponiveis", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            linha.Cells["quantidadeDataGridViewTextBoxColumn"].Value = produto.Quantidade;
                        }
                    }
                }
            }
        }
        #endregion

        #region Buttons



        private void btnNovoPr_Click_1(object sender, EventArgs e)
        {
            try
            {
                LimparProduto();
                txtObservacoes.Text = string.Empty;
                HabilitarProduto();
                dsProdutos.Clear();
                dsProdutos.NovoArtigo();
                dsProdutos.CarregaCategorias();
                dsProdutos.CarregarMarcas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar novo produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGravarPr_Click_1(object sender, EventArgs e)
        {
            try
            {
                ProdutosRow produtoRow = dsProdutos.Produtos[0];

                if (ValidaPreenchimentoProdutos())
                {
                    if (produtoRow.CodPr == dsProdutos.DaProxCodArtigo())
                    {
                        produtoRow.NomeProduto = txtEquipNome.Text;
                        produtoRow.Categorias = txtCat.SelectedValue.ToString();
                        produtoRow.Marcas = (int)txtMarca.SelectedValue;
                        produtoRow.IMEI = txtImei.Text;
                        produtoRow.Observacao = txtObservacoes.Text;
                        produtoRow.Tipo = txtTipoPr.Text;
                        produtoRow.PrecoCusto = decimal.Parse(TxtCusto.Text);
                        produtoRow.PreçoVenda = decimal.Parse(TxtPreco.Text);

                        dsProdutos.UpdateArtigos();

                        MessageBox.Show("Produto salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        bool novo = false;

                        dsStock.PesquisarStock(produtoRow.CodPr, ref novo);

                        MessageBox.Show("Produto não existente em Stock. Criada entrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dsStock.AtualizarStock(produtoRow.CodPr, int.Parse(txtQtd.Text), "AM+", "");

                        LimparProduto();
                        DesabilitarProduto();

                    }


                }
                else
                {
                    MessageBox.Show("Preencha corretamente todos os campos .", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gravar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNovo_Click_1(object sender, EventArgs e)
        {
            try
            {
                DgridArtigos.Enabled = true;
                FrmDados frmDados = new FrmDados();
                frmDados.MostrarTabelaDados("DsArtigos");

                if (frmDados.RowSelecionada is ProdutosRow produtoRow)
                {
                    string tipoDoc = TxtCodigoDoc.Text;
                    dsDocumentos.NovaLinhaArtigos(produtoRow, ref tipoDoc);
                    txtObservacoes.Text += produtoRow.Observacao + ";";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (DgridArtigos.CurrentRow != null)
                {
                    var id = Guid.Parse(DgridArtigos.CurrentRow.Cells["iDDataGridViewTextBoxColumn"].Value.ToString());
                    dsDocumentos.EliminarLinha(id);
                    txtObservacoes.Clear();
                    foreach (DataGridViewRow linha in DgridArtigos.Rows)
                    {
                        txtObservacoes.Text += linha.Cells["Observacao"].Value.ToString() + ";";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao eliminar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsGravarDoc_Click_1(object sender, EventArgs e)
        {
            try
            {
                var docRow = dsDocumentos.CabecDocumento[0];

                if (ValidaPreenchimentoDocumento())
                {
                    docRow.TipoDocumento = TxtCodigoDoc.Text;
                    docRow.NrDocumento = int.Parse(NrDoc.Text);
                    if (docRow.TipoDocumento == "EDF" || docRow.TipoDocumento == "NDF")
                    {
                        docRow.Cliente = "CL000";
                        docRow.Fornecedor = TxtCodigoCl.Text;
                    }
                    else
                    {
                        docRow.Cliente = TxtCodigoCl.Text;
                        docRow.Fornecedor = "FN000";
                    }
                    docRow.Total = decimal.Parse(txtTotal.Text);
                    docRow.Estado = txtEstado.Text;
                    docRow.Observacoes = txtObservacoes.Text;
                    docRow.DataEntrega = dateTimePicker1.Value.Date;
                    docRow.DataRececao = DataMod.Value.Date;
                    docRow.Desconto = int.Parse(txtDesconto.Text);
                    if (cBoxEuro.Checked)
                    {
                        docRow.TipoDesconto = "Euro";
                    }
                    if (cBoxPercent.Checked)
                    {
                        docRow.TipoDesconto = "Percent";
                    }
                    if (!cBoxEuro.Checked && !cBoxPercent.Checked)
                    {
                        docRow.TipoDesconto = string.Empty;
                    }

                    if ((txtCat.Text == string.Empty) || (txtMarca.Text == string.Empty))
                    {// Obter código do produto
                        docRow.CodProduto = "PR000";
                    }
                    else
                    {
                        //campo invisivel
                        docRow.CodProduto = txtCodPr.Text;
                    }
                    dsDocumentos.UpdateDoc();
                    if (DgridArtigos.Enabled)
                    {
                        dsDocumentos.UpdateLinhas();

                        if (TxtCodigoDoc.Text == "FTC" || TxtCodigoDoc.Text.Contains("ND"))
                        {
                            AtualizarEstoqueAoSalvarDocumento();
                        }
                    }

                    MessageBox.Show("Documento salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparFormulario();
                    DesabilitarBotoes();
                    dsDocumentos.ListaProdutos.Clear();
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios do documento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gravar documento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsNovoDoc_Click_1(object sender, EventArgs e)
        {
            try
            {
                LimparFormulario();
                HabilitarBotoes();
                DesabilitarProduto();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar novo documento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsSair_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        public void tsImprimir_Click_1(object sender, EventArgs e)
        {
            try
            {
                ConfigurarImpressao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao imprimir documento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtCodigoCl.Text.Contains("CL"))
                {
                    dsClientes.NovoCliente();
                    PrepararCliente();
                }
                else if (TxtCodigoCl.Text.Contains("FN"))
                {
                    dsClientes.NovoFornecedor();
                    PrepararFornecedor();
                }
                else if (TxtCodigoCl.Text == "")
                {
                    var resultado = MessageBox.Show("Deseja criar um Novo fornecedor?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        dsClientes.NovoFornecedor();
                        PrepararFornecedor();
                    }
                    else
                    {
                        dsClientes.NovoCliente();
                        PrepararCliente();
                    }
                }
                BtnGravarCliente.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGravarCliente_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (TxtCodigoCl.Text.Contains("CL"))
                {
                    ClientesRow novoCliente = dsClientes.Clientes[0];
                    if (ValidaPreenchimentoCliente())
                    {
                        if (novoCliente.CodCl == dsClientes.DaProxNrCliente())
                        {
                            novoCliente.Nome = TxtNomeCl.Text;
                            novoCliente.CodCl = TxtCodigoCl.Text;
                            novoCliente.Telefone = TxtTelefone.Text;
                            novoCliente.Email = TxtEmail.Text;

                            dsClientes.UpdateClientes();

                            MessageBox.Show("Cliente Criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preencha todos os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (TxtCodigoCl.Text.Contains("FN"))
                {
                    FornecedoresRow novoCliente = dsClientes.Fornecedores[0];

                    if (ValidaPreenchimentoFornecedor())
                    {
                        if (novoCliente.FornecedorID == dsClientes.DaProxNrFornecedor())
                        {
                            novoCliente.Nome = TxtNomeCl.Text;
                            novoCliente.FornecedorID = TxtCodigoCl.Text;
                            novoCliente.Contato = TxtTelefone.Text;
                            novoCliente.Site = TxtEmail.Text;
                            novoCliente.Morada = txtMorada.Text;
                            novoCliente.Categoria = cbCategoria.SelectedValue.ToString();

                            dsClientes.UpdateFornecedores();

                            MessageBox.Show("foenecedor Criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preencha todos os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                BtnGravarCliente.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gravar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbrirPr_Click_1(object sender, EventArgs e)
        {
            AbrirSelecaoProdutos();
        }

        private void tsAddProduto_Click_1(object sender, EventArgs e)
        {
            try
            {
                FrmProdutos frmProdutos = new FrmProdutos();
                frmProdutos.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir formulário de produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsConsultaProduto_Click_1(object sender, EventArgs e)
        {
            AbrirSelecaoProdutos();
        }

        private void tsMarcas_Click_1(object sender, EventArgs e)
        {
            try
            {
                FrmDados frmDados = new FrmDados();
                frmDados.MostrarTabelaDados("DsMarcas");
                if (frmDados.DialogResult == DialogResult.Cancel)
                {
                    LimparFormulario();
                    DesabilitarBotoes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar Marcas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsAddMarcas_Click_1(object sender, EventArgs e)
        {
            try
            {
                FrmCat_Marca frmCat_Marca = new FrmCat_Marca();
                frmCat_Marca.tipoDadosAtual = FrmCat_Marca.TipoDados.Marcas;
                frmCat_Marca.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir formulario: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsAddCategorias_Click_1(object sender, EventArgs e)
        {
            try
            {
                FrmCat_Marca frmCat_Marca = new FrmCat_Marca();
                frmCat_Marca.tipoDadosAtual = FrmCat_Marca.TipoDados.Categorias;
                frmCat_Marca.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir formulario: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsConsultaCliente_Click_1(object sender, EventArgs e)
        {
            AbrirSelecaoClientes();
        }

        private void tsConsultaForn_Click_1(object sender, EventArgs e)
        {
            AbrirSelecaoForn();
        }

        private void tsAddForn_Click_1(object sender, EventArgs e)
        {
            try
            {
                FrmClientes frmClientes = new FrmClientes();
                frmClientes.tipoDadosAtual = FrmClientes.TipoDados.Fornecedores;
                frmClientes.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir formulário de fornecedores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsArmazem_Click(object sender, EventArgs e)
        {
            FrmStock frmStock = new FrmStock();
            frmStock.ShowDialog();
        }

        private void tsAddCl_Click_1(object sender, EventArgs e)
        {
            try
            {
                FrmClientes frmClientes = new FrmClientes();
                frmClientes.tipoDadosAtual = FrmClientes.TipoDados.Clientes;
                frmClientes.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir formulário de clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsDocumentos_Click(object sender, EventArgs e)
        {
            AbrirSelecaoDocumentos();
        }

        private void tsConsultaCat_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDados frmDados = new FrmDados();
                frmDados.MostrarTabelaDados("DsCategorias");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar Categorias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbrirCliente_Click(object sender, EventArgs e)
        {
            if (TxtDescricaoDoc.Text.Contains("Fornecedor") || TxtCodigoCl.Text.Contains("FN"))
            {
                AbrirSelecaoForn();
            }
            else
            {
                AbrirSelecaoClientes();
            }
     
        }

        private void txtCat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {

                FrmCat_Marca frmCat_Marca = new FrmCat_Marca();
                frmCat_Marca.tipoDadosAtual = FrmCat_Marca.TipoDados.Categorias;
                frmCat_Marca.ShowDialog();
            }
        }

        private void txtMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {

                FrmCat_Marca frmCat_Marca = new FrmCat_Marca();
                frmCat_Marca.tipoDadosAtual = FrmCat_Marca.TipoDados.Marcas;
                frmCat_Marca.ShowDialog();
            }
        }
        private void txtObservacoes_KeyDown(object sender, KeyEventArgs e)
        {   // Precisamos bloquear Backspace ou Delete caso atinja a região bloqueada
            // Se for Backspace
            if (e.KeyCode == Keys.Back)
            {
                // Se a posição do cursor estiver menor ou igual ao tamanho inicial,
                // impedimos que o backspace apague o texto protegido
                if (txtObservacoes.SelectionStart <= lockedTextLength)
                {
                    e.SuppressKeyPress = true;
                }
            }
            // Se for Delete
            else if (e.KeyCode == Keys.Delete)
            {
                // Se a posição do cursor estiver dentro da região protegida,
                // também bloqueamos o delete
                if (txtObservacoes.SelectionStart < lockedTextLength)
                {
                    e.SuppressKeyPress = true;
                }
            }

        }

        private void txtObservacoes_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a posição de edição (SelectionStart) está antes do final do texto bloqueado
            if (txtObservacoes.SelectionStart < lockedTextLength)
            {
                // Movemos o cursor para o final do texto, para só permitir adicionar ao final.
                txtObservacoes.SelectionStart = txtObservacoes.Text.Length;
            }
        }

        private void txtObservacoes_MouseDown(object sender, MouseEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (txtObservacoes.SelectionStart < lockedTextLength)
                {

                    txtObservacoes.SelectionStart = txtObservacoes.Text.Length;
                    txtObservacoes.SelectionLength = 0;
                }
            }));
        }
        #endregion

        #region Impressao

        private void ConfigurarImpressao()
        {
            printDocument = new PrintDocument();

            // Configurar eventos de impressão
            printDocument.BeginPrint += BeginPrint;
            printDocument.PrintPage += PrintPage;

            // Configurar a pré-visualização
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                Text = "Pré-visualização de Impressão",
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen,
                UseAntiAlias = true
            };

            // Mostrar pré-visualização
            previewDialog.ShowDialog();
        }

        private void BeginPrint(object sender, PrintEventArgs e)
        {
            if (e.PrintAction == PrintAction.PrintToPrinter)
            {
                PrintDialog printDialog = new PrintDialog
                {
                    Document = (PrintDocument)sender,
                    AllowSomePages = true,
                    AllowSelection = true,
                    AllowCurrentPage = true,
                    AllowPrintToFile = true,
                    UseEXDialog = true,
                    ShowHelp = true
                };

                if (printDialog.ShowDialog() != DialogResult.OK)
                {
                    e.Cancel = true; // Cancela a impressão se o usuário não confirmar
                    return;
                }

                // Configurações da impressora selecionada
                ((PrintDocument)sender).PrinterSettings = printDialog.PrinterSettings;

                // Caso a impressora seja "Microsoft Print to PDF"
                if (printDialog.PrinterSettings.PrinterName == "Microsoft Print to PDF")
                {
                    // Configura o monitoramento do diretório onde o arquivo será salvo
                    string diretorioDestino = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    ConfigurarWatcher(diretorioDestino);
                }

                ((PrintDocument)sender).DefaultPageSettings = printDialog.PrinterSettings.DefaultPageSettings;
            }
        }

        private void ConfigurarWatcher(string diretorioDestino)
        {
            FileSystemWatcher fileWatcher = new FileSystemWatcher
            {
                Path = diretorioDestino,
                Filter = "*.pdf", // Monitora apenas arquivos PDF
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime
            };

            fileWatcher.Created += OnFileCreated;
            fileWatcher.EnableRaisingEvents = true; // Inicia o monitoramento
        }



        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                string arquivoCriado = e.FullPath;

                // Aguarda até que o arquivo esteja livre para ser renomeado
                if (WaitForFile(arquivoCriado))
                {
                    // Define o novo nome do arquivo
                    string novoNomeArquivo = $"{TxtNomeCl.Text.Replace(" ","_")}_{tipoDoc}.pdf";
                    string caminhoRenomeado = Path.Combine(Path.GetDirectoryName(arquivoCriado), novoNomeArquivo);

                    // Renomeia o arquivo
                    File.Move(arquivoCriado, caminhoRenomeado);
                    MessageBox.Show($"Arquivo renomeado para: {caminhoRenomeado}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Desabilita o watcher
                    ((FileSystemWatcher)sender).EnableRaisingEvents = false;
                    ((FileSystemWatcher)sender).Dispose();
                }
                else
                {
                    if (File.Exists(arquivoCriado))
                    {
                        // Se WaitForFile retornar false, significa que não foi possível "desbloquear" o arquivo no tempo limite
                        MessageBox.Show("O arquivo não pôde ser aberto para renomear (tempo esgotado).",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao renomear o arquivo: {ex.Message}",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private bool IsFileReady(string filePath)
        {
            try
            {
                // Tenta abrir o arquivo em modo exclusivo (sem compartilhamento)
                using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    // Se conseguir abrir e o tamanho for > 0, então provavelmente o arquivo está ok
                    return fs.Length > 0;
                }
            }
            catch
            {
                // Se der exceção, significa que não foi possível abrir o arquivo (ainda está sendo escrito ou bloqueado)
                return false;
            }
        }

        private bool WaitForFile(string filePath, int timeoutMs = 10000)
        {
            // Define um tempo máximo para tentar (por padrão, 10 segundos)
            DateTime endTime = DateTime.Now.AddMilliseconds(timeoutMs);

            while (DateTime.Now < endTime)
            {
                if (IsFileReady(filePath))
                {
                    // Assim que o arquivo estiver "pronto", retornamos
                    return true;
                }

                // Aguardar um pequeno intervalo antes de tentar novamente
                Thread.Sleep(500);
            }

            // Se o tempo esgotou e ainda não conseguimos abrir,
            // retornamos false para indicar que o arquivo não está pronto
            return false;
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // Definir margens e dimensões
                float marginLeft = e.MarginBounds.Left;
                float marginTop = e.MarginBounds.Top; // Ajuste conforme necessário
                float pageWidth = e.MarginBounds.Width;
                float pageHeight = e.MarginBounds.Height;

                // Definir as fontes
                Font fonteTitulo = new Font("Arial", 22, FontStyle.Bold);
                Font fonteSubtitulo = new Font("Arial", 14, FontStyle.Bold);
                Font fonteTexto = new Font("Arial", 12, FontStyle.Regular);

                Brush brush = Brushes.Black;

                // Posicionamento vertical inicial
                float yPos = marginTop;

                // Desenhar o cabeçalho (logotipo inicial, nome da loja e informações do documento)
                yPos = DrawHeader(e.Graphics, marginLeft, yPos, pageWidth, fonteTitulo, fonteTexto, brush);


                // Desenhar as informações do cliente
                yPos = DrawClientInfo(e.Graphics, marginLeft, yPos, pageWidth, fonteSubtitulo, fonteTexto, brush);

                // Desenhar a tabela de itens (DataGridView) com 7 colunas
                yPos = DrawItemsTable(e.Graphics, marginLeft, yPos, pageWidth, brush);


                // Desenhar as informações do produto após a tabela, com o título "Objeto"
                yPos = DrawObservacoesDescontoTotal(e.Graphics, marginLeft, yPos, TxtCodigoDoc.Text, pageWidth, fonteSubtitulo, fonteTexto, brush);

                yPos = DrawSeparator(e.Graphics, marginLeft, yPos, pageWidth);

                yPos = DrawFinalLogo(e.Graphics, marginLeft, yPos, marginTop, pageWidth, pageHeight);

                // Desenhar a assinatura e a data
                DrawSignatureAndDate(e.Graphics, marginLeft, yPos, pageWidth, fonteTexto, brush);

                // Desenhar o logotipo final

                // Indica que não há mais páginas a serem impressas
                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no PrintPage: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.HasMorePages = false;
            }
        }

        public float DrawHeader(Graphics graphics, float marginLeft, float yPos, float pageWidth, Font fonteTitulo, Font fonteTexto, Brush brush)
        {
            string logoPath = Path.Combine(Application.StartupPath, "Resources", "transferir.jpeg"); 


            string storeNameTemp = dsDocumentos.CabecDocumento[0].TipoDocumento;
            string storeName = dsDocumentos.TipoDocumentos.Where(x => x.CodDoc == storeNameTemp).Select(x => x.Descricao).First();
            // Nome do documento
            string codDocumento = TxtCodigoDoc.Text; // Código do documento


            int nrDocumento = int.Parse(NrDoc.Text); // Número do documento
            string documento = codDocumento + $"{nrDocumento:000}";
            string dataValor = DataMod.Value.ToShortDateString();

            tipoDoc = documento;

            float logoHeight = 110;
            float logoWidth = 0;

            // **1. Logo Centralizado e Ajustado à Largura da Página**
            if (File.Exists(logoPath))
            {
                using (Image logo = Image.FromFile(logoPath))
                {
                    // Calcular a largura do logo mantendo a proporção
                    float aspectRatio = logo.Width / (float)logo.Height;
                    logoWidth = aspectRatio * logoHeight + 30;

                    // Garantir que o logo não ultrapasse a largura da página
                    if (logoWidth > pageWidth)
                    {
                        logoWidth = pageWidth;
                        logoHeight = logoWidth / aspectRatio;
                    }

                    // Centralizar o logo horizontalmente
                    float logoX = marginLeft + (pageWidth - logoWidth) / 2;
                    graphics.DrawImage(logo, logoX, yPos, logoWidth, logoHeight);
                }
            }

            yPos += logoHeight + 10; // Espaço após o logo

            // **2. Linha Separadora**
            graphics.DrawLine(Pens.Black, marginLeft, yPos, marginLeft + pageWidth, yPos);
            yPos += 40; // Espaçamento de 40 unidades após a linha

            // **3. Nome do Documento Centralizado**
            SizeF storeNameSize = graphics.MeasureString(storeName, fonteTitulo);
            float storeNameX = marginLeft + (pageWidth - storeNameSize.Width) / 2;
            graphics.DrawString(storeName, fonteTitulo, brush, storeNameX, yPos);
            yPos += storeNameSize.Height + 10; // Espaço após o nome do documento

            // **4. Número da Fatura e Data na Mesma Linha dentro de um Retângulo**
            Font fonteNegrito = new Font(fonteTexto.FontFamily, fonteTexto.Size, FontStyle.Bold);
            Font fonteNormal = fonteTexto;

            string numeroLabel = "Número: ";
            string numeroValor = documento;
            string dataLabel = "Data: ";
            // dataValor já definido anteriormente

            // Medir alturas para alinhamento vertical
            float lineHeight = Math.Max(
                graphics.MeasureString(numeroLabel + numeroValor, fonteTexto).Height,
                graphics.MeasureString(dataLabel + dataValor, fonteTexto).Height);

            // Medir larguras dos textos

            SizeF dataSize = graphics.MeasureString(dataLabel + dataValor, fonteTexto);

            // **Desenhar Retângulo que Envolve o Texto do "Número" e da "Data"**
            float rectX = marginLeft;
            float rectY = yPos - 5; // Ajuste vertical para incluir o texto e um pequeno espaçamento
            float rectWidth = pageWidth;
            float rectHeight = lineHeight + 3; // Altura do texto mais espaçamento superior e inferior

            // Desenhar retângulo ao redor do texto do "Número" e "Data"
            graphics.DrawRectangle(Pens.Black, rectX, rectY, rectWidth, rectHeight);

            // **Número da Fatura Alinhado à Esquerda dentro do Retângulo**
            float numeroX = marginLeft + 5; // Espaçamento interno à esquerda
            float textoY = yPos; // Posição vertical do texto

            graphics.DrawString(numeroLabel, fonteNegrito, brush, numeroX, textoY);
            float numeroLabelWidth = graphics.MeasureString(numeroLabel, fonteNegrito).Width;
            graphics.DrawString(numeroValor, fonteNormal, brush, numeroX + numeroLabelWidth, textoY);

            // **Data Alinhada à Direita dentro do Retângulo**
            float dataX = marginLeft + pageWidth - dataSize.Width - 10; // Espaçamento interno à direita
            graphics.DrawString(dataLabel, fonteNegrito, brush, dataX, textoY);
            float dataLabelWidth = graphics.MeasureString(dataLabel, fonteNegrito).Width;
            graphics.DrawString(dataValor, fonteNormal, brush, dataX + dataLabelWidth, textoY);

            yPos += rectHeight + 20; // Avançar o yPos após esta seção, incluindo espaçamento adicional

            return yPos;
        }

        public float DrawClientInfo(Graphics graphics, float marginLeft, float yPos, float pageWidth, Font fonteSubtitulo, Font fonteTexto, Brush brush)
        {
            // Título da seção
            graphics.DrawString("Informações do Cliente ", fonteSubtitulo, brush, marginLeft, yPos);
            yPos += fonteSubtitulo.GetHeight(graphics) + 5;

            // Definir fontes
            Font fonteNegrito = new Font(fonteTexto.FontFamily, fonteTexto.Size, FontStyle.Bold);
            Font fonteNormal = fonteTexto;

            // Preparar informações do cliente
            string[] clienteLabels = { "Nome:", "Telefone:", "Email:" };
            string[] clienteValores = { TxtNomeCl.Text, TxtTelefone.Text, TxtEmail.Text };

            // Preparar informações do produto
            string[] produtoLabels = { "Categoria:", "Marca:", "Produto:", "IMEI: " };
            string[] produtoValores = { txtCat.Text, txtMarca.Text, txtEquipNome.Text, txtImei.Text };

            // Calcular a altura necessária para as informações do cliente e do produto
            float lineHeight = fonteTexto.GetHeight(graphics);
            int numLinhasCliente = clienteLabels.Length;
            int numLinhasProduto = produtoLabels.Length;
            int numLinhas = Math.Max(numLinhasCliente, numLinhasProduto);

            // Altura total do conteúdo dentro do retângulo
            float rectHeight = (lineHeight + 5) * numLinhas + 15; // 5 unidades de espaçamento entre linhas, 20 de espaçamento interno

            // Definir dimensões do retângulo
            float rectX = marginLeft;
            float rectY = yPos;
            float rectWidth = pageWidth;

            // Desenhar retângulo
            graphics.DrawRectangle(Pens.Black, rectX, rectY, rectWidth, rectHeight);

            // Espaçamento interno
            float paddingX = 10;
            float paddingY = 10;

            // Posição inicial para desenhar o texto dentro do retângulo
            float textY = rectY + paddingY + 15;

            // **Desenhar informações do cliente alinhadas à margem esquerda**
            float clienteX = rectX + paddingX;

            for (int i = 0; i < numLinhasCliente; i++)
            {
                // Desenhar label
                graphics.DrawString(clienteLabels[i], fonteNegrito, brush, clienteX, textY);
                float labelWidth = graphics.MeasureString(clienteLabels[i], fonteNegrito).Width;
                // Desenhar valor
                graphics.DrawString(clienteValores[i], fonteNormal, brush, clienteX + labelWidth + 5, textY);

                textY += lineHeight + 5; // Atualizar Y para a próxima linha
            }

            // **Desenhar informações do produto alinhadas à margem direita**
            // Resetar textY para a posição inicial
            textY = rectY + paddingY + 3;

            // Medir a largura máxima das labels e valores do produto
            float maxProdutoLabelWidth = 0;
            float maxProdutoValorWidth = 0;
            for (int i = 0; i < numLinhasProduto; i++)
            {
                float labelWidth = graphics.MeasureString(produtoLabels[i], fonteNegrito).Width;
                float valorWidth = graphics.MeasureString(produtoValores[i], fonteNormal).Width;
                if (labelWidth > maxProdutoLabelWidth) maxProdutoLabelWidth = labelWidth;
                if (valorWidth > maxProdutoValorWidth) maxProdutoValorWidth = valorWidth;
            }

            // Calcular a posição X inicial para as informações do produto
            float produtoX = rectX + rectWidth - paddingX - (maxProdutoLabelWidth + 5 + maxProdutoValorWidth);

            for (int i = 0; i < numLinhasProduto; i++)
            {
                // Desenhar label
                graphics.DrawString(produtoLabels[i], fonteNegrito, brush, produtoX, textY);
                float labelWidth = graphics.MeasureString(produtoLabels[i], fonteNegrito).Width;
                // Desenhar valor
                graphics.DrawString(produtoValores[i], fonteNormal, brush, produtoX + labelWidth + 5, textY);

                textY += lineHeight + 5; // Atualizar Y para a próxima linha
            }

            // Atualizar yPos para a próxima seção
            yPos += rectHeight + 30; // Espaçamento após o retângulo

            return yPos;
        }
        public float DrawObservacoesDescontoTotal(Graphics graphics, float marginLeft, float yPos, string codDocumento, float pageWidth, Font fonteSubtitulo, Font fonteTexto, Brush brush)
        {
            Font fonteNegrito = new Font(fonteTexto.FontFamily, 12, FontStyle.Bold);

            Font fonteNormal = new Font(fonteTexto.FontFamily, 10, FontStyle.Bold);
            // Espaçamento interno e entre elementos
            float padding = 10;
            float lineHeight = fonteTexto.GetHeight(graphics) + 5;

            // **1. Preparar textos e valores**
            string observacoesLabel = "Observações";
            string observacoesTexto = txtObservacoes.Text;
            string descontoValor = txtDesconto.Text;
            string descontoLabel = "Desconto:";
            if (cBoxPercent.Checked)
            {
                descontoValor = txtDesconto.Text + " %";
            }
            else if (cBoxEuro.Checked)
            {
                descontoValor = txtDesconto.Text + " €";
            }
            string totalLabel = "Total:";
            string totalValor = txtTotal.Text + "€";

            string previsaoLabel = "Previsão:";
            string previsaoTexto = dateTimePicker1.Value.Date.ToString("dd/MM/yyyy");

            // **2. Definir áreas para Observações e Desconto/Total**
            // Dividiremos a largura disponível em duas partes
            float availableWidth = pageWidth;
            float observacoesWidth = availableWidth * 0.7f; // 60% para Observações
            float valoresWidth = availableWidth * 0.3f;     // 40% para Desconto e Total

            // **3. Desenhar a seção de Observações**
            // **3.1. Desenhar o rótulo "Observações"**
            graphics.DrawString(observacoesLabel, fonteSubtitulo, brush, marginLeft, yPos);
            yPos += lineHeight;

            // **3.2. Desenhar o retângulo para o texto das Observações**
            float observacoesRectX = marginLeft;
            float observacoesRectY = yPos;
            float observacoesRectHeight = (lineHeight * 3) + (padding * 2); // 3 linhas de texto + espaçamento interno
            graphics.DrawRectangle(Pens.Black, observacoesRectX, observacoesRectY, observacoesWidth, observacoesRectHeight);

            // **3.3. Desenhar o texto das Observações dentro do retângulo**
            RectangleF observacoesTextRect = new RectangleF(
                observacoesRectX + padding,
                observacoesRectY + padding,
                observacoesWidth - (padding * 2),
                observacoesRectHeight - (padding * 2)
            );
            // Limitar o texto a 3 linhas
            StringFormat stringFormat = new StringFormat();
            stringFormat.Trimming = StringTrimming.EllipsisWord;
            stringFormat.FormatFlags = StringFormatFlags.LineLimit;

            graphics.DrawString(observacoesTexto, fonteTexto, brush, observacoesTextRect, stringFormat);

            // **4. Desenhar a seção de Desconto e Total**
            float valoresX = marginLeft + observacoesWidth;
            float valoresY = yPos;

            if (codDocumento == "ORC" || codDocumento == "NDC")
            {
                graphics.DrawString(previsaoLabel, fonteNormal, brush, valoresX + padding, valoresY + padding);
                float labelDireitaWidth = graphics.MeasureString(previsaoLabel, fonteNegrito).Width;
                graphics.DrawString(previsaoTexto, fonteNormal, brush, valoresX + padding + labelDireitaWidth, valoresY + padding);
            }
            // **4.1. Desenhar "Desconto" e valor**
            if (txtDesconto.Text != "0" && txtDesconto.Text != string.Empty)
            {
                graphics.DrawString(descontoLabel, fonteNormal, brush, valoresX + padding, valoresY + padding + 20);
                float descontoLabelWidth = graphics.MeasureString(descontoLabel, fonteSubtitulo).Width;
                graphics.DrawString(descontoValor, fonteNormal, brush, valoresX + padding + descontoLabelWidth - 15, valoresY + padding + 20);

            }

            // **4.2. Desenhar "Total" e valor abaixo de "Desconto"**
            float totalY = valoresY + lineHeight + padding;
            graphics.DrawString(totalLabel, fonteNegrito, brush, valoresX + padding + 20, totalY + padding + 20);
            float totalLabelWidth = graphics.MeasureString(totalLabel, fonteSubtitulo).Width;
            graphics.DrawString(totalValor, fonteTexto, brush, valoresX + padding + totalLabelWidth + 20, totalY + padding + 20);

            // **4.3. Desenhar retângulo ao redor de Desconto e Total**
            float valoresHeight = observacoesRectHeight; // Mesmo altura da seção de Observações
            graphics.DrawRectangle(Pens.Black, valoresX, valoresY, valoresWidth, valoresHeight);

            // **5. Atualizar yPos para a próxima seção**
            yPos += observacoesRectHeight + 40; // Espaçamento após a seção

            return yPos;
        }

        public float DrawSeparator(Graphics graphics, float marginLeft, float yPos, float pageWidth)
        {
            graphics.DrawLine(Pens.Black, marginLeft, yPos, marginLeft + pageWidth, yPos);
            yPos += 20; // Aumentar o espaçamento após a linha
            return yPos;
        }

        public void DrawSignatureAndDate(Graphics graphics, float marginLeft, float yPos, float pageWidth, Font fonteTexto, Brush brush)
        {
            string assinaturaText = "Assinatura";
            // Desenhar a assinatura
            SizeF assinaturaTextSize = graphics.MeasureString(assinaturaText, fonteTexto);
            float signatureLineWidth = pageWidth / 2;
            float totalSignatureWidth = assinaturaTextSize.Width + signatureLineWidth;
            float signatureBlockX = marginLeft + pageWidth / 2 - (totalSignatureWidth / 2);

            // Espaçamento após 'Assinatura'

            graphics.DrawString(assinaturaText, fonteTexto, brush, signatureBlockX, yPos);
            float lineY = yPos + assinaturaTextSize.Height / 2;
            graphics.DrawLine(Pens.Black, signatureBlockX + assinaturaTextSize.Width, lineY, signatureBlockX + assinaturaTextSize.Width + signatureLineWidth, lineY);
        }

        public float DrawItemsTable(Graphics graphics, float marginLeft, float yPos, float pageWidth, Brush brush)
        {
            // Título da seção
            Font fonteSubtitulo = new Font("Arial", 14, FontStyle.Bold);
            Font fonteTexto = new Font("Arial", 11, FontStyle.Bold);
            Font fonteTabela = new Font("Arial", 9, FontStyle.Regular);
            graphics.DrawString("Descritivo", fonteSubtitulo, brush, marginLeft, yPos);
            yPos += fonteSubtitulo.GetHeight(graphics) + 5; // Espaço após o título

            // Definir colunas
            int numColumns = 7;

            // Definir cabeçalhos das colunas
            var columnsToPrint = new[] { "NomeCategoria", "NomeMarca", "NomeProduto", "iMEIDataGridViewTextBoxColumn", "precoUntDataGridViewTextBoxColumn", "quantidadeDataGridViewTextBoxColumn", "totalDataGridViewTextBoxColumn" };
            var columnHeaders = new[] { "Categoria", "Marca", "Produto", "Código Id", "Preço Un", "Qtd", "Total" };

            // Calcular largura das colunas
            float totalAvailableWidth = pageWidth; // Espaço disponível para a tabela
            float columnWidth = totalAvailableWidth / numColumns;
            float[] columnWidths = Enumerable.Repeat(columnWidth, numColumns).ToArray();

            float xPos = marginLeft;
            float lineHeight = fonteTexto.GetHeight(graphics) + 10;

            Pen pen = Pens.Black;

            // Desenhar cabeçalho da tabela
            yPos += 5; // Espaçamento antes da tabela
            for (int i = 0; i < numColumns; i++)
            {
                // Desenhar retângulo da célula do cabeçalho
                graphics.DrawRectangle(pen, xPos, yPos, columnWidths[i], lineHeight);

                // Centralizar texto no cabeçalho
                string headerText = columnHeaders[i];
                RectangleF headerRect = new RectangleF(xPos, yPos, columnWidths[i], lineHeight);
                StringFormat headerFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                graphics.DrawString(headerText, fonteTexto, brush, headerRect, headerFormat);
                xPos += columnWidths[i];
            }
            yPos += lineHeight;


            // Desenhar linhas da tabela com os dados
            foreach (DataGridViewRow row in DgridArtigos.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Calcular a altura máxima necessária para esta linha
                    float maxCellHeight = 0;
                    List<string> cellValues = new List<string>();

                    for (int i = 0; i < numColumns; i++)
                    {
                        // Obter o valor da célula
                        string cellValue = row.Cells[columnsToPrint[i]].Value?.ToString() ?? "";
                        cellValues.Add(cellValue);

                        // Medir o tamanho do texto com quebra de linha
                        SizeF textSize = graphics.MeasureString(cellValue, fonteTabela, (int)columnWidths[i]);
                        if (textSize.Height > maxCellHeight)
                        {
                            maxCellHeight = textSize.Height;
                        }
                    }

                    // Definir a altura da linha com base na altura máxima das células
                    float cellHeight = maxCellHeight + 5; // Adicionar um pequeno espaçamento

                    xPos = marginLeft;
                    for (int i = 0; i < numColumns; i++)
                    {
                        // Desenhar retângulo da célula
                        graphics.DrawRectangle(pen, xPos, yPos, columnWidths[i], cellHeight);

                        // Definir o retângulo para desenhar o texto
                        RectangleF cellRect = new RectangleF(xPos + 2, yPos + 2, columnWidths[i] - 4, cellHeight - 4);

                        // Formatar o texto para quebra de linha
                        StringFormat cellFormat = new StringFormat
                        {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Near,
                            FormatFlags = StringFormatFlags.LineLimit // Permitir quebra de linha
                        };

                        // Desenhar o texto dentro da célula
                        graphics.DrawString(cellValues[i], fonteTabela, brush, cellRect, cellFormat);

                        xPos += columnWidths[i];
                    }
                    yPos += cellHeight;

                }
            }

            yPos += 20; // Espaçamento após a tabela
            return yPos;
        }



        public float DrawFinalLogo(Graphics graphics, float marginLeft, float yPos, float marginTop, float pageWidth, float pageHeight)
        {
            string bottomImagePath =  Path.Combine(Application.StartupPath, "Resources", "Morada2.jpeg");

            if (File.Exists(bottomImagePath))
            {
                using (Image bottomImage = Image.FromFile(bottomImagePath))
                {
                    float desiredBottomImgWidth = 500;
                    float bottomImgHeight = bottomImage.Height * (desiredBottomImgWidth / bottomImage.Width) - 75;

                    // Posicionar a imagem no fundo da página, centralizada horizontalmente
                    float bottomImageX = marginLeft + (pageWidth / 2) - (desiredBottomImgWidth / 2);
                    float bottomImageYPosition = marginTop + pageHeight - (bottomImgHeight / 2); // Posicionar logo após o último conteúdo

                    graphics.DrawImage(bottomImage, bottomImageX, bottomImageYPosition + 30, desiredBottomImgWidth, bottomImgHeight);
                    yPos = marginTop + pageHeight - bottomImgHeight - 50;

                }
            }
            return yPos;
        }


        #endregion

     
    }
}
