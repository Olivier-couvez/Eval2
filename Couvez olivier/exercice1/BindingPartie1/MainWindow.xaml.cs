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

namespace BindingPartie1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            MetreSaisi = Convert.ToString(0);
        }
        private string metreSaisi;
        public string MetreSaisi { get { return metreSaisi; } set { metreSaisi = value; OnPropertyChanged("MetreSaisi"); } }

        private string convDcm;
        public string ConvDcm { get { return convDcm; } set { convDcm = value; } }

        private string convCm;
        public string ConvCm { get { return convCm; } set { convCm = value; } }

        private string convMm;
        public string ConvMm { get { return convMm; } set { convMm = value; } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtbMetre.Focus();
        }
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                double tempTempo = 0;
                PropertyChanged(this, new PropertyChangedEventArgs(v));
                if (MetreSaisi != "")
                {
                    try
                    {
                        tempTempo = Convert.ToDouble(MetreSaisi);
                    }
                    catch
                    {
                        if (MetreSaisi != "-")
                        {
                            MessageBox.Show("Erreur de saisie", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }

                    ConvDcm = Convert.ToString(tempTempo*10);
                    ConvCm = Convert.ToString(tempTempo*100);
                    ConvMm = Convert.ToString(tempTempo*1000);
                    PropertyChanged(this, new PropertyChangedEventArgs("ConvDcm"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ConvCm"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ConvMm"));
                }
            }
        }
    }
}
