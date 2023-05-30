using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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
    /// Logika interakcji dla klasy OpcjeKwalifikacjeDalej.xaml
    /// </summary>
    public partial class OpcjeKwalifikacjeDalej : Window
    {
        private Kwalifikacje kwalifikacje;
        private ListaDruzyn wybraneDruzyny = new();
        private Stream stream;
        private BinaryFormatter formatter = new BinaryFormatter();
        public OpcjeKwalifikacjeDalej()
        {
            InitializeComponent();
            if (File.Exists("WybraneDruzyny.bin"))
            {
                stream = File.Open("WybraneDruzyny.bin", FileMode.Open);
                wybraneDruzyny = (ListaDruzyn)formatter.Deserialize(stream);
                stream.Close();
            }
            else
            {
                wybraneDruzyny = new();
            }

            foreach (Druzyna druzyna in wybraneDruzyny.GetListaDruzyn())
            {
                Druzyny.Items.Add(druzyna);
            }
        }

        private void DodajDruzyny_Click(object sender, RoutedEventArgs e)
        {
            DodajDruzynyDoKwalifikacji dodajDruzynyDoKwalifikacji = new();
            
            
            foreach (Druzyna druzyna in wybraneDruzyny.GetListaDruzyn())
            {
                dodajDruzynyDoKwalifikacji.listaWybranychDruzynKontrolka.Items.Add(druzyna);
                dodajDruzynyDoKwalifikacji.listaDruzynKontrolka.Items.Remove(druzyna);
            }

            if (true == dodajDruzynyDoKwalifikacji.ShowDialog())
            {
                Druzyny.Items.Clear();
                foreach (Druzyna druzyna in dodajDruzynyDoKwalifikacji.listaWybranychDruzynKontrolka.Items)
                {
                    Druzyny.Items.Add(druzyna);
                    wybraneDruzyny.DodajDruzyne(druzyna);
                }

                ZapisDoPliku();
            }
        }
        public void ZapisDoPliku()
        {
            stream = File.Open("WybraneDruzyny.bin", FileMode.Create);
            formatter.Serialize(stream, wybraneDruzyny);
            stream.Close();
        }
    }
}
