using System.Collections.Generic;
using MongoDB.Bson;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.GestionsBD;

namespace TP2_14E_A2022.Data.Gestions;

public class GestionOutil : GestionOutil.IGestionOutil
{
    public interface IGestionOutil
    {
        Outils CreerOutil(ObjectId id, string nom, string description, bool estBrise);
        //Outils ModifierOutil(string nom, string description, bool estBrise);
        //Outils SupprimerOutil(string nom, string description, bool estBrise);
        //utils LireOutil (string nom, string description, bool estBrise);
    }

    public OutilDB OutilDb; 
    public List<Outils> outils;
    
    public GestionOutil(OutilDB _outilDb)
    {
        this.OutilDb = _outilDb;
        outils = OutilDb.GetOutils();
    }
    
    public Outils CreerOutil(ObjectId id, string nom, string description, bool estBrise)
    {
        var outil = new Outils(id, nom, description, estBrise);
        outils.Add(new Outils(id, nom, description, estBrise));
        
        return outil;
    }
}