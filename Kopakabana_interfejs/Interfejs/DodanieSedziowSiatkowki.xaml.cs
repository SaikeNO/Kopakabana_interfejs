using Kopakabana;
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

namespace Kopakabana_interfejs.Interfejs
{
    /// <summary>
    /// Logika interakcji dla klasy DodanieSedziowSiatkowki.xaml
    /// </summary>
    public partial class DodanieSedziowSiatkowki : Window
    {
        private readonly Kantorek kantorek;
        private readonly Stream? stream;
        private readonly BinaryFormatter formatter = new();
        public DodanieSedziowSiatkowki(RozgrywkaSiatkowka rozgrywka, Sport sport)
        {
            InitializeComponent();
            if (File.Exists("Sedziowie.bin"))
            {
                stream = File.Open("Sedziowie.bin", FileMode.Open);
                kantorek = (Kantorek)formatter.Deserialize(stream);
                stream.Close();
            }
            else
            {
                kantorek = new();
            }
            foreach (Sedzia sedzia in kantorek.GetKantorekSportu(sport).GetSedziowie())
            {
                SedziowieKontrolkaGlowna.Items.Add(sedzia);
                SedziowieKontrolkaPom1.Items.Add(sedzia);
                SedziowieKontrolkaPom2.Items.Add(sedzia);
            }
        }

        private void WybierzGlownego_Click(object sender, RoutedEventArgs e)
        {
            if (SedziowieKontrolkaGlowna.SelectedItem is not Sedzia)
            {
                MessageBox.Show("Wybierz sędziego", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                WybranyGlowny.Text = SedziowieKontrolkaGlowna.SelectedItem.ToString();
            }
        }

        private void WybierzPom1_Click(object sender, RoutedEventArgs e)
        {
            if (SedziowieKontrolkaPom1.SelectedItem is not Sedzia)
            {
                MessageBox.Show("Wybierz sędziego", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                WybranyPom1.Text = SedziowieKontrolkaPom1.SelectedItem.ToString();
                
                
            }
        }

        

        private void WybierzPom2_Click(object sender, RoutedEventArgs e)
        {
            if (SedziowieKontrolkaPom2.SelectedItem is not Sedzia)
            {
                MessageBox.Show("Wybierz sędziego", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                WybranyPom2.Text = SedziowieKontrolkaPom2.SelectedItem.ToString();
            }
        }

        

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
