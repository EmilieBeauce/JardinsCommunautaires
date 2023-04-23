using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2_14E_A2022.Data.Gestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.GestionsBD;
using TP2_14E_A2022.Pages;
using System.Security.Cryptography.X509Certificates;
using static TP2_14E_A2022.Data.Gestions.GestionConnexion;
using static TP2_14E_A2022.Data.GestionsBD.PageConnexionBD;
using MongoDB.Driver.Core.Misc;
using System.Net;
using MongoDB.Bson;
using TP2_14E_A2022.Utils;

namespace TP2_14E_A2022.Data.Gestions.Tests
{

    [TestClass()]
    public class GestionConnexionTests
    {
        private PageConnexionBD pageConnexionBD;
        private GestionConnexion gestion;

        [TestInitialize]
        public void TestInitialize()
        {
            pageConnexionBD = new PageConnexionBD();
            gestion = new GestionConnexion(pageConnexionBD);
        }
        [TestMethod]
        public void TestCreerCompteGestionnaire_retourne_un_gestionnaire()
        {
            var mock = new Mock<IGestionConnexion>();
            mock.Setup(x => x.CreerCompteGestionnaire("John", "Doe", "jd@courriel.com", "password"))
                .Returns(new Gestionnaire { Prenom = "John", Nom = "Doe", Courriel = "jd@courriel.com", MotDePasse = "password" });
            
            var result = mock.Object.CreerCompteGestionnaire("John", "Doe", "jd@courriel.com", "password");

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Prenom, "John");
            Assert.AreEqual(result.Nom, "Doe");
            Assert.AreEqual(result.Courriel, "jd@courriel.com");
            Assert.AreEqual(result.MotDePasse, "password");
        }
        [TestMethod]
        public void CreerCompteGestionnaire_AvecDesParametresValides_RetourneUnGestionnaireCree()
        {
            string prenom = "John";
            string nom = "Doe";
            string courriel = "johndoe@test.ca";
            string motDePasse = "password123";

            Gestionnaire nouveauGestionnaire = gestion.CreerCompteGestionnaire(prenom, nom, courriel, motDePasse);

            Assert.IsNotNull(nouveauGestionnaire);
            Assert.AreEqual(prenom, nouveauGestionnaire.Prenom);
            Assert.AreEqual(nom, nouveauGestionnaire.Nom);
            Assert.AreEqual(courriel, nouveauGestionnaire.Courriel);
            Assert.AreEqual(motDePasse, nouveauGestionnaire.MotDePasse);
        }
        [TestMethod]
        public void CreerCompteGestionnaire_ExceptionLevee_RetourneNull()
        {
            var mockPageConnexionBD = new Mock<IPageConnexionBD>();
            var gestionnaireList = new List<Gestionnaire>();
            mockPageConnexionBD.Setup(m => m.GetGestionnaires()).Returns(gestionnaireList);

            var mockGestionConnexion = new GestionConnexion(mockPageConnexionBD.Object);

            string prenom = "";
            string nom = "Doe";
            string courriel = "johndoe@test.ca";
            string motDePasse = "password123";

            Gestionnaire nouveauGestionnaire = null;
            try
            {
                // Throw an exception when adding a new Gestionnaire to the list
                gestionnaireList.Add(new Gestionnaire(ObjectId.GenerateNewId(), prenom, nom, courriel, motDePasse));
                throw new Exception("Erreur lors de la création du compte gestionnaire");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ErrorMessages.GestionnaireCreationError, ex.Message);
            }

            // Assert
            Assert.IsNull(nouveauGestionnaire);
        }
        [TestMethod]
        public void TestCreerCompteGestionnaire_retourne_null_si_les_données_sont_incorrectes()
        {
            var mock = new Mock<IGestionConnexion>();
            mock.Setup(x => x.CreerCompteGestionnaire("John", "Doe", "jd@courriel.com", "password"))
                .Returns(new Gestionnaire { Prenom = "John", Nom = "Doe", Courriel = "jd@courriel.com", MotDePasse = "password" });
            
            var result = mock.Object.CreerCompteGestionnaire("John", "Doe", "jd@courriel.com", "");
            
            Assert.IsNull(result);
        }
        [TestMethod]
        public void NomEstValide_NullNom_ReturnsFalse()
        {
            string nom = null;
            var result = gestion.NomEstValide(nom);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void NomEstValide_EmptyNom_ReturnsFalse()
        {
            string nom = "";
            var result = gestion.NomEstValide(nom);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void NomEstValide_WhiteSpaceNom_ReturnsFalse()
        {
            string nom = " ";
            var result = gestion.NomEstValide(nom);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void PrenomEstValide_NullPrenom_ReturnsFalse()
        {
            string prenom = null;
            var result = gestion.PrenomEstValide(prenom);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void NomEstValide_Nom_ReturnsTrue()
        {
            string nom = "Doe";
            var result = gestion.NomEstValide(nom);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void PrenomEstValide_EmptyPrenom_ReturnsFalse()
        {
            string prenom = "";
            var result = gestion.PrenomEstValide(prenom);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void PrenomEstValide_WhiteSpacePrenom_ReturnsFalse()
        {
            string prenom = " ";
            var result = gestion.PrenomEstValide(prenom);
            Assert.IsFalse(result);
        }
        // test prenom est valid return true
        [TestMethod]
        public void PrenomEstValide_Prenom_ReturnsTrue()
        {
            string prenom = "John";
            var result = gestion.PrenomEstValide(prenom);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CourrielExiste_NullCourriel_ReturnsFalse()
        {
            string courriel = null;
            var result = gestion.CourrielExiste(courriel);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CourrielExiste_CourrielExists_ReturnsFalse()
        {
            var mockPageConnexionBD = new Mock<IPageConnexionBD>();
            var gestionnaireList = new List<Gestionnaire>
        {
            new Gestionnaire(ObjectId.GenerateNewId(), "Jane", "Doe", "janedoe@test.ca", "password123")
        };
            mockPageConnexionBD.Setup(m => m.GetGestionnaires()).Returns(gestionnaireList);

            var gestionConnexion = new GestionConnexion(mockPageConnexionBD.Object);

            string courriel = "janedoe@test.ca";
            bool result = gestionConnexion.CourrielExiste(courriel);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CourrielExiste_CourrielIsUnique_ReturnsTrue()
        {
            var mockPageConnexionBD = new Mock<IPageConnexionBD>();
            var gestionnaireList = new List<Gestionnaire>
        {
            new Gestionnaire(ObjectId.GenerateNewId(), "Jane", "Doe", "janedoe@test.ca", "password123")
        };
            mockPageConnexionBD.Setup(m => m.GetGestionnaires()).Returns(gestionnaireList);

            var gestionConnexion = new GestionConnexion(mockPageConnexionBD.Object);

            string courriel = "johndoe@test.ca";
            bool result = gestionConnexion.CourrielExiste(courriel);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CourrielEstVide_WhiteSpaceCourriel_ReturnsFalse()
        {
            string courriel = " ";
            var result = gestion.CourrielEstVide(courriel);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CourrielEstVide_EmptyCourriel_ReturnsTrue()
        {
            string courriel = "";
            var result = gestion.CourrielEstVide(courriel);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CourrielEstVide_NullCourriel_ReturnsTrue()
        {
            string courriel = null;
            var result = gestion.CourrielEstVide(courriel);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CourrielEstConforme_ManqueUnSymbole_ReturnsFalse()
        {
            string courriel = "john@doeca";
            var result = gestion.CourrielEstConforme(courriel);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CourrielEstConforme_ManqueUnPoint_ReturnsFalse()
        {
            string courriel = "johndoe@ca";
            var result = gestion.CourrielEstConforme(courriel);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CourrielEstConforme_ManqueUnNom_ReturnsFalse()
        {
            string courriel = "@doe.ca";
            var result = gestion.CourrielEstConforme(courriel);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CourrielEstConforme_Courriel_ReturnsTrue()
        {
            string courriel = "johndoe@test.ca";
            var result = gestion.CourrielEstConforme(courriel);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void MotDePasseEstVide_MotDePasseVide_ReturnsTrue()
        {
            string motDePasse = "";
            var result = gestion.MotDePasseEstVide(motDePasse);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void MotDePasseEstVide_MotDePasseNull_ReturnsTrue()
        {
            string motDePasse = null;
            var result = gestion.MotDePasseEstVide(motDePasse);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void MotDePasseEstVide_MotDePasseWhiteSpace_ReturnsTrue()
        {
            string motDePasse = " ";
            var result = gestion.MotDePasseEstVide(motDePasse);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void MotDePasseEstVide_MotDePasseNEstPasVide_ReturnsFalse()
        {
            string motDePasse = "password";
            var result = gestion.MotDePasseEstVide(motDePasse);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void MotDePasseEstConforme_MotDePasseVide_ReturnsFalse()
        {
            string motDePasse = "";
            var result = gestion.MotDePasseEstConforme(motDePasse);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void MotDePasseEstConforme_MotDePasseConforme_ReturnsTrue()
        {
            string motDePasse = "passwords";
            var result = gestion.MotDePasseEstConforme(motDePasse);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void MotDePasseEstConforme_MotDePassePasAssezLong_ReturnsFalse()
        {
            string motDePasse = "pwd";
            var result = gestion.MotDePasseEstConforme(motDePasse);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void MotDePasseEstEgaleConfirmation_ConfirmationEstDifferenteDuMotDePasse_ReturnsFalse()
        {
            string motDePasse = "password";
            string confirmation = "passwords";
            var result = gestion.MotDePasseEstEgaleConfirmation(motDePasse, confirmation);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void MotDePasseEstEgaleConfirmation_ConfirmationEstEgaleAuMotDePasse_ReturnsTrue()
        {
            string motDePasse = "password";
            string confirmation = "password";
            var result = gestion.MotDePasseEstEgaleConfirmation(motDePasse, confirmation);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void MotDePasseEstEgaleConfirmation_ConfirmationEstVide_ReturnsFalse()
        {
            string motDePasse = "password";
            string confirmation = "";
            var result = gestion.MotDePasseEstEgaleConfirmation(motDePasse, confirmation);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ConfirmationEstVide_ConfirmationEstNull_ReturnsTrue()
        {
            string confirmation = null;
            var result = gestion.ConfirmationEstVide(confirmation);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ConfirmationEstVide_ConfirmationEstVide_ReturnsTrue()
        {
            string confirmation = "";
            var result = gestion.ConfirmationEstVide(confirmation);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ConfirmationEstVide_ConfirmationEstWhiteSpace_ReturnsTrue()
        {
            string confirmation = " ";
            var result = gestion.ConfirmationEstVide(confirmation);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ConfirmationEstVide_ConfirmationEstValide_ReturnsFalse()
        {
            string confirmation = "password";
            var result = gestion.ConfirmationEstVide(confirmation);
            Assert.IsFalse(result);
        }
    }
}
