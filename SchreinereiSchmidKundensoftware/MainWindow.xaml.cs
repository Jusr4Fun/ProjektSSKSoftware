using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Datenbank.Model;
using Datenbank.Service;

namespace SchreinereiSchmidKundensoftware;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    DataService dataservice;
    Filter filter;
    public MainWindow()
    {
        InitializeComponent();       
        filter = new Filter();
        dataservice = new DataService(filter);
        Startup();
        this.DataContext = dataservice;
    }

    private void Startup()
    {
        dataservice.getData(filter);
    }

    private void Change_Click(object sender, RoutedEventArgs e)
    {
        var window = new EingabeFenster(dataservice);
        dataservice.Kunde_old = dataservice.Kunde;
        window.Owner = this;
        window.ShowDialog();
    }

    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        dataservice.changeKunde((Kunde)AllList.SelectedItem);
    }

    private void Search_Click(object sender, RoutedEventArgs e)
    {
        filter.ChangeFilterArguments(Suchfeld.Text);
        dataservice.getData(filter);
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult bestätigelöschen = System.Windows.MessageBox.Show("Sind sie sich sicher?", "Löschen bestätigen", System.Windows.MessageBoxButton.YesNo);
        if (bestätigelöschen == MessageBoxResult.Yes)
            dataservice.deleteKunde();
    }

    private void Suchfeld_TextChanged(object sender, TextChangedEventArgs e)
    {
        filter.ChangeFilterArguments(Suchfeld.Text);
        dataservice.getData(filter);
        AllList.SelectedIndex = 0;
    }

    private void Neuer_Kunde_Click(object sender, RoutedEventArgs e)
    {
        dataservice.Kunde_old = dataservice.Kunde;
        var ansP = new Ansprechpartner();
        dataservice.Kunde = new Kunde();
        dataservice.Kunde.Ansprechpartner = ansP;
        NeuKundeFenster neuerKunde = new NeuKundeFenster(dataservice);
        neuerKunde.Title = "Neuen Kunden Hinzufügen";
        neuerKunde.ShowDialog();
    }
}
