using System.Globalization;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace AppTP1
{
    public class Contact
    {
        private List<Utilisateur> ListUtilisateurs = new List<Utilisateur>();

        public void Ajouter(string p, string n, string adr, string codePostal, string ville, string email, string tel)
        {
            p = p.Substring(0, 1).ToUpper() + p.Substring(1).ToLower();
            n = n.ToUpper();
            ListUtilisateurs.Add(new Utilisateur(p, n, adr, codePostal, ville, email, tel));
        }

        public void Supprimer(int index)
        {
            Utilisateur temp = ListUtilisateurs[index];
            if (temp == null)
            {
                Console.WriteLine("Contact introuvable");
                return;
            }

            ListUtilisateurs.Remove(temp);

            Console.WriteLine(AfficherContacts());
        }

        public bool SauvegarderContact(string fname)
        {
            //if (nombreContact() == 0) return false;
            bool result = true;
            try
            {
                using var writer = new StreamWriter(fname, false); // overwrite
                foreach (Utilisateur elem in ListUtilisateurs)
                {
                    //Console.WriteLine(elem.asCsv());
                    writer.WriteLine(elem.asCsv());
                }

            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool RecupererContacts(string fname)
        {
            bool result = true;
            try
            {
                using var reader = new StreamReader(fname);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] items = line.Split(";");
                    if (items.Length == 7)
                        ListUtilisateurs.Add(new Utilisateur(items[0], items[1], items[2], items[3], items[4], items[5], items[6]));
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool ModifierContact(int index)
        {
            if (nombreContact() == 0)
            {
                Console.WriteLine("La liste de contact est vide.");
                return false;
            }

            Utilisateur temp = ListUtilisateurs[index];
            if (temp == null)
            {
                Console.WriteLine("Contact introuvable");
                return false;
            }

            Console.WriteLine("Contact trouvé : " + AfficherContact(index));

            int editName, editLastName, editAdr, editCode, editVille, editEmail, editTel = 0;

            Console.WriteLine("Voulez-vous modifier le prénom ? (1/0)");
            editName = int.Parse(Console.ReadLine());
            if (editName == 1)
            {
                Console.WriteLine("Entrez le nouveau prénom : ");
                string newPrenom = Console.ReadLine();
                temp.Prenom = newPrenom.Substring(0, 1).ToUpper() + newPrenom.Substring(1).ToLower();
            }

            Console.WriteLine("Voulez-vous modifier le nom ? (1/0)");
            editLastName = int.Parse(Console.ReadLine());
            if (editLastName == 1)
            {
                Console.WriteLine("Entrez le nouveau nom : ");
                string newNom = Console.ReadLine();
                temp.Nom = newNom.ToUpper();
            }

            Console.WriteLine("Voulez-vous modifier l'adresse ? (1/0)");
            editAdr = int.Parse(Console.ReadLine());
            if (editAdr == 1)
            {
                Console.WriteLine("Entrez la nouvelle adresse : ");
                string newAdr = Console.ReadLine();
                temp.Adresse = newAdr;
            }

            Console.WriteLine("Voulez-vous modifier le code postal ? (1/0)");
            editCode = int.Parse(Console.ReadLine());
            if (editCode == 1)
            {
                Console.WriteLine("Entrez le nouveau code postal : ");
                string newCode = Console.ReadLine();
                temp.CodePostal = newCode;
            }

            Console.WriteLine("Voulez-vous modifier la ville ? (1/0)");
            editVille = int.Parse(Console.ReadLine());
            if (editVille == 1)
            {
                Console.WriteLine("Entrez la nouvelle ville : ");
                string newVille = Console.ReadLine();
                temp.Ville = newVille;
            }

            Console.WriteLine("Voulez-vous modifier l'e-mail ? (1/0)");
            editEmail = int.Parse(Console.ReadLine());
            if (editEmail == 1)
            {
                Console.WriteLine("Entrez le nouvel e-mail : ");
                string newEmail = Console.ReadLine();
                temp.Email = newEmail;
            }

            Console.WriteLine("Voulez-vous modifier le numéro ? (1/0)");
            editTel = int.Parse(Console.ReadLine());
            if (editTel == 1)
            {
                Console.WriteLine("Entrez le nouveau numéro : ");
                string newTel = Console.ReadLine();
                temp.Telephone = newTel;
            }

            // Ajouter à la liste
            ListUtilisateurs[index] = temp;

            return true;
        }

        public string AfficherContacts()
        {
            StringBuilder sb = new StringBuilder();
            int id = 0;
            foreach (Utilisateur elem in ListUtilisateurs)
            {
                sb.AppendLine("[" + id + "] " + " -> \n\tPrénom : " + elem.Prenom + 
                    " \n\tNom : " + elem.Nom + 
                    " \n\tAdresse : " + elem.Adresse + 
                    " \n\tCode postal : " + elem.CodePostal + 
                    " \n\tVille : " + elem.Ville + 
                    " \n\tEmail : " + elem.Email + 
                    " \n\tTéléphone : " + elem.Telephone);
                id++;
            }
            return sb.ToString();
        }

        public string AfficherContact(int index)
        {
            Utilisateur usr = ListUtilisateurs[index];
            if (usr != null)
            {
                return "Prénom : " + usr.Prenom +
                    ", Nom : " + usr.Nom +
                    ", Adresse : " + usr.Adresse +
                    ", Code postal : " + usr.CodePostal +
                    ", Ville : " + usr.Ville +
                    ", Email : " + usr.Email +
                    ", Téléphone : " + usr.Telephone;
            }

            return "";
        }

        public string chercherContact(string valeur)
        {
            if (nombreContact() != 0)
            {
                valeur = valeur.ToLower();
                StringBuilder sb = new StringBuilder("Contact(s) trouvé(s) :\n");
                for (int i = 0; i < nombreContact(); i++)
                {
                    if (formattedString(ListUtilisateurs[i].Prenom) == formattedString(valeur) ||
                        formattedString(ListUtilisateurs[i].Nom) == formattedString(valeur) ||
                        formattedString(ListUtilisateurs[i].Adresse) == formattedString(valeur) ||
                        formattedString(ListUtilisateurs[i].CodePostal) == formattedString(valeur) ||
                        formattedString(ListUtilisateurs[i].Ville) == formattedString(valeur) ||
                        formattedString(ListUtilisateurs[i].Email) == formattedString(valeur) ||
                        formattedString(ListUtilisateurs[i].Telephone) == formattedString(valeur))
                    {
                        sb.AppendLine("[" + i + "] " + AfficherContact(i) + "\n");
                    }
                }

                return sb.ToString();
            }

            return "Aucun contact trouvé";

        }

        public int nombreContact()
        {
            return ListUtilisateurs.Count;
        }

        public string formattedString(string s)
        {
            s = s.ToLower().Trim();
            return string.Concat(
                s.Normalize(NormalizationForm.FormD)
                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            ).Normalize(NormalizationForm.FormC);
        }
    }
}
