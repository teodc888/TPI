using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP.Interface;

namespace TIP.Models
{
    public class Tarea : IEntidad
    {
        public int CodTarea { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FecInicio { get; set; }
        public DateTime FecVto { get; set; }
        public string Prioridad { get; set; }
        public int CodEstado { get; set; }
        public string HrasTrabajadas { get; set; }
        public string EstimacionHoras { get; set; }
        public int CodPrioridad { get; set; }

        public void Mapear(SqlDataReader reader)
        {
            CodTarea = reader.GetInt32(reader.GetOrdinal("CodTarea"));
            Nombre = reader.GetString(reader.GetOrdinal("Nombre"));
            Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"));
            FecInicio = reader.GetDateTime(reader.GetOrdinal("FecInicio"));
            FecVto = reader.GetDateTime(reader.GetOrdinal("FecVto"));
            Prioridad = reader.GetString(reader.GetOrdinal("Prioridad"));
            CodEstado = reader.GetInt32(reader.GetOrdinal("CodEstado"));
            HrasTrabajadas = reader.GetString(reader.GetOrdinal("HrasTrabajadas"));
            EstimacionHoras = reader.GetString(reader.GetOrdinal("EstimacionHoras"));
            CodPrioridad = reader.GetInt32(reader.GetOrdinal("CodPrioridad"));
        }
    }
}
