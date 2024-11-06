using System;

namespace CompteBanqueNS
{
    public class CompteBancaire
    {
        private string m_nomClient;
        private double m_solde;
        private bool m_bloqué = false;
        private CompteBancaire()
        { }

        public CompteBancaire(string nomClient, double solde)
        {

            m_nomClient = nomClient;
            m_solde = solde;
        }

        public string nomClient { get { return m_nomClient; } }
        public double Balance { get { return m_solde; } }

        public void Débiter(double montant)
        {
            if (m_bloqué)
            {
                throw new Exception("Compte Bloqué");
            }
            if (montant > m_solde)
            {
                throw new ArgumentOutOfRangeException("Montant débité doit etre supérieur ou égal au solde disponible");
            }
            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Montant doit etre positif");
            }
            m_solde -= montant; //Code intentionnellement faux
        }

        public void Créditer(double montant)
        {
            if (m_bloqué)
            {
                throw new Exception("Compte Bloqué");
            }
            if (montant < 0)
            {
                throw new ArgumentOutOfRangeException("Montant crébité doit etre supérieur à zéro");
            }
            m_solde += montant;
        }

        private void BloquerCompte()
        {
            m_bloqué = true;
        }

        private void DébloquerCompte()
        {
            m_bloqué = false;
        }

        public static void Main()
        {
            CompteBancaire cb = new CompteBancaire("Pr. Abdoulaye Diankha", 500000);

            cb.Créditer(500000);
            cb.Débiter(400000);
            Console.WriteLine("Solde disponible égal à F{0}", cb.Balance);
        }


    }
}
