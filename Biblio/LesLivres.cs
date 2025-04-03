using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class LesLivres
    {
        public List<Livre> lslivre;
        public BibliothequeEntities1 Entities;
        public LesLivres(BibliothequeEntities1 entities)
        {
            Entities = entities;
            this.init();
        }
        //Chargement des livres depuis la base de données dans une liste
        public void init()
        {
            this.lslivre = new List<Livre>();
            var livres = from p in this.Entities.Livre select p;
            foreach (Livre l in livres)
            {
                this.lslivre.Add(l);
            }
        }
        //Ajout d'un nouveau livre à la base et actualisation de la liste
        public void add(Livre l)
        {
            this.Entities.Livre.Add(l);
            this.Entities.SaveChanges();
            this.init();
        }
        //Suppréssion d'un livre dans la base et actualisation la liste
        public void remove(Livre l)
        {
            var liv = this.Entities.Livre.Find(l.IdLivre);
            this.Entities.Livre.Remove(l);
            this.Entities.SaveChanges();
            this.init();
        }
        //Recherche d'un livre par son titre exact
        public Livre Recherche(string titre)
        {

            Livre liv = new Livre();
            foreach (Livre l in this.lslivre)
            {
                if (l.Titre.Equals(titre))
                {
                    liv = l;
                }

            }
            return liv;
        }
        //Mis à jour des informations d'un livre existant
        public void Modifier(Livre l, string titre, string auteur, string genre, byte[] img)
        {
            var livres = this.Entities.Livre.Find(l.IdLivre);
            livres.Titre = titre;
            livres.Auteur= auteur;
            livres.Genre= genre;
            livres.image= img;
            this.Entities.SaveChanges();
            this.init();
        }
    }
}
