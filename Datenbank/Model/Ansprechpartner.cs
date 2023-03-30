using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datenbank.Model;

public class Ansprechpartner
{
    public int ID { get; set; }
    public string Vorname { get; set; }
    public string Name { get; set; }
    public string EMail { get; set; }
    public string Telefon { get; set; }

    public Kunde Kunde { get; set; }

    public Ansprechpartner Clone() => new Ansprechpartner()
    {
        ID = this.ID,
        Vorname = this.Vorname, 
        Name = this.Name, 
        EMail = this.EMail, 
        Telefon = this.Telefon, 
        Kunde = this.Kunde
    };

    public void CopyValues(Ansprechpartner ansprechpartner)
    {
        ansprechpartner.ID = ID;
        ansprechpartner.Vorname = Vorname;
        ansprechpartner.Name = Name;
        ansprechpartner.EMail = EMail;
        ansprechpartner.Telefon = Telefon;
        ansprechpartner.Kunde = Kunde;
    }
}
