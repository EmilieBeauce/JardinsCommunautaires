using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;
using static TP2_14E_A2022.Data.Gestions.GestionConnexion;

namespace TP2_14E_A2022.Data.GestionsBD
{
    public class MembreDB
    {
        private DAL dal;
        public GestionMembre gestionMembre ;

        public MembreDB()
        {
            dal = new DAL();
        }

        public virtual List<Membre> GetMembres()
        {
            var membres = new List<Membre>();

            try
            {
               var db = dal.GetDatabase();
               membres = db.GetCollection<Membre>("Membres").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return membres;
        }

        public bool AjouterMembre(string prenom, string nom, ObjectId? adresseCivique, ObjectId? idLot, ObjectId? idCotisation, bool payeCotisation)
        {
            try
            {
                MembreDB membreDB = new MembreDB();
                gestionMembre = new GestionMembre(membreDB);
                var db = dal.GetDatabase();
                Membre membre = gestionMembre.CreerMembre(prenom, nom, adresseCivique, idLot, idCotisation, payeCotisation);
                db.GetCollection<Membre>("Membres").InsertOne(membre);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création du compte : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        /** voir le detail d'un membre */
        public Membre GetMembre(ObjectId? idMembre)
        {
            Membre membre = new Membre();
            try
            {
                var db = dal.GetDatabase();
                membre = db.GetCollection<Membre>("Membres").Find(m => m.Id == idMembre).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la requête : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return membre;
        }
    }
}
