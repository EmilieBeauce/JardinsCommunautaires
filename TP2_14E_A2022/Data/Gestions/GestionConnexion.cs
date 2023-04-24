using MongoDB.Bson;
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
using System.Text.RegularExpressions;
using static TP2_14E_A2022.Data.GestionsBD.PageConnexionBD;
using TP2_14E_A2022.Utils;

namespace TP2_14E_A2022.Data.Gestions
{
    
    public class GestionConnexion : IGestionConnexion
    {
        public interface IGestionConnexion
        {
            Gestionnaire CreerCompteGestionnaire(string prenom, string nom, string courriel, string motDePasse);
        }

        public IPageConnexionBD pageConnexionBD;
        public List<Gestionnaire> gestionnaires; 

        public GestionConnexion(IPageConnexionBD pageConnexionBD)
        {
            this.pageConnexionBD = pageConnexionBD;
            gestionnaires = pageConnexionBD.GetGestionnaires();
        }

        public virtual Gestionnaire CreerCompteGestionnaire( string prenom, string nom, string courriel, string motDePasse)
        {
            try
            {
                var objectId = ObjectId.GenerateNewId();
                gestionnaires.Add(new Gestionnaire(objectId, prenom, nom, courriel, motDePasse));
                return gestionnaires.Last();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorMessages.GestionnaireCreationError, ex);
            }
        }
        /** validation si le nom est valide */
        public bool NomEstValide(string nom) 
        {
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
        public bool CourrielEstVide(string courriel) 
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
            string patronCourriel = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";


            if (Regex.IsMatch(courriel, patronCourriel, RegexOptions.IgnoreCase))
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

            if (gestionnaires.Exists(g => g.Courriel == courriel) || courriel == null)
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
            if (string.IsNullOrWhiteSpace(motDePasse) || motDePasse == "")
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

        /** confirmation n'est pas null ou vide*/
        public bool ConfirmationEstVide(string confirmation)
        {
            if (string.IsNullOrWhiteSpace(confirmation))
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
