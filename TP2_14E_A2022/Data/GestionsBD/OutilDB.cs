using System;
using System.Collections.Generic;
using System.Windows;
using MongoDB.Driver;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;

namespace TP2_14E_A2022.Data.GestionsBD;

public interface IOutilDB
{
    List<Outils> GetOutils();
        
}

public class OutilDB : IOutilDB
{
    private DAL dal;
    public GestionOutil gestionOutil;

    public OutilDB()
    {
        dal = new DAL();
    }

    public virtual List<Outils> GetOutils()
    {
        var outils = new List<Outils>();
        
        try
        {
            var db = dal.GetDatabase();
            outils = db.GetCollection<Outils>("Outils").Aggregate().ToList();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        return outils;
    }
    
    public void CreerOutil(Outils outil)
    {
        try
        {
            var db = dal.GetDatabase();
            db.GetCollection<Outils>("Outils").InsertOne(outil);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }


}