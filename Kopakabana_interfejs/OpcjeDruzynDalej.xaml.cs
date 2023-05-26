using System;
using System.Collections.Generic;
using System.Linq;
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
        public OpcjeDruzynDalej()
        {
            InitializeComponent();
        }

        private void DodajDruzyne_Click(object sender, RoutedEventArgs e)
        {
            DodajDruzyne dodajDruzyne = new DodajDruzyne();
            dodajDruzyne.ShowDialog();
        }
    }
}
