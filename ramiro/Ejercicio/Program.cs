using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Ejercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero;
            numero = 4;
            string palabra = "holaa";
            Console.WriteLine(palabra);

            Persona objPersona;
            objPersona = new Persona();
            objPersona.ConfigurarId(1);
            objPersona.ConfigurarNombre("juan");

            objPersona.Identificador = 2;
            objPersona.NombrePersona = "juan2";
            string nombre = objPersona.NombrePersona;
            objPersona.Apellido = "perez";

            objPersona.Direccion = new Direccion();
            objPersona.Direccion.Calle = "colon";
            objPersona.Direccion.Numero = 111;

            Direccion objDireccion = new Direccion();
            objDireccion.Calle = "dddd";
            objDireccion.Numero = 222;

            objPersona.Direccion = objDireccion;

            Direccion objdireccion2 = new Direccion("dean funes", 22);

            Direccion objdireccion3 = new Direccion()
            {
                Calle = "cccc",
                Numero = 222
            };

            Direccion objDireccion4 = new Direccion("colon", 444, 3);
            objDireccion4.ConfigurarNumeroDepto(7);

            Persona objPersona2 = new Persona();

            List<int> listaNumero;
            listaNumero = new List<int>();
            listaNumero.Add(4);
            listaNumero.Add(7);

            int sumaNumero = Persona.Suma(2, 3);

            Console.WriteLine("Hola mundo");
            System.Threading.Thread.Sleep(5000);
        }
    }
}
