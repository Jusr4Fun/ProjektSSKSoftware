using Datenbank.Model;
using Datenbank.Service;
using System.Windows;

namespace SchreinereiSchmidKundensoftware;

/// <summary>
/// Interaktionslogik für EingabeFenster.xaml
/// </summary>
public partial class EingabeFenster : Window
{
    private readonly DataService _dataService;
    public EingabeFenster(DataService datas)
    {
        InitializeComponent();
        this._dataService = datas;
        this.DataContext = _dataService;
    }

    private void SaveNew_Click(object sender, RoutedEventArgs e)
    {
        _dataService.UpdateKunde();
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        _dataService.Kunde_old.CopyValues(_dataService.Kunde);
        _dataService.Kunde_old = new(); 
        Kunde temp = _dataService.Kunde;
        _dataService.Kunde = new();
        _dataService.Kunde = temp;
        //dataService.getData();
    }
}
