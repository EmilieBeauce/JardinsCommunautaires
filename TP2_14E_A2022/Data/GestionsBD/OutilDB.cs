using System;
using System.Collections.Generic;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Driver;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;

namespace TP2_14E_A2022.Data.GestionsBD;

public class OutilDB : IOutilDB
{
    private DAL dal;
    private const string MESSAGE_ERREUR_CONNEXION = "Impossible de se connecter à la base de données";
    private const string MESSAGE_ERREUR = "ERREUR";
    
    public OutilDB()
    {
        dal = new DAL();
    }
    
    private IMongoCollection<Outils> GetOutilsCollection()
    {
        var db = dal.GetDatabase();
        return db.GetCollection<Outils>("Outils");
    }

    public virtual List<Outils> GetOutils()
    {
        var outils = new List<Outils>();
        
        try
        {
            outils = GetOutilsCollection().Aggregate().ToList();        
        }

        catch (Exception ex)
        {
            MessageBox.Show(MESSAGE_ERREUR_CONNEXION + ex.Message, MESSAGE_ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        return outils;
    }
    
    public void CreerOutil(Outils outil)
    {
        try
        {
            GetOutilsCollection().InsertOne(outil);
        }
        catch (Exception ex)
        {
            MessageBox.Show(MESSAGE_ERREUR_CONNEXION+ ex.Message, MESSAGE_ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    
    public void SupprimerOutil(ObjectId id)
    {
        try
        {
            var filter = Builders<Outils>.Filter.Eq(o => o.Id, id);
            GetOutilsCollection().DeleteOne(filter);
        }
        catch (Exception ex)
        {
            MessageBox.Show(MESSAGE_ERREUR_CONNEXION + ex.Message, MESSAGE_ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public void ModifierOutil(Outils outil)
    {
        try
        {
            var filter = Builders<Outils>.Filter.Eq(o => o.Id, outil.Id);
            var update = Builders<Outils>.Update
                .Set(o => o.Nom, outil.Nom)
                .Set(o => o.Description, outil.Description)
                .Set(o => o.EstBrise, outil.EstBrise);

            GetOutilsCollection().UpdateOne(filter, update);
        }
        catch (Exception ex)
        {
            MessageBox.Show(MESSAGE_ERREUR_CONNEXION + ex.Message, MESSAGE_ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    
    public Outils GetOutilById(ObjectId id)
    {
        Outils outil = null;

        try
        {
            var collection = GetOutilsCollection();
            outil = collection.Find(o => o.Id == id).FirstOrDefault();
        }
        catch (Exception ex)
        {
            MessageBox.Show(MESSAGE_ERREUR_CONNEXION + ex.Message, MESSAGE_ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        return outil;
    }


}