using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    class roteliste
    {
        string vorname, nachname;
        int id;
        public roteliste(string nachname, string vorname, int id)
        {
            this.nachname = nachname;
            this.vorname = vorname;
            this.id = id;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nachname
        {
            get { return nachname; }
            set { nachname = value; }
        }
        public string Vorname
        {
            get { return vorname; }
            set { vorname = value; }
        }
    }
}
