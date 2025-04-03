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
    public partial class ModifierMembre : Form
    {
        public BibliothequeEntities1 entities;
        public Membres membres;
        public Personnes personnes;
        //Constructeur: Initialise la fenêtre avec les données du membre à modifier
        public ModifierMembre(BibliothequeEntities1 entities,Membres mb)
        {
            InitializeComponent();
            this.entities = entities;
            this.membres= mb;
            this.personnes=new Personnes(this.entities);
            this.init();
        }
        //Charge les données du membre dans les champs du formulaire
        public void init() 
        {
            this.nom.Text = this.membres.Nom;
            this.prenom.Text=this.membres.Prenom;
            this.adresse.Text= this.membres.Adresse;
            this.email.Text=this.membres.email;
            this.tel.Text=this.membres.Telephone;
            if (this.membres.image != null)
            {
                Image imgLivre = this.ByteArrayToImage(this.membres.image);
                Image resizedImage = ResizeImage(imgLivre, this.image.Width, this.image.Height);

                // Afficher l'image redimensionnée dans le PictureBox
                this.image.Image = resizedImage;
            }
        }
        // Ferme la fenêtre sans sauvegarder
        private void annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Permet de modifier la photo du membre
        private void changerLimage_Click(object sender, EventArgs e)
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
                this.membres.image = ImageToByteArray(resizedImage);
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
        // Redimensionne une image en conservant ses proportions
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
        // Convertit un tableau de bytes en image affichable
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                // Créer une image à partir du MemoryStream
                Image image = Image.FromStream(ms);
                return image;
            }
        }
        // Sauvegarde les modifications du membre
        private void enregistrer_Click(object sender, EventArgs e)
        {
            this.personnes.Modifier(this.membres);
            this.Close();
        }
    }
}
