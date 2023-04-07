using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MongoDB.Driver;

namespace TP2_14E_A2022.Data.GestionsBD
{
    public class DALConnexion
    {
        private static MongoClient mongoDBClient;
        private static MongoClient OuvrirConnexion()
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

        public static MongoClient GetConnexion()
        {
            if (mongoDBClient == null)
            {
                mongoDBClient = OuvrirConnexion();
            }
            return mongoDBClient;
        }
    }
}