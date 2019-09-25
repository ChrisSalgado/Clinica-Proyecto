using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        //creamos un metodo para cargar el usuario 
        private void LoadUserData()
        {
            //el valor capturado en los atributos de la clase UserLoginCache de la capa common, se le asignan al Label correspondiente
            //DE ESTA MANERA PODEMOS TENER ESTOS CAMPOS DE CUALQUIER FORMULARIO O CAPA SIN LA NECESIDAD DE PASAR POR
            //PARAMETROS (ASI EVITAMOS PASAR EL ID POR PARAMETROS DE METODOS O CONSTRUCTORES) ESTO LA FORMA DE TENER SEGURIDAD POR METODO DE CAPAS

            lblNombre.Text = UserLoginCache.FirstName + ", " + UserLoginCache.LastName;
            lblPosicion.Text = UserLoginCache.Position;
            lblCorreo.Text = UserLoginCache.Email;

        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro/a de querer cerrar Sesión?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }
    }
}
