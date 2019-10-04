using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Clinica;

namespace Clinica
{
    public partial class frmInventario : Presentacion.frmPrincipal
    {
        public frmInventario()
        {
            InitializeComponent();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarInventario(object sender, KeyPressEventArgs e)
        {
            //para que solo acepte caracteres Alfabeticos
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
                ErroPv.Clear();
            }
            //para el backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                ErroPv.Clear();
            }
            //para admita la tecla espacio
            if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
                ErroPv.Clear();
            }
            //si no cumple nada de lo anterior que no lo deje pasar
            else
            {
                e.Handled = true;
                ErroPv.SetError(txtBuscar, "Solo se admiten caracteres alfabeticos");
            }
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {

        }

        private void BtnBuscarInventario_Click(object sender, EventArgs e)
        {

        }
    }
}
