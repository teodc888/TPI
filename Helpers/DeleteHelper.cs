using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP.Interface;

namespace TIP.Helpers
{
    public class DeleteHelper
    {
        private readonly string conexionString;
        public DeleteHelper() 
        { 
            conexionString= string.Empty;
        }


        public T delete<T>(string query) where T : IEntidad, new()
        {
            T entidad = new T();

            using (SqlConnection cnn = new SqlConnection(conexionString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                int filasAfectadas = cmd.ExecuteNonQuery();
                cnn.Close();
            }

            return entidad;
        }
    }
}
