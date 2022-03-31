using _01_Capa_DAT;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Capa_NEG
{
    public class AutorBL
    {
        public AutorBL()
        {
        }

        public List<AutorDTO> ConsultarAutores_x_Pais()
        {

            AutorDAO objAutor_x_PaisDAO = new AutorDAO();

            List<AutorDTO> listaAutor_x_PaisDTO = objAutor_x_PaisDAO.ConsultarAutor_X_Pais();
            //No deberia de pasarle el dato en duro

            return listaAutor_x_PaisDTO;

        }
    }
}
