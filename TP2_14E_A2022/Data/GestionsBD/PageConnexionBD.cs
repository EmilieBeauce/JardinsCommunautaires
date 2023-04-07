using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;

namespace TP2_14E_A2022.Data.GestionsBD
{
    public class PageConnexionBD
    {
        private DAL dal;
        private GestionConnexion gestionConnexion;

        public PageConnexionBD()
        {
            dal = new DAL();
        }
        public List<Gestionnaire> GetGestionnaires()
        {
            var gestionnaires = new List<Gestionnaire>();

            try
            {
                var db = dal.GetDatabase();
                gestionnaires = db.GetCollection<Gestionnaire>("Gestionnaires").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return gestionnaires;
        }
        public bool ValiderSiConnexionFonctionne(string courriel, string motDePasse)
        {
            bool estConnecte = false;

            try
            {
                estConnecte = GetGestionnaires().Any(g => g.Courriel == courriel && g.MotDePasse == motDePasse);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connexion : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return estConnecte;
        }

        public void CreerCompteGestionnaire(string prenom, string nom, string courriel, string motDePasse)
        {
            try
            {
                var db = dal.GetDatabase();
                Gestionnaire gestionnaire = gestionConnexion.CreerCompteGestionnaire(prenom, nom, courriel, motDePasse);
                db.GetCollection<Gestionnaire>("Gestionnaires").InsertOne(gestionnaire);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création du compte : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}




