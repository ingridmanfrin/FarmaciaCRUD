using Farmacia.Model;
using Farmacia.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Farmacia.Controller
{
    public class ProdutoController : IProdutoRepository
    {
        private readonly List<Produto> listaProdutos = new();
        int id = 0;
        public void AtualizarProduto(Produto produto)
        {
            var buscaProduto = BuscarNaCollection(produto.GetId());
            if(buscaProduto != null )
            {
                var index = listaProdutos.IndexOf(buscaProduto);
                listaProdutos[index] = produto;
                Console.WriteLine($"O Produto de código {produto.GetId()} foi atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine($"O Produto de código {produto.GetId()} não foi encontrado!");
            }
        }

        public void ConsultarProdutoPorId(int id)
        {
            var produto = BuscarNaCollection(id);

            if (produto is not null)
            {
                produto.Visualizar();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"O Produto de código {id} não foi encontrado!");
                Console.ResetColor();
            }
        }

        public void CriarProduto(Produto produto)
        {
            listaProdutos.Add(produto);
            Console.WriteLine($"O Produto de código {produto.GetId()} foi criado com sucesso!");
        }

        public void DeletarProduto(int id)
        {
            var produto = BuscarNaCollection(id);

            if (produto != null)
            {
                if (listaProdutos.Remove(produto) == true)
                {
                    Console.WriteLine($"O Produto de código {id} foi apagado com sucesso!");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"O Produto de código {id} não foi encontrado!");
                Console.ResetColor();
            }
        }

        public void ListarProdutos()
        {
            foreach (var produto in listaProdutos)
            {
                produto.Visualizar();
            }
        }

        public int GerarId()
        {
            return ++id;
        }

        public Produto? BuscarNaCollection(int id)
        {
            foreach (var produto in listaProdutos)
            {
                if (produto.GetId() == id)
                {
                    return produto;
                }
            }
            return null;
        }
    }
}

