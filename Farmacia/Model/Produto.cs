using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Farmacia.Model
{
    public abstract class Produto
    {
        private int id, tipo;
        private string nome;
        private decimal preco;

        public Produto(int id, int tipo, string nome, decimal preco)
        {
            this.id = id;
            this.tipo = tipo;
            this.nome = nome;
            this.preco = preco;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetTipo()
        {
            return tipo;
        }

        public void SetTipo(int tipo)
        {
            this.tipo = tipo;
        }

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public decimal GetPreco() 
        { 
            return preco;
        }

        public void SetPreco(decimal preco)
        {
            this.preco = preco;
        }

        public virtual void Visualizar()
        {
            string tipo = "";  //mesma coisa seria por: string tipo= string.empty;

            switch (this.tipo)
            {
                case 1:
                    tipo = "Cosmético";
                    break;
                case 2:
                    tipo = "Medicamento";
                    break;
            }

            Console.WriteLine("**************************************************");
            Console.WriteLine("Dados do Produto");
            Console.WriteLine("**************************************************");
            Console.WriteLine($"Id do Produto: {this.id}");
            Console.WriteLine($"Tipo do Produto: {tipo}"); ///pode ser cosmetico ou medicamento
            Console.WriteLine($"Nome do Produto: {this.nome}");
            Console.WriteLine($"Preço do Produto: {(this.preco).ToString("C")}");
        }
    }
}
