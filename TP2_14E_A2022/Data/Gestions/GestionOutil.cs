using System;
using System.Collections.Generic;
using MongoDB.Bson;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.GestionsBD;

namespace TP2_14E_A2022.Data.Gestions;

public class GestionOutil : IGestionOutil
{
    private readonly IOutilDB _outilDb;
    public List<Outils> outils;
    public GestionOutil(IOutilDB  outilDb)
    {
        _outilDb = outilDb;
        outils = _outilDb.GetOutils();
        
        //Before le deuxième refactoring
        //_gestionOutil = gestionOutil;
        
        
        //Before le "refactoring"
        //this.OutilDb = _outilDb;
        //outils = OutilDb.GetOutils();
    }
    
    public List<Outils> LireTousLesOutils()
    {
        return _outilDb.GetOutils();
    }
    public Outils CreerOutil(ObjectId id, string nom, string description, bool estBrise)
    {
        if (id == default(ObjectId))
        {
            throw new ArgumentNullException(nameof(id));
        }
    
        if (string.IsNullOrEmpty(nom))
        {
            throw new ArgumentException("Nom cannot be null or empty.", nameof(nom));
        }
        
        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentException("Description cannot be null or empty.", nameof(nom));
        }

        var outil = new Outils(id, nom, description, estBrise);
        outils.Add(new Outils(id, nom, description, estBrise));

        return outil;
    }
    
    public void SupprimerOutil(ObjectId id)
    {
        _outilDb.SupprimerOutil(id);
    }

    public void ModifierOutil(Outils outil)
    {
        _outilDb.ModifierOutil(outil);
    }
    
    
}