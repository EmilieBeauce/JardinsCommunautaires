using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.GestionsBD;

namespace TP2_14E_A2022.Data.Gestions
{
    public class GestionMembre
    {

        public MembreDB membreDb;
        public List<Membre> membres;

        public GestionMembre(MembreDB membreDb)
        {
            this.membreDb = membreDb;
            membres = membreDb.GetMembres();
        }

        public Membre CreerMembre(string prenom, string nom, ObjectId? idAdresseCivique,
            ObjectId? idLot, ObjectId? idCotisation)
        {

            var objectId = ObjectId.GenerateNewId();
            membres.Add(new Membre(objectId, prenom, nom, idAdresseCivique, idLot, idCotisation));
            return membres.Last();
        }

        public Membre ModifierMembre(ObjectId id, string prenom, string nom, ObjectId? idAdresseCivique,
                       ObjectId? idLot, ObjectId? idCotisation)
        {
            var membre = membres.Find(m => m.Id == id);
            if (membre == null)
            {
                throw new Exception("Ce membre n'existe pas.");
            }
            membre.Prenom = prenom;
            membre.Nom = nom;
            membre.IdAdresseCivique = idAdresseCivique;
            membre.IdLot = idLot;
            membre.IdCotisation = idCotisation;
            return membre;
        }
        public Membre SupprimerMembre (ObjectId id)
        {
            var membre = membres.Find(m => m.Id == id);
            if (membre == null)
            {
                throw new Exception("Ce membre n'existe pas.");
            }
            membres.Remove(membre);
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
    }
}
