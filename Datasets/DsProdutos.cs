using TeleBerço.Datasets.DsProdutosTableAdapters;

namespace TeleBerço.Datasets
{

    partial class DsProdutos
    {


        MarcasTableAdapter MarcasTableAdapter = new MarcasTableAdapter();
        ProdutosTableAdapter adpArtigos = new ProdutosTableAdapter();
        CategoriasTableAdapter CategoriasTableAdapter = new CategoriasTableAdapter();

        public void CarregaArtigos()
        {
            Produtos.Clear();
            adpArtigos.Fill(Produtos);
        }
        public void UpdateArtigos()
        {
            adpArtigos.Update(Produtos);
        }

        public void CarregarMarcas()
        {
            Marcas.Clear();
            MarcasTableAdapter.Fill(Marcas);
        }

        public void UpdateMarcas()
        {
            MarcasTableAdapter.Update(Marcas);
        }
        public void CarregaCategorias()
        {
            Categorias.Clear();
            CategoriasTableAdapter.Fill(Categorias);
        }

        public void UpdateCategorias()
        {
            CategoriasTableAdapter.Update(Categorias);
        }

        public string DaNomeCategoria(string cod)
        {
           return CategoriasTableAdapter.NomeCategoria(cod);
        }

        public string DaNomeMarca(int id)
        {
            return MarcasTableAdapter.NomeMarca(id);
        }

        public string DaNomeProduto(string cod)
        {
            return adpArtigos.NomeProduto(cod);
        }

        public string DaUltimoCodArtigo()
        {
            return adpArtigos.UltmCodPr();
        }

        public void NovoArtigo()
        {
            if (Produtos.Rows.Count == 0)
            {
                ProdutosRow novoArtigo = Produtos.NewProdutosRow();

                novoArtigo.CodPr = DaProxCodArtigo();
                novoArtigo.NomeProduto = "";
                novoArtigo.Observacao = "";
                novoArtigo.PrecoCusto = 0;
                novoArtigo.PreçoVenda = 0;
                novoArtigo.Categorias = "";
                novoArtigo.IMEI = "";
                novoArtigo.Marcas = 0;
                novoArtigo.Marca = "";
                novoArtigo.Categoria = "";
                novoArtigo.Tipo = "";
                Produtos.Rows.Add(novoArtigo);
            }
        }
        public ProdutosRow PesquisarArtigo(string codArtigo)
        {
            adpArtigos.FillByCodPr(Produtos, codArtigo);

            if (Produtos.Rows.Count > 0)
            {
                return Produtos[0];
            }
            else
            {
                NovoArtigo();
                return Produtos[0];
            }
        }

        public CategoriasRow PesquisarCat(string codCat)
        {
            CategoriasTableAdapter.FillByCodCat(Categorias, codCat);

            if (Produtos.Rows.Count > 0)
            {
                return Categorias[0];
            }
            else
            {
                NovaCategoria();
                return Categorias[0];
            }
        }

        public MarcasRow PesquisarMarca(int id)
        {
            MarcasTableAdapter.FillByMarca(Marcas, id);

            if (Produtos.Rows.Count > 0)
            {
                return Marcas[0];
            }
            else
            {
                NovaMarca();
                return Marcas[0];
            }
        }

        public string DaProxCodArtigo()
        {

            string codCl = DaUltimoCodArtigo();
            int valor = 0;
            if (codCl == null)
            {
                valor = 001;
                return $"PR{valor:000}";
            }
            else
            {
                //retiramos o CL ao cod incrementamos e voltamos a concatenar
                valor = int.Parse(codCl.Substring(2));
                valor++;
                return $"PR{valor:000}";
            }
        }

        public void NovaMarca()
        {
            if (Marcas.Rows.Count == 0)
            {
                MarcasRow marcasRow = Marcas.NewMarcasRow();

                marcasRow.Nome = "";

                Marcas.Rows.Add(marcasRow);
            }
        }

        public void NovaCategoria()
        {
            if (Categorias.Rows.Count == 0)
            {
                CategoriasRow catRow = Categorias.NewCategoriasRow();

                catRow.CodCat = "";
                catRow.Nome = "";

                Categorias.Rows.Add(catRow);
            }
        }
        public void EliminarPr(string id)
        {
            ProdutosRow linhaSelecionada = Produtos.FindByCodPr(id);
            if (linhaSelecionada.CodPr != "PR000")
            {
                linhaSelecionada?.Delete();
                UpdateArtigos();
            }
          
        }

        public void EliminarCat(string id)
        {
            CarregaCategorias();
            CategoriasRow linhaSelecionada = Categorias.FindByCodCat(id);
            if(linhaSelecionada.CodCat!="N/A")
            {
                linhaSelecionada?.Delete();
                UpdateCategorias();
            }
          
        }
        public void EliminarMarca(int id)
        {
            CarregarMarcas();
            MarcasRow linhaSelecionada = Marcas.FindById(id);
            if (linhaSelecionada.Nome != "N/A")
            {
                linhaSelecionada?.Delete();
                UpdateMarcas();
            }
        }


    }
}
