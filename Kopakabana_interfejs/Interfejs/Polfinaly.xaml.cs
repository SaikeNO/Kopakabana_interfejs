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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Kopakabana
{
    /// <summary>
    /// Logika interakcji dla klasy Polfinaly.xaml
    /// </summary>
    public partial class Polfinaly : Window
    {
        private Stream? stream;
        private readonly BinaryFormatter formatter = new();
        private readonly string fileName = "Polfinaly.bin";
        private readonly List<Rozgrywka> listaRozgrywek = new();
        private readonly List<Druzyna?> wygraneDruzyny = new();
        private Druzyna? ZwycieskaDruzyna;
        private Sport Sport { get; set; }  
        public Polfinaly(ListaDruzyn listaDruzyn, Sport sport)
        {
            InitializeComponent();
            Sport = sport;
            SportKontrolka.Text = sport.ToString();
            if (File.Exists(fileName))
            {
                stream = File.Open(fileName, FileMode.Open);
                listaRozgrywek = (List<Rozgrywka>)formatter.Deserialize(stream);
                stream.Close();
            } 
            else
            {
                listaRozgrywek.Add(new(listaDruzyn.GetListaDruzyn()[0], listaDruzyn.GetListaDruzyn()[1]));
                listaRozgrywek.Add(new(listaDruzyn.GetListaDruzyn()[2], listaDruzyn.GetListaDruzyn()[3]));
            }

            if(File.Exists("WygranaDruzyna.bin")) 
            {
                stream = File.Open("WygranaDruzyna.bin", FileMode.Open);
                ZwycieskaDruzyna = (Druzyna)formatter.Deserialize(stream);
                stream.Close();
            }

            foreach(Rozgrywka rozgrywka in listaRozgrywek)
            {
                Rozgrywki.Items.Add(rozgrywka);
                if(rozgrywka.WygranaDruzyna is not null)
                {
                    wygraneDruzyny.Add(rozgrywka.WygranaDruzyna);
                }
            }
        }
        private void WybierzSedziego_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywki.SelectedItem is not Rozgrywka rozgrywka) return;

            WybierzSedziego wybierzSedziego = new(rozgrywka, Sport);

            if (wybierzSedziego.ShowDialog() == true)
            {
                rozgrywka.Sedzia = wybierzSedziego.SedziowieKontrolka.SelectedItem as Sedzia;
                Rozgrywki.Items.Refresh();
                ZapisDoPliku();
            }
        }
        private void Rozegraj_Click(object sender, EventArgs e)
        {
            if (Rozgrywki.SelectedItem is not Rozgrywka rozgrywka) return;

            if (rozgrywka.Sedzia is null)
            {
                MessageBox.Show("Wybierz sędziego!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            OpcjeRozegraj opcjeRozegraj = new(rozgrywka);

            if (opcjeRozegraj.ShowDialog() == true)
            {
                rozgrywka.WygranaDruzyna = opcjeRozegraj.Druzyna1Kontrolka.Content as Druzyna;
                if (opcjeRozegraj.Druzyna2Kontrolka.IsChecked == true)
                {
                    rozgrywka.WygranaDruzyna = opcjeRozegraj.Druzyna2Kontrolka.Content as Druzyna;
                }

                wygraneDruzyny.Add(rozgrywka.WygranaDruzyna);
                MessageBox.Show($"Rozgrywka została rozegrana!\nWygrana Drużyna: {rozgrywka.WygranaDruzyna}", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                ZapisDoPliku();
            }
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy chcesz zresetować półfinały?", "box", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                wygraneDruzyny.Clear();
                ZwycieskaDruzyna = null;
                listaRozgrywek[0].WygranaDruzyna = null;
                listaRozgrywek[1].WygranaDruzyna = null;
                listaRozgrywek[0].Sedzia = null;
                listaRozgrywek[1].Sedzia = null;
                Rozgrywki.Items.Refresh();
                File.Delete("WygranaDruzyna.bin");
                ZapisDoPliku();
            }
        }
        public void ZapisDoPliku()
        {
            stream = File.Open(fileName, FileMode.Create);
            formatter.Serialize(stream, listaRozgrywek);
            stream.Close();
        }

        private void Final_Click(object sender, RoutedEventArgs e)
        {
            if (listaRozgrywek[0].WygranaDruzyna is null && listaRozgrywek[1].WygranaDruzyna is null)
            {
                MessageBox.Show("Najpierw rozegraj półfinały", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (ZwycieskaDruzyna is not null)
            {
                MessageBox.Show($"Finał został rozegrany!\nZwycięska Drużyna: {ZwycieskaDruzyna}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Rozgrywka final = new(wygraneDruzyny[0], wygraneDruzyny[1]);
                OpcjeRozegraj opcjeFinal = new(final);
                if (opcjeFinal.ShowDialog() == true)
                {
                    final.WygranaDruzyna = opcjeFinal.Druzyna1Kontrolka.Content as Druzyna;
                    if (opcjeFinal.Druzyna2Kontrolka.IsChecked == true)
                    {
                        final.WygranaDruzyna = opcjeFinal.Druzyna2Kontrolka.Content as Druzyna;
                    }
                    ZwycieskaDruzyna = final.WygranaDruzyna;
                    stream = File.Open("WygranaDruzyna.bin", FileMode.Create);
                    formatter.Serialize(stream, ZwycieskaDruzyna);
                    stream.Close();
                    MessageBox.Show($"Finał został rozegrany!\nZwycięska Drużyna: {final.WygranaDruzyna}", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
