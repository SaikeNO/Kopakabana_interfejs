using System;
using System.Collections.Generic;
using System.DirectoryServices;
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
        public void ZapisDoPliku()
        {
            stream = File.Open("Sedziowie.bin", FileMode.Create);
            formatter = new BinaryFormatter();
            formatter.Serialize(stream, kantorek);
            stream.Close();
        }
        private Kantorek kantorek;
        private Stream stream;
        private BinaryFormatter formatter;
        public OpcjeSedziow()
        {
            
            InitializeComponent();
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
                string imie, nazwisko;
                imie = oknosedzia.TextBoxImie.Text;
                
                nazwisko = oknosedzia.TextBoxNazwisko.Text;
                Sport sportSedzia = new Sport();
                
                
                if((oknosedzia.RadioButtonSiatkowka.IsChecked)== true)
                {
                    sportSedzia = new Siatkowka();
                }
                if ((oknosedzia.RadioButtonPrzeciaganieLiny.IsChecked) == true)
                {
                    sportSedzia = new PrzeciaganieLiny();
                }
                if ((oknosedzia.RadioButtonDwaOgnie.IsChecked) == true)
                {
                    sportSedzia = new DwaOgnie();
                }
                
                kantorek.DodajSedziego(new Sedzia( imie, nazwisko ,sportSedzia));
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

        private void UsunSedziego_Click(object sender, RoutedEventArgs e)
        {
            kantorek.UsunSedziego(listaSedziow.SelectedIndex);
            listaSedziow.Items.RemoveAt(listaSedziow.SelectedIndex);
            
            ZapisDoPliku();
            listaSedziow.Items.Clear();
            foreach (Sedzia sedzia in kantorek.GetSedziowie())
            {
                listaSedziow.Items.Add(sedzia);
            }
            listaSedziow.Items.Refresh();
            stream.Close();

        }

        private void EdytujSedziego_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
