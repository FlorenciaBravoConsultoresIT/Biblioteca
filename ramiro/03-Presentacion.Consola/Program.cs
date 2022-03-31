using _02_Negocio;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Presentacion.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            PaisBL objPaisBL = new PaisBL();

            List<PaisDTO> listaPaisDTO = objPaisBL.ConsultarPaises("America");

            foreach (var item in listaPaisDTO)
            {
                Console.WriteLine("Pais: " + item.Nombre);
            }

            List<PaisDTO> listaPaisDTO2 = objPaisBL.ConsultarPaises();

            foreach (var item in listaPaisDTO2)
            {
                Console.WriteLine("Pais Todos: " + item.Nombre);
            }

            string jsonString = JsonConvert.SerializeObject(listaPaisDTO2);
            Console.WriteLine(jsonString);

            List<PaisDTO> listaPaisDTOJsonDes = JsonConvert.DeserializeObject<List<PaisDTO>>(jsonString);

            Thread.Sleep(10000);
        }
    }
}
