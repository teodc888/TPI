using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP.Interface;

namespace TIP.Helpers
{
    public class SelectHelper
    {
        private readonly string conexionString;
        public SelectHelper() 
        {
            conexionString= string.Empty;
        }


        public T ConsultarEntidad<T>(string query) where T : IEntidad, new()
        {
            T entidad = new T();

            using (SqlConnection cnn = new SqlConnection(conexionString))
            {
                cnn.Open();              
                SqlCommand cmd = new SqlCommand(query, cnn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        entidad.Mapear(reader);
                    }
                }
            }

            return entidad;
        }
    }
}
