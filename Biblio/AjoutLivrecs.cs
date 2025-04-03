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
    public partial class AjoutLivrecs : Form
    {
        public BibliothequeEntities1 entities;
        public Livre Livre;
        public LesLivres LesLivres;
        //Initialise la fenêtre d'ajout de livre et charge les genres disponibles
        public AjoutLivrecs(BibliothequeEntities1 entities)
        {
            InitializeComponent();
            this.entities = entities;
            this.Livre = new Livre();
            this.LesLivres = new LesLivres(this.entities);
            this.init();
        }
        //Remplit la liste déroulante des genres disponibles
        public void init()
        {
            foreach(Genre g in this.entities.Genre)
            {
                this.genre.Items.Add(g.Genre1);
            }
            //this.genre.SelectedItem = this.entities.Genre.Find(1).Genre1;
        }
        //Ferme la fenêtre sans sauvegarder
        private void annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Enregistre le nouveau livre avec ses informations
        private void enregistrer_Click(object sender, EventArgs e)
        {
            this.Livre.Titre = this.titre.Text;
            this.Livre.Auteur = this.auteur.Text;
            this.Livre.Statut = "Disponible";
            this.Livre.DatePublication = this.date.Value;
            this.Livre.Genre= this.genre.SelectedItem.ToString();
            this.Livre.Isbn = this.isbn.Text;
            if(this.image!=null )
            {
                this.Livre.image = ImageToByteArray(this.image.Image);
                
            }
            this.LesLivres.add(this.Livre);
            this.Close();

        }
        //Ouvre un dialogue pour sélectionner une image de couverture
        private void charger_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Configurer le filtre pour les fichiers image
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Sélectionner une image";

            // Afficher le dialogue de sélection de fichier
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Charger l'image sélectionnée dans le PictureBox
                // this.photo.Image = new Bitmap(openFileDialog.FileName);
                // Charger l'image sélectionnée
                Image image = Image.FromFile(openFileDialog.FileName);

                // Redimensionner l'image pour qu'elle s'adapte au PictureBox
                Image resizedImage = ResizeImage(image, this.image.Width, this.image.Height);

                // Afficher l'image redimensionnée dans le PictureBox
                this.image.Image = resizedImage;

            }
        }
        //Redimensionne une image tout en conservant ses proportions
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
        // Convertit une image en tableau de bytes pour le stockage en base
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Vous pouvez changer le format si nécessaire
                return ms.ToArray();
            }
        }

    }
}
