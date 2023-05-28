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
    /// Logika interakcji dla klasy DodajDruzyne.xaml
    /// </summary>
    public partial class DodajDruzyne : Window
    {
        private List<Zawodnik> listaZawodnikow;
        private Stream stream;
        private BinaryFormatter formatter = new BinaryFormatter();
        public DodajDruzyne()
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
                listaZawodnikowKontrolka.Items.Add(zawodnik);
            }
        }

        private void OnOK_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NazwaDruzyny.Text))
            {
                MessageBox.Show("Nazwa Druzyny jest wymagana.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            { 
                DialogResult = true;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(listaZawodnikowKontrolka.SelectedItem != null)
            {
                listaWybranychZawodnikowKontrolka.Items.Add(listaZawodnikowKontrolka.SelectedItem as Zawodnik);
                listaZawodnikowKontrolka.Items.Remove(listaZawodnikowKontrolka.SelectedItem as Zawodnik);
            }
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (listaWybranychZawodnikowKontrolka.SelectedItem != null)
            {
                listaZawodnikowKontrolka.Items.Add(listaWybranychZawodnikowKontrolka.SelectedItem as Zawodnik);
                listaWybranychZawodnikowKontrolka.Items.Remove(listaWybranychZawodnikowKontrolka.SelectedItem as Zawodnik);
            }
        }
    }
}
