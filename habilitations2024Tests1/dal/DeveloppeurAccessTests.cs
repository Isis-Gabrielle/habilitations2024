using Microsoft.VisualStudio.TestTools.UnitTesting;
using habilitations2024.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using habilitations2024.model;

namespace habilitations2024.dal.Tests
{
    [TestClass()]
    public class DeveloppeurAccessTests
    {
        [TestMethod()]
        public void GetLesDeveloppeurs_AvecProfil_DeveloppeursFiltres()
        {
            DeveloppeurAccess developpeurAccess = new DeveloppeurAccess();
            Profil profilTest = new Profil(2, "designer");
            List<Developpeur> developpeursFiltres = developpeurAccess.GetLesDeveloppeurs(profilTest);
            int expectedCount = 5; 
            Assert.AreEqual(expectedCount, developpeursFiltres.Count, "Le nombre de développeurs filtrés par profil n'est pas valide.");
        }

        [TestMethod()]
        public void GetLesDeveloppeurs_SansProfil_AllDeveloppeurs()
        {
            DeveloppeurAccess developpeurAccess = new DeveloppeurAccess();
            List<Developpeur> developpeurs = developpeurAccess.GetLesDeveloppeurs();
            int expectedTotal = 15;
            Assert.AreEqual(expectedTotal, developpeurs.Count, "Le nombre total de développeurs retourné n'est pas valide.");
        }
    }
}