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

namespace Biblio
{
    public partial class UserLivre : UserControl
    {
        public BibliothequeEntities1 Entities;
        public LesLivres LesLivres;
        public Livre Livre;
        //// Constructeur: Initialise le contrôle utilisateur avec la connexion à la base de données
        public UserLivre(BibliothequeEntities1 entities)
        {
            InitializeComponent();
            
            Entities = entities;
            this.Livre=new Livre();
            this.LesLivres= new LesLivres(this.Entities);
            this.init();
        }
        // Initialise l'interface et charge la liste des livres par genre
        public void init()
        {
            this.affichage.Text = "";
            this.image.Image=null;
            this.lslivres.Nodes.Clear();
            foreach (Genre g in this.Entities.Genre)
            {
                TreeNode n1 = new TreeNode(g.Genre1);
                List<Livre> LstGenre = new List<Livre>();

                foreach (Livre l in this.LesLivres.lslivre)
                {
                    if (l.Genre.Equals(g.Genre1))
                    {
                        TreeNode n1child = new TreeNode(l.Titre);
                        n1.Nodes.Add(n1child);
                    }
                }
                this.lslivres.Nodes.Add(n1);


            }

        }
        // Affiche les détails du livre sélectionné
        private void lslivres_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            TreeNode nd = tv.SelectedNode;
            
            if (nd.Level > 0)
            {
                this.Livre = this.LesLivres.Recherche(nd.Text);
                if (this.Livre!=null)
                {
                    this.affichage.Text = this.Livre.affichage();
                    if (this.Livre.image != null)
                    {
                        Image imgLivre = this.ByteArrayToImage(this.Livre.image);
                        Image resizedImage = ResizeImage(imgLivre, this.image.Width, this.image.Height);

                        // Afficher l'image redimensionnée dans le PictureBox
                        this.image.Image = resizedImage;
                    }
                   
                    
                }

            }
        }
        //Réinitialise l'affichage
        private void Actualiser_Click(object sender, EventArgs e)
        {
            this.Livre=new Livre();
            this.init();
        }
        //Supprime le livre sélectionné
        private void supprimer_Click(object sender, EventArgs e)
        {
            if (this.Livre.IdLivre!= 0)
            {
                this.LesLivres.remove(this.Livre);
               
                this.init();
            }

            
        }
        //Ouvre la fenêtre de modification du livre
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Livre.IdLivre != 0)
            {
                this.Hide();
                ModifierLivre modifierLivre = new ModifierLivre(this.Entities, this.Livre);
                modifierLivre.ShowDialog();
                this.Show();
                this.init();
            }
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

        private void ajouter_Click(object sender, EventArgs e)
        {
            this.Hide();
            AjoutLivrecs ajout = new AjoutLivrecs(this.Entities);
            ajout.ShowDialog();
            this.Show();
            
            this.init();
        }
        //Ouvre la fenêtre d'emprunt pour le livre sélectionné
        private void emprunter_Click(object sender, EventArgs e)
        {
            if (this.Livre.IdLivre != 0)
            {
                this.Hide();
                Emprunter emprunter = new Emprunter(this.Livre, this.Entities);
                emprunter.ShowDialog();
                this.Show();
                this.init();
            }
            
        }
    }
}
