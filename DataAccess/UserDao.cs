using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    //heredamos de la clase conexión
    public class UserDao:ConnectionToSql
    {
        //Login de tipo booleano para retornar un valor (entro o no)
        public bool Login(string user, string pass)
        {
            //no necesitamos cerrar la conexión gracias al bloque "using" el cual garantiza llamar los metodos
            //desechables
            using (var connection = GetConnection())
            {
                //abrimos la conexión
                connection.Open();
                //declaramos variable comando para almacenar los comandos de sql como por ejemplo la conexión
                // y la sentencia SQL
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from users where LoginName=@user and password = @pass";
                    //parametrización de datos, declaramos el parametro + el atributo que recibe el método
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    //especificamos el tipo de comando
                    command.CommandType = CommandType.Text; //significará que lo que recibe es un texto
                    //declaramos el sqlDataReado que será igual al executeReader del comando
                    SqlDataReader reader = command.ExecuteReader();

                    //si el lector tiene filas retornamos true, o sea, la consulta fue exitosa
                    if (reader.HasRows)
                    {
                        return true;
                    }else
                    {
                        return false; //si retorna false es porque la consulta no existe
                        
                    }



                }
            }
        }
    }
}
