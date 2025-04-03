using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblio
{
    public partial class Form1 : Form
    {
        public UserControl FormActive;
        public Button buttoncourant;
        public Button ancien;
        public BibliothequeEntities1 BibliothequeEntities;
        public Form1()
        {
            InitializeComponent();
            this.BibliothequeEntities = new BibliothequeEntities1();
            this.init();
        }
        //Charge l'interface d'accueil par défaut
        public void init()
        {
            this.ChangeFormulaire(this.home, new Home());
        }
        //Affiche l'interface de gestion des livres
        private void livres_Click(object sender, EventArgs e)
        {
            UserLivre userLivre = new UserLivre(this.BibliothequeEntities);
            this.ChangeFormulaire(this.livres, userLivre);
        }
        // Configure et affiche un contrôle utilisateur dans la zone principale
        public void activeFormulaire(UserControl Fm)
        {
            Fm.Dock = DockStyle.Fill;
            this.affichage.Controls.Add(Fm);
            this.affichage.Tag = Fm;
            //Fm.BringToFront();
            //Fm.Show();
        }
        //Affiche l'interface de gestion des membres
        private void home_Click(object sender, EventArgs e)
        {
            Home homes = new Home();
            this.ChangeFormulaire(this.home, homes);
        }
        private void membres_Click(object sender, EventArgs e)
        {
            UserMembre userMembre = new UserMembre(this.BibliothequeEntities);
            this.ChangeFormulaire(this.membres, userMembre);
           
        }
        // Affiche l'interface de gestion des emprunts
        private void emprunts_Click(object sender, EventArgs e)
        {
            lesEmprunts lstEmprunts = new lesEmprunts(this.BibliothequeEntities);
            this.ChangeFormulaire(this.emprunts, lstEmprunts);
        }
        // Gère le changement d'interface entre les différents modules
        public void ChangeFormulaire(Button btn,UserControl user1)
        {

            if (this.buttoncourant != null)
            {
                //this.buttoncourant.BackColor = this.ancien.BackColor;
                //this.buttoncourant=null;
                this.buttoncourant = btn;
                if (this.FormActive != null)
                {
                    this.affichage.Controls.Remove(this.FormActive);
                    this.FormActive = null;
                    this.FormActive = user1;
                    this.activeFormulaire(this.FormActive);
                }
                else
                {
                    this.FormActive = user1;
                    this.activeFormulaire(this.FormActive);
                }

            }
            else
            {
                this.buttoncourant = btn;
                //this.ancien = this.home;
                if (this.FormActive != null)
                {
                    this.affichage.Controls.Remove(this.FormActive);
                    this.FormActive = null;
                    this.FormActive =user1 ;
                    this.activeFormulaire(this.FormActive);
                }
                else
                {
                    this.FormActive = user1;
                    this.activeFormulaire(this.FormActive);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
