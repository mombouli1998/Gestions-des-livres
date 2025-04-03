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
    public partial class lesEmprunts : UserControl
    {
        public BibliothequeEntities1 Entities;
        public ListeEmprunt listeEmprunt;
        public Emprunts emp;
        //Constructeur: Initialise les composants et charge la liste des emprunts
        public lesEmprunts(BibliothequeEntities1 entities)
        {
            InitializeComponent();
            Entities = entities;
            this.emp = new Emprunts();
            this.listeEmprunt = new ListeEmprunt(this.Entities);
            this.init();
        }
        //Configuration et remplissage du DataGridView avec la liste des emprunts
        public void init()
        {

            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();
            this.listeEmprunt = new ListeEmprunt(this.Entities);
            this.affichage.Text = "";
            DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn();
            ID.HeaderText = "IdEmprunt";
            ID.Name = "Id";
            ID.ReadOnly = true;
            //Titre
            DataGridViewTextBoxColumn Titre = new DataGridViewTextBoxColumn();
            Titre.HeaderText = "Titre";
            Titre.Name = "Titre";
            Titre.ReadOnly = true;
            //Nom
            DataGridViewTextBoxColumn Nom = new DataGridViewTextBoxColumn();
            Nom.HeaderText = "Nom";
            Nom.Name = "Nom";
            Nom.ReadOnly = true;
            //Prenom
            DataGridViewTextBoxColumn Prenom = new DataGridViewTextBoxColumn();
            Prenom.HeaderText = "Prenom";
            Prenom.Name = "Prenom";
            Prenom.ReadOnly = true;

            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Titre, Nom, Prenom });
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = false;
            if (this.listeEmprunt.emprunts1.Count > 0)
            {
                this.dataGridView1.Rows.Add(this.listeEmprunt.emprunts1.Count);
                for (int i = 0; i < this.listeEmprunt.emprunts1.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["Id"].Value = this.listeEmprunt.emprunts1[i].IdEmprunts;
                    this.dataGridView1.Rows[i].Cells["Titre"].Value = this.listeEmprunt.emprunts1[i].Livre.Titre;
                    this.dataGridView1.Rows[i].Cells["Nom"].Value = this.listeEmprunt.emprunts1[i].Membres.Nom;
                    this.dataGridView1.Rows[i].Cells["Prenom"].Value = this.listeEmprunt.emprunts1[i].Membres.Prenom;

                }
            }
        }
        //Gestion du retour d'un emprunt sélectionné
        private void retour_Click(object sender, EventArgs e)
        {
            if (this.emp.IdEmprunts != 0)
            {
                this.listeEmprunt.remove(this.emp);
                this.init();
            }
        }
        //Affichage des détails de l'emprunt sélectionné
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifier si l'index de la ligne est valide
            if (e.RowIndex >= 0)
            {
                // Récupérer la ligne sélectionnée
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                // Récupérer la valeur de la cellule "Titre"
                string titre = row.Cells["titre"].Value?.ToString();
                this.emp=this.listeEmprunt.recherche(titre);
                if(this.emp.IdEmprunts!=0)
                {
                    this.affichage.Text = this.emp.affichage();
                }


            }
        }
    }
}
