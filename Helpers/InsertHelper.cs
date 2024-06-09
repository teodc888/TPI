using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP.Interface;
using TIP.Properties;

namespace TIP.Helpers
{
    public class InsertHelper
    {
        private readonly string conexionString;
        public InsertHelper()
        {
            conexionString = "";
        }

        public T ConsultarEntidadPorId<T>(string query, string idFieldName, int id) where T : IEntidad, new()
        {
            T entidad = new T();

            using (SqlConnection cnn = new SqlConnection(conexionString))
            {
                cnn.Open();
                string queryWithId = $"{query} WHERE {idFieldName} = @id";
                SqlCommand cmd = new SqlCommand(queryWithId, cnn);
                cmd.Parameters.AddWithValue("@id", id);

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
