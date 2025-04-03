using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class ListeEmprunt
    {
        public BibliothequeEntities1 entities1;
        public List<Emprunts> emprunts1;
        public ListeEmprunt(BibliothequeEntities1 entities1)
        {
            this.entities1 = entities1;
            this.init();
            
        }
        //chargement des emprunts de la base de données dans une liste
        public void init()
        {
            this.emprunts1 = new List<Emprunts>();
            var emps = from p in this.entities1.Emprunts select p;
            foreach (Emprunts emp in emps)
            {
                this.emprunts1.Add(emp);
            }
        }
        //Ajout d'un emprunt dans la base de données
        public void add(Emprunts emprunt)
        { 
            this.entities1.Emprunts.Add(emprunt);
            this.entities1.SaveChanges();

        }
        //suppréssion d'un emprunt dans la base de données
        public void remove(Emprunts emprunt) 
        {
            var emp=this.entities1.Emprunts.Find(emprunt.IdEmprunts);
            var liv = this.entities1.Livre.Find(emprunt.LivreId);
            liv.Statut = "Disponible";
            this.entities1.Emprunts.Remove(emprunt);
            this.entities1.SaveChanges();
        }
        //Recherche d'un emprunts via le titre du livre
        public Emprunts recherche(string titre)
        {
            Emprunts emp = new Emprunts();
            foreach(Emprunts eps in this.emprunts1 )
            {
                if(eps.Livre.Titre.Equals(titre))
                {
                    emp=eps;
                }
            }
            return emp;
        }
    }
}
