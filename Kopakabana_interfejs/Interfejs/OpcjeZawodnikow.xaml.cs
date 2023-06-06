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
    /// Logika interakcji dla klasy OpcjeZawodnikow.xaml
    /// </summary>
    public partial class OpcjeZawodnikow : Window
    {
        private List<Zawodnik> listaZawodnikow;
        private Stream stream;
        private BinaryFormatter formatter = new BinaryFormatter();
        public OpcjeZawodnikow()
        {
            InitializeComponent();

            if (File.Exists("Zawodnicy.bin"))
            {
                stream = File.Open("Zawodnicy.bin", FileMode.Open);
                listaZawodnikow = (List<Zawodnik>)formatter.Deserialize(stream);
                stream.Close();
            }
            else
            {
                listaZawodnikow = new List<Zawodnik>();
            }

            foreach (Zawodnik zawodnik in listaZawodnikow)
            {
                Zawodnicy.Items.Add(zawodnik);
            }
        }

        private void DodajZawodnika_Click(object sender, RoutedEventArgs e)
        {
            DodajZawodnika dodajZawodnika = new();
            if (true == dodajZawodnika.ShowDialog())
            {
                int numerKoszulki = int.Parse(dodajZawodnika.NumerKoszulkiText.Text);

                Zawodnik zawodnik = new(dodajZawodnika.ImieZawodnika.Text, dodajZawodnika.NazwiskoZawodnika.Text, numerKoszulki);
                listaZawodnikow.Add(zawodnik);
                Zawodnicy.Items.Add(zawodnik);

                ZapisDoPliku();
            }
        }

        private void UsunZawodnika_Click(object sender, RoutedEventArgs e)
        {
            if (Zawodnicy.SelectedItem is not Zawodnik wybranyZawodnik)
            {
                MessageBox.Show("Wybierz zawodnika.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            listaZawodnikow.Remove(wybranyZawodnik);
            Zawodnicy.Items.Remove(wybranyZawodnik);

            ZapisDoPliku();
        }
        private void EdytujZawodnika_Click(object sender, RoutedEventArgs e)
        {
            if (Zawodnicy.SelectedItem is not Zawodnik zawodnik) {
                MessageBox.Show("Wybierz zawodnika.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; }
            DodajZawodnika dodajZawodnika = new();

            dodajZawodnika.ImieZawodnika.Text = zawodnik.Name;
            dodajZawodnika.NazwiskoZawodnika.Text = zawodnik.Surname;
            dodajZawodnika.NumerKoszulkiText.Text = zawodnik.NumerKoszulki + ""; // + "" jest po to aby przekonwertować int'a na string'a

            if (true == (dodajZawodnika.ShowDialog()))
            {
                zawodnik.Name = dodajZawodnika.ImieZawodnika.Text;
                zawodnik.Surname = dodajZawodnika.NazwiskoZawodnika.Text;
                zawodnik.NumerKoszulki = int.Parse(dodajZawodnika.NumerKoszulkiText.Text);

                ZapisDoPliku();
                Zawodnicy.Items.Refresh();
            }
        }
        public void ZapisDoPliku()
        {
            stream = File.Open("Zawodnicy.bin", FileMode.Create);
            formatter.Serialize(stream, listaZawodnikow);
            stream.Close();
        }
    }
}
