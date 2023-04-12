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
        private const string CHAINE_CONNEXION = "mongodb://localhost:27017/TP2DB";
        private const string NOM_BASE_DE_DONNEES = "TP2DB";
        private readonly MongoClient mongoDBClient;

        public DAL()
        {
            mongoDBClient = OuvrirConnexion();

        }
        /** get la data base mettre dans une variable db */
      public IMongoDatabase GetDatabase()
        {
            IMongoDatabase db = mongoDBClient.GetDatabase(NOM_BASE_DE_DONNEES);
            return db;
        }

        public static MongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                Console.Write("succes here");
                dbClient = new MongoClient(CHAINE_CONNEXION);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dbClient;
        }

    }

   
}
