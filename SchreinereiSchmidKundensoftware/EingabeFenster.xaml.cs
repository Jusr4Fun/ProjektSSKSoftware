using Datenbank.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchreinereiSchmidKundensoftware
{
    /// <summary>
    /// Interaktionslogik für EingabeFenster.xaml
    /// </summary>
    public partial class EingabeFenster : Window
    {
        private DataService dataService;
        public EingabeFenster(DataService datas)
        {
            InitializeComponent();
            this.dataService = datas;
            this.DataContext = dataService;
        }

        private void Save_Changes(object sender, RoutedEventArgs s)
        {

        }
    }
}
