using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace aplicacionBD
{
    public class clsConexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;


        public clsConexion()
        {
            this.Base = "Restaurente_pan_vino";
            this.Servidor = "DESKTOP-HRMH4OH";
            this.Usuario = string.Empty;
            this.Clave = string.Empty;
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Data Source=" + this.Servidor +
                                          "; Initial Catalog=" + this.Base +
                                          "; Integrated Security=True; trustservercertificate=true";
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public SqlConnection abrir()
        {
            SqlConnection miconexion = CrearConexion();

            try
            {
                miconexion.Open();
                MessageBox.Show("Conexión exitosa");
            }
            catch (Exception ex)
            {
               MessageBox.Show("Conexión No exitosa: " + ex.Message);
                throw;
            }

            return miconexion;
        }

        public void mostrar(String tabla, DataGridView grid)
        {
            string server = "Data Source = DESKTOP-HRMH4OH; Initial Catalog=Restaurente_pan_vino; Integrated Security = True; trustservercertificate=true";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            
            string query = "SELECT * FROM " + tabla;
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error " + ex.ToString());
                throw;
            }
            conectar.Close();
        }
    }
}