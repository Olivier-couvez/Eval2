using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ConvertisseurPrix
{
    /// <summary>
    /// Logique d'interaction pour GestionTaxe.xaml
    /// </summary>
    public partial class GestionTaxe : Window, INotifyPropertyChanged
    {
        private string tauxTaxe;
        public string TauxTaxe { get { return tauxTaxe; } set { tauxTaxe = value; OnPropertyChanged("TauxTaxe"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public GestionTaxe()
        {
            InitializeComponent();
            this.DataContext = this;
            txtbTaxe.Focus();
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));

            }
        }

        private void txtbTaxe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Close();
            }
        }
    }
}
