using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_14E_A2022.Data.Entites;

namespace TP2_14E_A2022.Data.Gestions
{
    public class GestionConnexion
    {
        private List<Gestionnaire> gestionnaires; 

        public GestionConnexion()
        {
            gestionnaires = new List<Gestionnaire>();
        }

        public void CreerCompte(string prenom, string nom, string courriel, string motDePasse)
        {
            
            if (gestionnaires.Exists(g => g.Courriel == courriel))
            {
                throw new Exception("Un compte avec ce nom et prénom existe déjà.");
            }

           
            gestionnaires.Add(new Gestionnaire(prenom, nom, courriel, motDePasse));
        }

        public bool SeConnecter(string prenom, string nom, string courriel, string motDePasse)
        {
           
            try
            {
                Gestionnaire gestionnaire = gestionnaires.Find(g => g.Courriel == courriel);
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
