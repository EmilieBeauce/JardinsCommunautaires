using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;

namespace TP2_14E_A2022.Data.GestionsBD
{
    public class PageConnexionBD
    {
        private DAL dal;

        public PageConnexionBD()
        {
            dal = new DAL();
        }

        public bool SeConnecter(string courriel, string motDePasse)
        {
            bool estConnecte = false;

            try
            {
                estConnecte = dal.GetGestionnaires().Any(g => g.Courriel == courriel && g.MotDePasse == motDePasse);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connexion : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return estConnecte;
        }
    }
}




