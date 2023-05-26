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

namespace Kopakabana
{
    /// <summary>
    /// Logika interakcji dla klasy OpcjeDruzyn.xaml
    /// </summary>
    public partial class OpcjeDruzyn : Window
    {
        
        public OpcjeDruzyn()
        {
            InitializeComponent();
        }

        private void Zawodnicy_Click(object sender, RoutedEventArgs e)
        {
            OpcjeZawodnikow opcjeZawodnikow = new OpcjeZawodnikow();
            opcjeZawodnikow.ShowDialog();
        }

        private void Druzyny_Click(object sender, RoutedEventArgs e)
        {
            OpcjeDruzynDalej opcjeDruzynDalej = new OpcjeDruzynDalej();
            opcjeDruzynDalej.ShowDialog();
        }
    }
}
