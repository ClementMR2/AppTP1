using System;
using System.Collections.Generic;
using System.Text;

namespace AppTP1
{
    internal class Program
    {
        static Contact cts;
        static string FileName = "contacts.csv";

        public static void Main(string[] args)
        {
            cts = new Contact();

            bool ok = cts.RecupererContacts(FileName);
            if (ok)
            {
                Console.WriteLine("[Contacts] Utilisateurs récupérés : " + cts.nombreContact());
            }

            bool flag = false;

            while(!flag)
            {
                Console.WriteLine("Choisir une option : ");
                Console.WriteLine("""
                [ 1 ] Ajouter un contact
                [ 2 ] Modifier un contact
                [ 3 ] Supprimer un contact
                [ 4 ] Sauvegarder les contacts
                [ 5 ] Afficher le nombre de contacts
                [ 6 ] Afficher les contacts
                [ 7 ] Chercher un contact
                [ 0 ] Quitter
                """);
                
               try {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Entrez le prénom : ");
                            string prenom = reask();
                            Console.WriteLine("Entrez le nom : ");
                            string nom = reask();
                            Console.WriteLine("Entrez l'adresse : ");
                            string adr = reask();
                            Console.WriteLine("Entrez le code postal : ");
                            string codePostal = reask();
                            Console.WriteLine("Entrez la ville : ");
                            string ville = reask();
                            Console.WriteLine("Entrez l'email : ");
                            string email = reask();
                            Console.WriteLine("Entrez le tel : ");
                            string tel = reask();

                            cts.Ajouter(prenom, nom, adr, codePostal, ville, email, tel);
                            break;
                        case 2:
                            Console.WriteLine("Liste de contacts : ");
                            Console.WriteLine(cts.AfficherContacts());

                            Console.WriteLine("Quel élément souhaitez-vous modifier [indice] ?");
                            ok = cts.ModifierContact(int.Parse(Console.ReadLine()));
                            if (ok)
                            {
                                Console.WriteLine("Modification réussite!");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Liste de contacts : ");
                            Console.WriteLine(cts.AfficherContacts());
                            Console.WriteLine("Quel élément souhaitez-vous supprimer [indice] ?");
                            cts.Supprimer(int.Parse(Console.ReadLine()));
                            break;
                        case 4:
                            ok = cts.SauvegarderContact(FileName);
                            if (ok)
                            {
                                Console.WriteLine("Sauvegarde réussite!");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Nombre de contacts : " + cts.nombreContact());
                            break;
                        case 6: 
                            Console.WriteLine("Liste de contacts : ");
                            Console.WriteLine(cts.AfficherContacts());
                            break;
                        case 7:
                            Console.WriteLine("Rechercher par prénom ou par nom : ");
                            Console.WriteLine(cts.chercherContact(Console.ReadLine()));
                            break;
                        case 0:
                            Console.WriteLine("Au revoir!");
                            ok = cts.SauvegarderContact(FileName);
                            if (ok)
                            {
                                Console.WriteLine("Sauvegarde réussite!");
                            }
                            flag = true;
                            break;
                    }
                    // Timer temporaire
                    Thread.Sleep(1000);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Valeur invalide : " + ex.Message);
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Impossible de trouver un élément à cet indice") ; 
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Nombre trop grand!");
                    continue;
                }
            }
        }

        static string reask()
        {
            string input = Console.ReadLine();
            while (input == "" || input == null)
            {
                Console.WriteLine("Entrer à nouveau : ");
                input = Console.ReadLine();
            }

            return input;
        }
    }
}
