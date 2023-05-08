using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MongoDB.Bson;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;
using static TP2_14E_A2022.Data.GestionsBD.PageConnexionBD;

namespace TP2_14E_A2022.Data.GestionsBD
{
    public class PageConnexionBD : IPageConnexionBD
    {
        private DAL dal;
        public GestionConnexion gestionConnexion;
        private const string MESSAGE_ERREUR = "Impossible de se connecter à la base de données ";

        public PageConnexionBD()
        {
            dal = new DAL();
        }

        private IMongoCollection<Gestionnaire> GetGestionnairesCollection()
        {
            var db = dal.GetDatabase();
            return db.GetCollection<Gestionnaire>("Gestionnaires");
        }
        public virtual List<Gestionnaire> GetGestionnaires()
        {
            try
            {
                return GetGestionnairesCollection().Aggregate().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(MESSAGE_ERREUR, ex.Message);
                
                return new List<Gestionnaire>();
            }
        }
        public string GetPrenomNomGestionnaire(string courriel)
        {
            var gestionnaire = GetGestionnairesCollection().Find(g => g.Courriel == courriel).FirstOrDefault();
            return gestionnaire != null ? $"{gestionnaire.Prenom} {gestionnaire.Nom}" : string.Empty;
        }
        public bool CreateGestionnaireBD(string prenom, string nom, string courriel, string motDePasse)
        {
            try
            {
                var gestionnaire = new Gestionnaire(ObjectId.GenerateNewId(), prenom, nom, courriel, motDePasse);
                GetGestionnairesCollection().InsertOne(gestionnaire);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : Le gestionnaire n'a pas rempli tous les champs convenablement", ex.Message);
                return false;
            }
        }
        
        public bool ValiderSiCourrielExiste(string courriel)
        {
            var gestionnaire = GetGestionnairesCollection().Find(g => g.Courriel == courriel).FirstOrDefault();
            return gestionnaire != null;
        }
        
        public bool ValiderSiMotDePasseEstLeBon(string courriel, string motDePasse)
        {
            var gestionnaire = GetGestionnairesCollection().Find(g => g.Courriel == courriel).FirstOrDefault();
            return gestionnaire != null && gestionnaire.MotDePasse == motDePasse;
        }
    }
}




