using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MailServices
{
    class SystemSupportMail : MasterMailServer
    {
        //clase para administrar y enviar correos electronicos del propio sistema

        public SystemSupportMail()
        {
            //normalmente estos datos se obtienen de la Base de datos. 
            senderMail = "cristopher.salgado1997@gmail.com";
            password = "Alexander01";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;

            initializeSmtpClient();
        }

    }
}
