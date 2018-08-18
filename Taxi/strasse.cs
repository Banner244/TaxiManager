using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    class strasse
    {
        /*    public string strase(string uebergabe)
            {

                return uebergabe;
            }
            public string plz(string uebergabe)
            {

                return uebergabe;
            }*/
        string str, plz, stadt, ort;
        public strasse(string str, string plz, string stadt,string ort)
        {
            this.str = str;
            this.plz = plz;
            this.stadt = stadt;
            this.ort = ort;
        }
        public string Str
        {
            get { return str; }
            set { str = value; }
        }
        public string Plz
        {
            get { return plz; }
            set { plz = value; }
        }
        public string Stadt
        {
            get { return stadt; }
            set { stadt = value; }
        }
        public string Ort
        {
            get { return ort; }
            set { ort = value; }
        }
   

    }

}
