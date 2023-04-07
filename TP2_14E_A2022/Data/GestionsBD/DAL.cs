using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using TP2_14E_A2022.Data.Entites;

namespace TP2_14E_A2022.Data.GestionsBD
{
    public class DAL
    {
        private MongoClient mongoDBClient;

        public DAL()
        {
            mongoDBClient = DALConnexion.GetConnexion();
        }

        public List<Gestionnaire> GetGestionnaires()
        {
            var gestionnaires = new List<Gestionnaire>();

            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                gestionnaires = db.GetCollection<Gestionnaire>("Gestionnaires").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return gestionnaires;
        }

        public MongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                dbClient = new MongoClient("mongodb://localhost:27017/TP2DB");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dbClient;
        }

    }
}
