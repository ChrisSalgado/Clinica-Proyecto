using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    //hacemos la clase de tipo abstracta para que no sea instanciada
    public abstract class ConnectionToSql
    {
        //permitimos que la variable solo de lectura y privada
        private readonly string connectionString;
        //metodo para identificar a la base de datos, servidor y las credenciales de windows

        public ConnectionToSql()
        {
            connectionString = "Server=LAPTOP-1VL3UP2E; DataBase=clinicaP; integrated security= true";
        }

        //metodo para obtener la conexión
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
