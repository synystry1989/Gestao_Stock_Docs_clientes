using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TeleBerço.Datasets;
using TeleBerço.Datasets.DsProdutosTableAdapters;
using static TeleBerço.Datasets.DsStock;

namespace TeleBerço
{
    public partial class FrmStock : Form
    {
        public FrmStock()
        {
            InitializeComponent();
        }

        DsProdutos dsProdutos = new DsProdutos();

        DsStock dsStock = new DsStock();

        public DataRow RowSelecionada { get; private set; }
        public string tipoDoc { get; set; } = string.Empty;
        public int nrDoc { get; set; }

        private DataView dataViewStock { get; set; }
        private DataView dataViewMov { get; set; }


        private void FrmStock_Load(object sender, EventArgs e)
        {
            CarregarMovimentos();
            CarregarStockPr();
            ConfigurarControles();
        }
        #region Metodos

        private void ConfigurarControles()
        {
            try
            {
                // Configura os controles de filtro e pesquisa com base no tipo de dados atual
                cbTipoDoc.Items.AddRange(new string[] { "Entrada", "Saida" });
                cbFiltro.Items.Clear();
                cbFiltro.Enabled = true;
                cbOrdenar.Items.Clear();

                StockDgridConfig();
                MovStockDgridConfig();

                cbOrdenar.Items.AddRange(new string[] { "Data", "Tipo" });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro nas configurações iniciais: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CarregarStockPr()
        {

            dsStock.CarregarStockPr();
            AdicionarDetalhesProdutos();
            dataViewStock = new DataView(dsStock.StockPr);
            dGridStock.DataSource = dataViewStock;
        }

        private void CarregarMovimentos()
        {
            dsStock.CarregarMovimentos();
            AdicionarDetalhes();
            dataViewMov = new DataView(dsStock.MovimentacoeStock);
            dgridMovimentos.DataSource = dataViewMov;
        }

        private void StockDgridConfig()
        {
            dGridStock.AutoGenerateColumns = false;
            dGridStock.Columns["Marca"].Visible = false;
            dGridStock.Columns["Categoria"].Visible = false;
            dGridStock.Columns["NomeProduto"].HeaderText = "Produto";
            dGridStock.Columns["CodPr"].HeaderText = "Codigo";
            dGridStock.Columns["NomeMarca"].HeaderText = "Marca";
            dGridStock.Columns["NomeCategoria"].HeaderText = "Categoria";
            dGridStock.Columns["NomeCategoria"].DisplayIndex = 4;
            dGridStock.Columns["NomeProduto"].DisplayIndex = 3;
            dGridStock.Columns["NomeMarca"].DisplayIndex = 1;
            dGridStock.Columns["CodPr"].DisplayIndex = 0;
        }

        private void MovStockDgridConfig()
        {
            
            dgridMovimentos.Columns["MovimentacaoID"].Visible = false;
            dgridMovimentos.Columns["ProdutoID"].Visible = false;
            dgridMovimentos.Columns["DataMovimentacao"].DisplayIndex = 0;
            dgridMovimentos.Columns["NomeProduto"].DisplayIndex = 2;
            dgridMovimentos.Columns["nrDocumnto"].DisplayIndex = 1;
            dgridMovimentos.Columns["DataMovimentacao"].HeaderText = "Data";
            dgridMovimentos.Columns["NomeProduto"].HeaderText = "Produto";
            dgridMovimentos.Columns["nrDocumnto"].HeaderText = "Documento";
        }

        private void StockColorCh()
        {

            foreach (DataGridViewRow row in dGridStock.Rows)
            {
                row.Cells["Quantidade"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                int valor = int.Parse(row.Cells["Quantidade"].Value.ToString());
                if (valor <= 2)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.DefaultCellStyle.SelectionForeColor = Color.Red;
                }

                else if (valor <= 5)
                {
                    row.DefaultCellStyle.ForeColor = Color.Yellow;
                    row.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                }
            }
        }
        private void MovStockColorCh()
        {
            foreach (DataGridViewRow row in dgridMovimentos.Rows)
            {
                string valor = row.Cells["nrDocumnto"].Value.ToString();

                if (!valor.Contains("AM"))
                {
                    var currentFont = dgridMovimentos.Font;
                    row.Cells["nrDocumnto"].Style.Font = new Font(currentFont, FontStyle.Bold);
                }
                string tipo = row.Cells["TipoMovimentacao"].Value.ToString();

                if (tipo == "E")
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                    row.DefaultCellStyle.SelectionForeColor = Color.Green;
                }
                if (tipo == "S")
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.DefaultCellStyle.SelectionForeColor = Color.Red;
                }
            }
        }

        private void AdicionarDetalhesProdutos()
        {
            // Adiciona colunas de Marca e Categoria se não existirem
            try
            {
                foreach (DataRow row in dsStock.StockPr.Rows)
                {
                    // Preenche a coluna Marca
                    if (row["Marca"] != DBNull.Value)
                        row["NomeMarca"] = dsProdutos.DaNomeMarca((int)row["Marca"]);

                    // Preenche a coluna Categoria
                    if (row["Categoria"] != DBNull.Value)
                        row["NomeCategoria"] = dsProdutos.DaNomeCategoria(row["Categoria"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar Marcas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AdicionarDetalhes()
        {
            try
            {
                foreach (DataRow row in dsStock.MovimentacoeStock.Rows)
                {
                    // Preenche a coluna Categoria
                    if (row["ProdutoID"] != DBNull.Value)
                        row["NomeProduto"] = dsProdutos.DaNomeProduto(row["ProdutoID"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar detalhes :"+ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidarPreenchimento()
        {
            return !string.IsNullOrWhiteSpace(TxtCodigo.Text) &&
                               !string.IsNullOrWhiteSpace(TxtQtdExistente.Text) &&
                                !string.IsNullOrWhiteSpace(txtQtd.Text) &&
                                 !string.IsNullOrWhiteSpace(cbTipoDoc.Text);
        }
        #endregion

        #region Funcoes
        private void AplicarFiltroPorDatas(DateTime dataInicio, DateTime dataFim)
        {
            DateTime inicio = dataInicio.Date;
            DateTime inicioDia = inicio.AddDays(1);

            DateTime fim = dataFim.Date;
            DateTime fimDia = fim.AddDays(1);
            // mesma data, hora zero


            dataViewMov.RowFilter = string.Format("{0} >= #{1:MM/dd/yyyy}# AND {0} < #{2:MM/dd/yyyy}#",
                                               "DataMovimentacao", inicioDia, fimDia);

        }

        private void AplicarFiltroPorData(DateTime data)
        {
            DateTime inicioDoDia = data.Date;        // mesma data, hora zero
            DateTime fimDoDia = inicioDoDia.AddDays(1);

            dataViewMov.RowFilter = string.Format("{0} >= #{1:MM/dd/yyyy}# AND {0} < #{2:MM/dd/yyyy}#",
                                                  "DataMovimentacao", inicioDoDia, fimDoDia);
        }

        private void SelecionarLinhaAtual(DataGridView dataGrid)
        {
            try
            {
                if (dataGrid.CurrentRow != null && dataGrid.CurrentRow.DataBoundItem != null)
                {
                    RowSelecionada = ((DataRowView)dataGrid.CurrentRow.DataBoundItem).Row;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void PesquisarProdutos(string termo)
        {
            // Pesquisa em várias colunas
            dataViewStock.RowFilter = $"NomeProduto LIKE '%{termo}%'  OR CodPr LIKE '%{termo}%' ";
        }


        private void AplicarFiltro(string campo, string valor)
        {
           if (campo=="Tipo")
            {campo= "TipoMovimentacao"; }
            dataViewMov.RowFilter = $"{campo}  = '{valor}'";
        }
        #endregion

        #region Logica
        private void dgridMovimentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgridMovimentos.Columns["nrDocumnto"].Index && (!dgridMovimentos.CurrentCell.Value.ToString().Contains("AM")))
         {
                tipoDoc = dgridMovimentos.CurrentCell.Value.ToString().Substring(0, 3);
                nrDoc = int.Parse(dgridMovimentos.CurrentCell.Value.ToString().Substring(3));

                FrmDocumentos frmDocumentos = new FrmDocumentos
                {
                    tipoDoc = tipoDoc,
                    nrDoc = nrDoc
                };
                frmDocumentos.ShowDialog();
            }
        }

        private void cbOrdenar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cbFiltro.Items.Clear();
            btnAplicar.Enabled = true;
            if (cbOrdenar.SelectedItem == null)
            {
                return;
            }
            string campo = cbOrdenar.SelectedItem.ToString();

            if (campo == "Data")
            {
                cbFiltro.Items.AddRange(new string[] { "Dia", "Periodo" }); // Ajuste conforme necessário               
                btnAplicar.Enabled= false;
            }
            else if (campo == "Tipo")
            {
                cbFiltro.Items.AddRange(new string[] { "E", "S" }); // Ajuste conforme necessário
            }
            cbFiltro.Text = "";
            cbFiltro.Enabled = cbFiltro.Items.Count > 0;
        }

        private void cbFiltro_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (cbFiltro.Text == "Dia")
            {
                dateTimePicker2.Visible = true;
                dateTimePicker1.Visible = false;
                label5.Visible = false;
            }
            else if (cbFiltro.Text == "Periodo")
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label5.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                label5.Visible = false;
            }
        }

        private void dGridStock_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = dGridStock.CurrentRow;

            string campo = "NomeProduto";
            string valor = row.Cells["NomeProduto"].Value.ToString();

            AplicarFiltro(campo, valor);
        }

        private void dgridMovimentos_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            MovStockColorCh();
        
        }

        private void dGridStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            StockColorCh();
     

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

        private void cbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFiltro.Items.Clear();

            if (cbOrdenar.SelectedItem == null)
            {
                return;
            }
            string campo = cbOrdenar.SelectedItem.ToString();

            if (campo == "Data")
            {
                cbFiltro.Items.AddRange(new string[] { "Dia", "Periodo" }); // Ajuste conforme necessário               

            }
            else if (campo == "Tipo")
            {
                cbFiltro.Items.AddRange(new string[] { "E", "S" }); // Ajuste conforme necessário
            }
         
            cbFiltro.Enabled = cbFiltro.Items.Count > 0;
        }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltro.Text == "Dia")
            {
                dateTimePicker2.Visible = true;
                dateTimePicker1.Visible = false;    
                label5.Visible = false;
            }
            else if (cbFiltro.Text == "Periodo")
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label5.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                label5.Visible = false;
            }
        }

      
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (txtPesquisa.Text == string.Empty)
            {
                btnRefresh_Click_1(sender, e);
            }
        }
        #endregion

        #region Buttons

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            if (ValidarPreenchimento())
            {
                ArmazemRow stock = dsStock.Armazem[0];

                int valor = int.Parse(txtQtd.Text);

                if (cbTipoDoc.Text == "Entrada")
                {
                    tipoDoc = "AM+";
                }
                else
                {
                    tipoDoc = "AM-";
                }
                stock.ProdutoID = TxtCodigo.Text;

                dsStock.AtualizarStock(stock.ProdutoID, valor, tipoDoc, "");
                btnRefresh_Click_1 (sender, e);
                Limpar();
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
            SelecionarLinhaAtual(dGridStock);
            if (RowSelecionada is StockPrRow row)
            {
                bool novo = false;
                dsStock.PesquisarStock(row.CodPr, ref novo);
                TxtCodigo.Text = dsStock.Armazem[0].ProdutoID;
                TxtQtdExistente.Text = dsStock.Armazem[0].Quantidade.ToString();
                txtQtd.Enabled = true;
                cbTipoDoc.Enabled = true;
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Limpar()
        {
            TxtCodigo.Clear();
            TxtQtdExistente.Clear();
            cbTipoDoc.Text = "";
            txtQtd.Text = "0";
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {

            // Limpa filtros e recarrega os dados
            cbOrdenar.Text = "";
            cbFiltro.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            txtPesquisa.Text = string.Empty;

            CarregarMovimentos();
            CarregarStockPr();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtPesquisa.Text))
            {
                MessageBox.Show("Por favor, insira um termo para pesquisa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PesquisarProdutos(txtPesquisa.Text);


        }

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





        #endregion

    }
    
}

