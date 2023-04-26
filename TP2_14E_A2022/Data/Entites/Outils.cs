using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace TP2_14E_A2022.Data.Entites;

public class Outils
{
    #region attributs
    private ObjectId? _id;
    private string _Nom;
    private string _Description;
    private bool _EstBrise;
    #endregion
    #region Propriétés
    public ObjectId? Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Nom
    {
        get { return _Nom; }
        set { _Nom = value; }
    }
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    public bool EstBrise
    {
        get { return _EstBrise; }
        set { _EstBrise = value; }
    }
    #endregion
    #region Constructeurs
    public Outils() { }
    
    public Outils(ObjectId id, string nom, string description, bool estBrise)
    {
        Id = id;
        Nom = nom;
        Description = description;
        EstBrise = estBrise;
    }
    #endregion
}
