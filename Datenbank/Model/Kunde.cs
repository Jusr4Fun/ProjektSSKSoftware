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

    public Kunde Clone() => new Kunde()
    {
        ID = this.ID,
        Betrieb = this.Betrieb,
        Straße = this.Straße,
        Ort = this.Ort,
        PLZ = this.PLZ,
        AnsprechId = this.AnsprechId,
        Ansprechpartner = Ansprechpartner.Clone()
    };

    public void CopyValues(Kunde kunde)
    {
        kunde.ID = ID;
        kunde.Betrieb =Betrieb;
        kunde.Straße = Straße;
        kunde.Ort = Ort;
        kunde.PLZ = PLZ;
        kunde.AnsprechId = AnsprechId;
        Ansprechpartner.CopyValues(kunde.Ansprechpartner);
    }
}
