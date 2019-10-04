using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinica;


using System.Runtime.InteropServices;
using Domain;
using Common.Cache;
using Clinica;



namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            LoadUserData(); 
        }
        private void LoadUserData()
        {
            lblNombre.Text = UserLoginCache.FirstName + ", " + UserLoginCache.LastName;
            lblPosicion.Text = UserLoginCache.Position;
            lblCorreo.Text = UserLoginCache.Email;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Estas seguro de Cerrar Sesión?", "WARNING",MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
                
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmLogin());
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
            {
                activeForm.Close();
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelChildForm.Controls.Add(childForm);
                childForm.BringToFront();
                childForm.Show();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, EventArgs e)

        {

        }



        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelChildForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }


        private void BtnInventario_Click(object sender, EventArgs e)
        {
            
        private void BtnEditar_Click(object sender, EventArgs e)
        {

        }

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            frmInventario verfrmInventario = new frmInventario();
            verfrmInventario.Show();
            this.Hide();

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
        }


            frmAgregar verfrmAgregar = new frmAgregar();
            verfrmAgregar.Show();
            this.Hide();
        }

    }

}
