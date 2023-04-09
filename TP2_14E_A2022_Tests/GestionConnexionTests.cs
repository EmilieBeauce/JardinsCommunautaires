using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2_14E_A2022.Data.Gestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.Gestions;

namespace TP2_14E_A2022.Data.Gestions.Tests
{
    [TestClass()]
    public class GestionConnexionTests
    {
        [TestMethod()]
        public void ValiderSiDonneesConnexionConcordes_Retourne_True_Si_Donnees_Concordent()
        {
            // Arrange
            var gestionConnexion = new GestionConnexion(); // create an instance of GestionConnexion

            var gestionnaires = new List<Gestionnaire>
    {
        new Gestionnaire("John", "Doe", "john.doe@example.com", "password123"),
        new Gestionnaire("Jane", "Doe", "jane.doe@example.com", "password456")
    };

            // Act
            var result = gestionConnexion.ValiderSiDonneesConnexionConcordes("john.doe@example.com", "password123");


        }
    }
}
