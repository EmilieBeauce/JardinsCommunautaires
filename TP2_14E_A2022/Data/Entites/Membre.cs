using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls;

namespace TP2_14E_A2022.Data.Entites
{
    public class Membre
    {
        #region Attributs
        public event PropertyChangedEventHandler PropertyChanged;

        private ObjectId _id;
        private string _prenom;
        private string _nom;
        private bool _estPaye;
        private int _cotisation;
        private DateTime _dateInscription;
        private ObjectId? _idAdresseCivique;
        private ObjectId? _idLot;
        #endregion
        #region Propriétés
        public ObjectId Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Cotisation
        {
            get { return _cotisation; }
            set { _cotisation = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }
        public DateTime DateInscription
        {
            get { return _dateInscription; }
            set { _dateInscription = value; }
        }
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public bool EstPaye
        {
            get { return _estPaye; }
            set
            {
                _estPaye = value;
                OnPropertyChanged();
            }
        }

        public ObjectId? IdAdresseCivique
        {
            get { return _idAdresseCivique; }
            set { _idAdresseCivique = value; }
        }
        public ObjectId? IdLot
        {
            get { return _idLot; }
            set { _idLot = value; }
        }
        #endregion
        #region constructeur
        public Membre() { }
      
        public Membre(ObjectId id, string prenom, string nom, bool estPaye, ObjectId? idAdresseCivique, 
            ObjectId? idLot, int cotisation, DateTime dateInscription)
        {
            Id = id;
            Prenom = prenom;
            Nom = nom;
            EstPaye = estPaye;
            IdAdresseCivique = idAdresseCivique;
            IdLot = idLot;
            Cotisation = cotisation;
            DateInscription = dateInscription;
        }
        #endregion


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
