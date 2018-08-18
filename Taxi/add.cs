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
using System.Xml;
namespace Taxi
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }
        bool change=false;
        private void button2_Click(object sender, EventArgs e)
        {
            /*    if(change==false)
                    this.Close();
                else
                    Application.Restart();*/
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" || txtPLZ.Text != "" || txtStadt.Text != "" || txtStrasse.Text != "")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"ort.xml");
                XmlNode daten = doc.CreateElement("Daten");
                XmlNode stadt = doc.CreateElement("Stadt");
                stadt.InnerText = txtStadt.Text;
                daten.AppendChild(stadt);
                XmlNode strasse = doc.CreateElement("Strasse");
                strasse.InnerText = txtStrasse.Text;
                daten.AppendChild(strasse);
                XmlNode plz = doc.CreateElement("PLZ");
                plz.InnerText = txtPLZ.Text;
                daten.AppendChild(plz);
                XmlNode station = doc.CreateElement("Station");
                station.InnerText = comboBox1.Text;
                daten.AppendChild(station);

                doc.DocumentElement.AppendChild(daten);
                doc.Save(@"ort.xml");
                MessageBox.Show("Hinzugefügt!");
            }

        }
        private void add_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (change != false)    void neu() methode test
          //      Application.Restart();

        }

        private void add_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
/*     try
     {
         if (comboBox1.Text != "" || txtPLZ.Text != "" && txtStadt.Text != "" && txtStrasse.Text != "")
         {
             using (StreamWriter outputFile = new StreamWriter("ort.txt", true))
             {
                // outputFile.Write(txtStadt.Text + "°" + txtStrasse.Text + "°" + txtPLZ.Text + "°" + comboBox1.Text + "|");
                 outputFile.WriteLine(txtStadt.Text + "°" + txtStrasse.Text + "°" + txtPLZ.Text + "°" + comboBox1.Text + "|");
             }
             change = true;
             MessageBox.Show("Hinzugefügt!");
         }
         else
         {
             change = false;
             MessageBox.Show("Alle Felder müssen ausgefüllt werden!");
         }
     }
     catch
     {
         MessageBox.Show("FATAL ERROR !!! \nCONTACT ME");
     }*/

//  DataSet myDaraSet = new DataSet();
//myDaraSet.ReadXml(@"ort.xml");
//    op.DataSource = myDaraSet.Tables[0].DefaultView;
//      myDaraSet.Tables.Add("ff");
//  int n = op.Rows.Add();
//  op.Rows[op.Rows.Add()].Cells[0].Value = txtStadt.Text;
/*op.Rows[n].Cells[1].Value = txtStrasse.Text;
op.Rows[n].Cells[2].Value = txtPLZ.Text;
op.Rows[n].Cells[3].Value = txtOrt.Text;*/

//    myDaraSet.WriteXml(@"ort.xml");
//      DataSet ds = new DataSet();
//  ds.ReadXml(@"orte.xml");

//        ds.ReadXml(@"orte.xml");

//         ds.DataSetName = "Adress";
//    DataTable dt = new DataTable("Items");
//       dt.Columns.Add(new DataColumn("Stadt", typeof(string)));
//     dt.Columns.Add(new DataColumn("Strasse", typeof(string)));
//   dt.Columns.Add(new DataColumn("PLZ", typeof(string)));
// dt.Columns.Add(new DataColumn("Station", typeof(string)));
/*   DataRow dr = dt.NewRow();

   dr["Stadt"] = txtStadt.Text;
    dr["Strasse"] = "f";
    dr["PLZ"] = "f";
    dr["Station"] = "John";*/
//      int i= dt.Columns.Count;
//       dt.Rows.Add("a", "a", "a" , "a");
//   dt.Rows[1].
//     dt.Rows.Add(dr);
//     ds.Tables.Add(dt);
//    ds.WriteXmlSchema(@"orte.xml");
//     ds.WriteXml(@"orte.xml");
/*       DataSet ds = new DataSet();
       DataTable dt = new DataTable("Item");
       DataRow dr =dt.NewRow();
       ds.ReadXml(@"orte.xml");*/
