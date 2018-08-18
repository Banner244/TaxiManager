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
    public partial class protokol : Form
    {
        public protokol()
        {
            InitializeComponent(); 
            toolTip1.SetToolTip(this.button2, "Kein .txt an deinen Namen Schreiben !");
        }
        public string CustomValue2 { get; set; }
        public bool ena { get; set; }
        bool schliessen = false;
        private void button1_Click(object sender, EventArgs e)
        {
            schliessen = true;
            Form1 main = new Form1();
            System.IO.DirectoryInfo ParentDirectory = new System.IO.DirectoryInfo(@"protokolle/");
            if (File.Exists(@"protokolle/"+ comboBox1.Text+".txt"))
            {
                /*main.*/CustomValue2 = comboBox1.Text+".txt";
                ena = true;      
                this.Close();
            }
            else
            {
                MessageBox.Show("Protokoll-Account nicht gefunden !");
            }
        }
        private void protokol_Load(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            loh();
            main.WindowState = FormWindowState.Minimized;
        }
        void loh()
        {
            comboBox1.Items.Clear();
            System.IO.DirectoryInfo ParentDirectory = new System.IO.DirectoryInfo(@"protokolle/");
            foreach (System.IO.FileInfo f in ParentDirectory.GetFiles())
            {
                string name="";
                char[] txtweg=f.Name.ToCharArray();
                for(int i=0;i<txtweg.Length;i++)
                {
                    if(txtweg[i].ToString()=="."&& txtweg[i+1].ToString() == "t"&& txtweg[i+2].ToString() == "x"&& txtweg[i+3].ToString() == "t")
                    {
                        break;
                    }
                    else
                    {
                        name += txtweg[i].ToString();
                    }
                }
                comboBox1.Items.Add(name);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            schliessen = true;
            if (!File.Exists(@"protokolle/" + comboBox1.Text))
            {
                using (StreamWriter outputFile = new StreamWriter(@"protokolle/" + comboBox1.Text + ".txt", true))
                {
                    outputFile.Write("");
                }
                // System.IO.File.CreateText(@"protokolle/"+comboBox1.Text+".txt");
                MessageBox.Show("Protokoll erstellt !");
                loh();
                comboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Dieses Protokoll existiert bereits !");
            }
        }

        private void protokol_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(schliessen==false)
            {
                Application.Exit();
            }
        }
    }
}
