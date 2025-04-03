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
    public partial class AjoutMembre : Form
    {
        public BibliothequeEntities1 BibliothequeEntities;
        public Personnes personnes;
        public Membres membres;
        public AjoutMembre(BibliothequeEntities1 bibliothequeEntities)
        {
            InitializeComponent();
            BibliothequeEntities = bibliothequeEntities;
            this.personnes = new Personnes(this.BibliothequeEntities);
            this.membres = new Membres();
        }
        //Permet de sélectionner et redimensionner une photo de profil
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
                Image resizedImage = ResizeImage(image, this.photo.Width, this.photo.Height);

                // Afficher l'image redimensionnée dans le PictureBox
                this.photo.Image = resizedImage;
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
        //Ferme la fenêtre sans sauvegarder
        private void annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Enregistre les informations du nouveau membre
        private void button1_Click(object sender, EventArgs e)
        {
            this.membres.Nom=this.nom.Text;
            this.membres.Prenom=this.prenom.Text;
            this.membres.Adresse=this.adresse.Text;
            this.membres.email=this.email.Text;
            this.membres.Telephone=this.tel.Text;
            if (this.photo.Image != null)
            {
                this.membres.image=ImageToByteArray(this.photo.Image);
            }
            this.personnes.add(this.membres);
            this.Close();
        }
        // Convertit une image en tableau de bytes pour le stockage
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
