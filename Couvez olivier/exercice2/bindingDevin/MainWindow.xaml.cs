
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

namespace bindingDevin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        int Nb_EssaiJeu = 10;
        Int32 PlageJeu = 1000;
        private int nbEssaisReste = 10;
        private bool jeuEnCours = false;
        private Int32 nbAChercher = 0;
        private Int32 minNb = 0;
        private Int32 maxNb = 1000;
        private bool trouve = false;

        private string nbEssai;
        public string NbEssai { get { return nbEssai; } set { nbEssai = value; OnPropertyChanged("NbEssai"); } }

        private string plage;
        public string Plage { get { return plage; } set { plage = value; OnPropertyChanged("Plage"); } }

        private string proposition;
        public string Proposition { get { return proposition; } set { proposition = value; OnPropertyChanged("Proposition"); } }

        private string message;
        public string Message { get { return message; } set { message = value; OnPropertyChanged("Message"); } }

        public ICommand CommandeProposition { get; set; }
        public ICommand CommandeNouveau { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            CommandeProposition = new Command(CommandePropositionAction);
            CommandeNouveau = new Command(CommandeNouveauAction);
            nbAChercher = NbAlea(ref minNb, ref maxNb);
            NbEssai = Convert.ToString(Nb_EssaiJeu);
            Plage = Convert.ToString(PlageJeu);
            Message = "Choisissez votre nombre d'essais et la plage de jeu";
            txtbProposition.IsEnabled = false;
        }

        private void JeuDuDevin_Loaded(object sender, RoutedEventArgs e)
        {
            {
                txtbEssai.Focus();
            }
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));

                if (v == "NbEssai")
                {
                    if (NbEssai != "")
                    {
                        if ((Convert.ToInt16(NbEssai) < 10) || (Convert.ToInt16(NbEssai) > 30))
                        {
                            MessageBox.Show("La nombre d'essais d'oit être compris entre 10 et 30");
                            Nb_EssaiJeu = 10;
                            nbEssaisReste = 10;
                        }
                        else
                        {
                            Nb_EssaiJeu = Convert.ToInt16(NbEssai);
                            nbEssaisReste = Convert.ToInt16(NbEssai);
                        }
                    }
                }

                if (v == "Plage")
                {
                    if (Plage != "")
                    {
                        if ((Convert.ToInt16(Plage) < 1000) || (Convert.ToInt32(Plage) > 100000))
                        {
                            MessageBox.Show("La nombre d'essais d'oit être compris entre 1000 et 100000");
                            Nb_EssaiJeu = 1000;
                            nbEssaisReste = 1000;
                        }
                        else
                        {
                            PlageJeu = Convert.ToInt16(Plage);
                            maxNb = Convert.ToInt16(Plage);
                        }
                    }
                }
            }


        }
        public void CommandePropositionAction(object parametre)
        {
            if (nbEssaisReste != 0)
            {
                // A mettre au premier essais !

                if (nbEssaisReste == Convert.ToInt16(NbEssai))
                {
                    jeuEnCours = true;
                }


                if (Convert.ToInt32(Proposition) > nbAChercher)
                {
                    Message = "le nombre à trouver est plus petit";
                }
                else
                {
                    if (Convert.ToInt32(Proposition) < nbAChercher)
                    {
                        Message = "le nombre à trouver est plus grand";
                    }
                    else
                    {
                        MessageBox.Show("BRAVO, vous avez trouvé le nombre mystère !");
                        jeuEnCours = false;
                        txtbProposition.IsEnabled = false;
                        txtbEssai.IsEnabled = true;
                        txtbPlage.IsEnabled = true;
                        nbEssaisReste = 0;

                    }
                }

                Proposition = "";
                txtbProposition.Focus();
                nbEssaisReste = nbEssaisReste - 1;
            }
            if (nbEssaisReste == 0)
            {
                MessageBox.Show("Désolé, vous n'avez trouvé le nombre mystère ! c'était le chiffe " + nbAChercher);
                txtbProposition.IsEnabled = false;
                txtbEssai.IsEnabled = true;
                txtbPlage.IsEnabled = true;
                jeuEnCours = false;
            }

        }

        public void CommandeNouveauAction(object parametre)
        {
            Message = "";

            nbEssaisReste = Convert.ToInt16(NbEssai); // Initialise le nombre d'essais restant !

            // génération du nombre aléatoire
            nbAChercher = NbAlea(ref minNb, ref maxNb);
            trouve = false;
            jeuEnCours = false;

            // Affichage du message de début de jeu

            Message = "Choisissez votre nombre d'essais";
            txtbProposition.IsEnabled = true;
            txtbEssai.IsEnabled = false;
            txtbPlage.IsEnabled = false;
        }

        static int NbAlea(ref int minAlea, ref int maxAlea)
        {
            Random aleat = new Random();
            return aleat.Next(minAlea, maxAlea);
        }



        public void txtbProposition_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {

                    if (nbEssaisReste != 0)
                    {
                        // A mettre au premier essais !

                        if (nbEssaisReste == Convert.ToInt16(NbEssai))
                        {
                            jeuEnCours = true;
                        }


                        if (Convert.ToInt32(Proposition) > nbAChercher)
                        {
                            Message = "le nombre à trouver est plus petit";
                        }
                        else
                        {
                            if (Convert.ToInt32(Proposition) < nbAChercher)
                            {
                                Message = "le nombre à trouver est plus grand";
                            }
                            else
                            {
                                MessageBox.Show("BRAVO, vous avez trouvé le nombre mystère !");
                                txtbProposition.IsEnabled = false;
                                txtbEssai.IsEnabled = true;
                                txtbPlage.IsEnabled = true;
                                jeuEnCours = false;
                                nbEssaisReste = 0;

                            }
                        }

                        Proposition = "";
                        txtbProposition.Focus();
                        nbEssaisReste = nbEssaisReste - 1;
                    }
                    if (nbEssaisReste == 0)
                    {
                        MessageBox.Show("Désolé, vous n'avez trouvé le nombre mystère ! c'était le chiffe " + nbAChercher);
                        txtbProposition.IsEnabled = false;
                        txtbEssai.IsEnabled = true;
                        txtbPlage.IsEnabled = true;
                        jeuEnCours = false;
                    }
                }
            }
            catch
            {

                MessageBox.Show("Saisir un chiffre!");
            }
        }
    }
}
