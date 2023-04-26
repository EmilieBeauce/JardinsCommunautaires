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
        private readonly IPageConnexionBD pageConnexionBD;

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

        public bool NomEstValide(string nom) => !string.IsNullOrWhiteSpace(nom);

        public bool PrenomEstValide(string prenom) => !string.IsNullOrWhiteSpace(prenom);
        
        public bool CourrielEstVide(string courriel)
        {
            if (courriel == null || courriel == "")
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
            return Regex.IsMatch(courriel, patronCourriel, RegexOptions.IgnoreCase);
        }
        public bool CourrielExiste(string courriel)
        {
            if (gestionnaires.Exists(g => g.Courriel == courriel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool MotDePasseEstVide(string motDePasse) => string.IsNullOrWhiteSpace(motDePasse);

        public bool MotDePasseEstConforme(string motDePasse) => motDePasse.Length >= 8;

        public bool MotDePasseEstEgaleConfirmation(string motDePasse, string confirmation) => motDePasse == confirmation;

        /** confirmation n'est pas null ou vide*/

        public bool ConfirmationEstVide(string confirmation) => string.IsNullOrWhiteSpace(confirmation);
    }
}
