using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_14E_A2022.Data.Entites
{
    public class Gestionnaire
    {
        #region Attributs
        private ObjectId? _id;
        private string _prenom;
        private string _nom;
        private string _courriel;
        private string _motDePasse;
        #endregion

        #region Propriétés
        public ObjectId? Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public string Courriel
        {
            get { return _courriel; }
            set { _courriel = value; }
        }
        public string MotDePasse
        {
            get { return _motDePasse; }
            set { _motDePasse = value; }
        }
        #endregion

        #region Constructeurs
        public Gestionnaire() { }

        public Gestionnaire(ObjectId? id, string prenom, string nom, string courriel, string motDePasse)
        {
            Id = id;
            Prenom = prenom;
            Nom = nom;
            Courriel = courriel; ;
            MotDePasse = motDePasse;
        }
        #endregion
    }
}
