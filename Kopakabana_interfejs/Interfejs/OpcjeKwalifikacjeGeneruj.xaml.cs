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
    /// Logika interakcji dla klasy OpcjeKwalifikacjeGeneruj.xaml
    /// </summary>
    public partial class OpcjeKwalifikacjeGeneruj : Window
    {
        private Kwalifikacje kwalifikacje;
        private Stream? stream;
        private readonly BinaryFormatter formatter = new();
        private Sport Sport { get; set; }
        private string fileName = "KwalifikacjeSiatkowka.bin";
        private ListaDruzyn ListaDruzyn { get; set; }
        public OpcjeKwalifikacjeGeneruj(Sport sport, ListaDruzyn listaDruzyn)
        {
            InitializeComponent();
            Sport = sport;
            ListaDruzyn = listaDruzyn;
            SportKontrolka.Text = Sport.ToString();

            if (Sport is DwaOgnie)
            {
                fileName = "KwalifikacjeDwaOgnie.bin";
            }
            else if(Sport is PrzeciaganieLiny)
            {
                fileName = "KwalifikacjePrzeciaganieLiny.bin";
            }

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

        private void WybierzSedziego_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywki.SelectedItem is not Rozgrywka rozgrywka) return;

            WybierzSedziego wybierzSedziego = new(rozgrywka, Sport);

            if(wybierzSedziego.ShowDialog() == true )
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

                MessageBox.Show($"Rozgrywka została rozegrana!\nWygrana Drużyna: {rozgrywka.WygranaDruzyna}", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                kwalifikacje.Tabela.DodajPunkt(rozgrywka.WygranaDruzyna);
                kwalifikacje.Tabela.Sortuj();
                
                PrintListBoxes();
                ZapisDoPliku();
                
            }
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Czy chcesz zresetować kwalifikacje?", "box", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                kwalifikacje = new(Sport, ListaDruzyn);
                PrintListBoxes();
                File.Delete("Polfinaly.bin");
                File.Delete("WygranaDruzyna.bin");
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
        public void ZapisDoPliku()
        {
            stream = File.Open(fileName, FileMode.Create);
            formatter.Serialize(stream, kwalifikacje);
            stream.Close();
        }

        private void PrintListBoxes()
        {
            Rozgrywki.Items.Clear();
            Tabela.Items.Clear();
            kwalifikacje.GetListaRozgrywek().ForEach(rozgrywka => Rozgrywki.Items.Add(rozgrywka));
            kwalifikacje.GetTabela().ForEach(wiersz => Tabela.Items.Add(wiersz));
        }
    }
}
