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
           
            gestionnaires.Add(new Gestionnaire(prenom, nom, courriel, motDePasse));
            return gestionnaires.Last();
        }

        public bool ValiderSiConnexionFonctionne(string courriel, string motDePasse)
        {
            bool estConnecte = false;
            if (courriel == null || motDePasse == null || courriel == "" || motDePasse == "")
            {
                MessageBox.Show("Veuillez entrer un courriel et un mot de passe", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
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

    }

   
}
