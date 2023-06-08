using Kopakabana;
using Kopakabana_interfejs.Interfejs;
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

namespace Kopakabana_interfejs
{
    /// <summary>
    /// Logika interakcji dla klasy OpcjeKwalifikacjiGenerujSiatkowka.xaml
    /// </summary>
    public partial class OpcjeKwalifikacjiGenerujSiatkowka : Window
    {
        private Kwalifikacje kwalifikacje;
        private Stream? stream;
        private readonly BinaryFormatter formatter = new();
        private Sport Sport { get; set; }
        private string fileName = "KwalifikacjeSiatkowka.bin";
        private ListaDruzyn ListaDruzyn { get; set; }
        public OpcjeKwalifikacjiGenerujSiatkowka(Sport sport, ListaDruzyn listaDruzyn)
        {
            InitializeComponent();
            Sport = sport;
            ListaDruzyn = listaDruzyn;
            if (File.Exists(fileName))
            {
                stream = File.Open(fileName, FileMode.Open);
                kwalifikacje = (Kwalifikacje)formatter.Deserialize(stream);
                stream.Close();
            }
            else
            {
                kwalifikacje = new(Sport, listaDruzyn);
            }
            PrintListBoxes();
            ZapisDoPliku();
        }

        public void ZapisDoPliku()
        {
            stream = File.Open(fileName, FileMode.Create);
            formatter.Serialize(stream, kwalifikacje);
            stream.Close();
        }

        private void PrintListBoxes()
        {
            RozgrywkaSiatkowka.Items.Clear();
            Tabela.Items.Clear();
            kwalifikacje.GetListaRozgrywek().ForEach(rozgrywka => RozgrywkaSiatkowka.Items.Add(rozgrywka));
            kwalifikacje.GetTabela().ForEach(wiersz => Tabela.Items.Add(wiersz));
        }

        private void Rozegraj_Click(object sender, RoutedEventArgs e)
        {
            if (RozgrywkaSiatkowka.SelectedItem is not Rozgrywka rozgrywka) return;

            if (rozgrywka.Sedzia is null)
            {
                MessageBox.Show("Wybierz sędziow!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

                MessageBox.Show($"Rozgrywka została rozegrana!\nWygrana Drużyna: {rozgrywka.WygranaDruzyna}", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                kwalifikacje.Tabela.DodajPunkt(rozgrywka.WygranaDruzyna);
                kwalifikacje.Tabela.Sortuj();

                PrintListBoxes();
                ZapisDoPliku();

            }
        }

        private void Polfinaly_Click(object sender, RoutedEventArgs e)
        {
            if (kwalifikacje.CzyRozegrane())
            {
                Polfinaly polfinaly = new(kwalifikacje.ZnajdzNajlepsze4(), Sport);
                polfinaly.ShowDialog();
            }
            else
            {
                MessageBox.Show("Najpierw rozegraj wszystkie kwalifikacje!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy chcesz zresetować kwalifikacje?", "box", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                kwalifikacje = new(Sport, ListaDruzyn);
                PrintListBoxes();
                File.Delete("Polfinaly.bin");
                File.Delete("WygranaDruzyna.bin");
                ZapisDoPliku();
            }
        }

        private void Wybierz_sedziego_glownego_Click(object sender, RoutedEventArgs e)
        {
            if (RozgrywkaSiatkowka.SelectedItem is not RozgrywkaSiatkowka rozgrywka) return;

            DodanieSedziowSiatkowki sedziowieSiatkowki = new(rozgrywka, Sport);
            
            if (sedziowieSiatkowki.ShowDialog() == true)
            {
                rozgrywka.Sedzia = (Sedzia)sedziowieSiatkowki.SedziowieKontrolkaGlowna.SelectedItem;
                rozgrywka.sedzia1 = (Sedzia)sedziowieSiatkowki.SedziowieKontrolkaPom1.SelectedItem;
                rozgrywka.sedzia2 = (Sedzia)sedziowieSiatkowki.SedziowieKontrolkaPom2.SelectedItem;

                RozgrywkaSiatkowka.Items.Refresh();
                ZapisDoPliku();
            }
         
        }

        
    }
}
