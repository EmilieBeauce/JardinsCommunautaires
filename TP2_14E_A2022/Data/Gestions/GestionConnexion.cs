using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Pages;
using TP2_14E_A2022.Data.GestionsBD;

namespace TP2_14E_A2022.Data.Gestions
{
    public class GestionConnexion
    {
        public PageConnexionBD pageConnexionBD;
        private List<Gestionnaire> gestionnaires; 

        public GestionConnexion()
        {
            pageConnexionBD = new PageConnexionBD();
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
