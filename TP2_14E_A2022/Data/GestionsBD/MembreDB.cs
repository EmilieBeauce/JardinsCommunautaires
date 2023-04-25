using DynamicData.Kernel;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
using static TP2_14E_A2022.Data.Gestions.GestionConnexion;

namespace TP2_14E_A2022.Data.GestionsBD
{
    public class MembreDB
    {
        private DAL dal;
        public GestionMembre gestionMembre ;

        public MembreDB()
        {
            dal = new DAL();
        }
        /** obtenir la liste des membres */
        public virtual List<Membre> GetMembres()
        {
            var membres = new List<Membre>();

            try
            {
               var db = dal.GetDatabase();
               membres = db.GetCollection<Membre>("Membres").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return membres;
        }
        /** ajouter un membre */
        public bool AjouterMembre(string prenom, string nom, bool estPaye, ObjectId? adresseCivique,  ObjectId? idLot, ObjectId? idCotisation)
        {
            try
            {
                MembreDB membreDB = new MembreDB();
                gestionMembre = new GestionMembre(membreDB);
                var db = dal.GetDatabase();
                Membre membre = gestionMembre.CreerMembre(prenom, nom, estPaye, adresseCivique, idLot, idCotisation);
                db.GetCollection<Membre>("Membres").InsertOne(membre);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création du compte : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        /** voir le detail d'un membre */
        public Membre GetMembre(ObjectId idMembre)
        {
            Membre membre = new Membre();
            try
            {
                var db = dal.GetDatabase();
                membre = db.GetCollection<Membre>("Membres").Find(m => m.Id == idMembre).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la requête : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return membre;
        }
        /** modifier un membre */
        public bool ModifierMembreDB(ObjectId idMembre, string prenom, string nom, ObjectId? idAdresseCivique, ObjectId? idLot, ObjectId? idCotisation)
        {
            try
            {
                var db = dal.GetDatabase();
                var membreCollection = db.GetCollection<Membre>("Membres");
                var membre = membreCollection.Find(m => m.Id == idMembre).FirstOrDefault();

                if (membre == null)
                {
                    MessageBox.Show("Ce membre n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                membre.Prenom = prenom;
                membre.Nom = nom;
                membre.IdAdresseCivique = idAdresseCivique;
                membre.IdLot = idLot;
                membre.IdCotisation = idCotisation;

                membreCollection.ReplaceOne(m => m.Id == idMembre, membre);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification du membre : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        /** supprimer un membre */
        public bool SupprimerMembre(ObjectId idMembre)
        {
            try
            {
                var db = dal.GetDatabase();
                db.GetCollection<Membre>("Membres").DeleteOne(m => m.Id == idMembre);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression du membre : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        
        public void UpdateEstPayeStatusInDatabase()
        {
            try
            {
                var db = dal.GetDatabase();

                var filter = Builders<Membre>.Filter.Empty;
                var update = Builders<Membre>.Update.Set("EstPaye", true);
                db.GetCollection<Membre>("Membres").UpdateMany(filter, update);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du statut EstPaye : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public void UpdateMembreEstPaye(ObjectId membreId, bool estPaye)
        {
            try
            {
                var db = dal.GetDatabase();
                var membreCollection = db.GetCollection<Membre>("Membres");

                var filter = Builders<Membre>.Filter.Eq(m => m.Id, membreId);
                var update = Builders<Membre>.Update.Set(m => m.EstPaye, estPaye);

                if (estPaye)
                {
                    update = update.Set(m => m.Cotisation, 0);
                }

                membreCollection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du statut EstPaye : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public bool UpdateCotisation(ObjectId memberId, int newCotisation)
        {
            try
            {
                var db = dal.GetDatabase();
                var membreCollection = db.GetCollection<Membre>("Membres");
                var membre = membreCollection.Find(m => m.Id == memberId).FirstOrDefault();

                if (membre == null)
                {
                    MessageBox.Show("Ce membre n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                
                if (membre.EstPaye)
                {
                    newCotisation = 0;
                }

                membre.Cotisation = newCotisation;

                var filter = Builders<Membre>.Filter.Eq(m => m.Id, memberId);
                var update = Builders<Membre>.Update.Set(m => m.Cotisation, newCotisation);

                membreCollection.UpdateOne(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour de la cotisation : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


        


    }
}
