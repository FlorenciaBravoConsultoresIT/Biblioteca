using _02_Negocio;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            string url = ConfigurationManager.AppSettings["pepito"];
            //string url = "www.fabricarg.com";

            List<PaisDTO> listaPaisDTO = this.ConsultarPaises();

            this.CargarPaisesCombobox(listaPaisDTO);
            this.CargarPaisesGrilla(listaPaisDTO);

            foreach (var item in listaPaisDTO)
            {
                lblHola.Text = lblHola.Text + " " + item.Nombre;
            }

        }

        private void CargarPaisesCombobox(List<PaisDTO> listaPaisDTO)
        {
            ddlPaises.Items.Clear();
            ddlPaises.DataSource = listaPaisDTO;
            ddlPaises.DataTextField = "Nombre";
            ddlPaises.DataValueField = "Id";
            ddlPaises.DataBind();

            ddlPaises.Items.Add(new ListItem("Seleccionar", "0", true));
        }

        private void CargarPaisesGrilla(List<PaisDTO> listaPaisDTO)
        {
            grdPrueba.DataSource = listaPaisDTO;
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
            catch(Exception ex)
            {
                //loggear en archivo de log
                lblHola.Text = "OCURRIO UN ERROR";
            }

            return listPaisDTO;
        }

        protected void btnPrueba_Click(object sender, EventArgs e)
        {
            lblBoton.Text = ddlPaises.SelectedValue;
        }
    }
}