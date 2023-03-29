using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Datenbank.Model;

public class Kunde
{
    public int ID { get; set; }
    public string Betrieb { get; set; }
    public string Straße { get; set; }
    public string Ort { get; set; }
    public string PLZ { get; set; }
    public int AnsprechId { get; set; }
    public Ansprechpartner Ansprechpartner { get; set; }
}
