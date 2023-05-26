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
        public OpcjeZawodnikow()
        {
            InitializeComponent();
            Stream stream;
            BinaryFormatter formatter;
            if (File.Exists("Zawodnicy.bin"))
            {
                stream = File.Open("Zawodnicy.bin", FileMode.Open);
                formatter = new BinaryFormatter();
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
            Zawodnicy.Items.Refresh();
        }

        private void DodajZawodnikow1_Click(object sender, RoutedEventArgs e)
        {
            DodajZawodnika dodajZawodnika = new DodajZawodnika();
            if(true == dodajZawodnika.ShowDialog())
            {
                Stream stream;
                BinaryFormatter formatter;
                if (File.Exists("Zawodnicy.bin"))
                {
                    stream = File.Open("Zawodnicy.bin", FileMode.Open);
                    formatter = new BinaryFormatter();
                    listaZawodnikow = (List<Zawodnik>)formatter.Deserialize(stream);
                    stream.Close();
                }
                else
                {
                    listaZawodnikow = new List<Zawodnik>();
                }
                string imie, nazwisko;
                imie = dodajZawodnika.ImieZawodnika.Text;
                nazwisko = dodajZawodnika.NazwiskoZawodnika.Text;
                int numerKoszulki = int.Parse(dodajZawodnika.NumerKoszulkiText.Text);
                listaZawodnikow.Add(new Zawodnik(imie, nazwisko, numerKoszulki));
                stream = File.Open("Zawodnicy.bin", FileMode.Create);
                formatter = new BinaryFormatter();
                formatter.Serialize(stream, listaZawodnikow);
                Zawodnicy.Items.Clear();
                foreach (Zawodnik zawodnik in listaZawodnikow)
            {
                Zawodnicy.Items.Add(zawodnik);
            }
            Zawodnicy.Items.Refresh();
                stream.Close();
            }

        }

        private void UsunZawodnika_Click(object sender, RoutedEventArgs e)
        {
            Zawodnicy.Items.RemoveAt(Zawodnicy.SelectedIndex);
        }
    }
}
