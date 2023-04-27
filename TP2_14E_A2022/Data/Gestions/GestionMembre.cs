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

        private const string MESSAGE_ERREUR = "Ne peux avoir une valeur null ou vide ! ";

        public GestionMembre(MembreDB membreDb)
        {
            this.membreDb = membreDb;
            membres = membreDb.GetMembres();
            CalculateFeesAndSetEstPayeStatus();
        }

        public Membre CreerMembre(string prenom, string nom, bool estPaye, ObjectId? idAdresseCivique,
            ObjectId? idLot, ObjectId? idCotisation)
        {
            if (string.IsNullOrEmpty(prenom))
            {
                throw new ArgumentException(MESSAGE_ERREUR, nameof(prenom));
            }

            if (string.IsNullOrEmpty(nom))
            {
                throw new ArgumentException(MESSAGE_ERREUR, nameof(nom));
            }

            var objectId = ObjectId.GenerateNewId();
            DateTime inscriptionDate = DateTime.Now;
            int cotisation = CalculateCotisation(inscriptionDate);
    
            if (estPaye)
            {
                cotisation = 0;
            }

            membres.Add(new Membre(objectId, prenom, nom, estPaye, idAdresseCivique, idLot, cotisation, inscriptionDate));

            return membres.Last();
        }

        public Membre ModifierMembre(ObjectId id, string prenom, string nom, ObjectId? idAdresseCivique,
            ObjectId? idLot)
        {
            if (string.IsNullOrEmpty(prenom))
            {
                throw new ArgumentException(MESSAGE_ERREUR, nameof(prenom));
            }

            if (string.IsNullOrEmpty(nom))
            {
                throw new ArgumentException(MESSAGE_ERREUR, nameof(nom));
            }

            var membre = membres.Find(m => m.Id == id);

            membre.Prenom = prenom;
            membre.Nom = nom;
            membre.IdAdresseCivique = idAdresseCivique;
            membre.IdLot = idLot;
            
            return membre;
        }

        public string GetAdresseMessage(Membre membre) =>
            membre.IdAdresseCivique == null ? "Adresse à compléter" : string.Empty;

        public string GetLotMessage(Membre membre) =>
            membre.IdLot == null ? "Attribution de lot à faire" : string.Empty;

        public void UpdateMembreEstPaye(ObjectId membreId, bool estPaye)
        {
            if (membreId == default(ObjectId))
            {
                throw new ArgumentException(MESSAGE_ERREUR, nameof(membreId));
            }

            membreDb.UpdateMembreEstPaye(membreId, estPaye);
        }
        public int CalculateFeesAndSetEstPayeStatus()
        {
            DateTime currentDate = GetCustomDate();
            
            if (currentDate.Month == 4 && currentDate.Day == 1)
            {
                int weeksSinceDueDate = (int)Math.Floor((currentDate - new DateTime(currentDate.Year, 4, 1)).TotalDays / 7);
                int totalFees = 20 + (weeksSinceDueDate * 10);
            
                foreach (var membre in membres)
                {
                    membre.EstPaye = false;
                    membre.Cotisation = totalFees;
                }

                membreDb.UpdateEstPayeStatusInDatabase();

                return totalFees;
            }
            
            return 0;
        }
        
        public bool PrenomEstValide(string prenom)
        {
            return !string.IsNullOrWhiteSpace(prenom);
        }

        public bool NomEstValide(string nom)
        {
            return !string.IsNullOrWhiteSpace(nom);
        }

        public virtual Membre GetMembreById(ObjectId membreId)
        {
            if (membreId == default(ObjectId))
            {
                throw new ArgumentException("Invalid ObjectId provided.");
            }

            return membreDb.GetMembre(membreId);
        }

        public virtual void UpdateMembreCotisation(ObjectId membreId, int newCotisation)
        {
            if (membreId == default(ObjectId))
            {
                throw new ArgumentException(MESSAGE_ERREUR, nameof(membreId));
            }

            membreDb.UpdateCotisation(membreId, newCotisation);
        }
        
        public int CalculateCotisation(DateTime dateInscription)
        {
            int cotisation = 20;
            
            // Pour tester la cotisation, juste remplacer le DateTime.Now par GetCustomDate(). 
            TimeSpan timeSinceInscription = DateTime.Now - dateInscription;
            int yearsPassed = (int)(timeSinceInscription.TotalDays / 365.25);
            int weeksPassed = (int)(timeSinceInscription.TotalDays - (yearsPassed * 365.25)) / 7;

            if (weeksPassed > 0)
            {
                cotisation += weeksPassed * 10;
            }

            return cotisation;
        }


        /// <summary>
        /// Utilisé pour testé la date de la cotisation, simplement remplacé le DateNow par celle-ci.
        /// </summary>
        /// <returns></returns>
        public DateTime GetCustomDate() => new DateTime(2023, 6, 30);
        
    }
}
