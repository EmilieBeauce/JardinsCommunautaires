using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;
using static TP2_14E_A2022.Data.GestionsBD.PageConnexionBD;

namespace TP2_14E_A2022.Data.GestionsBD
{
    public class PageConnexionBD : IPageConnexionBD
    {
        public interface IPageConnexionBD
        {
            List<Gestionnaire> GetGestionnaires();
            bool CreateGestionnaireBD(string prenom, string nom, string courriel, string motDePasse);
        }
        private DAL dal;
        public GestionConnexion gestionConnexion;

        public PageConnexionBD()
        {
            dal = new DAL();
        }
        /** faire une listes de gestionnaires*/
        public virtual List<Gestionnaire> GetGestionnaires()
        {
            var gestionnaires = new List<Gestionnaire>();

            try
            {
                var db = dal.GetDatabase();
                gestionnaires = db.GetCollection<Gestionnaire>("Gestionnaires").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible de se connecter à la base de données ", ex.Message);
            }
            return gestionnaires;
        }
        /** aller chercher le nom et prenom du gestionaire pour des fin d'afficahge*/
        public string GetPrenomNomGestionnaire(string courriel)
        {
            var db = dal.GetDatabase();
            var gestionnaire = db.GetCollection<Gestionnaire>("Gestionnaires").Find(g => g.Courriel == courriel).FirstOrDefault();
            return gestionnaire.Prenom + " " + gestionnaire.Nom;
        }
        /** créer un gestionnaire */
        public bool CreateGestionnaireBD(string prenom, string nom, string courriel, string motDePasse)
        {
            try
            {
                PageConnexionBD pageConnexionBD = new PageConnexionBD();
                gestionConnexion = new GestionConnexion(pageConnexionBD);
                var db = dal.GetDatabase();
                Gestionnaire gestionnaire = gestionConnexion.CreerCompteGestionnaire(prenom, nom, courriel, motDePasse);
                db.GetCollection<Gestionnaire>("Gestionnaires").InsertOne(gestionnaire);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : Le gestionnaire n'a pas rempli tous les champs convenablement", ex.Message);
                return false;
            }
        }
        /** Valider si le courriel existe*/
        public bool ValiderSiCourrielExiste(string courriel)
        {
            var db = dal.GetDatabase();
            var gestionnaire = db.GetCollection<Gestionnaire>("Gestionnaires").Find(g => g.Courriel == courriel).FirstOrDefault();
            if (gestionnaire == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /** Valider Si le Mot De Passe Est Le Bon */
        public bool ValiderSiMotDePasseEstLeBon(string courriel, string motDePasse)
        {
            var db = dal.GetDatabase();
            var MotDePasseEstBon = false;
            var gestionnaire = db.GetCollection<Gestionnaire>("Gestionnaires").Find(g => g.Courriel == courriel).FirstOrDefault();
            if (gestionnaire.MotDePasse == motDePasse)
            {
                MotDePasseEstBon = true;
            }
            else
            {
                MotDePasseEstBon = false;
            }
            return MotDePasseEstBon;
        }
    }
}




