using Datenbank.Service;
using System.Windows;


namespace SchreinereiSchmidKundensoftware;

/// <summary>
/// Interaktionslogik für EingabeFenster.xaml
/// </summary>
public partial class NeuKundeFenster : Window
{
    private DataService dataService;
    public NeuKundeFenster(DataService datas)
    {
        InitializeComponent();
        this.dataService = datas;
        this.DataContext = dataService;
    }

    private void Save_Changes(object sender, RoutedEventArgs s)
    {
        dataService.NewKunde();
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs s)
    {
        dataService.Kunde = dataService.Kunde_old;
        dataService.Kunde_old = null;
    }
}
