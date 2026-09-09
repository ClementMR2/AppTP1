using System;
using System.Collections.Generic;
using System.Text;

namespace AppTP1
{
    public class Utilisateur
    {
        public string Prenom;
        public string Nom;
        public string Adresse;
        public string CodePostal;
        public string Ville;
        public string Email;
        public string Telephone;

        public Utilisateur(string prenom, string nom, string adr, string codePostal, string ville, string email, string tel)
        {
            this.Prenom = prenom;
            this.Nom = nom;
            this.Adresse = adr;
            this.CodePostal = codePostal;
            this.Ville = ville;
            this.Email = email;
            this .Telephone = tel;
        }

        public string asCsv()
        {
            return this.Prenom + ";" + this.Nom + ";" + 
                this.Adresse + ";" + this.CodePostal + ";" + 
                this.Ville + ";" + this.Email + ";" + this.Telephone;
        }
    }
}
