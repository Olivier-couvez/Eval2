
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
        int PlageJeu = 1000;
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
        public string Proposition { get { return proposition; } set { proposition = value; } }

        private string message;
        public string Message { get { return message; } set { message = value; } }

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
                if (v == "NbEssai")
                {
                    Nb_EssaiJeu = Convert.ToInt16(NbEssai);
                    nbEssaisReste = Convert.ToInt16(NbEssai);
                }

                if (v == "Plage")
                {
                    PlageJeu = Convert.ToInt16(Plage);
                }            
            }

            
        }
        private void CommandePropositionAction(object parametre)
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

                        nbEssaisReste = 0;

                    }
                }

                Proposition = "0";

                nbEssaisReste = nbEssaisReste - 1;
            }
            if (nbEssaisReste == 0)
            {
                MessageBox.Show("Désolé, vous n'avez trouvé le nombre mystère ! c'était le chiffe " + nbAChercher);
                jeuEnCours = false;
            }

        }

        private void CommandeNouveauAction(object parametre)
        {
            Message = "";

            nbEssaisReste = Convert.ToInt16(NbEssai); // Initialise le nombre d'essais restant !

            // génération du nombre aléatoire
            nbAChercher = NbAlea(ref minNb, ref maxNb);
            trouve = false;
            jeuEnCours = false;

            // Affichage du message de début de jeu

           Message = "Choisissez votre nombre d'essais";
        }

        static int NbAlea(ref int minAlea, ref int maxAlea)
        {
            Random aleat = new Random();

            return aleat.Next(minAlea, maxAlea);
        }



        private void txtbProposition_KeyDown(object sender, KeyEventArgs e)
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
                                    jeuEnCours = false;

                                    nbEssaisReste = 0;

                                }
                            }

                            Proposition = "0";

                            nbEssaisReste = nbEssaisReste - 1;
                        }
                        if (nbEssaisReste == 0)
                        {
                            MessageBox.Show("Désolé, vous n'avez trouvé le nombre mystère ! c'était le chiffe " + nbAChercher);
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
