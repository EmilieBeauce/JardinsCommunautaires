using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_14E_A2022.Data.Entites;

namespace TP2_14E_A2022.Data.GestionsBD
{
    public class PageConnexionBD
    {
        {
        private readonly IMongoCollection<Gestionnaire> _gestionnairesCollection;

        public PageConnexionBD()
        {
            MongoClient client = DalConnexion.GetConnexion();
            var database = client.GetDatabase("TP2DB");
            _gestionnairesCollection = database.GetCollection<Gestionnaire>("gestionnaires");
        }

        public bool SeConnecter(string courriel, string motDePasse)
        {
            var gestionnaire = _gestionnairesCollection.Find(g => g.Courriel == courriel && g.MotDePasse == motDePasse).FirstOrDefault();
            return gestionnaire != null;
        }
    }

}
}
