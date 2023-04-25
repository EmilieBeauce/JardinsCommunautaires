using System.Collections.Generic;
using MongoDB.Bson;
using TP2_14E_A2022.Data.Entites;

namespace TP2_14E_A2022.Data.Gestions;

public interface IGestionOutil
{
    Outils CreerOutil(ObjectId id, string nom, string description, bool estBrise);
    List<Outils> LireTousLesOutils();
    void SupprimerOutil(ObjectId id);
    void ModifierOutil(Outils outil);
    Outils GetOutilById(ObjectId id);
    
}