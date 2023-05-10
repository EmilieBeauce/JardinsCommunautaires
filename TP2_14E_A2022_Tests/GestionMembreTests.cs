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
using DynamicData;
using MongoDB.Bson;

namespace TP2_14E_A2022.Data.Gestions.Tests
{
    [TestClass()]
    public class GestionMembreTests
    {
        private MembreDB membreDB;
        private GestionMembre gestion;
        private Mock<MembreDB> mockMembreDB;
        private List<Membre> membres;

        [TestInitialize]
        public void TestInitialize()
        {
            Console.WriteLine("Starting TestMethod...");

            membreDB = new MembreDB();
            gestion = new GestionMembre(membreDB);
            mockMembreDB = new Mock<MembreDB>();
            membres = new List<Membre>() { new Membre(), new Membre() };
        }
        [TestMethod]
        public void GestionMembre_Constructeur_RetourneDesMembresDeMembreDB()
        {
            Console.WriteLine("Starting TestMethod...");

            mockMembreDB.Setup(m => m.GetMembres()).Returns(membres);

            var gestionMembre = new GestionMembre(mockMembreDB.Object);

            Assert.AreEqual(membres, gestionMembre.membres);
        }
        [TestMethod]
        public void GestionMembre_Constructeur_RetournepasDesMembresDeMembreDB()
        {
            var membresIncorrects = new List<Membre>() { new Membre() };
            mockMembreDB.Setup(m => m.GetMembres()).Returns(membresIncorrects);

            var gestionMembre = new GestionMembre(mockMembreDB.Object);

            Assert.AreNotEqual(membres, gestionMembre.membres);
        }
        [TestMethod]
        public void CreerMembre_AjouteNouveauMembreEtRetourneLeDernierMembreAjoute()
        {
            mockMembreDB.Setup(m => m.GetMembres()).Returns(membres);
            var gestionMembre = new GestionMembre(mockMembreDB.Object);
            string prenom = "Jean";
            string nom = "Dupont";
            bool estPaye = false;
            ObjectId idAdresseCivique = ObjectId.GenerateNewId();
            ObjectId idLot = ObjectId.GenerateNewId();
            ObjectId idCotisation = ObjectId.GenerateNewId();

            var membre = gestionMembre.CreerMembre(prenom, nom, estPaye, idAdresseCivique, idLot, idCotisation);

            Assert.AreEqual(membres.Last(), membre);
        }
        [TestMethod]
        public void CreerMembre_AjouteNouveauMembreEtRetournePasLeDernierMembreAjoute()
        {
            // Arrange
            mockMembreDB.Setup(m => m.GetMembres()).Returns(membres);
            var gestionMembre = new GestionMembre(mockMembreDB.Object);
            string prenom = "Jean";
            string nom = "Dupont";
            bool estPaye = false;
            ObjectId idAdresseCivique = ObjectId.GenerateNewId();
            ObjectId idLot = ObjectId.GenerateNewId();
            ObjectId idCotisation = ObjectId.GenerateNewId();

            // Act
            var membre = gestionMembre.CreerMembre(prenom, nom, estPaye, idAdresseCivique, idLot, idCotisation);

            // Assert
            Assert.AreNotEqual(membres.Count, 0);
            Assert.AreEqual(membres.Last(), membre);
        }

        [TestMethod]
        public void ModifierMembre_ModifieCorrectementLesInformationsDuMembre()
        {
            // Arrange
            
            var membres = new List<Membre>() { new Membre() { Id = ObjectId.GenerateNewId(), Prenom = "Jean", Nom = "Dupont", IdAdresseCivique = null, IdLot = null } };
            mockMembreDB.Setup(m => m.GetMembres()).Returns(membres);
            var gestionMembre = new GestionMembre(mockMembreDB.Object);

            ObjectId idMembre = membres[0].Id;
            string nouveauPrenom = "Robert";
            string nouveauNom = "Martin";
            ObjectId nouveauIdAdresseCivique = ObjectId.GenerateNewId();
            ObjectId nouveauIdLot = ObjectId.GenerateNewId();
            ObjectId nouveauIdCotisation = ObjectId.GenerateNewId();

            // Act
            var membreModifie = gestionMembre.ModifierMembre(idMembre, nouveauPrenom, nouveauNom, nouveauIdAdresseCivique, nouveauIdLot);

            // Assert
            Assert.AreEqual(nouveauPrenom, membreModifie.Prenom);
            Assert.AreEqual(nouveauNom, membreModifie.Nom);
            Assert.AreEqual(nouveauIdAdresseCivique, membreModifie.IdAdresseCivique);
            Assert.AreEqual(nouveauIdLot, membreModifie.IdLot);
        
        }

        [TestMethod]
        public void GetAdresseMessage_RetourneAdresseACompleter_QuandIdAdresseCiviqueEstNull()
        {
            // Arrange
            var membre = new Membre() { IdAdresseCivique = null };
            var gestionMembre = new GestionMembre(new MembreDB());

            // Act
            var message = gestionMembre.GetAdresseMessage(membre);

            // Assert
            Assert.AreEqual("Adresse à compléter", message);
        }

        [TestMethod]
        public void GetAdresseMessage_RetourneAucunMessage_QuandIdAdresseCiviqueExiste()
        {
            // Arrange
            var membre = new Membre() { IdAdresseCivique = ObjectId.GenerateNewId() };
            var gestionMembre = new GestionMembre(new MembreDB());

            // Act
            var message = gestionMembre.GetAdresseMessage(membre);

            // Assert
            Assert.AreEqual("", message);
        }

        [TestMethod]
        public void GetLotMessage_RetourneMessageAttributionDeLotAFaire_QuandIdLotEstNull()
        {
            // Arrange
            var membre = new Membre() { IdLot = null };
            var gestionMembre = new GestionMembre(new MembreDB());

            // Act
            var message = gestionMembre.GetLotMessage(membre);

            // Assert
            Assert.AreEqual("Attribution de lot à faire", message);
        }
        [TestMethod]
        public void GetLotMessage_RetourneAucunMessage_QuandIdLotExiste()
        {
            // Arrange
            var membre = new Membre() { IdLot = ObjectId.GenerateNewId() };
            var gestionMembre = new GestionMembre(new MembreDB());

            // Act
            var message = gestionMembre.GetLotMessage(membre);

            // Assert
            Assert.AreEqual("", message);
        }
        
        [TestMethod]
        public void PrenomEstValide_With_Valid_Prenom()
        {
            // Arrange
            var membreDbMock = new Mock<MembreDB>();
            var gestionMembre = new GestionMembre(membreDbMock.Object);
            string validPrenom = "John";

            // Act
            bool result = gestionMembre.PrenomEstValide(validPrenom);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PrenomEstValide_With_Invalid_Prenom()
        {
            // Arrange
            var membreDbMock = new Mock<MembreDB>();
            var gestionMembre = new GestionMembre(membreDbMock.Object);
            string invalidPrenom = string.Empty;

            // Act
            bool result = gestionMembre.PrenomEstValide(invalidPrenom);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NomEstValide_With_Valid_Nom()
        {
            // Arrange
            var membreDbMock = new Mock<MembreDB>();
            var gestionMembre = new GestionMembre(membreDbMock.Object);
            string validNom = "Doe";

            // Act
            bool result = gestionMembre.NomEstValide(validNom);

            // Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void UpdateMembreCotisation_UpdateCotisation_WhenValidInputsAreProvided()
        {
            // Arrange
            var membreId = ObjectId.GenerateNewId();
            var newCotisation = 50;
            var mockMembreDB = new Mock<MembreDB>();
            var gestionMembre = new GestionMembre(mockMembreDB.Object);

            // Act
            gestionMembre.UpdateMembreCotisation(membreId, newCotisation);

            // Assert
            mockMembreDB.Verify(mock => mock.UpdateCotisation(membreId, newCotisation), Times.Once);
        }
        
        [TestMethod]
        public void GetMembreById_RetourneMembre_QuandMembreExiste()
        {
            // Arrange
            var membreId = ObjectId.GenerateNewId();
            var membre = new Membre() { Id = membreId };
            var membreDbMock = new Mock<MembreDB>();
            membreDbMock.Setup(db => db.GetMembre(membreId)).Returns(membre);
            var gestionMembre = new GestionMembre(membreDbMock.Object);

            // Act
            var result = gestionMembre.GetMembreById(membreId);

            // Assert
            Assert.AreEqual(membreId, result.Id);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMembreById_ThrowsException_WhenMembreIdIsDefault()
        {
            // Arrange
            var gestionMembre = new GestionMembre(new MembreDB());
            var defaultId = default(ObjectId);

            // Act
            var membre = gestionMembre.GetMembreById(defaultId);

        }
        
        [TestMethod]
        public void GetMembreById_ReturnsMembre_WhenMembreExists()
        {
            // Arrange
            var membre = new Membre() { Id = ObjectId.GenerateNewId() };
            var membreDbMock = new Mock<MembreDB>();
            membreDbMock.Setup(m => m.GetMembre(membre.Id)).Returns(membre);
            var gestionMembre = new GestionMembre(membreDbMock.Object);

            // Act
            var result = gestionMembre.GetMembreById(membre.Id);

            // Assert
            Assert.AreEqual(membre, result);
        }





    }
}