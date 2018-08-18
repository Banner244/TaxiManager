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
    public partial class perh : Form
    {
        public perh()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {//xNode.SelectSingleNode("ID")).InnerText
                if (textBox1.Text != ""|| textBox2.Text != "")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"roteliste.xml");
                    XmlNode person = doc.CreateElement("Person");
                    //xNode.SelectSingleNode("Station").InnerText
                    XmlNode id = doc.CreateElement("ID");
                    
                    bool test = false;
                    
                    foreach (XmlNode xNode in doc.SelectNodes("People/Person"))
                    {
                        i= int.Parse(xNode.SelectSingleNode("ID").InnerText);
                //        MessageBox.Show(i.ToString());
                        //i++;
                    }
                    i++;
                    id.InnerText = i.ToString();
                    person.AppendChild(id);



                    //     MessageBox.Show("1");
                    //       if (i==h&&i+1!=h+1)
                    //     {
                    //     MessageBox.Show((i+1)+" "+(h+1));
                    //       id.InnerText = i++.ToString();
                    //             person.AppendChild(id);


                    XmlNode nachname = doc.CreateElement("Nachname");
                    nachname.InnerText = textBox1.Text;
                    person.AppendChild(nachname);
                    nachname.InnerText = textBox1.Text;
                    person.AppendChild(nachname);
                    XmlNode vorname = doc.CreateElement("Vorname");
                    vorname.InnerText = textBox2.Text;
                    person.AppendChild(vorname);
                    XmlNode bemerkung = doc.CreateElement("Bemerkung");
                    bemerkung.InnerText = textBox3.Text;
                    person.AppendChild(bemerkung);

                    doc.DocumentElement.AppendChild(person);
                    doc.Save(@"roteliste.xml");
                    MessageBox.Show("Hinzugefügt!");
                    /*       using (StreamWriter outputFile = new StreamWriter("roteliste.txt", true))
                           {
                               // outputFile.Write(txtStadt.Text + "°" + txtStrasse.Text + "°" + txtPLZ.Text + "°" + comboBox1.Text + "|");
                            //   outputFile.WriteLine();
                               outputFile.WriteLine(textBox2.Text + "°"+ textBox1.Text + "|");
                           }
                               change = true;*/
                }
                else
                {
                    //change = false;
                    MessageBox.Show("Alle Felder müssen ausgefüllt werden!");
                }
            }
            catch
            {
                MessageBox.Show("FATAL ERROR !!! \nCONTACT ME");
            }
        }

        public void perh_FormClosed(object sender, FormClosedEventArgs e)
        {
            //  Application.Exit(new blacklist());
            //Application.Run(oo);
        }
    }
}
/*
 *                         if (i != int.Parse(xNode.SelectSingleNode("ID").InnerText))
                        {
                            xNode.c
                            id.InnerText = i.ToString();
                            person.AppendChild(id);
                            test = false;
                            break;
                        }
                        else
                        {
                            test = true;
                        }*/



/*
 *                     DataSet ds = new DataSet();
                    ds.ReadXml(@"roteliste.xml");
                    DataTable dt = new DataTable("Item");
                    int i = ds.Tables[0].Rows.Count;
                    ds.DataSetName = "Adress";
                    dt.Columns.Add(new DataColumn("Vorname", typeof(string)));
                    dt.Columns.Add(new DataColumn("Nachname", typeof(string)));
                    dt.Rows.Add(ds.Tables[0].Rows[i-1 ]["Nachname"] = textBox1.Text, ds.Tables[0].Rows[i-1]["Vorname"] = textBox2.Text);

                    //    dt.Rows.Add(ds.Tables[0].Rows[i-1]["Vorname"] = "ll");
                    //ds.Tables[0].Rows[i]["Nachname"] = "jj";
                    // ds.Tables[0].Rows[i]["Vorname"] = "jl";

                    ds.Tables[0].Rows[0]["Nachname"] = "Mustermann";
                     ds.Tables[0].Rows[0]["Vorname"] = "Max";
                    ds.Tables.Add(dt);
                    ds.WriteXml(@"roteliste.xml");
              //      dataGridView1.DataSource = ds.Tables[0].DefaultView;
              */
