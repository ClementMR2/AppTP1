using AppTP1;

namespace TestProject1
{
    [TestClass]
    public sealed class TestUtilisateur
    {
        static Utilisateur user = new Utilisateur(
            "Bobby", "Bob", "1 Rue Exemple", "75001", "Paris", "bob.dylan@example.com", "0123456789");

        [TestMethod]
        public void TestCreation()
        {
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestLettersOnName()
        {
            foreach (char c in user.Prenom)
            {
                Assert.IsTrue(Char.IsLetter(c) || Char.IsWhiteSpace(c) || c == '-');
            }
            foreach (char c in user.Nom)
            {
                Assert.IsTrue(Char.IsLetter(c) || Char.IsWhiteSpace(c) || c == '-');
            }
        }

        [TestMethod]
        public void TestNotNullProperties()
        {
            Assert.IsFalse(String.IsNullOrEmpty(user.Prenom));
            Assert.IsFalse(String.IsNullOrEmpty(user.Nom));
            Assert.IsFalse(String.IsNullOrEmpty(user.Adresse));
            Assert.IsFalse(String.IsNullOrEmpty(user.CodePostal));
            Assert.IsFalse(String.IsNullOrEmpty(user.Ville));
            Assert.IsFalse(String.IsNullOrEmpty(user.Email));
            Assert.IsFalse(String.IsNullOrEmpty(user.Telephone));
        }

        [TestMethod]
        public void TestCodePostal()
        {
            Assert.IsTrue(user.CodePostal.All(c => Char.IsDigit(c)));
        }

        [TestMethod]
        public void TestTelephone()
        {
            string digitsOnly = new string(user.Telephone.Where(Char.IsDigit).ToArray());
            Assert.IsTrue(digitsOnly.Length >= 7);
            Assert.IsTrue(digitsOnly.All(Char.IsDigit));
        }

        [TestMethod]
        public void TestEmail()
        {
            Assert.IsTrue(user.Email.Contains("@"));
            Assert.IsTrue(user.Email.Contains('.'));
        }
    }
}
