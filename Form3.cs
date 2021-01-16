using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Calculador_de_Amperaje
{
    
    public partial class Form3 : Form
    {
        

        public int contadorFormaTres;
        public bool Result { get; set; }
        public int factorForm1;

        public Form3(int contadorFormaDos,int factor)
        {
            InitializeComponent();
            contadorFormaTres = contadorFormaDos;
            factorForm1 = factor;
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
        
        
        public void button2_Click(object sender, EventArgs e)
        {

            // Excel claseuno = new Excel(@"D:\Excel.xlsx", 1);
            //claseuno.writeToCell(0, 0, "Texto de la vida");
            //claseuno.Save();

                 
                SLDocument sl = new SLDocument(@"D:\Excel.xlsx");
                sl.SetCellValue("A1", "Area");
                sl.SetCellValue("A2", contadorFormaTres);
                sl.SetCellValue("C1", "Factor");
                sl.SetCellValue("C2", factorForm1);
                sl.Save();

            Form1.accumulator = 0;
            this.Close();

            Form4 forma4 = new Form4();
            forma4.ShowDialog();

            

            

            


        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Result = true;
                
            
        }

        public void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                // Prompt user to save his data
                MessageBox.Show("Reiniciar el programa por favor");
                
        // Autosave and clear up ressources
        }




    }

}
            