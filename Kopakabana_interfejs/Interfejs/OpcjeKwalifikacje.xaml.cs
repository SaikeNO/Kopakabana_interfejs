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
    /// Logika interakcji dla klasy OpcjeKwalifikacje.xaml
    /// </summary>
    public partial class OpcjeKwalifikacje : Window
    {
        private Kwalifikacje kwalifikacje;
        public OpcjeKwalifikacje()
        {
            InitializeComponent();
        }

        private void Tabela_Click(object sender, RoutedEventArgs e)
        {
            OpcjeTabela opcjeTabela = new();
            opcjeTabela.ShowDialog();
        }

        private void Kwalifikacje_Click(object sender, RoutedEventArgs e)
        {
            OpcjeDruzynDalej opcjeDruzynDalej = new OpcjeDruzynDalej();
            opcjeDruzynDalej.ShowDialog();
        }
    }
}
