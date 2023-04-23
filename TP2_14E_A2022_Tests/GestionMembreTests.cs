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
            membreDB = new MembreDB();
            gestion = new GestionMembre(membreDB);
            mockMembreDB = new Mock<MembreDB>();
            membres = new List<Membre>() { new Membre(), new Membre() };
        }
        [TestMethod]
        public void GestionMembre_Constructeur_RetourneDesMembresDeMembreDB()
        {
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
            ObjectId idAdresseCivique = ObjectId.GenerateNewId();
            ObjectId idLot = ObjectId.GenerateNewId();
            ObjectId idCotisation = ObjectId.GenerateNewId();

            var membre = gestionMembre.CreerMembre(prenom, nom, idAdresseCivique, idLot, idCotisation);

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
            ObjectId idAdresseCivique = ObjectId.GenerateNewId();
            ObjectId idLot = ObjectId.GenerateNewId();
            ObjectId idCotisation = ObjectId.GenerateNewId();

            // Act
            var membre = gestionMembre.CreerMembre(prenom, nom, idAdresseCivique, idLot, idCotisation);

            // Assert
            Assert.AreNotEqual(membres.Count, 0);
            Assert.AreEqual(membres.Last(), membre);
        }

        [TestMethod]
        public void ModifierMembre_ModifieCorrectementLesInformationsDuMembre()
        {
            // Arrange
            
            var membres = new List<Membre>() { new Membre() { Id = ObjectId.GenerateNewId(), Prenom = "Jean", Nom = "Dupont", IdAdresseCivique = null, IdLot = null, IdCotisation = null } };
            mockMembreDB.Setup(m => m.GetMembres()).Returns(membres);
            var gestionMembre = new GestionMembre(mockMembreDB.Object);

            ObjectId idMembre = membres[0].Id;
            string nouveauPrenom = "Robert";
            string nouveauNom = "Martin";
            ObjectId nouveauIdAdresseCivique = ObjectId.GenerateNewId();
            ObjectId nouveauIdLot = ObjectId.GenerateNewId();
            ObjectId nouveauIdCotisation = ObjectId.GenerateNewId();

            // Act
            var membreModifie = gestionMembre.ModifierMembre(idMembre, nouveauPrenom, nouveauNom, nouveauIdAdresseCivique, nouveauIdLot, nouveauIdCotisation);

            // Assert
            Assert.AreEqual(nouveauPrenom, membreModifie.Prenom);
            Assert.AreEqual(nouveauNom, membreModifie.Nom);
            Assert.AreEqual(nouveauIdAdresseCivique, membreModifie.IdAdresseCivique);
            Assert.AreEqual(nouveauIdLot, membreModifie.IdLot);
            Assert.AreEqual(nouveauIdCotisation, membreModifie.IdCotisation);
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
        public void GetCotisationMessage_RetourneLeBonMessage_QuandIdCotisationEstNull()
        {
            // Arrange
            var membre = new Membre() { IdCotisation = null };
            var gestionMembre = new GestionMembre(new MembreDB());

            // Act
            var message = gestionMembre.GetCotisationMessage(membre);

            // Assert
            Assert.AreEqual("Cotisation à venir", message);
        }
        [TestMethod]
        public void GetCotisationMessage_RetourneAucunMessage_QuandIdCotisationExiste()
        {
            // Arrange
            var membre = new Membre() { IdCotisation = ObjectId.GenerateNewId() };
            var gestionMembre = new GestionMembre(new MembreDB());

            // Act
            var message = gestionMembre.GetCotisationMessage(membre);

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
    }
}