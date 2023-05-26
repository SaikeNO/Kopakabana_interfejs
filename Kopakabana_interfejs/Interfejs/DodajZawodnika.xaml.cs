using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Logika interakcji dla klasy DodajZawodnika.xaml
    /// </summary>
    public partial class DodajZawodnika : Window
    {
        
        public DodajZawodnika()
        {
            InitializeComponent();
           


        }

        private void OnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void OnAnuluj_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NazwiskoZawodnika_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ImieZawodnika_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void NumerKoszulkiText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
