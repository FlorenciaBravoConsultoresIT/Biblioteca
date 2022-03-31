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
    public class AutorDAO
    {
        public List<AutorDTO> ConsultarAutor_X_Pais(string nombre)
        {
            List<AutorDTO> resultado = new List<AutorDTO>();

            string connectionString = ConfigurationManager.ConnectionStrings["Capacitacion"].ToString();

            using (SqlConnection objSqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand objSqlCommand = new SqlCommand())
                {
                    //consulta base de datos
                    objSqlCommand.Parameters.Clear();
                    objSqlCommand.CommandType = CommandType.StoredProcedure;
                    //que deberia de ir aca
                    objSqlCommand.CommandText = "SP_Autores_x_Pais";
                    objSqlCommand.Parameters.Add("@TAP", SqlDbType.VarChar).Value = nombre;
                    objSqlCommand.CommandTimeout = 30;
                    objSqlCommand.Connection = objSqlConnection;

                    System.Data.DataSet respuestaDS = new DataSet();
                    using (SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand))
                    {
                        objSqlDataAdapter.Fill(respuestaDS);
                    }

                    //mapeo de resultados
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<DataRow, AutorDTO>()
                        .ForMember(dest => dest.AUT_Nombre, opts => opts.MapFrom(src => src["AUT_Nombre"]))
                        .ForMember(dest => dest.AUT_Apellido, opts => opts.MapFrom(src => src["AUT_Apellido"]))
                    );

                    resultado = config.CreateMapper().Map<List<AutorDTO>>(respuestaDS.Tables[0].Rows);
                }
            }
            return resultado;
        }
    }
}
