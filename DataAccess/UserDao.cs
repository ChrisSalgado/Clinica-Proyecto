using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common.Cache;

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
                        //mientras el lector lea las filas en la base de datos, agregamos los valores de la fila a los campos de la clase estatica (en la capa common)
                        while (reader.Read())
                        {
                            //se invoca la clase estatica en la capa common con cada uno de los atributos del usuario y luego le almacenamos los valores leídos en la base de datos, uno cada uno
                            UserLoginCache.IdUser = reader.GetInt32(0);//el número es el numero de la casilla en la base de datos {0} hace referencia al Id
                            UserLoginCache.FirstName = reader.GetString(3);//{3} hace referencia al Nombre en la base de datos
                            UserLoginCache.LastName = reader.GetString(4);//{4} hace referencia al Apellido en la base de datos
                            UserLoginCache.Position = reader.GetString(5); //{5} hace referencia a la posicion en la base de datos
                            UserLoginCache.Email = reader.GetString(6); //{6} hace referencia al Email en la base de datos
                            //ahora los valores permanecen en memoria y podemos usarlos en cualquier momento y desde cualquier capa
                            //por ejemplo, para validación y permisos de dominio de usuario en la capa de dominio.
                        }
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
