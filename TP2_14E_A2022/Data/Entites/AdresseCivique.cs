using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_14E_A2022.Data.Entites
{
    public class AdresseCivique
    {
        #region Attributs
        private ObjectId? _id;
        private int _numeroDImmeuble;
        private string unite;
        private string _rue;
        private string _ville;
        private string _province;
        private string _codePostal;
        #endregion
        #region Propriétés
        public ObjectId? Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int NumeroDImmeuble
        {
            get { return _numeroDImmeuble; }
            set { _numeroDImmeuble = value; }
        }
        public string Unite
        {
            get { return unite; }
            set { unite = value; }
        }
        public string Rue
        {
            get { return _rue; }
            set { _rue = value; }
        }
        public string Ville
        {
            get { return _ville; }
            set { _ville = value; }
        }
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }
        public string CodePostal
        {
            get { return _codePostal; }
            set { _codePostal = value; }
        }
        #endregion
        #region Constructeurs
        public AdresseCivique() { }
        public AdresseCivique(ObjectId? id, int numeroDImmeuble, string unite, string rue, string ville, string province, string codePostal)
        {
            Id = id;
            NumeroDImmeuble = numeroDImmeuble;
            Unite = unite;
            Rue = rue;
            Ville = ville;
            Province = province;
            CodePostal = codePostal;
        }
        #endregion
    }
}
