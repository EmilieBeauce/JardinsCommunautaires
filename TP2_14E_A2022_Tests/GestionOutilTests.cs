using Moq;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.GestionsBD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP2_14E_A2022.Data.Gestions.Tests
{
    [TestClass]
    public class GestionOutilTests
    {
        private IGestionOutil _gestionnaireOutils;
        private Mock<IGestionOutil> _outilsRepositoryMock;

        /// <summary>
        /// TESTS POUR LE CREATE
        /// </summary>
        [TestMethod()]
        public void Creer_Outil_Avec_Bonne_Valeurs()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            outilDbMock.Setup(repo => repo.GetOutils()).Returns(new List<Outils>());
            var gestionOutil = new GestionOutil(outilDbMock.Object);

            var id = ObjectId.GenerateNewId();
            var nom = "Test Outil";
            var description = "Ceci est un outil de test";
            var estBrise = false;

            // Act
            var outil = gestionOutil.CreerOutil(id, nom, description, estBrise);

            // Assert
            //Assert.NotNull(outil);
            Assert.AreEqual(id, outil.Id);
            Assert.AreEqual(nom, outil.Nom);
            Assert.AreEqual(description, outil.Description);
            Assert.AreEqual(estBrise, outil.EstBrise);
        }
        
        [TestMethod]
        public void Creer_Outil_Avec_Mauvaises_Valeurs()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            outilDbMock.Setup(repo => repo.GetOutils()).Returns(new List<Outils>());
            var gestionOutil = new GestionOutil(outilDbMock.Object);

            var id = ObjectId.GenerateNewId();
            string invalidNom = string.Empty;
            string invalidDescription = string.Empty;
            var estBrise = false;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => gestionOutil.CreerOutil(id, invalidNom, invalidDescription, estBrise));
        }

        
        [TestMethod]
        public void Creer_Outil_Et_Ajouter_A_Liste_Outil()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            outilDbMock.Setup(repo => repo.GetOutils()).Returns(new List<Outils>());
            outilDbMock.Setup(repo => repo.CreerOutil(It.IsAny<Outils>())).Callback<Outils>(outil => outilDbMock.Object.GetOutils().Add(outil));
        
            var gestionOutil = new GestionOutil(outilDbMock.Object);

            var id = ObjectId.GenerateNewId();
            var nom = "Test Outil";
            var description = "Ceci est un outil de test";
            var estBrise = false;

            // Act
            var outil = gestionOutil.CreerOutil(id, nom, description, estBrise);

            // Assert
            Assert.IsTrue(outilDbMock.Object.GetOutils().Contains(outil));
        }
        
        [TestMethod]
        public void Creer_Outil_Et_Lance_Exeception_Avec_Un_Null_Id()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            outilDbMock.Setup(repo => repo.GetOutils()).Returns(new List<Outils>());
            var gestionOutil = new GestionOutil(outilDbMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => gestionOutil.CreerOutil(default(ObjectId), "Test Outil", "Ceci est un outil de test", false));
        }

        /// <summary>
        /// TESTS POUR LE READALL
        /// </summary>
        [TestMethod]
        public void Lire_Tous_Les_Outils()
        {
            // Arrange
            var mock = new Mock<IGestionOutil>();
            var expectedOutils = new List<Outils>
            {
                new Outils(ObjectId.GenerateNewId(), "Nom 1", "Description 1", false),
                new Outils(ObjectId.GenerateNewId(), "Nom 2", "Description 2", true)
            };

            mock.Setup(x => x.LireTousLesOutils()).Returns(expectedOutils);

            // Act
            var outils = mock.Object.LireTousLesOutils();

            // Assert
            //mauvais valide que c nul et que c le bon comte = 2 test
            Assert.IsNotNull(outils);
            Assert.AreEqual(expectedOutils.Count, outils.Count);
            CollectionAssert.AreEqual(expectedOutils, outils);
        }
        
        /// <summary>
        /// TEST POUR LES MODIFIÉ
        /// </summary>
        [TestMethod]
        public void Modifier_Un_Outil()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            var outil = new Outils(ObjectId.GenerateNewId(), "Nom", "Description", false);
            outilDbMock.Setup(repo => repo.GetOutilById(outil.Id.Value)).Returns(outil);
            outilDbMock.Setup(repo => repo.ModifierOutil(It.IsAny<Outils>())).Verifiable();

            var gestionOutil = new GestionOutil(outilDbMock.Object);

            string updatedNom = "Updated Test Outil";
            string updatedDescription = "Ceci est un outil de test mis à jour";
            bool updatedEstBrise = true;

            outil.Nom = updatedNom;
            outil.Description = updatedDescription;
            outil.EstBrise = updatedEstBrise;

            // Act
            gestionOutil.ModifierOutil(outil);

            // Assert
            outilDbMock.Verify(repo => repo.ModifierOutil(It.Is<Outils>(o => o.Id == outil.Id && o.Nom == updatedNom && o.Description == updatedDescription && o.EstBrise == updatedEstBrise)), Times.Once);
        }

        [TestMethod]
        public void Supprimer_Un_Outil()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            var outil = new Outils
            {
                Id = ObjectId.GenerateNewId(),
                Nom = "Test Outil",
                Description = "Ceci est un outil de test",
                EstBrise = false
            };

            outilDbMock.Setup(repo => repo.CreerOutil(outil)).Verifiable();
            outilDbMock.Setup(repo => repo.SupprimerOutil(outil.Id.Value)).Verifiable();
            outilDbMock.Setup(repo => repo.GetOutilById(outil.Id.Value)).Returns((Outils)null);

            var gestionOutil = new GestionOutil(outilDbMock.Object);

            // Act
            gestionOutil.CreerOutil(outil.Id.Value, outil.Nom, outil.Description, outil.EstBrise);
            gestionOutil.SupprimerOutil(outil.Id.Value);
            var deletedOutil = gestionOutil.GetOutilById(outil.Id.Value);

            // Assert
            outilDbMock.Verify(repo => repo.SupprimerOutil(outil.Id.Value), Times.Once);
            Assert.IsNull(deletedOutil);
        }

        
    }
}
