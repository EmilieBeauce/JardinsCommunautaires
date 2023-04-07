using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP2_14E_A2022.Data.Entites;

namespace TP2_14E_A2022.Data.GestionsBD
{
    public class PageConnexionBD
    {
        private const string GESTIONNAIRES_COLLECTION_NAME = "gestionnaires";
        private const string NOM_BASE_DE_DONNEES = "TP2DB";
        private readonly IMongoCollection<Gestionnaire> _gestionnairesCollection;

        public PageConnexionBD()
        {
            try
            {
                MongoClient client = DALConnexion.GetConnexion();
                var database = client.GetDatabase(NOM_BASE_DE_DONNEES);
                _gestionnairesCollection = database.GetCollection<Gestionnaire>(GESTIONNAIRES_COLLECTION_NAME);
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur s'est produite lors de la connexion à la base de données.", ex);
            }
        }
        public List<Gestionnaire> GetGestionnaires()
        {
            var gestionnaires = new List<Gestionnaire>();

            try
            {
                MongoClient client = DALConnexion.GetConnexion();
                IMongoDatabase db = client.GetDatabase(NOM_BASE_DE_DONNEES);
                gestionnaires = db.GetCollection<Gestionnaire>("gestionnaires").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return gestionnaires;
        }
        public bool SeConnecter(string courriel, string motDePasse)
        {
          
            try
            {
                var estConnecte = _gestionnairesCollection.Find(g => g.Courriel == courriel && g.MotDePasse == motDePasse).Any();
                return estConnecte;
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur s'est produite lors de la recherche du gestionnaire.", ex);
            }
        }
    }

}

