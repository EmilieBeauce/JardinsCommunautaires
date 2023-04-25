using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.GestionsBD;
using System.Diagnostics;
using MongoDB.Driver;

namespace TP2_14E_A2022.Data.Gestions
{
    public class GestionMembre
    {

        public MembreDB membreDb;
        public List<Membre> membres;

        public GestionMembre(MembreDB membreDb)
        {
            Debug.WriteLine("GestionMembre constructor called");
            Console.WriteLine("GestionMembre constructor called");

            this.membreDb = membreDb;
            membres = membreDb.GetMembres();
            CalculateFeesAndSetEstPayeStatus();
        }

        public Membre CreerMembre(string prenom, string nom, bool estPaye, ObjectId? idAdresseCivique,
            ObjectId? idLot, ObjectId? idCotisation)
        {
            var objectId = ObjectId.GenerateNewId();
            membres.Add(new Membre(objectId, prenom, nom, estPaye, idAdresseCivique, idLot, idCotisation, 0, DateTime.Now));
            return membres.Last();
        }

        public Membre ModifierMembre(ObjectId id, string prenom, string nom, ObjectId? idAdresseCivique,
                       ObjectId? idLot, ObjectId? idCotisation)
        {
            var membre = membres.Find(m => m.Id == id);
         
            membre.Prenom = prenom;
            membre.Nom = nom;
            membre.IdAdresseCivique = idAdresseCivique;
            membre.IdLot = idLot;
            membre.IdCotisation = idCotisation;
            return membre;
        }
    
        
        
        public string GetAdresseMessage(Membre membre)
        {
            if (membre.IdAdresseCivique == null)
            {
                return "Adresse à compléter";
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetCotisationMessage(Membre membre)
        {
            if(membre.IdCotisation == null)
            {
                return "Cotisation à venir";
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Utilisé pour testé la date de la cotisation
        /// </summary>
        /// <returns></returns>
        public DateTime GetCustomDate()
        {
            // Change this to the desired date for testing
            return new DateTime(2023, 5, 30);
        }

        public string GetLotMessage(Membre membre)
        {
            if (membre.IdLot == null)
            {
                return "Attribution de lot à faire";
            }
            else
            {
                return string.Empty;
            }
        }
        
        
        //TODO: 
        //Petit verif comme les autres.
        public void UpdateMembreEstPaye(ObjectId membreId, bool estPaye)
        {
            membreDb.UpdateMembreEstPaye(membreId, estPaye);
        }

        
        
        public int CalculateFeesAndSetEstPayeStatus()
        {
            DateTime currentDate = GetCustomDate();
            Debug.WriteLine($"Current date: {currentDate}");
            if (currentDate.Month == 4 && currentDate.Day == 1)
            {
                int weeksSinceDueDate = (int)Math.Floor((currentDate - new DateTime(currentDate.Year, 4, 1)).TotalDays / 7);
                Debug.WriteLine($"Weeks since due date: {weeksSinceDueDate}");
                int totalFees = 20 + (weeksSinceDueDate * 10);
                foreach (var membre in membres)
                {
                    membre.EstPaye = false;
                    membre.Cotisation = totalFees;
                    Debug.WriteLine($"Updated Cotisation for member {membre.Id}: {membre.Cotisation}");                
                }

                // Update EstPaye status for all users in the database
                membreDb.UpdateEstPayeStatusInDatabase();

                return totalFees;
            }
            return 0;
        }
        
        public void UpdateMembreCotisation(ObjectId membreId, int newCotisation)
        {
            membreDb.UpdateCotisation(membreId, newCotisation);
        }
        
        public int CalculateCotisation(DateTime dateInscription)
        {
            int cotisation = 20;
            int weeksPassed = (int)(GetCustomDate() - dateInscription).TotalDays / 7;

            if (weeksPassed > 0)
            {
                cotisation += weeksPassed * 10; // Increase $10 for every week passed
            }

            return cotisation;
        }
        
        
        
    }
}
