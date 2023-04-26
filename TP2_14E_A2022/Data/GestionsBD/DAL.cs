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
        private const string NOM_BD = "TP2DB";
        private const string MESSAGE_ERREUR = "Impossible de se connecter à la base de données. Erreur";
        private readonly MongoClient _mongoDBClient;

        public DAL()
        {
            _mongoDBClient = OpenConnection();
        }

        public IMongoDatabase GetDatabase()
        {
            try
            {
                return _mongoDBClient.GetDatabase(NOM_BD);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{MESSAGE_ERREUR} {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        private static MongoClient OpenConnection()
        {
            try
            {
                return new MongoClient(CHAINE_CONNEXION);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{MESSAGE_ERREUR} {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }



}
