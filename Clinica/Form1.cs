using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Domain;

namespace Presentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            if(TxtUsuario.Text == "USUARIO")
            {
                TxtUsuario.Text = "";
                TxtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            if(TxtUsuario.Text == "")
            {
                TxtUsuario.Text = "USUARIO";
                TxtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if(txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if(txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (TxtUsuario.Text != "USUARIO")
            {
                if (txtContraseña.Text != "CONTRASEÑA")
                {
                    //si los campos no estan vacios, instanciamos 
                    //al modelo usuario de la capa de dominio.
                    UserModel user = new UserModel();
                    //DECLARAMOS UNA VARIABLE IMPLICITA DE NOMBRE LOGINVALIDO

                    var validLogin = user.LoginUser(TxtUsuario.Text, txtContraseña.Text); //asignamos como valor el resultado que retorna el metodo de iniciar sesión de la capa de dominio
                      //si el inicio de sesión es verdadero, instanciamos al formulario que queremos ir  
                    if (validLogin == true)
                    {
                        FrmPrincipal mainMenu = new FrmPrincipal();
                        mainMenu.Show();
                        this.Hide();
                    }else
                    {
                        msgError("Usuario o contraseña incorrectos. \n Prueba otra vez.");
                        txtContraseña.Clear();
                        TxtUsuario.Focus();
                    }





                }else
                {
                    msgError("Porfavor, ingrese una contraseña");
                }
            }else
            {
                msgError("¡Por favor, digite un usuario!");
            }
        }

        //metodo para mostrar un mensaje de error por si los cuadros de texto quedan vacios
        private void msgError(string msg)
        {
            lblErrorMessage.Text = "" + msg;
            lblErrorMessage.Visible = true;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
