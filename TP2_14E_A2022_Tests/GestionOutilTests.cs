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

        [TestMethod()]
        public void Creer_Outil_Avec_Bonne_Valeurs()
        {
            Console.WriteLine("Starting TestMethod...");

            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            outilDbMock.Setup(repo => repo.GetOutils()).Returns(new List<Outils>());
            var gestionOutil = new GestionOutil(outilDbMock.Object);

            var id = ObjectId.GenerateNewId();
            var nom = "Test Outil";
            var description = "Ceci est un outil de test";
            var estBrise = false;

            var outil = gestionOutil.CreerOutil(id, nom, description, estBrise);

            Assert.AreEqual(id, outil.Id);
            Assert.AreEqual(nom, outil.Nom);
            Assert.AreEqual(description, outil.Description);
            Assert.AreEqual(estBrise, outil.EstBrise);
        }
        
        /*[TestMethod]
        public void Creer_Outil_Avec_Mauvaises_Valeurs()
        {
            Console.WriteLine("Starting TestMethod...");

            var outilDbMock = new Mock<IOutilDB>();
            outilDbMock.Setup(repo => repo.GetOutils()).Returns(new List<Outils>());
            var gestionOutil = new GestionOutil(outilDbMock.Object);

            var id = ObjectId.GenerateNewId();
            string invalidNom = string.Empty;
            string invalidDescription = string.Empty;
            var estBrise = false;

            Assert.ThrowsException<ArgumentNullException>(() => gestionOutil.CreerOutil(id, invalidNom, invalidDescription, estBrise));
        }

        
        [TestMethod]
        public void Creer_Outil_Et_Ajouter_A_Liste_Outil()
        {
            var outilDbMock = new Mock<IOutilDB>();
            outilDbMock.Setup(repo => repo.GetOutils()).Returns(new List<Outils>());
            outilDbMock.Setup(repo => repo.CreerOutil(It.IsAny<Outils>())).Callback<Outils>(outil => outilDbMock.Object.GetOutils().Add(outil));
        
            var gestionOutil = new GestionOutil(outilDbMock.Object);

            var id = ObjectId.GenerateNewId();
            var nom = "Test Outil";
            var description = "Ceci est un outil de test";
            var estBrise = false;

            var outil = gestionOutil.CreerOutil(id, nom, description, estBrise);

            Assert.IsTrue(outilDbMock.Object.GetOutils().Contains(outil));
        }
        
        [TestMethod]
        public void Creer_Outil_Et_Lance_Exeception_Avec_Un_Null_Id()
        {
            var outilDbMock = new Mock<IOutilDB>();
            outilDbMock.Setup(repo => repo.GetOutils()).Returns(new List<Outils>());
            var gestionOutil = new GestionOutil(outilDbMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => gestionOutil.CreerOutil(default(ObjectId), "Test Outil", "Ceci est un outil de test", false));
        }

        [TestMethod]
        public void Lire_Tous_Les_Outils()
        {
            var mock = new Mock<IGestionOutil>();
            var expectedOutils = new List<Outils>
            {
                new Outils(ObjectId.GenerateNewId(), "Nom 1", "Description 1", false),
                new Outils(ObjectId.GenerateNewId(), "Nom 2", "Description 2", true)
            };

            mock.Setup(x => x.LireTousLesOutils()).Returns(expectedOutils);

            var outils = mock.Object.LireTousLesOutils();

            Assert.IsNotNull(outils);
            Assert.AreEqual(expectedOutils.Count, outils.Count);
            CollectionAssert.AreEqual(expectedOutils, outils);
        }
        
        [TestMethod]
        public void Modifier_Un_Outil_Avec_Succes()
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

            gestionOutil.ModifierOutil(outil);

            outilDbMock.Verify(repo => repo.ModifierOutil(It.Is<Outils>(o => o.Id == outil.Id && o.Nom == updatedNom && o.Description == updatedDescription && o.EstBrise == updatedEstBrise)), Times.Once);
        }

        [TestMethod]
        public void Supprimer_Un_Outil()
        {
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

        
        [TestMethod]
        public void Nom_Et_Prenom_Valide()
        {
            var outilDbMock = new Mock<IOutilDB>();
            var gestionOutil = new GestionOutil(outilDbMock.Object);
            string validNom = "Test Outil";

            bool result = gestionOutil.NomEstValide(validNom);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Invalide_Nom()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            var gestionOutil = new GestionOutil(outilDbMock.Object);
            string invalidNom = string.Empty;

            // Act
            bool result = gestionOutil.NomEstValide(invalidNom);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Description_Est_Valide_Avec_Description_Valide()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            var gestionOutil = new GestionOutil(outilDbMock.Object);
            string validDescription = "This is a valid description.";

            // Act
            bool result = gestionOutil.DescriptionEstValide(validDescription);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Description_Est_Valide_Avec_Une_Description_Invalide()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            var gestionOutil = new GestionOutil(outilDbMock.Object);
            string invalidDescription = string.Empty;

            // Act
            bool result = gestionOutil.DescriptionEstValide(invalidDescription);

            // Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void GetOutil_Avec_Id_Et_Retourne_Null_Quand_Id_Est_Pas_Trouver()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            outilDbMock.Setup(repo => repo.GetOutilById(It.IsAny<ObjectId>())).Returns((Outils)null);
            var gestionOutil = new GestionOutil(outilDbMock.Object);

            // Act
            var result = gestionOutil.GetOutilById(ObjectId.GenerateNewId());

            // Assert
            Assert.IsNull(result);
        }

        
        [TestMethod]
        public void GetOutil_Avec_Id_Et_Retourne_Le_Bon_Outil_Avec_Succes()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            var expectedOutil = new Outils(ObjectId.GenerateNewId(), "Nom", "Description", false);
            outilDbMock.Setup(repo => repo.GetOutilById(expectedOutil.Id.Value)).Returns(expectedOutil);
            var gestionOutil = new GestionOutil(outilDbMock.Object);

            // Act
            var actualOutil = gestionOutil.GetOutilById(expectedOutil.Id.Value);

            // Assert
            Assert.IsNotNull(actualOutil);
            Assert.AreEqual(expectedOutil.Id, actualOutil.Id);
            Assert.AreEqual(expectedOutil.Nom, actualOutil.Nom);
            Assert.AreEqual(expectedOutil.Description, actualOutil.Description);
            Assert.AreEqual(expectedOutil.EstBrise, actualOutil.EstBrise);
        }
        
        [TestMethod]
        public void Modifie_Outil_Et_Expection_Quand_Realise_Outil_Est_Null()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            var gestionOutil = new GestionOutil(outilDbMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => gestionOutil.ModifierOutil(null));
        }
        
        [TestMethod]
        public void Modifie_Outil_Et_Lance_Exception_Quand_Id_De_Outil_Est_Default()
        {
            // Arrange
            var outilDbMock = new Mock<IOutilDB>();
            var invalidOutil = new Outils(default(ObjectId), "Nom", "Description", false);
            var gestionOutil = new GestionOutil(outilDbMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => gestionOutil.ModifierOutil(invalidOutil));
        }
        */

        
    }
}
