using Datenbank.Service;
using System.Windows;


namespace SchreinereiSchmidKundensoftware;

/// <summary>
/// Interaktionslogik für EingabeFenster.xaml
/// </summary>
public partial class NeuKundeFenster : Window
{
    private readonly DataService _dataService;
    public NeuKundeFenster(DataService datas)
    {
        InitializeComponent();
        this._dataService = datas;
        this.DataContext = _dataService;
    }

    private void SaveChanges_Click(object sender, RoutedEventArgs e)
    {
        _dataService.NewKunde();
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        _dataService.Kunde = _dataService.Kunde_old;
        _dataService.Kunde_old = new();
    }
}
