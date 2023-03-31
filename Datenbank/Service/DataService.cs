using System.Linq;
using System.Collections.ObjectModel;
using Datenbank.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Datenbank.Service;

public class DataService : INotifyPropertyChanged
{
    private readonly Filter _filter;
    private Kunde _kunde = new();
    private Kunde _kunde_old = new();
    private ObservableCollection<Kunde> _kundeList = new();
    private readonly DataBaseContext _context;
    public ObservableCollection<Kunde> Kunden {
        get => _kundeList;
        set
        {
            if (_kundeList == value) return;

            _kundeList = value;
            OnPropertyChanged();
        }
    }
    public Kunde Kunde {
        get => _kunde;
        set
        {
            if (_kunde == value) return;

            _kunde = value;
            OnPropertyChanged();
        }
    }

    public Kunde Kunde_old
    {
        get => _kunde_old;
        set
        {
            if (_kunde_old == value) return;

            _kunde_old = value;
            OnPropertyChanged();
        }
    }

    public DataService(Filter filter)
    {
        _filter= filter;
        _context= new DataBaseContext();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

    public void GetData(Filter filter)
    {
        var list = SearchProducts(filter.returnFilterArgsArray()).ToList();
        Kunden = new ObservableCollection<Kunde>(list);
    }

    public void ChangeKunde(Kunde kunde)
    {
        Kunde= kunde;
    }

    IQueryable<Kunde> SearchProducts(params string[] keywords)
    {
        IQueryable<Kunde> query = _context.Kunde.Include(b => b.Ansprechpartner);

        foreach (string keyword in keywords)
        {
            string temp = keyword;
            query = query.Where(p => p.Betrieb.Contains(temp) 
                                  || p.Ort.Contains(temp) 
                                  || p.PLZ.Contains(temp)
                                  || p.Straße.Contains(temp)
                                  || p.Ansprechpartner.Vorname.Contains(temp)
                                  || p.Ansprechpartner.Name.Contains(temp)
                                  || p.Ansprechpartner.EMail.Contains(temp)
                                  || p.Ansprechpartner.Telefon.Contains(temp)
                                     );
        }
        return query;
    }

    public void UpdateKunde()
    {
        _context.Update(Kunde);
        _context.SaveChanges();
    }

    public void DeleteKunde()
    {
        _context.Remove(Kunde);
        _context.Remove(Kunde.Ansprechpartner);
        _context.SaveChanges();
        GetData(_filter);
    }

    public void NewKunde()
    {
        _context.Database.EnsureCreated();
        _context.Ansprechpartner.Add(Kunde.Ansprechpartner);
        _context.Kunde.Add(Kunde);
        _context.SaveChanges();
        GetData(_filter);
    }
}
