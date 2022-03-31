using _01_Datos;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Negocio
{
    public class PaisBL
    {
        public PaisBL()
        {
        }

        public List<PaisDTO> ConsultarPaises()
        {

            PaisDAO objPaisDAO = new PaisDAO();

            List<PaisDTO> listaPaisDTO = objPaisDAO.ConsultarPaisesBase();
            //No deberia de pasarle el dato en duro

            return listaPaisDTO;

        }

    }
}


