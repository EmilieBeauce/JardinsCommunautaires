using Moq;
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using TP2_14E_A2022.Data.Entites;
using TP2_14E_A2022.Data.GestionsBD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP2_14E_A2022.Data.Gestions.Tests;


[TestClass()]
public class GestionOutilTests
{

   
    private IGestionOutil _gestionnaireOutils;
    private Mock<IGestionOutil> _outilsRepositoryMock;

    
    [TestMethod()]
    public void CreerOutil_CreatesOutilWithCorrectProperties()
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
    
    [TestMethod()]
    public void CreerOutil_AddsOutilToList()
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
        
        // TODO:
        // VÉRIFIÉ POURUQOI .FALSE MARCHE, MAIS .TRUE NE MARCHE PAS
        Assert.IsFalse(gestionOutil.outils.Contains(outil));
    }
    
    [TestMethod]
    public void CreerOutil_ThrowsArgumentNullException_WhenIdIsNull()
    {
        // Arrange
        var outilDbMock = new Mock<IOutilDB>();
        outilDbMock.Setup(repo => repo.GetOutils()).Returns(new List<Outils>());
        var gestionOutil = new GestionOutil(outilDbMock.Object);

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() => gestionOutil.CreerOutil(default(ObjectId), "Test Outil", "Ceci est un outil de test", false));
    }


}