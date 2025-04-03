using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Personnes
    {
        public BibliothequeEntities1 Entities;
        public List<Membres> Listmembres;
        public Personnes( BibliothequeEntities1 bibliothequeEntities) 
        {
            this.Entities = bibliothequeEntities;
            this.init();
        }
        //Chargement des membres depuis la base de données dans une liste
        public void init()
        { 
            this.Listmembres = new List<Membres>();
            var lstmembre=from p in this.Entities.Membres select p;
            foreach(Membres m in lstmembre)
            {
                this.Listmembres.Add(m);
            }
        }
       //Ajout d'un membre dans la base de données et actualisation de la liste
        public void add(Membres m)
        {
            this.Entities.Membres.Add(m);
            this.Entities.SaveChanges();
            this.init();
        }
        //suppression d'un memenbre dans la base de données et actualisation de la liste
        public void remove(Membres m) 
        {
            var memb=this.Entities.Membres.Find(m.IdPersonne);
            if (memb != null) 
            {
                this.Entities.Membres.Remove(memb);
                this.Entities.SaveChanges() ;
                this.init() ;
            }
        }
        //Recherche d'un membre par son nom ou prénom
        public Membres recherche(string m)
        {
            var mb=m.ToUpper();
            Membres membres1=new Membres();
            if(this.Listmembres != null)
            {
                foreach(Membres membres in this.Listmembres)
                {
                    if (membres.Nom.ToUpper().Equals(mb)|| membres.Prenom.ToUpper().Equals(mb))
                    {
                        membres1= membres;
                    }
                }
            }
            return membres1;
        }
        //mis à jour des informations d'un membre existant
        public void Modifier(Membres mb)
        {
            var m = this.Entities.Membres.Find(mb.IdPersonne);
            m.email=mb.email;
            m.image=mb.image;
            m.Adresse=mb.Adresse;  
            m.Nom=mb.Nom;
            m.Prenom=mb.Prenom;
            m.Telephone = mb.Telephone;
            this.Entities.SaveChangesAsync() ;
            this.init();
        }
    }
}
