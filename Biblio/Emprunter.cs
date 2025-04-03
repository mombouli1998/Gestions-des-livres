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
    public partial class Emprunter : Form
    {
        public Livre livre;
        public BibliothequeEntities1 Entities;
        public Personnes personnes;
        public Membres membres;
        //Initialise la fenêtre d'emprunt avec le livre sélectionné
        public Emprunter(Livre livre,BibliothequeEntities1 entities)
        {
            InitializeComponent();
            this.livre = livre;
            this.Entities = entities;
            this.personnes=new Personnes(this.Entities);
            this.membres = new Membres();
            this.init();
        }
        //Affiche les informations du livre à emprunter
        public void init()
        {
            this.affiche.Text = this.livre.affichage();
        }
        //Recherche un membre par son nom et affiche ses informations
        private void recherche_Click(object sender, EventArgs e)
        {
            if (this.rechercheNom != null) 
            {
                this.membres = this.personnes.recherche(this.rechercheNom.Text);
                if (this.membres.IdPersonne != 0)
                {
                    this.nom.Text = this.membres.Nom;
                    this.prenom.Text=this.membres.Prenom;
                    this.adresse.Text=this.membres.Adresse;
                    this.tel.Text = this.membres.Telephone;
                    this.email.Text = this.membres.email;
                    
                }
                
            }
        }
        //Ferme la fenêtre sans effectuer l'emprunt
        private void annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Gère l'emprunt du livre (nouveau membre ou membre existant)
        private void emp_Click(object sender, EventArgs e)
        {
            if (this.membres.IdPersonne == 0)
            {
                this.membres.Nom = this.nom.Text;
                this.membres.Prenom = this.prenom.Text;
                this.membres.Adresse = this.adresse.Text;
                this.membres.Telephone = this.tel.Text;
                this.membres.email = this.email.Text;
                Emprunts emp=new Emprunts();
                emp.DateRetour = this.dateR.Value;
                emp.DateEmprunt = this.dateE.Value;
                this.livre.Statut = "Indisponible";
                this.livre.nbEmprunt += 1;
                this.personnes.add(this.membres);
                emp.Membres = this.personnes.recherche(this.nom.Text);
                emp.Livre=this.livre;
                this.Entities.Emprunts.Add(emp);
                this.Entities.SaveChanges();

            }
            else
            {
                Emprunts emp = new Emprunts();
                emp.DateRetour = this.dateR.Value;
                emp.DateEmprunt = this.dateE.Value;
                this.livre.nbEmprunt += 1;
                this.livre.Statut = "Indisponible";
                emp.Membres = this.personnes.recherche(this.nom.Text);
                emp.Livre = this.livre;
                this.Entities.Emprunts.Add(emp);
                this.Entities.SaveChanges();
            }
            this.Close();
        }
    }
}
