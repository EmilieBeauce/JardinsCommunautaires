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
        private const string MESSAGE_ERREUR_CONNEXION = "Impossible de se connecter à la base de données";
        private const string MESSAGE_ERREUR = "Erreur";
        
        private DAL dal;

        public MembreDB()
        {
            dal = new DAL();
        }

        private IMongoCollection<Membre> GetMembresCollection()
        {
            var db = dal.GetDatabase();
            return db.GetCollection<Membre>("Membres");
        }
        
        /** obtenir la liste des membres */
        public virtual List<Membre> GetMembres()
        {
            var membres = new List<Membre>();

            try
            {
                membres = GetMembresCollection().Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(MESSAGE_ERREUR_CONNEXION + ex.Message, MESSAGE_ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return membres;
        }
        /** ajouter un membre */
        public bool AjouterMembre(Membre membre)
        {
            try
            {
                GetMembresCollection().InsertOne(membre);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création du compte : " + ex.Message, MESSAGE_ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


        /** voir le detail d'un membre */
        public virtual Membre GetMembre(ObjectId idMembre)
        {
            Membre membre = new Membre();

            try
            {
                membre = GetMembresCollection().Find(m => m.Id == idMembre).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la requête : " + ex.Message, MESSAGE_ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return membre;
        }

        /** modifier un membre */
        public bool ModifierMembreDB(Membre updatedMembre)
        {
            try
            {
                var filter = Builders<Membre>.Filter.Eq(m => m.Id, updatedMembre.Id);
                GetMembresCollection().ReplaceOne(filter, updatedMembre);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification du membre : " + ex.Message, MESSAGE_ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        /** supprimer un membre */
        public bool SupprimerMembre(ObjectId idMembre)
        {
            try
            {
                var filter = Builders<Membre>.Filter.Eq(m => m.Id, idMembre);
                GetMembresCollection().DeleteOne(filter);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression du membre : " + ex.Message, MESSAGE_ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        
        public void UpdateEstPayeStatusInDatabase()
        {
            try
            {
                var filter = Builders<Membre>.Filter.Empty;
                var update = Builders<Membre>.Update.Set("EstPaye", true);
                GetMembresCollection().UpdateMany(filter, update);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du statut EstPaye : " + ex.Message, MESSAGE_ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
        public void UpdateMembreEstPaye(ObjectId membreId, bool estPaye)
        {
            try
            {
                var membreCollection = GetMembresCollection();

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
        public virtual bool UpdateCotisation(ObjectId memberId, int newCotisation)
        {
            try
            {
                var membreCollection = GetMembresCollection();
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
