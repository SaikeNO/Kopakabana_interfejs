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
        private BinaryFormatter formatter = new();
        private Sport Sport { get; set; }
        private string fileName;
        public OpcjeKwalifikacjeGeneruj(Sport sport, ListaDruzyn listaDruzyn)
        {
            InitializeComponent();
            Sport = sport;
            
            if(Sport is DwaOgnie)
            {
                fileName = "KwalifikacjeDwaOgnie.bin";
            }
            else if(Sport is PrzeciaganieLiny)
            {
                fileName = "KwalifikacjePrzeciaganieLiny.bin";
            }
            else
            {
                fileName = "KwalifikacjeSiatkowka.bin";
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

            kwalifikacje.GetListaRozgrywek().ForEach(rozgrywka => Rozgrywki.Items.Add(rozgrywka));
            kwalifikacje.GetTabela().ForEach(wiersz => Tabela.Items.Add(wiersz));
        }

        private void WybierzSedziego_Click(object sender, RoutedEventArgs e)
        {
            if (Rozgrywki.SelectedItem is not Rozgrywka rozgrywka) return;

            WybierzSedziego wybierzSedziego = new(rozgrywka);

            if(wybierzSedziego.ShowDialog() == true )
            {

            }
        }
        private void Rozegraj_Click(object sender, EventArgs e)
        {
            
        }
        public void ZapisDoPliku()
        {
            stream = File.Open(fileName, FileMode.Create);
            formatter.Serialize(stream, kwalifikacje);
            stream.Close();
        }
    }
}
