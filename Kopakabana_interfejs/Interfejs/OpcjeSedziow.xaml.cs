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
    /// Logika interakcji dla klasy OpcjeSedziow.xaml
    /// </summary>
    public partial class OpcjeSedziow : Window
    {
        public OpcjeSedziow()
        {
            
            InitializeComponent();
            Stream stream;
            BinaryFormatter formatter;
            Kantorek kantorek;
            if (File.Exists("Sedziowie.bin"))
            {
                stream = File.Open("Sedziowie.bin", FileMode.Open);
                formatter = new BinaryFormatter();
                kantorek = (Kantorek)formatter.Deserialize(stream);
                stream.Close();
            }
            else
            {
                kantorek = new Kantorek();
            }

            foreach (Sedzia sedzia in kantorek.GetSedziowie())
            {
                listaSedziow.Items.Add(sedzia);
            }
            listaSedziow.Items.Refresh();
        }

        private void DodajSedziego_Click(object sender, RoutedEventArgs e)
        {
            DodajSedziego oknosedzia = new DodajSedziego();
            
            if(true == oknosedzia.ShowDialog())
            {
                
                Stream stream;
                BinaryFormatter formatter;
                Kantorek kantorek;
                if (File.Exists("Sedziowie.bin"))
                {
                    stream = File.Open("Sedziowie.bin", FileMode.Open);
                    formatter = new BinaryFormatter();
                    kantorek = (Kantorek)formatter.Deserialize(stream);
                    stream.Close();
                }
                else
                {
                    kantorek = new Kantorek();
                }
                string imie, nazwisko;
                imie = oknosedzia.TextBoxImie.Text;
                nazwisko = oknosedzia.TextBoxNazwisko.Text;
                kantorek.DodajSedziego(new Sedzia( imie, nazwisko ,new Siatkowka() ));
                stream = File.Open("Sedziowie.bin", FileMode.Create);
                formatter = new BinaryFormatter();
                formatter.Serialize(stream, kantorek);
                listaSedziow.Items.Clear();
                foreach (Sedzia sedzia in kantorek.GetSedziowie())
                {
                    listaSedziow.Items.Add(sedzia);
                }
                listaSedziow.Items.Refresh();
                stream.Close();

                
            }
            
        }

        private void ListaSedziw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
