using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_14E_A2022.Data.Entites;

namespace TP2_14E_A2022.Data.GestionsBD
{
    public interface IPageConnexionBD
    {
        List<Gestionnaire> GetGestionnaires();
        bool CreateGestionnaireBD(string prenom, string nom, string courriel, string motDePasse);
    }
}
