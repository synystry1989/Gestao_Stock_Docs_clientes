using System;
using System.Windows.Forms;
using TeleBerço.Datasets.DsStockTableAdapters;

namespace TeleBerço.Datasets
{

    partial class DsStock
    {
        ArmazemTableAdapter armazemTableAdapter = new ArmazemTableAdapter();
        MovimentacoeStockTableAdapter movimentacoeStockTableAdapter = new MovimentacoeStockTableAdapter();
        StockPrTableAdapter stockPrTableAdapter = new StockPrTableAdapter();
        movStockQuerryAdapter movStockQuerryAdapter = new movStockQuerryAdapter();
        DsProdutos dsProdutos = new DsProdutos();

        public void CarregarStockPr()
        {
            StockPr.Clear();

            stockPrTableAdapter.FillPr_Stock(StockPr);
        }

        public void CarregarMovimentos()
        {
            MovimentacoeStock.Clear();
            movimentacoeStockTableAdapter.Fill(MovimentacoeStock);
        }

        public void UpdateStock()
        {
            armazemTableAdapter.Update(Armazem);
        }

        public void UpdateMovimentos()
        {
            movimentacoeStockTableAdapter.Update(MovimentacoeStock);
        }

        public void NovoStockRow(string produto)
        {
            var stock = Armazem.NewArmazemRow();

            stock.ProdutoID = produto;
            stock.Quantidade = 0;
            Armazem.AddArmazemRow(stock);
        }

        public void NovoMovimentoRow()
        {
            var movimento = MovimentacoeStock.NewMovimentacoeStockRow();

            movimento.ProdutoID = "";
            movimento.DataMovimentacao = DateTime.Now.Date;
            movimento.Quantidade = 0;
            movimento.TipoMovimentacao = "";
            movimento.NomeProduto = "";
            movimento.nrDocumnto = "";
            MovimentacoeStock.AddMovimentacoeStockRow(movimento);
        }


        public void EliminarMov(string prd)
        {

            movimentacoeStockTableAdapter.FillByProduto(MovimentacoeStock, prd);

            foreach (MovimentacoeStockRow mov in MovimentacoeStock.Rows)
            {
                mov.Delete();

            }
            UpdateMovimentos();

        }

        public ArmazemRow PesquisarStock(string produto, ref bool pr)
        {
            Armazem.Clear();
            armazemTableAdapter.FillByProdutoId(Armazem, produto);

            if (Armazem.Rows.Count > 0)
            {
                pr = false;
                return Armazem[0];
            }
            else
            {
                NovoStockRow(produto);
                pr = true;
                return Armazem[0];
            }
        }

        public void EliminarStock(string id)
        {
            try
            {
                bool novo = false;
                ArmazemRow linhaSelecionada = PesquisarStock(id, ref novo);
                linhaSelecionada.Delete();
                UpdateStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registo nao encontrado: " + ex.Message);
            }

        }


        public void AtualizarStock(string produtoID, int quantidade, string tipoDocumento, string nrDoc)
        {
            // Encontrar o registro do produto no estoque
            ArmazemRow stockRow = Armazem[0];

            string tipoEntrada = "";
            int ajusteQuantidade = 0;
            DateTime data = DateTime.Now;

            if (stockRow.ProdutoID == produtoID)
            {

                if ((tipoDocumento.Contains("FTC")) || (tipoDocumento.Contains("NDF")))
                {
                    // Para vendas e devoluções ao fornecedor, diminuir o estoque
                    ajusteQuantidade = -quantidade;
                    tipoEntrada = "S";
                }
                else if (tipoDocumento.Contains("NDC"))
                {
                    // Para compras e devoluções de clientes, aumentar o estoque
                    ajusteQuantidade = quantidade;
                    tipoEntrada = "E";
                }


                // Atualizar a quantidade no estoque

                if (tipoDocumento == "AM+")
                {
                    tipoEntrada = "E";
                    ajusteQuantidade = quantidade;
                    nrDoc = "AMN";

                }
                else if (tipoDocumento == "AM-")
                {
                    tipoEntrada = "S";
                    ajusteQuantidade = -quantidade;
                    nrDoc = "AMN";
                }

                stockRow.Quantidade += ajusteQuantidade;
                // Verificar se a quantidade não ficou negativa
                if (stockRow.Quantidade < 0)
                {
                    MessageBox.Show($"stock insuficiente para o produto {produtoID}.");

                    stockRow.Quantidade = 0; // Ajustar para zero para evitar estoque negativo
                }
                if (quantidade > 0)
                {
                    RegistrarMovimentacao(stockRow.ProdutoID, quantidade, tipoEntrada, data, nrDoc);
                }
                MessageBox.Show($"Stock atualizdo com sucesso! {produtoID}.");
                UpdateStock();
            }


        }
        public void RegistrarMovimentacao(string produtoID, int quantidade, string tipoMovimento, DateTime date, string nrDoc)
        {
            MovimentacoeStock.Clear();
            NovoMovimentoRow();

            MovimentacoeStockRow novaMovimentacao = MovimentacoeStock[0];

            novaMovimentacao.ProdutoID = produtoID;
            novaMovimentacao.Quantidade = quantidade;
            novaMovimentacao.TipoMovimentacao = tipoMovimento; // 'E' para entrada, 'S' para saída
            novaMovimentacao.NomeProduto = dsProdutos.DaNomeProduto(produtoID);
            novaMovimentacao.DataMovimentacao = date;
            novaMovimentacao.nrDocumnto = nrDoc;

            UpdateMovimentos();
        }


    }
}


