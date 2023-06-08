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
    /// Logika interakcji dla klasy WybierzSedziego.xaml
    /// </summary>
    public partial class WybierzSedziego : Window
    {
        private readonly Kantorek kantorek;
        private readonly Stream? stream;
        private readonly BinaryFormatter formatter = new();
        public WybierzSedziego(Rozgrywka rozgrywka, Sport sport)
        {
            InitializeComponent();
            Rozgrywka.Text = rozgrywka.ToString();
            WygranaDruzynaKontrolka.Text = rozgrywka.WygranaDruzyna?.ToString();

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
                SedziowieKontrolka.Items.Add(sedzia);
            }
        }
        public WybierzSedziego(RozgrywkaSiatkowka rozgrywkaSiatkowka, Sport sport)
        {
            InitializeComponent();
            Rozgrywka.Text = rozgrywkaSiatkowka.ToString();
            WygranaDruzynaKontrolka.Text = rozgrywkaSiatkowka.WygranaDruzyna?.ToString();
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
                SedziowieKontrolka.Items.Add(sedzia);
            }
        }

        private void OnOk_Click(object sender, RoutedEventArgs e)
        {
            if (SedziowieKontrolka.SelectedItem is not Sedzia) 
            {
                MessageBox.Show("Wybierz sędziego", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
            else if (!string.IsNullOrEmpty(WygranaDruzynaKontrolka.Text))
            {
                MessageBox.Show("Rozgrywka została już rozegrana", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}
