using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_14E_A2022.Data;

namespace TP2_14E_A2022.Data.Gestions
{
    public class GestionConnexion
    {
        private List<Gestionnaire> gestionnaires; 

        public GestionConnexion()
        {
            gestionnaires = new List<Gestionnaire>();
        }

        public void CreerCompte(string prenom, string nom, string motDePasse)
        {
            
            if (gestionnaires.Exists(g => g.Prenom == prenom && g.Nom == nom))
            {
                throw new Exception("Un compte avec ce nom et prénom existe déjà.");
            }

           
            gestionnaires.Add(new Gestionnaire(prenom, nom, motDePasse));
        }

        public bool SeConnecter(string prenom, string nom, string motDePasse)
        {
           
            Gestionnaire gestionnaire = gestionnaires.Find(g => g.Prenom == prenom && g.Nom == nom);

            if (gestionnaire != null && gestionnaire.MotDePasse == motDePasse)
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
