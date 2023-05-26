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
    /// Logika interakcji dla klasy OpcjeSedziow.xaml
    /// </summary>
    public partial class OpcjeSedziow : Window
    {
        public OpcjeSedziow()
        {
            InitializeComponent();
        }

        private void DodajSedziego_Click(object sender, RoutedEventArgs e)
        {
            DodajSedziego oknosedzia = new DodajSedziego();
            oknosedzia.ShowDialog();
            
        }

        private void ListaSedziw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
