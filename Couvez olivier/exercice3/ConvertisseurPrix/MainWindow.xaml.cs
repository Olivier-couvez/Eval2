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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConvertisseurPrix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        double tauxTaxe = 20;

        private string prixttc;
        public string PrixTTC { get { return prixttc; } set { prixttc = value; OnPropertyChanged("PrixTTC"); } }

        private string prixht;
        public string PrixHT { get { return prixht; } set { prixht = value; OnPropertyChanged("PrixHT"); } }

        public ICommand CommandeTaxe { get; set; }
        public ICommand CommandeSens { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            CommandeTaxe = new Command(CommandeTaxeAction);
            CommandeSens = new Command(CommandeSensAction);
            txtbTTC.IsEnabled = false;
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));

                if (v == "PrixTTC")
                {
                    if ((PrixTTC != "") && (txtbTTC.IsEnabled == true))
                    {
                        try
                        {
                            PrixHT = (Convert.ToDouble(PrixTTC) / (1 + (tauxTaxe / 100))).ToString("#.## €");
                        }
                        catch
                        {
                            MessageBox.Show("Erreur dans votre saisie !");
                        }
                    }
                }

                if (v == "PrixHT")
                {
                    if ((PrixHT != "") && (txtbHT.IsEnabled == true))
                    {
                        try
                        {
                            PrixTTC = (Convert.ToDouble(PrixHT) +(Convert.ToDouble(PrixHT)  * tauxTaxe / 100)).ToString("#.## €");
                        }
                        catch
                        {
                            MessageBox.Show("Erreur dans votre saisie !");
                        }
                    }
                }

            }
        }

        public void CommandeTaxeAction(object parametre)
        {
            GestionTaxe fenGestionTaxe = new GestionTaxe();
            fenGestionTaxe.TauxTaxe = Convert.ToString(20);
            fenGestionTaxe.ShowDialog();
            try
            {
                tauxTaxe = Convert.ToDouble(fenGestionTaxe.TauxTaxe);
            }
            catch
            {
                MessageBox.Show("erreur dans la saisie du taux de taxe, taxe remise à 20%");
                tauxTaxe = 20;
            }
        }

        public void CommandeSensAction(object parametre)
        {
            if(txtbTTC.IsEnabled == true)
            {
                txtbTTC.IsEnabled = false;
                txtbHT.IsEnabled = true;
                PrixHT = "";
                txtbHT.Focus();
                lblTitre.Content = "Convertisseur HT <--> TTC";
            }
            else
            {
                txtbTTC.IsEnabled = true;
                txtbHT.IsEnabled = false;
                PrixTTC = "";
                txtbTTC.Focus();
                lblTitre.Content = "Convertisseur TTC <--> HT";
            }
        }

    }
}
