using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Biblio
{
    public partial class UserMembre : UserControl
    {
        public BibliothequeEntities1 Entities;
        public Personnes personnes;
        public Membres membres;
        // Constructeur: Initialise le contrôle avec la connexion à la base de données
        public UserMembre(BibliothequeEntities1 entities)
        {
            InitializeComponent();
            Entities = entities;
            this.personnes=new Personnes(this.Entities);
            this.membres = new Membres();
            this.init();
        }
        // Configure et remplit le DataGridView avec la liste des membres
        public void init()
        {
           
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();
            this.affichage.Text = "";
            this.image.Image = null;
            this.personnes.init();
            
            DataGridViewTextBoxColumn ID = new DataGridViewTextBoxColumn();
            ID.HeaderText = "IdPersonne";
            ID.Name = "Id";
            ID.ReadOnly = true;
            //Nom
            DataGridViewTextBoxColumn Nom = new DataGridViewTextBoxColumn();
            Nom.HeaderText = "Nom";
            Nom.Name = "Nom";
            Nom.ReadOnly = true;
            
            //Prenom
            DataGridViewTextBoxColumn Prenom = new DataGridViewTextBoxColumn();
            Prenom.HeaderText = "Prenom";
            Prenom.Name = "Prenom";
            Prenom.ReadOnly = false;

            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Nom, Prenom });
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = false;
            if (this.personnes.Listmembres.Count > 0) 
            {
                this.dataGridView1.Rows.Add(this.personnes.Listmembres.Count);
                for (int i = 0; i < this.personnes.Listmembres.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["Id"].Value = this.personnes.Listmembres[i].IdPersonne;
                    this.dataGridView1.Rows[i].Cells["Nom"].Value = this.personnes.Listmembres[i].Nom;
                    this.dataGridView1.Rows[i].Cells["Prenom"].Value = this.personnes.Listmembres[i].Prenom;
                    
                }
            }


        }
        //Ouvre la fenêtre d'ajout d'un nouveau membre
        private void add_Click(object sender, EventArgs e)
        {
            AjoutMembre ajoutMembre = new AjoutMembre(this.Entities);
            ajoutMembre.Show();
            this.init();
        }
        // Affiche les détails du membre sélectionné
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.image.Image = null;
            // Vérifier si l'index de la ligne est valide
            if (e.RowIndex >= 0)
            {
                // Récupérer la ligne sélectionnée
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                // Récupérer la valeur de la cellule "Titre"
                string titre = row.Cells["Nom"].Value?.ToString();

                this.membres = this.personnes.recherche(titre);
                if (this.membres != null) 
                {
                    this.affichage.Text = this.membres.affichage();
                    if (this.membres.image != null)
                    {
                        Image imgLivre = this.ByteArrayToImage(this.membres.image);
                        Image resizedImage = ResizeImage(imgLivre, this.image.Width, this.image.Height);
                        
                        // Afficher l'image redimensionnée dans le PictureBox
                        this.image.Image = resizedImage;
                    }

                    else 
                    { 
                    }
                    
                }
               

            }
        }


        //Réinitialise l'affichage
        private void button1_Click(object sender, EventArgs e)
        {
            this.membres = new Membres();
            this.init();
        }
        // Méthode pour convertir un tableau de bytes en image
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                // Créer une image à partir du MemoryStream
                Image image = Image.FromStream(ms);
                return image;
            }
        }
        public static Image ResizeImage(Image image, int width, int height)
        {
            // Calculer le ratio pour conserver l'aspect de l'image
            double ratioX = (double)width / image.Width;
            double ratioY = (double)height / image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            // Calculer les nouvelles dimensions
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            // Créer une nouvelle image redimensionnée
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }
        // Supprime le membre sélectionné
        private void supprimer_Click(object sender, EventArgs e)
        {
            if (this.membres.IdPersonne != 0)
            {
                this.personnes.remove(this.membres);
                this.init();
            }  
        }
        //Ouvre la fenêtre de modification du membre
        private void modifier_Click(object sender, EventArgs e)
        {
            if (this.membres.IdPersonne != 0)
            {
                ModifierMembre modifierMembre = new ModifierMembre(this.Entities, this.membres);
                modifierMembre.Show();
                this.init();
            }
        }
    }
}
