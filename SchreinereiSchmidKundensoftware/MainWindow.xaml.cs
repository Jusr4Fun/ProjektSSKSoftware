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
        dataservice = new DataService();
        Startup();
        this.DataContext = dataservice;
    }

    private void Startup()
    {
        dataservice.getData(filter);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var window = new EingabeFenster(dataservice);
        window.Owner = this;
        window.ShowDialog();

        //using (var context = new DataBaseContext())
        //{
        //    // Creates the database if not exists
        //    context.Database.EnsureCreated();

        //    // Adds a publisher
        //    var kunde = new Kunde
        //    {
        //        Betrieb = "Mariner Books",
        //        Straße = "DerWeg 14",
        //        Ort = "Berlin",
        //        PLZ = "1234567"
        //    };
        //    context.Kunde.Add(kunde);

        //    // Adds some books
        //    context.Ansprechpartner.Add(new Ansprechpartner
        //    {
        //        Name = "978-0544003415",
        //        Vorname = "The Lord of the Rings",
        //        EMail = "J.R.R. Tolkien",
        //        Telefon = "English",
        //        Kunde = kunde
        //    });

        //    // Saves changes
        //    context.SaveChanges();
        //}
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

    private void Suchfeld_TextChanged(object sender, TextChangedEventArgs e)
    {
        filter.ChangeFilterArguments(Suchfeld.Text);
        dataservice.getData(filter);
        AllList.SelectedIndex = 0;
    }
}
