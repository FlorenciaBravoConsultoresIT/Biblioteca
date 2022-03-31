using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Persona
    {
        public Persona()
        {
            this.nombre = "juancito";
        }

        private int Id;
        private string nombre;

        public int Identificador
        {
            get
            {
                return this.Id;
            }
            set
            {
                this.Id = value;
            }
        }

        public string NombrePersona
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellido { get; set; }

        public Direccion Direccion { get; set; }

        public void ConfigurarNombre(string nombrePersona)
        {
            this.nombre = nombrePersona;
        }

        public void ConfigurarId(int identificador)
        {
            this.Id = identificador;
        }

        public int ConsultarId()
        {
            return this.Id;
        }

        public string ConsultarNombre()
        {
            return this.nombre;
        }

        public static int Suma(int numero1, int numero2)
        {
            return numero1 + numero2;
        }
    }
}
