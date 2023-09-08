using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Model
{
    public class Cosmetico : Produto
    {
        private string fragancia;

        public Cosmetico(int id, int tipo, string nome, decimal preco, string fragancia) : base(id, tipo, nome, preco)
        {
            this.fragancia = fragancia;
        }
        public string GetFragancia()
        {
            return this.fragancia;
        }

        public void SetFragancia(decimal limite)
        {
            this.fragancia = fragancia;
        }

        public override void Visualizar()
        {
            base.Visualizar();
            Console.WriteLine($"Fragância do Produto: {this.fragancia}");
        }
    }
}
