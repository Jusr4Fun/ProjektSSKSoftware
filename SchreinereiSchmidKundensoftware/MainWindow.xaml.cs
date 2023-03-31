using System.Windows;
using System.Windows.Controls;
using Datenbank.Model;
using Datenbank.Service;

namespace SchreinereiSchmidKundensoftware;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DataService _dataservice;
    private readonly Filter _filter;
    public MainWindow()
    {
        InitializeComponent();       
        _filter = new Filter();
        _dataservice = new DataService(_filter);
        Startup();
        this.DataContext = _dataservice;
    }

    private void Startup()
    {
        _dataservice.GetData(_filter);
    }

    private void Change_Click(object sender, RoutedEventArgs e)
    {
        var window = new EingabeFenster(_dataservice);
        _dataservice.Kunde_old = _dataservice.Kunde.Clone();
        window.Owner = this;
        window.ShowDialog();
    }

    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _dataservice.ChangeKunde((Kunde)AllList.SelectedItem);
    }

    private void Search_Click(object sender, RoutedEventArgs e)
    {
        _filter.ChangeFilterArguments(Suchfeld.Text);
        _dataservice.GetData(_filter);
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult bestätigelöschen = System.Windows.MessageBox.Show("Sind sie sich sicher?", "Löschen bestätigen", System.Windows.MessageBoxButton.YesNo);
        if (bestätigelöschen == MessageBoxResult.Yes)
            _dataservice.DeleteKunde();
    }

    private void Suchfeld_TextChanged(object sender, TextChangedEventArgs e)
    {
        _filter.ChangeFilterArguments(Suchfeld.Text);
        _dataservice.GetData(_filter);
        AllList.SelectedIndex = 0;
    }

    private void NeuerKunde_Click(object sender, RoutedEventArgs e)
    {
        _dataservice.Kunde_old = _dataservice.Kunde;
        var ansP = new Ansprechpartner();
        _dataservice.Kunde = new Kunde();
        _dataservice.Kunde.Ansprechpartner = ansP;
        NeuKundeFenster neuerKunde = new NeuKundeFenster(_dataservice);
        neuerKunde.Title = "Neuen Kunden Hinzufügen";
        neuerKunde.ShowDialog();
    }
}
