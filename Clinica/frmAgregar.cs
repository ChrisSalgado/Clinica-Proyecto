using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica
{
    public partial class frmAgregar : Presentacion.frmPrincipal
    {

        private SqlConnection conn;
        private SqlCommand Insert_A;
        private string sCn;


        public frmAgregar()
        {
            InitializeComponent();

            ConexionBaseProductos cn = new ConexionBaseProductos();
            cn.conec();
            sCn = cn.cadena;
            conn = new SqlConnection(sCn);
            conn.Open();
        }

        private void FrmAgregar_Load(object sender, EventArgs e)
        {
            CategoriaProducto();
            TipoProducto();
        }


        public void CategoriaProducto()
        {
            cmbCategoriaProducto.Items.Add("Ginecologia");
            cmbCategoriaProducto.Items.Add("Odontologia");
            cmbCategoriaProducto.Items.Add("General");
            cmbCategoriaProducto.SelectedText.ToString();
            

        }

        public void TipoProducto()
        {
            cmbTipoProducto.Items.Add("Analgesicos");
            cmbTipoProducto.Items.Add("Antiácidos");
            cmbTipoProducto.Items.Add("antiulcerosos");
            cmbTipoProducto.Items.Add("Antialérgicos");
            cmbTipoProducto.Items.Add("Antidiarreicos");
            cmbTipoProducto.Items.Add("laxantes");
            cmbTipoProducto.Items.Add("Antiinfecciosos");
            cmbTipoProducto.Items.Add("Antiinflamatorios");
            cmbTipoProducto.Items.Add("Antipiréticos");
            cmbTipoProducto.Items.Add("Antitusivos");
            cmbTipoProducto.Items.Add("mucolíticos");
           
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnGuardaryAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string InsertarMedicamentos;

                

                InsertarMedicamentos = "insert into Medicamentos(NombreMedicamento, CodCategoria, IdCantidad, Descripcion, Ubicacion, Fecha_Ingreso, Codtipo, Fecha_vencimiento)";
                InsertarMedicamentos += "VALUES(@NombreMedicamento,@CodCategoria,@IdCantidad,@Descripcion,@Ubicacion,@Fecha_Ingreso,@Codtipo,@Fecha_vencimiento)";
                Insert_A = new SqlCommand(InsertarMedicamentos, conn);
                Insert_A.Parameters.Add(new SqlParameter("@NombreMedicamento", SqlDbType.VarChar));
                Insert_A.Parameters["@NombreMedicamento"].Value = txtNombreProducto.Text;
                Insert_A.Parameters.Add(new SqlParameter("@CodCategoria", SqlDbType.VarChar));
                Insert_A.Parameters["@CodCategoria"].Value = cmbCategoriaProducto.Text;
                Insert_A.Parameters.Add(new SqlParameter("@IdCantidad", SqlDbType.Char));
                Insert_A.Parameters["@IdCantidad"].Value = txtCantidad.Text;
                Insert_A.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar));
                Insert_A.Parameters["@Descripcion"].Value = txtDescripcionProducto.Text;
                Insert_A.Parameters.Add(new SqlParameter("@Ubicacion", SqlDbType.VarChar));
                Insert_A.Parameters["@Ubicacion"].Value = txtUbicacion.Text;
                Insert_A.Parameters.Add(new SqlParameter("@Fecha_Ingreso", SqlDbType.Date));
                Insert_A.Parameters["@Fecha_Ingreso"].Value = txtFechaIngreso.Text;
                Insert_A.Parameters.Add(new SqlParameter("@Codtipo", SqlDbType.VarChar));
                Insert_A.Parameters["@IdCodtipo"].Value = cmbTipoProducto.Text;
                Insert_A.Parameters.Add(new SqlParameter("@Fecha_vencimiento", SqlDbType.Date));
                Insert_A.Parameters["Fecha_vencimiento"].Value = txtFechaVencimiento.Text;
                Insert_A.ExecuteNonQuery();
                //Limpiamos los texbox
                txtNombreProducto.Text = "";
                cmbCategoriaProducto.Text = "";
                txtCantidad.Text = "";
                txtUbicacion.Text = "";
                txtFechaIngreso.Text = "";
                txtFechaVencimiento.Text = "";
                txtDescripcionProducto.Text = "";
                cmbTipoProducto.Text = "";
                MessageBox.Show("Producto agregado con exito.Cmamo!");
                conn.Close();


            }
            catch(Exception A)
            {
                MessageBox.Show("Error", A.ToString());
            }
        }

        private void CmbTipoProducto_SelectedValueChanged(object sender, EventArgs e)
        {

           // MessageBox.Show(cmbTipoProducto.SelectedValue.ToString() );

        }
    }
}
