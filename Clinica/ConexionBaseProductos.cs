using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Clinica
{
     class ConexionBaseProductos
    {
        //private readonly string connectionString;

        //public ConexionBaseProductos()
        //{
        //    connectionString = "Server=LAPTOP-1VL3UP2E; DataBase=ClinicaComunal; integrated security= true";
        //}

        //protected SqlConnection GetConnection()
        //{
        //    return new SqlConnection(connectionString);
        //}
        public string server,  db, creden;
        public string cadena;

        public void conec()
        {
            //server = "LAPTOP - 1VL3UP2E";
            //db = "ClinicaComunal";
            cadena = "Data Source=LAPTOP-1VL3UP2E; Initial Catalog = ClinicaComunal; Integrated Security = True";
        }


    }
}
