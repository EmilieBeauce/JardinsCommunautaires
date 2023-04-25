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
            membres.Add(new Membre(objectId, prenom, nom, estPaye, idAdresseCivique, idLot, idCotisation, 0, DateTime.Now));
            
            return membres.Last();
        }

        public Membre ModifierMembre(ObjectId id, string prenom, string nom, ObjectId? idAdresseCivique,
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

            var membre = membres.Find(m => m.Id == id);

            membre.Prenom = prenom;
            membre.Nom = nom;
            membre.IdAdresseCivique = idAdresseCivique;
            membre.IdLot = idLot;
            membre.IdCotisation = idCotisation;
            
            return membre;
        }

        public string GetAdresseMessage(Membre membre) =>
            membre.IdAdresseCivique == null ? "Adresse à compléter" : string.Empty;

        public string GetCotisationMessage(Membre membre) =>
            membre.IdCotisation == null ? "Cotisation à venir" : string.Empty;
        
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
        
        public void UpdateMembreCotisation(ObjectId membreId, int newCotisation)
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
            int weeksPassed = (int)(GetCustomDate() - dateInscription).TotalDays / 7;

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
        public DateTime GetCustomDate() => new DateTime(2023, 5, 30);
        
    }
}
