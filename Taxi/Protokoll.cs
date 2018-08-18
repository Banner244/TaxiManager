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

namespace Taxi
{
    
    public partial class Protokoll : Form
    {
        
        public Protokoll()
        {
            InitializeComponent();
        }
        //  string ueber;
        public string CustomValue { get; set; }
        public string name1 { get; set; }
        private void Protokoll_Load(object sender, EventArgs e)
        {
            
            textBox1.Text = CustomValue;
      //      textBox3.Text = this.name1;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            using (StreamWriter outputFile = new StreamWriter(@"protokolle/"+ this.name1, true))
            {
                outputFile.WriteLine("[" + System.DateTime.Now.ToShortDateString() + " || " + System.DateTime.Now.ToShortTimeString() + "] " + CustomValue + " "+ textBox2.Text+"| Telefon: "+textBox3.Text+",");
                outputFile.WriteLine("Bemerkung: "+textBox4.Text);
                outputFile.WriteLine("----------------------------------------------------------------------------------------------------------");
                //outputFile.WriteLine("[" + System.DateTime.Now.ToShortDateString() + " || " + System.DateTime.Now.ToShortTimeString() + "] " + listAusgabe.SelectedItem.ToString().Replace(System.Environment.NewLine, "") + ", ");
                //     MessageBox.Show("Protokollieren Erfolgreich!");
            }
            MessageBox.Show("Protokolliert !");
            this.Close();
        }
        void te()
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
