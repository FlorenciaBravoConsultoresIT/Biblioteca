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

namespace _01_Datos
{
    public class PaisDAO
    {
        public List<PaisDTO> ConsultarPaises()
        {
            List<PaisDTO> paises = new List<PaisDTO>();

            paises.Add(new PaisDTO() { Id = 1, Nombre = "Argentina", Continente = "America" });
            paises.Add(new PaisDTO() { Id = 2, Nombre = "Chile", Continente = "America" });
            paises.Add(new PaisDTO() { Id = 2, Nombre = "Francia", Continente = "Europa" });

            return paises;
        }

        public List<PaisDTO> ConsultarPaisesBase(int? idPais = null)
        {
            List<PaisDTO> resultado = new List<PaisDTO>();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Capacitacion"].ToString();

                using (SqlConnection objSqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand objSqlCommand = new SqlCommand())
                    {
                        //consulta base de datos
                        objSqlCommand.Parameters.Clear();
                        objSqlCommand.CommandType = CommandType.StoredProcedure;
                        objSqlCommand.CommandText = "SP_Pais";
                        objSqlCommand.Parameters.Add("@idPais", SqlDbType.Int).Value = idPais;
                        objSqlCommand.CommandTimeout = 30;
                        objSqlCommand.Connection = objSqlConnection;

                        System.Data.DataSet respuestaDS = new DataSet();
                        using (SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand))
                        {
                            objSqlDataAdapter.Fill(respuestaDS);
                        }

                        //mapeo de resultados
                        var config = new MapperConfiguration(cfg => cfg.CreateMap<DataRow, PaisDTO>()
                            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src["idPais"]))
                            .ForMember(dest => dest.Nombre, opts => opts.MapFrom(src => src["nombre"]))
                            .ForMember(dest => dest.Continente, opts => opts.MapFrom(src => src["continente"]))
                        );

                        resultado = config.CreateMapper().Map<List<PaisDTO>>(respuestaDS.Tables[0].Rows);
                    }
                }
            }
            catch (Exception ex)
            {
                string valor = "error";

                throw ex;
            }

            return resultado;
        }

    }
}
