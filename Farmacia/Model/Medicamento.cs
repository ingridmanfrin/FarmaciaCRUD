using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Model
{
    public class Medicamento : Produto
    {
        private string generico;

        public Medicamento(int id, int tipo, string nome, decimal preco, string generico) : base(id, tipo, nome, preco)
        {
            this.generico = generico;
        }
        public string GetGenerico()
        {
            return this.generico;
        }

        public void SetGenerico(decimal limite)
        {
            this.generico = generico;
        }

        public override void Visualizar()
        {
            base.Visualizar();
            Console.WriteLine($"Nome do Genérico: {this.generico}");
        }
    }
}
