using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Datenbank;
using Datenbank.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.CodeDom;

namespace Datenbank.Service;

public class DataService : INotifyPropertyChanged
{
    private Filter _filter;
    private Kunde _kunde;
    private Kunde _kunde_old;
    private ObservableCollection<Kunde> _kundeList = new ObservableCollection<Kunde>();
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
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

    public void getData() {

        using (var context = new DataBaseContext())
        {
            var list = SearchProducts(_filter.returnFilterArgsArray()).ToList();            
            Kunden = new ObservableCollection<Kunde>(list);
        }
    }

    public void getData(Filter filter)
    {

        using (var context = new DataBaseContext())
        {
            var list = SearchProducts(filter.returnFilterArgsArray()).ToList();
            Kunden = new ObservableCollection<Kunde>(list);
        }
    }

    public void changeKunde(Kunde kunde)
    {
        Kunde= kunde;
    }

    IQueryable<Kunde> SearchProducts(params string[] keywords)
    {
        var dataContext = new DataBaseContext();
        IQueryable<Kunde> query = dataContext.Kunde.Include(b => b.Ansprechpartner);

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
        using(var context = new DataBaseContext())
        {
            context.Update(Kunde);

            context.SaveChanges();
        }
    }

    public void deleteKunde()
    {
        using(var context = new DataBaseContext())
        {
            context.Remove(Kunde);

            context.SaveChanges();
        }
        getData(_filter);
    }

    public void NewKunde()
    {
        using (var context = new DataBaseContext())
        {
            context.Database.EnsureCreated();

            context.Ansprechpartner.Add(Kunde.Ansprechpartner);

            context.Kunde.Add(Kunde);

            context.SaveChanges();
        }
        getData(_filter);
    }
}
