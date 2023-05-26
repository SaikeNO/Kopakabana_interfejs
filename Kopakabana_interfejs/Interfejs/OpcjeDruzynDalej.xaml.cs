using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
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
    /// Logika interakcji dla klasy OpcjeDruzynDalej.xaml
    /// </summary>
    public partial class OpcjeDruzynDalej : Window
    {
        private ListaDruzyn listaDruzyn;
        private Stream stream;
        private BinaryFormatter formatter;
        public OpcjeDruzynDalej()
        {
            InitializeComponent();

            if (File.Exists("Druzyny.bin"))
            {
                stream = File.Open("Druzyny.bin", FileMode.Open);
                formatter = new BinaryFormatter();
                listaDruzyn = (ListaDruzyn)formatter.Deserialize(stream);
                stream.Close();
            }
            else
            {
                listaDruzyn = new();
            }

            foreach (Druzyna d in listaDruzyn.GetListaDruzyn())
            {
                Druzyny.Items.Add(d);
            }
        }

        private void DodajDruzyne_Click(object sender, RoutedEventArgs e)
        {
            DodajDruzyne dodajDruzyne = new();
            if (true == dodajDruzyne.ShowDialog())
            {
                /*Druzyna druzyna = new(dodajDruzyne.NazwaDruzyny.Text, dodajDruzyne.listaZawodnikow);
                listaDruzyn.DodajDruzyne(druzyna);
                Druzyny.Items.Add(druzyna);
                */
                ZapisDoPliku();
            }
        }
        public void ZapisDoPliku()
        {
            stream = File.Open("Druzyny.bin", FileMode.Create);
            formatter.Serialize(stream, listaDruzyn);
            stream.Close();
        }
    }
}
