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
    public partial class blacklist : Form
    {
        public blacklist()
        {
            InitializeComponent();
            daten();
            liste();
       //     timer1.Start();
        }
        int z = 0;
        roteliste[] rliste = new roteliste[0];
        string[] lol = new string[20];
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            neu();
            Array.Resize(ref stringarr, stringarr.Length - (stringarr.Length - 1));
            listBox1.Items.Clear();
            z = 1;

            char[] charraytxta = textBox1.Text.ToCharArray();
            for (int i = 0; i < charraytxta.Length; i++)
            {
                stringarr[i] = charraytxta[i].ToString(); //stringarr=textbox1 als array
                Array.Resize(ref stringarr, stringarr.Length + 1);
            }
            char[] charsn = nachname[z].ToCharArray();

            //char[] charsn = ((ds.Tables[0].Rows[z]["Nachname"]).ToString()).ToCharArray();
            for (int i = 0; i < charsn.Length; i++)
            {
                stringarr2[i, z] = charsn[i].ToString();
                if (i == charsn.Length - 1)
                {
                    i = -1;
                    if (z != nachname.Length - 2)
                    {
                        z++;
                        charsn = nachname[z].ToCharArray();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            z = 1;
            bool check = false;
            listBox1.Items.Clear();
            for (int i = 0; i < charraytxta.Length; i++)
            {
                if (stringarr[i].Equals(stringarr2[i, z], StringComparison.OrdinalIgnoreCase))
                {
                    if (i == charraytxta.Length - 1 && check == false)
                    {
                        // ausgabe(z);

                        listBox1.Items.Add(rliste[z].Nachname+ " "+rliste[z].Vorname);
                        if (z != nachname.Length - 1)
                        {
                            i = -1;
                            z++;
                        }
                    }
                }
                else
                {
                    check = true;
                    if (z != nachname.Length - 1)
                    {
                        i = -1;
                        z++;
                        check = false;
                    }
                    else if (z == nachname.Length)
                    {
                        break;
                    }
                }
            }
        }
        
        void liste()
        {
            listBox1.Items.Clear();
            for (int i = 0; i <= nachname.Length - 1; i++)
            {
                Array.Resize(ref rliste, rliste.Length + 1);
                rliste[rliste.Length - 1] = new roteliste(nachname[i], vorname[i], id[i]);
            }
        }
        string[] vorname = new string[1];
        string[] nachname = new string[1];
        int[] id = new int[1];
        void neu()
        {
            Array.Resize(ref rliste, rliste.Length - rliste.Length);
            daten();
            liste();
        }
        void daten()
        {
            int zaeler = 0;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"roteliste.xml");
            Array.Resize(ref nachname, nachname.Length + 1 - (nachname.Length));
            Array.Resize(ref vorname, vorname.Length + 1 - (vorname.Length));
            Array.Resize(ref id, id.Length + 1 - (id.Length));
            foreach (XmlNode xNode in xDoc.SelectNodes("People/Person"))
            {
                
                // if (xNode.SelectSingleNode("Nachname").InnerText == textBox1.Text)
                //   {
                Array.Resize(ref nachname, nachname.Length + 1);
                Array.Resize(ref vorname, vorname.Length + 1);
                Array.Resize(ref id, id.Length + 1);
                nachname[zaeler] = xNode.SelectSingleNode("Nachname").InnerText;
                vorname[zaeler] = xNode.SelectSingleNode("Vorname").InnerText;
                id[zaeler] =int.Parse( xNode.SelectSingleNode("ID").InnerText);
                //        MessageBox.Show(nachname[zaeler]+ " "+ vorname[zaeler]);
                zaeler++;
                //        xNode.ParentNode.RemoveChild(xNode);
                //   xNode.RemoveAll();
                //    xDoc.Save(@"roteliste.xml");
                //    }
            }
            
 
        }
        string[] stringarr = new string[1];
        string[,] stringarr2 = new string[999, 999];
        private void button1_Click(object sender, EventArgs e)
        {
            neu();
            ausgabe();
            DataSet ds = new DataSet();
            ds.ReadXml(@"roteliste.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            perh phinz = new perh();
            phinz.Visible = true;

        }
        string eins, zwei;

        private void blacklist_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Run(new blacklist());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string txteingabe = listBox1.SelectedItem.ToString();
                char[] eingabechar = txteingabe.ToCharArray();

                string eins = null;
                for (int i = 0; i < eingabechar.Length; i++)
                {
                    if (eingabechar[i].ToString() != " ")
                        eins += eingabechar[i].ToString();
                    else
                        break;
                }
                //        MessageBox.Show("*"+zwei+"*");
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"roteliste.xml");

                foreach (XmlNode xNode in xDoc.SelectNodes("People/Person"))
                {
                    if (xNode.SelectSingleNode("ID").InnerText == eins)
                    {
                        xNode.ParentNode.RemoveChild(xNode);
                        //       MessageBox.Show("");
                        //   xNode.RemoveAll();
                        xDoc.Save(@"roteliste.xml"); // xNode.SelectSingleNode("Bemerkung").InnerText
                        this.Text = "Rote Liste (Gelöscht: " + xNode.SelectSingleNode("Vorname").InnerText + " " + xNode.SelectSingleNode("Nachname").InnerText + ")\n";
                    }
                }
            }
            catch
            {
                MessageBox.Show("Bitte eine Person auswählen");
            }
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void txtInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string txteingabe = listBox1.SelectedItem.ToString();
                char[] eingabechar = txteingabe.ToCharArray();

                string eins = null;
                for (int i = 0; i < eingabechar.Length; i++)
                {
                    if (eingabechar[i].ToString() != " ")
                        eins += eingabechar[i].ToString();
                    else
                        break;
                }
                //        MessageBox.Show("*"+zwei+"*");
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"roteliste.xml");

                foreach (XmlNode xNode in xDoc.SelectNodes("People/Person"))
                    if (xNode.SelectSingleNode("ID").InnerText == eins)
                        MessageBox.Show("Bemerkung: " + xNode.SelectSingleNode("Bemerkung").InnerText);
            }
            catch
            {
                MessageBox.Show("Bitte eine Person auswählen");
            }
        }

        void ausgabe()
        {
            listBox1.Items.Clear();
            for (int i = 1; i < rliste.Length - 1; i++)
            {
                listBox1.Items.Add(rliste[i].Id+" "+rliste[i].Vorname + " " + rliste[i].Nachname);
            }
        }
    }
}


/*    richTextBox1.Text = "";
    Array.Resize(ref nachname, nachname.Length + 1 - (nachname.Length));
    Array.Resize(ref vorname, vorname.Length + 1 - (vorname.Length));
    if (System.IO.File.Exists(@"roteliste.txt") == false)
    {
        MessageBox.Show("Die ort.txt Fehlt..");
    }
    else
    {

          string text = System.IO.File.ReadAllText(@"roteliste.txt");
           richTextBox1.Text = text;
           int zaeler = 0;
           int zaeler2 = 0;
           char[] datachar = text.ToCharArray();
           for (int i = 0; i < datachar.Length - 1; i++)
           {
               if (datachar[i].ToString() == "|")
               {
                   Array.Resize(ref nachname, nachname.Length + 1);
                   Array.Resize(ref vorname, vorname.Length + 1);
                   zaeler2 = 0;
                   zaeler++;
               }
               else
               {
                   if (datachar[i].ToString() != "°")
                   {
                       switch (zaeler2)
                       {
                           case 0: vorname[zaeler] += datachar[i].ToString(); break;
                           case 1: nachname[zaeler] += datachar[i].ToString(); break;
                       }
                   }
                   else if (datachar[i].ToString() == "°")
                   {
                       zaeler2++;
                   }
               }
           }
    }*/

/*      neu();
      eins = null;
      zwei = null;
      string text = System.IO.File.ReadAllText(@"roteliste.txt");
      char[] txtue = text.ToCharArray();

      string sitem = listBox1.SelectedItem.ToString();
      char[] listue = sitem.ToCharArray();
      //Replace(System.Environment.NewLine
      int z=0;
      bool wleitung=false;
      bool two = false;
   //   MessageBox.Show(sitem);
      for (int i = 0; i < txtue.Length - 1; i++)
      {
          zwei += txtue[i].ToString();
          if(wleitung==false)
          {
              if(z!=0)
              {
                  if (txtue[i - 1].ToString() == listue[z - 1].ToString() && txtue[i].ToString() == "°")
                  {
                      i++;
                      z++;
                  }
              }
              if (txtue[i].ToString()== listue[z].ToString())
              {
                  z++;
              }
              else
              {
                  if (z == 0)
                  {
                      eins = zwei;
                  }
                  else
                  {
                      z = 0;
                      eins += txtue[i].ToString();
                  }
              }
              if (z == listue.Length)
              {
                  wleitung = true;
              }
          }
          else
          {
              if(two==false)
              {
                  two=true;
            //      eins += "\n";
              }
              else
              {
                  eins += txtue[i].ToString();
              }
          }
      }
      File.WriteAllText(@"roteliste.txt", eins);
      MessageBox.Show("Erfolgreich von der Liste entfernt !");
      neu();
      ausgabe();*/




/*
 * 
            neu();
            Array.Resize(ref stringarr, stringarr.Length - (stringarr.Length - 1));
            listBox1.Items.Clear();
            z = 1;

            char[] charraytxta = textBox1.Text.ToCharArray();
            for (int i = 0; i < charraytxta.Length; i++)
            {
                stringarr[i] = charraytxta[i].ToString();
                Array.Resize(ref stringarr, stringarr.Length + 1);
            }
            char[] charsn = nachname[z].ToCharArray();
            for (int i = 0; i < charsn.Length; i++)
            {
                stringarr2[i, z] = charsn[i].ToString();
                if (i == charsn.Length - 1)
                {
                    i = -1;
                    if (z != nachname.Length - 2)
                    {
                        z++;
                        charsn = nachname[z].ToCharArray();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            z = 1;
            bool check = false;
            listBox1.Items.Clear();
            for (int i = 0; i < charraytxta.Length; i++)
            {
                if (stringarr[i].Equals(stringarr2[i, z], StringComparison.OrdinalIgnoreCase))
                {
                    if (i == charraytxta.Length - 1 && check == false)
                    {
                        // ausgabe(z);
                        
                        listBox1.Items.Add(rliste[z].Vorname + " " +rliste[z].Nachname);
                        if (z != nachname.Length - 1)
                        {
                            i = -1;
                            z++;
                        }
                    }
                }
                else
                {
                    check = true;
                    if (z != nachname.Length - 1)
                    {
                        i = -1;
                        z++;
                        check = false;
                    }
                    else if (z == nachname.Length)
                    {
                        break;
                    }
                }
            }*/

/*    try
    {
        if (textBox1.Text!="")
        {
            using (StreamWriter outputFile = new StreamWriter("roteliste.txt", true))
            {
                // outputFile.Write(txtStadt.Text + "°" + txtStrasse.Text + "°" + txtPLZ.Text + "°" + comboBox1.Text + "|");
                outputFile.WriteLine(textBox1.Text);
            }
        //    change = true;
            MessageBox.Show("Hinzugefügt!");
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
    }*/
/*  //   richTextBox1.Text = "";
       Array.Resize(ref vorname, vorname.Length + 1 - (vorname.Length));
       Array.Resize(ref nachname, nachname.Length + 1 - (nachname.Length));
       if (System.IO.File.Exists(@"roteliste.txt") == false)
       {
           MessageBox.Show("Die roteliste.txt Fehlt..");
       }
       else
       {
           string text = System.IO.File.ReadAllText(@"roteliste.txt");
        //   richTextBox1.Text = text;
           int zaeler = 0;
           int zaeler2 = 0;
           char[] datachar = text.ToCharArray();
           for (int i = 0; i < datachar.Length - 1; i++)
           {
               if (datachar[i].ToString() == "|")
               {
                   Array.Resize(ref vorname, vorname.Length + 1);
                   Array.Resize(ref nachname, nachname.Length + 1);
                   zaeler2 = 0;
                   zaeler++;
               }
               else
               {
                   if (datachar[i].ToString() != "°")
                   {
                       switch (zaeler2)
                       {
                           case 0: nachname[zaeler] += datachar[i].ToString(); break;
                           case 1: vorname[zaeler] += datachar[i].ToString(); break;
                       }
                       MessageBox.Show(nachname[zaeler]+" "+ vorname[zaeler]);
                   }
                   else if (datachar[i].ToString() == "°")
                   {
                       zaeler2++;
                   }
               }
           }
       }*/
