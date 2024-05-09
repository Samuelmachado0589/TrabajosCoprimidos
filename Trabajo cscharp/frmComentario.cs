using aplicacionBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormularioMDI
{
    public partial class frmComentario : Form
    {

        public static frmComentario Instancia = null;
        public static frmComentario ventanaUnica()
        {
            if (Instancia == null)
            {
                Instancia = new frmComentario();
            }
            return Instancia;
        }
        clsConexion conexion = new clsConexion();
        public frmComentario()
        {
            InitializeComponent();
          conexion.CrearConexion();
            conexion.abrir();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-HRMH4OH;Initial Catalog=Restaurente_pan_vino;Integrated Security=True;trustservercertificate=true");
            conexion.Open();

            int ID_Reserva = Convert.ToInt32(txtReserva.Text);
            string Comnetario = txtComentario.Text;
            DateTime Fecha_Comentario = Convert.ToDateTime(dtpComentario.Value);
            string  AUX = "I";
            int id_Comentario = Convert.ToInt32(txtIdComentario.Text);


            SqlCommand proc = new SqlCommand("SP_Comentario", conexion);

            proc.CommandType = CommandType.StoredProcedure;

            proc.Parameters.AddWithValue("@ID_Reserva", Convert.ToInt32(txtReserva.Text));
            proc.Parameters.AddWithValue("@Comentario", txtComentario.Text);
            proc.Parameters.AddWithValue("@Fecha_Comentario", dtpComentario.Value);
            proc.Parameters.AddWithValue("@AUX", AUX);
            proc.Parameters.AddWithValue("@ID_Comentario", id_Comentario);
            proc.ExecuteNonQuery();

            MessageBox.Show("Se insertaron los datos correctamente");


            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-HRMH4OH;Initial Catalog=Restaurente_pan_vino;Integrated Security=True;trustservercertificate=true");
            conexion.Open();

            int ID_Reserva = Convert.ToInt32(txtReserva.Text);
            string Comentario = txtComentario.Text;
            DateTime Fecha_Comentario = Convert.ToDateTime(dtpComentario.Value);
            string AUX = "U";
            int id_Comentario = Convert.ToInt32(txtIdComentario.Text);


            SqlCommand proc = new SqlCommand("SP_Comentario", conexion);
            proc.CommandType = CommandType.StoredProcedure;
            proc.Parameters.AddWithValue("@ID_Reserva", ID_Reserva);
            proc.Parameters.AddWithValue("@Comentario", Comentario);
            proc.Parameters.AddWithValue("@Fecha_Comentario", Fecha_Comentario);
            proc.Parameters.AddWithValue("@ID_Comentario", id_Comentario);
            proc.Parameters.AddWithValue("@AUX", AUX);
            proc.ExecuteNonQuery();

            MessageBox.Show("Se actualizaron los datos correctamente");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-HRMH4OH;Initial Catalog=Restaurente_pan_vino;Integrated Security=True;trustservercertificate=true");
            conexion.Open();

            int ID_Reserva = 0;
            string Comentario = "";
            DateTime Fecha_Comentario = Convert.ToDateTime("2023-05-09");
            int id_Comentario = Convert.ToInt32( txtIdComentario.Text);
            string AUX = "D";

            SqlCommand proc = new SqlCommand("SP_Comentario", conexion);
            proc.CommandType = CommandType.StoredProcedure;

            proc.Parameters.AddWithValue("@ID_Reserva", ID_Reserva);
            proc.Parameters.AddWithValue("@Comentario", Comentario);
            proc.Parameters.AddWithValue("@Fecha_Comentario", Fecha_Comentario);
            proc.Parameters.AddWithValue("@ID_Comentario", id_Comentario);
            proc.Parameters.AddWithValue("@AUX", AUX);
            proc.ExecuteNonQuery();

            MessageBox.Show("Se eliminaron los datos correctamente");

        }
    }
}