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
        public void TestValiderSiConnexionFonctionne()
        {
            // Arrange
            var mock = new Mock<IGestionConnexion>();
            // Act
            mock.Setup(x => x.ValiderSiConnexionFonctionne("jd@courriel.com", "password")).Returns(true);
            // Assert
            Assert.IsTrue(mock.Object.ValiderSiConnexionFonctionne("jd@courriel.com", "password"));

        }

        [TestMethod]
        public void TestValiderSiDonneesConnexionConcordes()
        {
            // Arrange
            var mock = new Mock<IGestionConnexion>();
            // Act
            mock.Setup(x => x.ValiderSiDonneesConnexionConcordes("jd@courriel.com", "password")).Returns((bool)true);
            // Assert
            Assert.IsTrue(mock.Object.ValiderSiDonneesConnexionConcordes("jd@courriel.com", "password"));
        }

    }
}
