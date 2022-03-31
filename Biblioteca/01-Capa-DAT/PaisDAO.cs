using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Capa_DAT
{
    public class PaisDAO
    {
        public List<PaisDTO> ConsultarPaisesBase()
        {
            List<PaisDTO> resultado = new List<PaisDTO>();

            string connectionString = ConfigurationManager.ConnectionStrings["Capacitacion"].ToString();

            using (SqlConnection objSqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand objSqlCommand = new SqlCommand())
                {
                    //consulta base de datos
                    objSqlCommand.Parameters.Clear();
                    objSqlCommand.CommandType = CommandType.StoredProcedure;
                    //tengo que modificar aca
                    objSqlCommand.CommandText = "SP_Pais";
             //       objSqlCommand.CommandTimeout = 30;
                    objSqlCommand.Connection = objSqlConnection;

                    System.Data.DataSet respuestaDS = new DataSet();
                    using (SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand))
                    {
                        objSqlDataAdapter.Fill(respuestaDS);
                    }

                    //mapeo de resultados
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<DataRow, PaisDTO>()
                        .ForMember(dest => dest.PAI_Nombre, opts => opts.MapFrom(src => src["PAI_Nombre"]))
                    );

                    resultado = config.CreateMapper().Map<List<PaisDTO>>(respuestaDS.Tables[0].Rows);
                }
            }
            return resultado;
        }       
    }
}
