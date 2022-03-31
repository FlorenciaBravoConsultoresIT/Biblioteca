using _02_Capa_NEG;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  string url = ConfigurationManager.AppSettings["pepito"];
            //string url = "www.fabricarg.com";

            List<PaisDTO> listaPaisDTO = this.ConsultarPaises();

            this.CargarPaisesCombobox(listaPaisDTO);
           // this.CargarPaisesGrilla(listaPaisDTO);

       //     foreach (var item in listaPaisDTO)
         //   {
           //     lblHola.Text = lblHola.Text + " " + item.Nombre;
           // }

        }

        private void CargarPaisesCombobox(List<PaisDTO> listaPaisDTO)
        {
            ddlPaises.Items.Clear();
            ddlPaises.DataSource = listaPaisDTO;
            ddlPaises.DataTextField = "PAI_Nombre";
            ddlPaises.DataValueField = "PAI_Nombre";
            ddlPaises.DataBind();

            ddlPaises.Items.Add(new ListItem("Seleccionar", "0", true));
        }

        private void CargarAutoresGrilla(List<AutorDTO> listaAutorDTO)
        {
            grdPrueba.DataSource = listaAutorDTO;
            grdPrueba.DataBind();
        }



        private List<PaisDTO> ConsultarPaises()
        {
            List<PaisDTO> listPaisDTO = new List<PaisDTO>();

            try
            {
                PaisBL objPaisBL = new PaisBL();
                listPaisDTO = objPaisBL.ConsultarPaises();
            }
            catch (Exception ex)
            {
                //loggear en archivo de log
                lblHola.Text = "OCURRIO UN ERROR";
            }

            return listPaisDTO;
        }

        private List<AutorDTO> ConsultarAutores(string pais)
        {
            List<AutorDTO> listAUTORDTO = new List<AutorDTO>();

            try
            {
                AutorBL objautor = new AutorBL();
                listAUTORDTO = objautor.ConsultarAutores_x_Pais(pais);
            }
            catch (Exception ex)
            {
                //loggear en archivo de log
                lblHola.Text = "OCURRIO UN ERROR";
            }

            return listAUTORDTO;
        }


        protected void btnPrueba_Click(object sender, EventArgs e)
        {
            List<AutorDTO> listAUTORDTO = ConsultarAutores(ddlPaises.SelectedValue);

         //   lblBoton.Text = ddlPaises.SelectedValue;
            CargarAutoresGrilla(listAUTORDTO);
        }
    }
}
