using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Direccion
    {
        private int numeroDepto;

        public Direccion(string calle, int numero)
        {
            this.Calle = calle;
            this.Numero = numero;
        }

        public Direccion(string calle, int numero, int numeroDepto)
        {
            this.Calle = calle;
            this.Numero = numero;
            this.numeroDepto = numeroDepto;
        }

        public Direccion()
        {
        }

        public string Calle { get; set; }
        public int Numero { get; set; }

        public void ConfigurarNumeroDepto(int numero)
        {
            this.numeroDepto = numero;
        }
    }
}
