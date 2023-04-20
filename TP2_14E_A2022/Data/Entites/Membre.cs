﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_14E_A2022.Data.Entites
{
    public class Membre
    {
        #region Attributs
        private ObjectId? _id;
        private string _prenom;
        private string _nom;
        private string? _idAdresseCivique;
        private string? _idLot;
        private string? _idCotisation;
        private bool _payeCotisation;
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
        public string? IdAdresseCivique
        {
            get { return _idAdresseCivique; }
            set { _idAdresseCivique = value; }
        }
        public string? IdLot
        {
            get { return _idLot; }
            set { _idLot = value; }
        }
        public string? IdCotisation
        {
            get { return _idCotisation; }
            set { _idCotisation = value; }
        }
        public bool PayeCotisation
        {
            get { return _payeCotisation; }
            set { _payeCotisation = value; }
        }
        #endregion
        #region constructeur
        public Membre() { }
      
        public Membre(ObjectId? id, string prenom, string nom, string? idAdresseCivique, string? idLot, string? idCotisation, bool payeCotisation)
        {
            Id = id;
            Prenom = prenom;
            Nom = nom;
            IdAdresseCivique = idAdresseCivique;
            IdLot = idLot;
            IdCotisation = idCotisation;
            PayeCotisation = payeCotisation;
        }
        #endregion

    }
}
