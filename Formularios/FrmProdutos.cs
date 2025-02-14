﻿using System;
using System.Data;
using System.Windows.Forms;
using TeleBerço.Datasets;
using static TeleBerço.Datasets.DsProdutos;
using static TeleBerço.Datasets.DsStock;

namespace TeleBerço
{
    public partial class FrmProdutos : Form
    {
        public DataRow RowSelecionada { get; set; }
        private FrmDados frmDados = new FrmDados();
        private DsProdutos dsArtigos = new DsProdutos();
        private DsStock dsStock = new DsStock();

        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            CarregarMarcasECategorias();

            if (RowSelecionada != null)
            {
                CarregarProdutoSelecionado();

            }
            else
            {
                PrepararNovoProduto();
            }
            TxtCodigoPr.Select();
            HabilitarCampos();
        }

        private void CarregarMarcasECategorias()
        {
            try
            {
                dsArtigos.CarregaCategorias();
                dsArtigos.CarregarMarcas();

                txtMarca.DataSource = dsArtigos.Marcas;
                txtMarca.DisplayMember = "Nome";
                txtMarca.ValueMember = "Id";

                txtModelo.DataSource = dsArtigos.Categorias;
                txtModelo.DisplayMember = "Nome";
                txtModelo.ValueMember = "CodCat";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparFormulario()
        {
            TxtCodigoPr.Text = string.Empty;
            TxtNomeProduto.Text = string.Empty;
            TxtObservacao.Text = string.Empty;
            TxtCusto.Text = string.Empty;
            TxtPreco.Text = string.Empty;
            txtImei.Text = string.Empty;
            txtTipoPr.Text = string.Empty;
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtQtd.Text = "0";
        }

        private void HabilitarCampos()
        {
       
            TxtNomeProduto.Enabled = true;
            TxtObservacao.Enabled = true;
            TxtCusto.Enabled = true;
            TxtPreco.Enabled = true;
            txtImei.Enabled = true;
            txtTipoPr.Enabled = true;
            txtMarca.Enabled = true;
            txtModelo.Enabled = true;
            txtQtd.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnGravar.Enabled = true;
        }

        private void DesabilitarCampos()
        {
     
            TxtNomeProduto.Enabled = false;
            TxtObservacao.Enabled = false;
            TxtCusto.Enabled = false;
            TxtPreco.Enabled = false;
            txtImei.Enabled = false;
            txtTipoPr.Enabled = false;
            txtMarca.Enabled = false;
            txtModelo.Enabled = false;
            txtQtd.Enabled = false;
            BtnGravar.Enabled = false;
            BtnEliminar.Enabled= false;
        }

        private bool ValidarPreenchimento()
        {
            return !string.IsNullOrWhiteSpace(TxtCodigoPr.Text) &&
                   !string.IsNullOrWhiteSpace(TxtNomeProduto.Text) &&
                   !string.IsNullOrWhiteSpace(txtMarca.Text) &&
                   !string.IsNullOrWhiteSpace(txtModelo.Text) &&
                   !string.IsNullOrWhiteSpace(TxtCusto.Text);

        }

        private void CarregarProdutoSelecionado()
        {
            try
            {
                var produtoRow = (ProdutosRow)RowSelecionada;
                if (produtoRow != null)
                {
                    TxtCodigoPr.Text = produtoRow.CodPr;
                    PreencherProduto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrepararNovoProduto()
        {
            try
            {
                LimparFormulario();
                TxtCodigoPr.Text = dsArtigos.DaProxCodArtigo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preparar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherProduto()
        {
            try
            {
           
                var produtoRow = dsArtigos.PesquisarArtigo(TxtCodigoPr.Text);

                if (produtoRow.CodPr != dsArtigos.DaProxCodArtigo())
                {
                    dsArtigos.CarregaCategorias();
                    dsArtigos.CarregarMarcas();
                    TxtNomeProduto.Text = produtoRow.NomeProduto;
                    TxtObservacao.Text = produtoRow.Observacao;
                    TxtCusto.Text = produtoRow.PrecoCusto.ToString("F2");
                    TxtPreco.Text = produtoRow.PreçoVenda.ToString("F2");
                    txtImei.Text = produtoRow.IMEI;
                    txtTipoPr.Text = produtoRow.Tipo;
                    txtMarca.SelectedValue = produtoRow.Marcas;
                    txtModelo.SelectedValue = produtoRow.Categorias;

                }
                else
                {
                    PrepararNovoProduto();
                }
                HabilitarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                PrepararNovoProduto();
                HabilitarCampos();
                TxtCodigoPr.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar novo produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarPreenchimento())
                {
                    ProdutosRow produtoRow = dsArtigos.Produtos[0];

                    produtoRow.CodPr = TxtCodigoPr.Text;
                    produtoRow.NomeProduto = TxtNomeProduto.Text;
                    produtoRow.Observacao = TxtObservacao.Text;
                    produtoRow.PrecoCusto = decimal.Parse(TxtCusto.Text);
                    produtoRow.PreçoVenda = decimal.Parse(TxtPreco.Text);
                    produtoRow.IMEI = txtImei.Text;
                    produtoRow.Tipo = txtTipoPr.Text;
                    produtoRow.Marcas = (int)txtMarca.SelectedValue;
                    produtoRow.Categorias = txtModelo.SelectedValue.ToString();

                    dsArtigos.UpdateArtigos();

                    MessageBox.Show("Produto salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Se o produto não existe no estoque, adicioná-lo     
                    bool novo = false;
                    ArmazemRow row = dsStock.PesquisarStock(produtoRow.CodPr, ref novo);
                    if (novo)
                    {
                        MessageBox.Show("Produto não existente em stock!Sera criada entrada Nova", "Sucesso");

                    }
                   if (txtQtd.Text != "0" && txtQtd.Text != null)
                    {
                        dsStock.AtualizarStock(row.ProdutoID, int.Parse(txtQtd.Text), "AM+", "");      

                    }
                                            
                    LimparFormulario();
                    DesabilitarCampos();

                               
                }
                else
                {
                    MessageBox.Show("Por favor, preencha corretamente todos os campos .", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gravar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {

                frmDados.MostrarTabelaDados("DsMarcas");
                dsArtigos.CarregarMarcas();
            }
        }

        private void txtModelo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {

                frmDados.MostrarTabelaDados("DsCategorias");
                dsArtigos.CarregaCategorias();
            }
        }

        private void TxtCodigoPr_Leave(object sender, EventArgs e)
        {
            PreencherProduto();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = MessageBox.Show("Deseja realmente excluir este Produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    TxtCodigoPr.Focus();
                    dsStock.EliminarStock(TxtCodigoPr.Text);

                    dsStock.EliminarMov(TxtCodigoPr.Text);
                    dsArtigos.EliminarPr(TxtCodigoPr.Text);
                 
                    LimparFormulario();
                    DesabilitarCampos();

                    MessageBox.Show("Produto excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
