﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Pages;
using TP2_14E_A2022.Data.GestionsBD;
using Moq;
using System.Windows;
using static TP2_14E_A2022.Data.Gestions.GestionConnexion;
using ControlzEx.Standard;

namespace TP2_14E_A2022.Data.Gestions
{
    
    public class GestionConnexion : IGestionConnexion
    {
        public interface IGestionConnexion
        {
            Gestionnaire CreerCompteGestionnaire(string prenom, string nom, string courriel, string motDePasse);
            bool ValiderSiConnexionFonctionne(string courriel, string motDePasse);
            bool ValiderSiDonneesConnexionConcordes(string courriel, string motDePasse);
        }

        public PageConnexionBD pageConnexionBD;
        public List<Gestionnaire> gestionnaires; 

        public GestionConnexion(PageConnexionBD pageConnexionBD)
        {
            this.pageConnexionBD = pageConnexionBD;
            gestionnaires = pageConnexionBD.GetGestionnaires();
        }


        public Gestionnaire CreerCompteGestionnaire( string prenom, string nom, string courriel, string motDePasse)
        {
            
            if (gestionnaires.Exists(g => g.Courriel == courriel))
            {
                throw new Exception("Un compte avec ce courriel existe déjà.");
            }
            
            var objectId = ObjectId.GenerateNewId();
            gestionnaires.Add(new Gestionnaire(objectId, prenom, nom, courriel, motDePasse));
            return gestionnaires.Last();
        }

        public bool ValiderSiConnexionFonctionne(string courriel, string motDePasse)
        {
            bool estConnecte = false;
            if (courriel == null || motDePasse == null || courriel == "" || motDePasse == "")
            {
                
                return estConnecte;
            }

            try
            {
                estConnecte = ValiderSiDonneesConnexionConcordes(courriel, motDePasse);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connexion : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }           

            return estConnecte;
        }

        public bool ValiderSiDonneesConnexionConcordes(string courriel, string motDePasse)
        {
            try
            {
                Gestionnaire gestionnaire = gestionnaires.FirstOrDefault(g => g.Courriel == courriel);
                if (gestionnaire != null && gestionnaire.MotDePasse == motDePasse)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Une erreur s'est produite lors de la recherche du gestionnaire.", ex);
            }
        }
        /** validation si le nom est valide */
        public bool NomEstValide(string nom) {

            if (string.IsNullOrWhiteSpace(nom))
            {
                return false;

            }
            else
            {
               return true;
            }
        }
        /** validation si le prenom est valide */
        public bool PrenomEstValide(string prenom)
        {
            if (string.IsNullOrWhiteSpace(prenom))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool CourrielEstVIde(string courriel) 
        { 
            if (courriel == null || courriel == "" )
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }
        public bool CourrielEstConforme(string courriel)
        {

            if (courriel.Contains("@") && courriel.Contains("."))
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }
        public bool CourrielExiste(string courriel)
        {
            if (gestionnaires.Exists(g => g.Courriel == courriel))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /** mot de passe valide */
        public bool MotDePasseEstVide(string motDePasse)
        {
            if (string.IsNullOrWhiteSpace(motDePasse))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /** validation si le mot de passe est conforme */
        public bool MotDePasseEstConforme(string motDePasse)
        {
            if (motDePasse.Length >= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /** validation si le mot de passe est égale a la confirmation */
        public bool MotDePasseEstEgaleConfirmation(string motDePasse, string confirmation)
        {
            if (motDePasse == confirmation)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

     
       
    }
}
