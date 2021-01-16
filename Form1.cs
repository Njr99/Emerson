using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Ganss.Excel;
using SpreadsheetLight;

namespace Calculador_de_Amperaje
{
    public partial class Form1 : Form
    {
        /*
        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog =PruebaDeSQL;Integrated Security = True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        conexionbd conexion = new conexionbd();
        */

        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        conexionbd conexion = new conexionbd();
        public static string connectionString = ("Data Source = .\\SQLEXPRESS;Initial Catalog =PruebaDeSQL;Integrated Security = True");
        SqlConnection con = new SqlConnection(connectionString);
        


        public static int accumulator;
        public  int contador;
        public int factor;
        


        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
            numericUpDown1.Visible = false;
            button2.Visible = false;
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                    Console.WriteLine("Conexión Exitosa");
                    MessageBox.Show("Conexión a la base de datos de manera exitosa", "Estatus de Conexión MSSQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }

                adpt = new SqlDataAdapter("SELECT * FROM Inventario", connectionString);
                dt = new DataTable();
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;

            } catch (Exception ex)
            {
                Console.WriteLine("Error al intentar conectarse a Base de Datos" + ex.Message);
            }
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            numericUpDown1.Visible = true;
            button2.Visible = true;
            

            string numeroIngresadoPorUsuario = textBox1.Text;         
            int i;

            if (textBox1.Text == "")
            {
                MessageBox.Show("Porfavor ingresa un número");
            }
            else
            {
                int numeroIngresadoPorUsuarioConvertido;
                bool textSuccess = int.TryParse(numeroIngresadoPorUsuario, out numeroIngresadoPorUsuarioConvertido);

                if (textSuccess)
                {

                    adpt = new SqlDataAdapter("SELECT Id,NumeroDeSerie,NombreDeArticulo,Medida FROM Inventario WHERE NumeroDeSerie = " + numeroIngresadoPorUsuario, con);

                    dt = new DataTable();
                    adpt.Fill(dt);
                    dataGridView1.DataSource = dt;


                    i = dt.Rows.Count;

                        if (i == 0)
                        {
                             MessageBox.Show("No existe el articulo en la base de datos");
                        } else
                        {

                            contador = Convert.ToInt32(dataGridView1.Rows[0].Cells[3].Value.ToString    ());                       
                        conexion.cerrar();
                        

                        /*
                       Form2 forma2 = new Form2(contador);
                       forma2.ShowDialog();
                        */
                    }
                } else
                {
                    MessageBox.Show("Porfavor ingresa un número entero");
                }
                
            }

            

        }

        public void multiplicarContadorPorUserInput(int c_ounter)
        {
            contador *= c_ounter;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                //factor = Convert.ToInt32(numericUpDown2.Value);
                factor = Convert.ToInt32(numericUpDown2.Value);

                if (factor <= 0)
                {
                    MessageBox.Show("Por favor ingresa un factor.");
                }
                else
                {


                    multiplicarContadorPorUserInput(Convert.ToInt32(numericUpDown1.Value));
                    accumulator += contador;

                    MessageBox.Show("Ahorita cuentas con la siguiente area: " + accumulator.ToString());
                    Form3 forma3 = new Form3(accumulator, factor);
                    forma3.ShowDialog();
                    using (forma3)
                    {
                        if (forma3.Result)
                        {
                            textBox1.Text = string.Empty;
                            label2.Visible = false;
                            numericUpDown1.Visible = false;
                            button2.Visible = false;
                            numericUpDown1.Value = 1;
                        }
                    }
                }
            } else
            {
                MessageBox.Show("Ingresa un valor que sea mayor a 0 porfavor");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            accumulator = 0;
            
            textBox1.Text = string.Empty;
            label2.Visible = false;
            numericUpDown1.Visible = false;
            button2.Visible = false;
            numericUpDown1.Value = 1;

            adpt = new SqlDataAdapter("SELECT * FROM Inventario", connectionString);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            factor = 0;
            numericUpDown2.Value = 0;
        }
    }

     
}
