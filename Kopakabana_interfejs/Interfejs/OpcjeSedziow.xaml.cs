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
        private Kantorek kantorek;
        private Stream stream;
        private BinaryFormatter formatter = new BinaryFormatter();
        public OpcjeSedziow()
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
                kantorek = new Kantorek();
            }

            foreach (Sedzia sedzia in kantorek.GetSedziowie())
            {
                listaSedziow.Items.Add(sedzia);
            }
        }

        private void DodajSedziego_Click(object sender, RoutedEventArgs e)
        {
            DodajSedziego oknosedzia = new DodajSedziego();
            
            if(true == oknosedzia.ShowDialog())
            {
                Sport sportSedzia = new Siatkowka();
                
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

                Sedzia sedzia = new(oknosedzia.TextBoxImie.Text, oknosedzia.TextBoxNazwisko.Text, sportSedzia);
                kantorek.DodajSedziego(sedzia);
                listaSedziow.Items.Add(sedzia);

                ZapisDoPliku();
            }
        }
        private void UsunSedziego_Click(object sender, RoutedEventArgs e)
        {
            kantorek.UsunSedziego(listaSedziow.SelectedIndex);
            listaSedziow.Items.RemoveAt(listaSedziow.SelectedIndex);
            
            ZapisDoPliku();
        }

        private void EdytujSedziego_Click(object sender, RoutedEventArgs e)
        {
            DodajSedziego edycjaSedziego = new DodajSedziego();
            if(true == (edycjaSedziego.ShowDialog()))
            {

            }
        }
        public void ZapisDoPliku()
        {
            stream = File.Open("Sedziowie.bin", FileMode.Create);
            formatter.Serialize(stream, kantorek);
            stream.Close();
        }
    }
}
