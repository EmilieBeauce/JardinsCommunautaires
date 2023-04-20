﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;

namespace TP2_14E_A2022.Data.GestionsBD
{
    public interface IPageConnexionBD
    {
        List<Gestionnaire> GetGestionnaires();
        bool ValiderSiConnexionFonctionne(string courriel, string motDePasse);
    }
    public class PageConnexionBD : IPageConnexionBD
    {
        private DAL dal;
        public GestionConnexion gestionConnexion;

        public PageConnexionBD()
        {
            dal = new DAL();
         

        }
        public virtual List<Gestionnaire> GetGestionnaires()
        {
            var gestionnaires = new List<Gestionnaire>();

            try
            {
                var db = dal.GetDatabase();
                gestionnaires = db.GetCollection<Gestionnaire>("Gestionnaires").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return gestionnaires;
        }
        public bool ValiderSiConnexionFonctionne(string courriel, string motDePasse)
        {
            bool estConnecte = false;
            if (courriel == null || motDePasse == null || courriel == "" || motDePasse == "")
            {
                
                return estConnecte;
            }

            if (gestionConnexion == null)
            {
                PageConnexionBD pageConnexionBD = new PageConnexionBD();
                gestionConnexion = new GestionConnexion(pageConnexionBD);
            }
            try
            {
                estConnecte = gestionConnexion.ValiderSiDonneesConnexionConcordes(courriel, motDePasse);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connexion : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return estConnecte;
        }

        public string GetPrenomNomGestionnaire(string courriel)
        {
            var db = dal.GetDatabase();
            var gestionnaire = db.GetCollection<Gestionnaire>("Gestionnaires").Find(g => g.Courriel == courriel).FirstOrDefault();
            return gestionnaire.Prenom + " " + gestionnaire.Nom;
        }

        public bool LoginBD(string prenom, string nom, string courriel, string motDePasse)
        {
            try
            {
                PageConnexionBD pageConnexionBD = new PageConnexionBD();
                gestionConnexion = new GestionConnexion(pageConnexionBD);
                var db = dal.GetDatabase();
                Gestionnaire gestionnaire = gestionConnexion.CreerCompteGestionnaire(prenom, nom, courriel, motDePasse);
                db.GetCollection<Gestionnaire>("Gestionnaires").InsertOne(gestionnaire);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création du compte : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public bool ValiderSiCourrielExiste(string courriel)
        {
            var db = dal.GetDatabase();
            var gestionnaire = db.GetCollection<Gestionnaire>("Gestionnaires").Find(g => g.Courriel == courriel).FirstOrDefault();
            if (gestionnaire == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}




