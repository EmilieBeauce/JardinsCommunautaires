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
            ObjectId? idLot, ObjectId? idCotisation, bool payeCotisation)
        {

            var objectId = ObjectId.GenerateNewId();
            membres.Add(new Membre(objectId, prenom, nom, idAdresseCivique, idLot, idCotisation, payeCotisation));
            return membres.Last();
        }

        public Membre ModifierMembre(string prenom, string nom, ObjectId? idAdresseCivique,
                       ObjectId? idLot, ObjectId? idCotisation, bool payeCotisation)
        {
            var membre = membres.Find(m => m.IdAdresseCivique == idAdresseCivique);
            if (membre == null)
            {
                throw new Exception("Aucun abonnement avec cette adresse civique n'existe.");
            }
            membre.Prenom = prenom;
            membre.Nom = nom;
            membre.IdAdresseCivique = idAdresseCivique;
            membre.IdLot = idLot;
            membre.IdCotisation = idCotisation;
            membre.PayeCotisation = payeCotisation;
            return membre;
        }


        
    }
}
