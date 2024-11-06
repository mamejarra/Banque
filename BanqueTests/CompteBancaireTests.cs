using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompteBanqueNS;
using System;

namespace BanqueTests
{
    [TestClass]
    public class CompteBancaireTests
    {
        [TestMethod]
        public void VérifierDébitCompteCorrect()
        {
            double soldeInitial = 500000;
            double montantDébit = 400000;
            double soldeAttendu = 100000;
            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);

            compte.Débiter(montantDébit);

            Assert.AreEqual(soldeAttendu, compte.Balance, 0.001, "Compte débité incorrectement");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DébiterMontantNégatifLèveArgumentOutOfRange()
        {
            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", 500000);
            double montantDébit = -100;

            compte.Débiter(montantDébit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DébiterMontantSupérieurSoldeLèveArgumentOutOfRange()
        {
            var compte = new CompteBancaire("Pr. Abdoulaye Diankha", 500000);
            double montantDébit = 600000;

            compte.Débiter(montantDébit);
        }
    }
}
