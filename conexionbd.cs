using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Calculador_de_Amperaje
{
     public class conexionbd
    {
        string cadena = "Data Source = .\\SQLEXPRESS;Initial Catalog =PruebaDeSQL;" +
            "Integrated Security=True";
        public SqlConnection conectarbd = new SqlConnection();
        

        public conexionbd()
        {
            conectarbd.ConnectionString = cadena;
        }

        public void abrir()
        {
            try
            {
                conectarbd.Open();
                Console.WriteLine("Conexión Exitosa");
                MessageBox.Show("Conexión a la base de datos de manera exitosa", "Estatus de Conexión MSSQL",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error conectando base de datos" + ex.Message);
            }
        }

        public void cerrar()
        {
            conectarbd.Close();
            Console.WriteLine("Se ha cerrado la conexión a la base de datos");
        }

       
    }
}
