using System;
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
    /// Logika interakcji dla klasy DodajSedziego.xaml
    /// </summary>
    public partial class DodajSedziego : Window
    {
        public DodajSedziego()
        {
            InitializeComponent();

        }

        private void TextBoxImie_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void WyborDyscypliny_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        
    }
}
