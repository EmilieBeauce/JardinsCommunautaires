using MongoDB.Bson;
using TP2_14E_A2022.Data.Entites;

namespace TP2_14E_A2022.Data.Gestions;

public interface IGestionOutil
{
    Outils CreerOutil(ObjectId id, string nom, string description, bool estBrise);
    
    // TODO:
    //Outils ModifierOutil(string nom, string description, bool estBrise);
    //Outils SupprimerOutil(string nom, string description, bool estBrise);
    //utils LireOutil (string nom, string description, bool estBrise);
}