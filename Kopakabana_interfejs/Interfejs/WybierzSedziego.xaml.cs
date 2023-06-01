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
    /// Logika interakcji dla klasy WybierzSedziego.xaml
    /// </summary>
    public partial class WybierzSedziego : Window
    {
        private readonly Kantorek kantorek;
        private readonly Stream? stream;
        private readonly BinaryFormatter formatter = new();
        public WybierzSedziego(Rozgrywka rozgrywka)
        {
            InitializeComponent();
            Rozgrywka.Text = rozgrywka.ToString();

            if (File.Exists("Sedziowie.bin"))
            {
                stream = File.Open("Sedziowie.bin", FileMode.Open);
                kantorek = (Kantorek)formatter.Deserialize(stream);
                stream.Close();
            }
            else
            {
                kantorek = new();
            }

            foreach (Sedzia sedzia in kantorek.GetSedziowie())
            {
                //listaSedziow.Items.Add(sedzia);
            }
        }
    }
}
