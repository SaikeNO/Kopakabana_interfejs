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
    /// Logika interakcji dla klasy DodajDruzynyDoKwalifikacji.xaml
    /// </summary>
    public partial class DodajDruzynyDoKwalifikacji : Window
    {
        private ListaDruzyn listaDruzyn;
        private Stream stream;
        private BinaryFormatter formatter = new BinaryFormatter();
        public DodajDruzynyDoKwalifikacji()
        {
            InitializeComponent();
            if (File.Exists("Druzyny.bin"))
            {
                stream = File.Open("Druzyny.bin", FileMode.Open);
                listaDruzyn = (ListaDruzyn)formatter.Deserialize(stream);
                stream.Close();
            }
            else
            {
                listaDruzyn = new();
            }

            foreach (Druzyna druzyna in listaDruzyn.GetListaDruzyn())
            {
                listaDruzynKontrolka.Items.Add(druzyna);
            }
        }

        private void OnOK_click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(listaDruzynKontrolka.SelectedItem != null)
            {
                listaWybranychDruzynKontrolka.Items.Add(listaDruzynKontrolka.SelectedItem as Druzyna);
                listaDruzynKontrolka.Items.Remove(listaDruzynKontrolka.SelectedItem as Druzyna);
            }
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (listaWybranychDruzynKontrolka.SelectedItem != null)
            {
                listaDruzynKontrolka.Items.Add(listaWybranychDruzynKontrolka.SelectedItem as Druzyna);
                listaWybranychDruzynKontrolka.Items.Remove(listaWybranychDruzynKontrolka.SelectedItem as Druzyna);
            }
        }
    }
}
