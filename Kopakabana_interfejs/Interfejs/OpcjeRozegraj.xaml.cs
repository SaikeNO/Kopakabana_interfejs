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
    /// Logika interakcji dla klasy OpcjeRozegraj.xaml
    /// </summary>
    public partial class OpcjeRozegraj : Window
    {
        private Rozgrywka Rozgrywka { get; set; }
        public OpcjeRozegraj(Rozgrywka rozgrywka)
        {
            Rozgrywka = rozgrywka;
            InitializeComponent();
            Druzyna1Kontrolka.Content = Rozgrywka.druzyna1;
            Druzyna2Kontrolka.Content = Rozgrywka.druzyna2;

            Druzyna2Kontrolka.IsChecked = Rozgrywka.druzyna2.Equals(Rozgrywka.WygranaDruzyna);
            
            WygranaDruzynaKontrolka.Text = Rozgrywka.WygranaDruzyna?.ToString();
            RozgrywkaKontrolka.Text = Rozgrywka.ToString();
        }   

        private void OnOk_Click(object sender, RoutedEventArgs e)
        {
            if(Rozgrywka.WygranaDruzyna == null)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Rozgrywka została już rozegrana", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
