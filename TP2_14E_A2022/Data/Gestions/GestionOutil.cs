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
    
    const string MESSAGE_ERREUR = "{0} ne peux avoir une valeur par défault qui est null ou vide!";
    
    public GestionOutil(IOutilDB  outilDb)
    {
        _outilDb = outilDb;
        outils = _outilDb.GetOutils();
    }
    
    public List<Outils> LireTousLesOutils()
    {
        return _outilDb.GetOutils();
    }
    public Outils CreerOutil(ObjectId id, string nom, string description, bool estBrise)
    {
        if (id == default(ObjectId))
        {
            throw new ArgumentNullException(string.Format(MESSAGE_ERREUR, nameof(id)), nameof(id));        
        }

        if (string.IsNullOrEmpty(nom))
        {
            throw new ArgumentNullException(string.Format(MESSAGE_ERREUR, nameof(nom)), nameof(nom));            
        }

        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentNullException(string.Format(MESSAGE_ERREUR, nameof(description)), nameof(description));        
        }

        var outil = new Outils(id, nom, description, estBrise);
        _outilDb.CreerOutil(outil);
        
        return outil;
    }

    
    public void SupprimerOutil(ObjectId id)
    {
        if (id == default(ObjectId))
        {
            throw new ArgumentException(string.Format(MESSAGE_ERREUR, nameof(id)), nameof(id));        
        }
        _outilDb.SupprimerOutil(id);
    }

    public void ModifierOutil(Outils outil)
    {
        if (outil == null)
        {
            throw new ArgumentNullException(string.Format(MESSAGE_ERREUR, nameof(outil)));
        }

        if (outil.Id == default(ObjectId))
        {
            throw new ArgumentException(string.Format(MESSAGE_ERREUR, nameof(outil.Id)), nameof(outil.Id));        
        }

        if (string.IsNullOrEmpty(outil.Nom))
        {
            throw new ArgumentException(string.Format(MESSAGE_ERREUR, nameof(outil.Nom)), nameof(outil.Nom));        
        }

        if (string.IsNullOrEmpty(outil.Description))
        {
            throw new ArgumentException(string.Format(MESSAGE_ERREUR, nameof(outil.Description)), nameof(outil.Description));        
        }

        _outilDb.ModifierOutil(outil);
    }

    
    public Outils GetOutilById(ObjectId id)
    {
        if (id == default(ObjectId))
        {
            throw new ArgumentException(string.Format(MESSAGE_ERREUR, nameof(id)), nameof(id));        
        }
        
        return _outilDb.GetOutilById(id);
    }
    
}