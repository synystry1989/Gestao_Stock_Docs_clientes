using System;
using System.Data;
using System.Windows.Forms;
using TeleBerço.Datasets;
using static TeleBerço.Datasets.DsProdutos;

namespace TeleBerço
{
    public partial class FrmCat_Marca : Form
    {
        public FrmCat_Marca()
        {
            InitializeComponent();
        }

        public DataRow RowSelecionada { get; set; }

        DsProdutos dsProdutos = new DsProdutos();

        public enum TipoDados
        {
            Marcas,
            Categorias
        }
        public TipoDados tipoDadosAtual;
        private void FrmCat_Marca_Load(object sender, EventArgs e)
        {

            if (tipoDadosAtual == TipoDados.Categorias)
            {
               
                LabelMarca.Visible = false;

                if (RowSelecionada != null)
                {
                    var Row = (CategoriasRow)RowSelecionada;

                    dsProdutos.PesquisarCat(Row.CodCat);

                    TxtNome.Text = Row.Nome;
                    TxtCodigo.Text = Row.CodCat;

                }
                else
                {
                    dsProdutos.NovaCategoria();
                }
                
            }
            else if (tipoDadosAtual == TipoDados.Marcas)
            {
                

                TxtCodigo.Visible = false;
                LabelMarca.Visible = true;
                label1.Visible = false;

                if (RowSelecionada != null)
                {
                    var Row = (MarcasRow)RowSelecionada;

                    dsProdutos.PesquisarMarca(Row.Id);

                    TxtCodigo.Text = Row.Id.ToString();
                    TxtNome.Text = Row.Nome;
                }
                else
                {
                    dsProdutos.NovaMarca();
                }
            }

        }
        private bool Verificacao()
        {
            return !string.IsNullOrWhiteSpace(TxtCodigo.Text) &&
                   !string.IsNullOrWhiteSpace(TxtNome.Text);

        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            if (tipoDadosAtual == TipoDados.Categorias)
            {
                dsProdutos.NovaCategoria();
            }
            else
            {
                dsProdutos.NovaMarca();
            }
                LimparCampos();
            HabilitarCampos();

        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tipoDadosAtual == TipoDados.Categorias)
                {
                    CategoriasRow catRow = dsProdutos.Categorias[0];

                    if ((catRow != null) && (Verificacao()))
                    {

                        catRow.CodCat = TxtCodigo.Text;
                        catRow.Nome = TxtNome.Text;
                        dsProdutos.UpdateCategorias();
                       dsProdutos.Categorias.Clear();
                        MessageBox.Show($"Categoria Gravada com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MarcasRow Row = dsProdutos.Marcas[0];

                    if (Row != null)
                    {
                        Row.Nome = TxtNome.Text;
                        dsProdutos.UpdateMarcas();
                       dsProdutos.Marcas.Clear();
                        MessageBox.Show($"Marca Gravada com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                LimparCampos();
                DesabilitarCampos();
            }
            catch (Exception ex)
            {
                if (tipoDadosAtual == TipoDados.Categorias)
                {
                    MessageBox.Show($"Erro ao gravar categoria: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Erro ao gravar Marca: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

            if (TxtCodigo.Text != string.Empty)
            {
                if (tipoDadosAtual == TipoDados.Categorias)
                {
                    dsProdutos.EliminarCat(TxtCodigo.Text);
                }
                else
                {
                    dsProdutos.EliminarMarca(int.Parse(TxtCodigo.Text));
                }
                LimparCampos();
                DesabilitarCampos();
            }
            else
            {
                MessageBox.Show($"Preencha corretammente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void LimparCampos()
        {

            TxtCodigo.Text = string.Empty;
            TxtNome.Text = string.Empty;
        }

        private void DesabilitarCampos()
        {

            TxtCodigo.Enabled = false;
            TxtNome.Enabled = false;
        }
        private void HabilitarCampos()
        {

            TxtCodigo.Enabled = true;
            TxtNome.Enabled = true;
        }


    }
}
