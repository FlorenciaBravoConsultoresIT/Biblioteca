using _01_Capa_DAT;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Capa_NEG
{
    public class PaisBL
    {
        public PaisBL()
        {
        }

        public List<PaisDTO> ConsultarPaises(string continente = "")
        {
            try
            {
                PaisDAO objPaisDAO = new PaisDAO();

                List<PaisDTO> listaPaisDTO = objPaisDAO.ConsultarPaisesBase();

             //   if (!String.IsNullOrEmpty(continente))
               // {
                // //   return listaPaisDTO.Where(x => x.Continente.Equals(continente)).ToList();
//}
          //      else
            //    {
                    return listaPaisDTO;
              //  }
            }
            catch (Exception ex)
            {
                //loggear en un archivo
                throw ex;
            }
        }
    }
}
