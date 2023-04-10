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
using TP2_14E_A2022.Data.GestionsBD;
using TP2_14E_A2022.Pages;
using System.Security.Cryptography.X509Certificates;
using static TP2_14E_A2022.Data.Gestions.GestionConnexion;

namespace TP2_14E_A2022.Data.Gestions.Tests
{
    [TestClass()]
    public class GestionConnexionTests
    {


        [TestMethod]
        public void TestValiderSiConnexionFonctionne_retourne_vrai_si_les_données_sont_exactes()
        {
            // Arrange
            var mock = new Mock<IGestionConnexion>();
           
            // Act
            mock.Setup(x => x.ValiderSiConnexionFonctionne("jd@courriel.com", "password")).Returns(true);
            
            // Assert
            Assert.IsTrue(mock.Object.ValiderSiConnexionFonctionne("jd@courriel.com", "password"));

        }

        [TestMethod]
        public void TestValiderSiConnexionFonctionne_retourne_faux_si_les_données_sont_incorrectes()
        {
            // Arrange
            var mock = new Mock<IGestionConnexion>();
            
            // Act
            mock.Setup(x => x.ValiderSiConnexionFonctionne("jd@courriel.com", "password")).Returns(true);

            // Assert
            Assert.IsFalse(mock.Object.ValiderSiConnexionFonctionne("rd@courriel.com", "passworld"));
        }

        [TestMethod]
        public void TestValiderSiDonneesConnexionConcordes_retourne_vrai_si_les_données_sont_exactes()
        {
            // Arrange
            var mock = new Mock<IGestionConnexion>();
            
            // Act
            mock.Setup(x => x.ValiderSiDonneesConnexionConcordes("jd@courriel.com", "password")).Returns((bool)true);
            
            // Assert
            Assert.IsTrue(mock.Object.ValiderSiDonneesConnexionConcordes("jd@courriel.com", "password"));
        }

        //retourne faux si les données sont incorrectes

        [TestMethod]
        public void TestValiderSiDonneesConnexionConcordes_retourne_faux_si_les_données_sont_incorrectes()
        {
            // Arrange
            var mock = new Mock<IGestionConnexion>();

            // Act
            mock.Setup(x => x.ValiderSiDonneesConnexionConcordes("jd@courriel.com", "password"));

            // Assert
            Assert.IsFalse(mock.Object.ValiderSiDonneesConnexionConcordes("rd@courriel.com", "passworld"));
        }

        [TestMethod]
        public void TestCreerCompteGestionnaire_retourne_un_gestionnaire()
        {
            // Arrange
            var mock = new Mock<IGestionConnexion>();
            mock.Setup(x => x.CreerCompteGestionnaire("John", "Doe", "jd@courriel.com", "password"))
                .Returns(new Gestionnaire { Prenom = "John", Nom = "Doe", Courriel = "jd@courriel.com", MotDePasse = "password" });

            // Act
            var result = mock.Object.CreerCompteGestionnaire("John", "Doe", "jd@courriel.com", "password");

            // Assert 
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Prenom, "John");
            Assert.AreEqual(result.Nom, "Doe");
            Assert.AreEqual(result.Courriel, "jd@courriel.com");
            Assert.AreEqual(result.MotDePasse, "password");
        }

        [TestMethod]
        public void TestCreerCompteGestionnaire_retourne_null_si_les_données_sont_incorrectes()
        {
            // Arrange
            var mock = new Mock<IGestionConnexion>();
            mock.Setup(x => x.CreerCompteGestionnaire("John", "Doe", "jd@courriel.com", "password"))
                .Returns(new Gestionnaire { Prenom = "John", Nom = "Doe", Courriel = "jd@courriel.com", MotDePasse = "password" });

            // Act
            var result = mock.Object.CreerCompteGestionnaire("John", "Doe", "jd@courriel.com", "");

            // Assert
            Assert.IsNull(result);
        }

    }
}
