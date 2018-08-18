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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml;

namespace Taxi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
            daten();
            liste(); 
            toolTip1.SetToolTip(this.txtEingabe, "Gib eine Straße an !"); 
            toolTip1.SetToolTip(this.button2, "Adresse Hinzufügen !");
            toolTip1.SetToolTip(this.btProtokoll, "Adresse in Protokoll einfügen");
            toolTip1.SetToolTip(this.btProto, "Öffnet das Protokoll");
            toolTip1.SetToolTip(this.button3, "Öffnet den Manager der Roten Liste"); 
            toolTip1.SetToolTip(this.txtDelete, "Adresse(ausgewählte Straße) Löschen");
            this.Enabled = false;
            timer1.Start();
        }
        strasse[] stras = new strasse[0];
        private void btSuche_Click(object sender, EventArgs e)
        {
            
        }
        protokol kk = new protokol();
  //      Form1 main = new Form1();
        private void Form1_Load(object sender, EventArgs e)
        {
            kk.Visible = true;
            kk.Focus();
        }

        string[] strassennamen = new string[1];
        string[] strassenplz = new string[1];
        string[] strassenstadt = new string[1];
        string[] strassenort = new string[1];

        void daten()
        {
            int zaeler = 0;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"ort.xml");
            Array.Resize(ref strassennamen, strassennamen.Length + 1 - (strassennamen.Length));
            Array.Resize(ref strassenplz, strassenplz.Length + 1 - (strassenplz.Length));
            Array.Resize(ref strassenstadt, strassenstadt.Length + 1 - (strassenstadt.Length));
            Array.Resize(ref strassenort, strassenort.Length + 1 - (strassenort.Length));
            foreach (XmlNode xNode in xDoc.SelectNodes("Adress/Daten"))
            {

                // if (xNode.SelectSingleNode("Nachname").InnerText == textBox1.Text)
                //   {
                Array.Resize(ref strassennamen, strassennamen.Length + 1);
                Array.Resize(ref strassenplz, strassenplz.Length + 1);
                Array.Resize(ref strassenstadt, strassenstadt.Length + 1);
                Array.Resize(ref strassenort, strassenort.Length + 1);
                strassenstadt[zaeler] = xNode.SelectSingleNode("Stadt").InnerText;
                strassennamen[zaeler] = xNode.SelectSingleNode("Strasse").InnerText;
                strassenplz[zaeler] = xNode.SelectSingleNode("PLZ").InnerText;
                strassenort[zaeler] = xNode.SelectSingleNode("Station").InnerText;
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

        int z = 0;
        private void txtEingabe_TextChanged(object sender, EventArgs e)
        {
            neu();
            Array.Resize(ref stringarr, stringarr.Length -(stringarr.Length-1));
            listAusgabe.Items.Clear();
            z = 0;

            char[] charraytxta = txtEingabe.Text.ToCharArray();
            for (int i = 0; i < charraytxta.Length; i++)
            {
                stringarr[i] = charraytxta[i].ToString();
                Array.Resize(ref stringarr, stringarr.Length +1);
            }
            char[] charsn = strassennamen[z].ToCharArray();
            for (int i = 0; i < charsn.Length; i++)
            {
                stringarr2[i, z] = charsn[i].ToString();
                if (i == charsn.Length - 1)
                {
                    i = -1;
                    if (z != strassennamen.Length - 2)
                    {
                        z++;
                        charsn = strassennamen[z].ToCharArray();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            z = 0;
            bool check = false;
            listAusgabe.Items.Clear();
            for (int i = 0; i < charraytxta.Length; i++)
            {
                if (stringarr[i].Equals(stringarr2[i, z], StringComparison.OrdinalIgnoreCase))
                {
                    if (i == charraytxta.Length - 1 && check == false)
                    {
                        ausgabe(z);
                        if (z != strassennamen.Length - 1)
                        {
                            i = -1;
                            z++;
                        }
                    }
                }
                else
                {
                    check = true;
                    if (z != strassennamen.Length - 1)
                    {
                        i = -1;
                        z++;
                        check = false;
                    }
                    else if (z == strassennamen.Length)
                    {
                        break;
                    }
                }
            }
        }
        void liste()
        {
            for (int i = 0; i <= strassennamen.Length - 1; i++)
            {
                Array.Resize(ref stras, stras.Length + 1);
                stras[stras.Length - 1] = new strasse(strassennamen[i], strassenplz[i], strassenstadt[i], strassenort[i]);
            }
        }
        void ausgabe(int l)
        {
            listAusgabe.Items.Add(stras[l].Str + " " + stras[l].Plz+ " "+ stras[l].Stadt+ " " + stras[l].Ort);
        }
        private void label1_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show("Hersteller: Alexander Warawa\nKontakt: alexander.warawa@hotmail.de");
        }
        public string proto;
        
        private void btProtokoll_Click(object sender, EventArgs e)
        {
            if(listAusgabe.SelectedItem!=null)
            {
                Protokoll main3 = new Protokoll();
                main3.name1 = kk.CustomValue2;
                main3.CustomValue = protokoll2;//("[" + System.DateTime.Now.ToShortDateString() + " || " + System.DateTime.Now.ToShortTimeString() + "] " + listAusgabe.SelectedItem.ToString().Replace(System.Environment.NewLine, "") ); 
                
                main3.Visible = true;
            }
            else
            {
                MessageBox.Show("Bitte die zu Protokollierende Straße auswählen.");
            }
        }
        private void btProto_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad", @"protokolle/" + kk.CustomValue2);
            }
            catch
            {
                MessageBox.Show("Das Protokoll Existiert nicht !");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            box neue = new box();
            neue.Visible = true;
        }
        string protokoll2;
        private void listAusgabe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aua = listAusgabe.SelectedItem.ToString();
            char[] aza = aua.ToCharArray();
            string[] ausarr = new string[4];
            int z = 0;
            for (int i = 0; i < aza.Length; i++)
            {
                if (aza[i].ToString() != " ")
                {
                    ausarr[z] += aza[i].ToString();
                }
                else if (aza[i].ToString() == " "&& aza[i+1].ToString() != " ")
                {
                    z++;
                }
            }
            ausarr[2] = ausarr[2].Replace(System.Environment.NewLine, "");
            labelInform.Text = "Stadt: "+ ausarr[2] + "\n\nStraße: " + ausarr[0] + "\n\nPLZ: " + ausarr[1] + "\n\nStation: "+ ausarr[3];
            protokoll2 =  "Stadt: "+ausarr[2]  + " PLZ: " + ausarr[1] + " Station: " + ausarr[3]+" Straße: "+ ausarr[0];
        }
        private void button2_Click(object sender, EventArgs e)
        {
            add adden = new add();
            adden.Visible = true;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if(kk.ena ==true)
            {
                this.Enabled = true;
                this.WindowState = FormWindowState.Normal;
                this.Text = "Adressen (Protokoll: "+kk.CustomValue2+")";
                kk.ena = false;
                timer1.Stop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            blacklist neue = new blacklist();
            neue.Visible = true;
            
        }
        //stras[l].Str + " " + stras[l].Plz+ " "+ stras[l].Stadt+ " " + stras[l].Ort
        private void txtDelete_Click(object sender, EventArgs e)
        {
            try
            {
                neu();
                string txteingabe = listAusgabe.SelectedItem.ToString();
                char[] eingabechar = txteingabe.ToCharArray();
                string[] hueperarray = new string[4];

                int hueper = 0;
                for (int i = 0; i < eingabechar.Length; i++)
                {
                    if (eingabechar[i].ToString() != " ")
                    {
                        switch (hueper)
                        {
                            case 0: hueperarray[hueper] += eingabechar[i].ToString(); break;
                            case 1: hueperarray[hueper] += eingabechar[i].ToString(); break;
                            case 2: hueperarray[hueper] += eingabechar[i].ToString(); break;
                            case 3: hueperarray[hueper] += eingabechar[i].ToString(); break;
                        }
                    }
                    else
                    {
                        hueper++;
                    }
                }
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"ort.xml");
                foreach (XmlNode xNode in xDoc.SelectNodes("Adress/Daten"))
                {
                    if (xNode.SelectSingleNode("Strasse").InnerText == hueperarray[0] && xNode.SelectSingleNode("PLZ").InnerText == hueperarray[1] && xNode.SelectSingleNode("Stadt").InnerText == hueperarray[2] && xNode.SelectSingleNode("Station").InnerText == hueperarray[3])
                    {
                        xNode.ParentNode.RemoveChild(xNode);
                        //   xNode.RemoveAll();
                        MessageBox.Show("Adresse wurde entfernt");
                        xDoc.Save(@"ort.xml");
                        neu();
                        ausgabe2();
                    }
                }
            }
            catch
            {

            }
         }
         void neu()
         {
              //  listAusgabe.Items.Clear();
                Array.Resize(ref stras, stras.Length - stras.Length);
                daten();
                liste();
        }
        void ausgabe2()
        {
            listAusgabe.Items.Clear();
            for (int i = 1; i < stras.Length - 1; i++)
            {
                listAusgabe.Items.Add(stras[i].Str + " " + stras[i].Plz + " " + stras[i].Stadt + " " + stras[i].Ort);
          //      listBox1.Items.Add(stras[i].Vorname + " " + stras[i].Nachname);
            }
        }
        private void txtAuflisten_Click(object sender, EventArgs e)
        {
            neu();
            ausgabe2();
        }
    }
}
/*         richTextBox1.Text = "";
            Array.Resize(ref strassennamen, strassennamen.Length+1 - (strassennamen.Length));
            Array.Resize(ref strassenplz, strassenplz.Length + 1 - (strassenplz.Length));
            Array.Resize(ref strassenstadt, strassenstadt.Length + 1 - (strassenstadt.Length));
            Array.Resize(ref strassenort, strassenort.Length + 1 - (strassenort.Length));
            if(System.IO.File.Exists(@"ort.txt")==false)
            {
                MessageBox.Show("Die ort.txt Fehlt..");
            }
            else
            {
                string text = System.IO.File.ReadAllText(@"ort.txt");
                richTextBox1.Text = text;
                int zaeler = 0;
                int zaeler2 = 0;
                char[] datachar = text.ToCharArray();
                for (int i = 0; i < datachar.Length - 1; i++)
                {
                    if (datachar[i].ToString() == "|")
                    {
                        Array.Resize(ref strassennamen, strassennamen.Length + 1);
                        Array.Resize(ref strassenplz, strassenplz.Length + 1);
                        Array.Resize(ref strassenstadt, strassenstadt.Length + 1);
                        Array.Resize(ref strassenort, strassenort.Length + 1);
                        zaeler2 = 0;
                        zaeler++;
                    }
                    else
                    {
                        if (datachar[i].ToString() != "°")
                        {
                            switch (zaeler2)
                            {
                                case 0: strassenstadt[zaeler] += datachar[i].ToString(); break;
                                case 1: strassennamen[zaeler] += datachar[i].ToString(); break;
                                case 2: strassenplz[zaeler] += datachar[i].ToString(); break;
                                case 3: strassenort[zaeler] += datachar[i].ToString(); break;
                            }
                        }
                        else if (datachar[i].ToString() == "°")
                        {
                            zaeler2++;
                        }
                    }
                }
            }*/

/*    if(CustomValue2==true)
     {
         Form1 oo = new Form1();
         base.Enabled = true;
         timer1.Stop();
   //      MessageBox.Show("");
     }*/



/*        using (StreamWriter outputFile = new StreamWriter("Protokoll.txt", true))
        {

            main.CustomValue = ("[" + System.DateTime.Now.ToShortDateString() + " || " + System.DateTime.Now.ToShortTimeString() + "] " + listAusgabe.SelectedItem.ToString().Replace(System.Environment.NewLine, "") + ", "); 
            //outputFile.WriteLine("[" + System.DateTime.Now.ToShortDateString() + " || " + System.DateTime.Now.ToShortTimeString() + "] " + listAusgabe.SelectedItem.ToString().Replace(System.Environment.NewLine, "") + ", ");
            //     MessageBox.Show("Protokollieren Erfolgreich!");
        }*/


//Strassen Name
/*     strassennamen[0] = "eggestraße";
     strassennamen[1] = "stoDdartstraße";
     strassennamen[2] = "pennerweg";
     strassennamen[3] = "judenweg";
     strassennamen[4] = "eggeweg";
     strassennamen[5] = "eggesep";

     //Strassen PLZ
     strassenplz[0] = "32758";
     strassenplz[1] = "32756";
     strassenplz[2] = "32755";
     strassenplz[3] = "32754";
     strassenplz[4] = "32753";
     strassenplz[5] = "32752";

     //Strassen Stadt
     strassenstadt[0] = "detmold";
     strassenstadt[1] = "detmold";
     strassenstadt[2] = "detmold";
     strassenstadt[3] = "detmold";
     strassenstadt[4] = "detmold";
     strassenstadt[5] = "detmold";

     strassenort[0] = "ja";
     strassenort[1] = "ja";
     strassenort[2] = "ja";
     strassenort[3] = "ja";
     strassenort[4] = "ja";
     strassenort[5] = "ja";*/

/*     using (StreamReader outputFile = new StreamReader("ort.txt", true))
     {
    //     string hh=outputFile.;
      //   MessageBox.Show(hh);
     }*/
//  Array.Resize(ref stras, stras.Length + 1);

/*if(strassennamen[i+1]==null&&strassenplz[i+1]==null)
{
    break;
}*/
// daten(i);
//    MessageBox.Show(i+" "+ strassennamen.Length);

/* listAusgabe.Items.Clear();
         if (stringarr[i] == stringarr2[i, z]) 
         {
   //          MessageBox.Show(stringarr[i] +" "+ stringarr2[i, z]);
             listAusgabe.Items.Add(stras[z].Str);
         }
         else
         {
             z++;
         }
         if(i== charraytxta.Length-1&&z!= strassennamen.Length-1)
         {
             z++;
         }

 */


/*
 *  for (int j = 0; j < strassennamen.Length; j++)
        { 
            if (zaeler != stringarr.Length)
            {
                MessageBox.Show(i + " " + j);
                if (stringarr[i] == stringarr2[i, j])
                {
                    listAusgabe.Items.Add(stras[i].Str + " " + stras[i].Plz);

                }
                else
                {
                    i = 0;
                        //          MessageBox.Show("g");
                    j++;
                    break;
                }
            }
            else
            {
                break;
            }


  /*      if (z == strassennamen.Length )
        {
                MessageBox.Show(z+" strassennamen");
                break;
        }*/










