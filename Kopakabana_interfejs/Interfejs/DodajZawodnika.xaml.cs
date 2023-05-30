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
            if (string.IsNullOrEmpty(ImieZawodnika.Text) || string.IsNullOrEmpty(NazwiskoZawodnika.Text) || string.IsNullOrEmpty(NumerKoszulkiText.Text) )
            {
                MessageBox.Show("Imie, nazwisko i nr koszulki jest wymagana.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(!int.TryParse(NumerKoszulkiText.Text, out _)){
                MessageBox.Show("Nr koszulki musi być liczbą.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}
