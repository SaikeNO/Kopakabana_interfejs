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
        public DodajDruzynyDoKwalifikacji(ListaDruzyn wybraneDruzyny)
        {
            InitializeComponent();
            if (File.Exists("Druzyny.bin"))
            {
                BinaryFormatter formatter = new();
                Stream stream = File.Open("Druzyny.bin", FileMode.Open);
                ListaDruzyn listaDruzyn = (ListaDruzyn)formatter.Deserialize(stream);
                stream.Close();
                
                listaDruzyn.GetListaDruzyn().ForEach(druzyna => listaDruzynKontrolka.Items.Add(druzyna));
            }

            wybraneDruzyny.GetListaDruzyn().ForEach(druzyna => MoveToWybraneDruzyny(druzyna));
        }

        private void OnOK_click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (listaDruzynKontrolka.SelectedItem is not Druzyna druzyna) return;

            MoveToWybraneDruzyny(druzyna);
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (listaWybranychDruzynKontrolka.SelectedItem is not Druzyna druzyna) return;

            MoveToDruzyny(druzyna);
        }
        public void MoveToWybraneDruzyny(Druzyna druzyna)
        {
            listaWybranychDruzynKontrolka.Items.Add(druzyna);
            listaDruzynKontrolka.Items.Remove(druzyna);
        }
        public void MoveToDruzyny(Druzyna druzyna)
        {
            listaDruzynKontrolka.Items.Add(druzyna);
            listaWybranychDruzynKontrolka.Items.Remove(druzyna);
        }
    }
}
