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
        private string _prenom;
        private string _nom;
        private string _motDePasse;
        #endregion

        #region Propriétés
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
        public string MotDePasse
        {
            get { return _motDePasse; }
            set { _motDePasse = value; }
        }
        #endregion

        #region Constructeurs
        public Gestionnaire()
        {
            _prenom = "";
            _nom = "";
            _motDePasse = "";
        }

        public Gestionnaire(string prenom, string nom, string motDePasse)
        {
            _prenom = prenom;
            _nom = nom;
            _motDePasse = motDePasse;
        }
        #endregion


    }
}
