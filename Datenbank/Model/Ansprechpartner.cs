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
}
