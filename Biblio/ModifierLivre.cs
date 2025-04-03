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
    public partial class ModifierLivre : Form
    {   
        public BibliothequeEntities1 Entities;
        public Livre Livre;
        public LesLivres LesLivres;
        public byte[] imgb;
        // Constructeur: Initialise la fenêtre de modification avec le livre sélectionné
        public ModifierLivre(BibliothequeEntities1 entities, Livre livre)
        {
            InitializeComponent();
            Entities = entities;
            this.Livre = livre;
            this.LesLivres=new LesLivres(this.Entities);
            this.init();
        }
        // Charge les données du livre dans les champs du formulaire
        public void init()
        {
            this.titre.Text = this.Livre.Titre;
            this.auteur.Text = this.Livre.Auteur;
            var g = from p in this.Entities.Genre select p;
            foreach (Genre genre in g) 
            {
                this.genre.Items.Add(genre.Genre1);
            }
            this.genre.SelectedItem=this.Livre.Genre;

            if (this.Livre.image != null && this.Livre.image.Length > 0)  
            {
                // Convertir le tableau de bytes en image
                Image images = ByteArrayToImage(this.Livre.image);

                // Afficher l'image dans un PictureBox
                image.Image = images;
            }
            
        }
        // Ferme la fenêtre sans sauvegarder
        private void annuler_Click(object sender, EventArgs e)
        {
            this.Close();   
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
        // Permet de sélectionner une nouvelle image
        private void changerImage_Click(object sender, EventArgs e)
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
                this.imgb= ImageToByteArray(resizedImage);
            }
        }
        // Convertit une image en tableau de bytes pour stockage
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Vous pouvez changer le format si nécessaire
                return ms.ToArray();
            }
        }
        //Redimensionne une image en conservant ses proportions
        public static Image ResizeImage(Image image, int width, int height)
        {
            // Calcule le ratio pour conserver l'aspect de l'image
            double ratioX = (double)width / image.Width;
            double ratioY = (double)height / image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            // Calcule les nouvelles dimensions
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            // Crée une nouvelle image redimensionnée
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }
        //Sauvegarde les modifications du livre
        private void enregistrer_Click(object sender, EventArgs e)
        {
            string g=this.genre.SelectedItem.ToString();
            this.LesLivres.Modifier(this.Livre, this.titre.Text, this.auteur.Text,g,this.imgb);
            this.Close();
        }
    }
}
