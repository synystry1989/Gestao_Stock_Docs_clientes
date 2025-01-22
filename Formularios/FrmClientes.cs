using System;
using System.Data;
using System.Reflection.Emit;
using System.Windows.Forms;
using TeleBerço.Datasets;
using static TeleBerço.Datasets.DsClientes;

namespace TeleBerço
{
    public partial class FrmClientes : Form
    {
        private DsClientes dsClientes = new DsClientes();


        public DataRow RowSelecionada { get; set; }

        public enum TipoDados
        {
            Clientes,
            Fornecedores
        }
        public TipoDados tipoDadosAtual { get; set; }

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load_1(object sender, EventArgs e)
        {
           

            if (tipoDadosAtual == TipoDados.Clientes)
            {
                ConfigInicialCl();

                if (RowSelecionada != null)
                {
                    CarregarClienteSelecionado(sender,e);

                }
                else
                {
                    PrepararNovoCliente();
                }

            }
            else if (tipoDadosAtual == TipoDados.Fornecedores)
            {
                ConfigInicialForn();

                if (RowSelecionada != null)
                {
                    CarregarFornecedorSelecionado(sender,e);
                }
                else
                {
                    PrepararNovoFornecedor();
                }
            }
            HabilitarCampos();
        }

        private void ConfigInicialCl()
        {

            lblForncedor.Visible = false;
            lblMorada.Visible = false;
            lblLoja.Visible = false;
            txtMorada.Visible = false;
            cbCategoria.Visible = false;
            label1.Visible = false;

            LabelCliente.Visible = true;
            LblEmail.Visible = true;
            
        }
        private void ConfigInicialForn()
        {
            LabelCliente.Visible = false;
            LblEmail.Visible = false;
            lblForncedor.Visible = true;
            lblMorada.Visible = true;
            lblLoja.Visible = true;
            cbCategoria.Visible = true;
            label1.Visible = true;
            dsProdutos.CarregaCategorias();
        }


        private void CarregarFornecedorSelecionado(object sender,EventArgs e)
        {
            try
            {
                var clienteRow = (FornecedoresRow)RowSelecionada;
                TxtCodigoCl.Text = clienteRow.FornecedorID;
                TxtCodigoCl_Leave(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarClienteSelecionado(object sender,EventArgs e)
        {
            try
            {
                var clienteRow = (ClientesRow)RowSelecionada;
                TxtCodigoCl.Text = clienteRow.CodCl;
                TxtCodigoCl_Leave(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrepararNovoCliente()
        {
            try
            {
                LimparFormulario();
                TxtCodigoCl.Text = dsClientes.DaProxNrCliente();        
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preparar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrepararNovoFornecedor()
        {
            try
            {
                LimparFormulario();
                TxtCodigoCl.Text = dsClientes.DaProxNrFornecedor();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preparar Fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherCliente()
        {
            try
            {
                var clienteRow = dsClientes.PesquisaCliente(TxtCodigoCl.Text);

                if (clienteRow.CodCl != dsClientes.DaProxNrCliente())
                {
                    TxtNomeCl.Text = clienteRow.Nome;
                    TxtTelefone.Text = clienteRow.Telefone;
                    TxtEmail.Text = clienteRow.Email;
                }
                else
                {
                    PrepararNovoCliente();                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherFornecedor()
        {
            try
            {
                var clienteRow = dsClientes.PesquisaFornecedor(TxtCodigoCl.Text);

                if (clienteRow.FornecedorID != dsClientes.DaProxNrFornecedor())
                {
                    TxtNomeCl.Text = clienteRow.Nome;
                    TxtTelefone.Text = clienteRow.Contato;
                    TxtEmail.Text = clienteRow.Site;
                    cbCategoria.Text = dsProdutos.DaNomeCategoria(clienteRow.Categoria);
                    txtMorada.Text = clienteRow.Morada;             
                }
                else
                {
                    PrepararNovoFornecedor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher Fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimparFormulario()
        {
            TxtCodigoCl.Text = string.Empty;
            TxtNomeCl.Text = string.Empty;
            TxtTelefone.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            cbCategoria.Text= string.Empty;
            txtMorada.Text= string.Empty;
        }

        private void HabilitarCampos()
        {

         
            TxtNomeCl.Enabled = true;
            TxtTelefone.Enabled = true;
            TxtEmail.Enabled = true;
            txtMorada.Enabled = true;
            cbCategoria.Enabled = true;

            BtnGravar.Enabled = true;
            BtnEliminar.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            TxtNomeCl.Enabled = false;       
            TxtTelefone.Enabled = false;
            TxtEmail.Enabled = false;
            txtMorada.Enabled = false;
            cbCategoria.Enabled = false;
            BtnGravar.Enabled = false;
            BtnEliminar.Enabled = false;
        }

        private bool ValidarPreenchimento()
        {
            return !string.IsNullOrWhiteSpace(TxtCodigoCl.Text) &&
                   !string.IsNullOrWhiteSpace(TxtNomeCl.Text) &&
                   !string.IsNullOrWhiteSpace(TxtTelefone.Text);
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            if (tipoDadosAtual == TipoDados.Clientes)
            {
                PrepararNovoCliente();
                TxtCodigoCl.Focus();
            }
            else if (tipoDadosAtual == TipoDados.Fornecedores)
            {
                PrepararNovoFornecedor();
                TxtCodigoCl.Focus();
            }
            HabilitarCampos();
            
        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarPreenchimento())
                {
                    if (tipoDadosAtual == TipoDados.Clientes)
                    {

                        ClientesRow novoCliente = dsClientes.Clientes[0];

                        if (novoCliente != null)
                        {

                            novoCliente.CodCl = TxtCodigoCl.Text;
                            novoCliente.Nome = TxtNomeCl.Text;
                            novoCliente.Email = TxtEmail.Text;
                            novoCliente.Telefone = TxtTelefone.Text;
                            dsClientes.UpdateClientes();
                        
                            MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFormulario();
                            DesabilitarCampos();
                        }
                    }
                    else if (tipoDadosAtual == TipoDados.Fornecedores)
                    {
                        FornecedoresRow novoCliente = dsClientes.Fornecedores[0];

                        if (novoCliente != null)
                        {

                            novoCliente.FornecedorID = TxtCodigoCl.Text;
                            novoCliente.Nome = TxtNomeCl.Text;
                            novoCliente.Site = TxtEmail.Text;
                            novoCliente.Contato = TxtTelefone.Text;
                            novoCliente.Categoria = cbCategoria.SelectedValue.ToString();
                            novoCliente.Morada = txtMorada.Text;
                            dsClientes.UpdateFornecedores();
                     
                            MessageBox.Show($"fornecedor gravado com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFormulario();
                            DesabilitarCampos();
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Por favor, preencha todos os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gravar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tipoDadosAtual == TipoDados.Clientes)
                {
                    if (!string.IsNullOrEmpty(TxtCodigoCl.Text))
                    {
                        var resultado = MessageBox.Show("Deseja realmente excluir este cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)

                        {
                            TxtCodigoCl.Focus();
                            dsClientes.EliminarCliente(TxtCodigoCl.Text);

                            MessageBox.Show("Cliente excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFormulario();
                            DesabilitarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (tipoDadosAtual == TipoDados.Fornecedores && !string.IsNullOrEmpty(TxtCodigoCl.Text))
                {
                                      
                        var resultado = MessageBox.Show("Deseja realmente excluir este fornecedor?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resultado == DialogResult.Yes)
                        {
                            TxtCodigoCl.Focus();
                            dsClientes.EliminarFornecedor(TxtCodigoCl.Text);

                            MessageBox.Show("Fornecedor excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparFormulario();
                            DesabilitarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Fornecedor não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }                   
                }
            }
            catch (Exception ex)
            {
                if (tipoDadosAtual == TipoDados.Clientes)
                {
                    MessageBox.Show($"Erro ao excluir cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tipoDadosAtual == TipoDados.Fornecedores)
                {
                    MessageBox.Show($"Erro ao excluir fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtCodigoCl_Leave(object sender, EventArgs e)
            {
             if (tipoDadosAtual == TipoDados.Clientes)
            {
                PreencherCliente();
            }
            else if (tipoDadosAtual == TipoDados.Fornecedores)
            {
                PreencherFornecedor();
            }
        }
        }
    }

