using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public sealed class TestContact
    {
        [TestMethod]
        public void TestAjouter()
        {
            var c = new AppTP1.Contact();
            int before = c.nombreContact();
            c.Ajouter("Alice", "Dupont", "1 rue", "75001", "Paris", "a@example.com", "0123456789");
            Assert.AreEqual(before + 1, c.nombreContact());
        }

        [TestMethod]
        public void TestSupprimer()
        {
            var c = new AppTP1.Contact();
            c.Ajouter("First", "One", "Adr1", "11111", "City1", "one@example.com", "0101010101");
            c.Ajouter("Second", "Two", "Adr2", "22222", "City2", "two@example.com", "0202020202");

            Assert.AreEqual(2, c.nombreContact());

            c.Supprimer(0);

            Assert.AreEqual(1, c.nombreContact());
            string remaining = c.AfficherContact(0);
            Assert.IsTrue(remaining.Contains("Second"));
        }
    }
}
