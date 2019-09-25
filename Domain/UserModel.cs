using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess; //importamos la capa de acceso a datos

namespace Domain
{
    public class UserModel
    {
        //instanciamos el objeto de acceso a datos de usuario
        UserDao userDao = new UserDao();
        //iniciamos un metodo booleano de nombre inicio de sesión de usuario
        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }
    }
}
