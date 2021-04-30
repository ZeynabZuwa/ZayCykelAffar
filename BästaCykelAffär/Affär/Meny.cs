using BästaCykelAffär.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BästaCykelAffär.Affär
{
    public class Meny
    {
        private int kundId = 0;

        public void VisaMeny()
        {

            
            Console.WriteLine("VÄLKOMMEN TILL ZAY CYKEL AFFÄR!");
            Console.WriteLine("");


            Console.WriteLine("Tryck 1 för att visa alla cyklar");

            Console.WriteLine("Tryck 2 för att registrera dig som kund och köpa en cykel");
            Console.WriteLine("");
            Console.WriteLine("** Admin funktioner **");

            Console.WriteLine("Tryck 3 för en lista med alla ordrar");

            Console.WriteLine("Tryck 4 för att ändra pris på cykel");

            Console.WriteLine( "Tryck 5 för att lägga till en cykel");

            Console.WriteLine("Tryck 6 för att ta bort en kund");

            string input1 = Console.ReadLine();

            switch (input1)
            {
                case "1":
                    Console.WriteLine("Lista med alla cyklar");
                    Program.admin.ListaMedCyklar();
                    Console.WriteLine("");

                    break;

                case "2":

                    try
                    {
                        Console.WriteLine("Vänligen skapa ett kund konto för att komma vidare: ");

                        Console.WriteLine("Förnamn: ");
                        string förnamn = Console.ReadLine();

                        Console.WriteLine("Efternamn: ");
                        string efternamn = Console.ReadLine();

                        Console.WriteLine("Email: ");
                        string email = Console.ReadLine();

                        Console.WriteLine("Telefonnummer (Endast siffror): ");
                        int telefonnummer = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Gatuadress: ");
                        string gatuadress = Console.ReadLine();

                        Console.WriteLine("postnummer (Endast siffror): ");
                        int postNummer = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ort: ");
                        string ort = Console.ReadLine();

                        int _kundId;
                        if (Program.admin.LäggTillKund(förnamn, efternamn, email, telefonnummer, gatuadress, postNummer, ort, out _kundId))
                        {
                            kundId = _kundId;
                        }

                        Program.admin.ListaMedCyklar();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();

                        Console.WriteLine("Skriv in cykel id på den cykel du vill köpa: ");
                        int Cykel_id = Convert.ToInt32(Console.ReadLine());

                        // det är för att se att det id som man skriver in verkligen finns i databasen

                        using (var context = new CykelAffärContext())
                        {
                            var v = context.Cyklar.Where(context => context.Cykel_id == Cykel_id).Select(collumn => collumn.Pris).FirstOrDefault();

                            Program.admin.CykelOrder(Cykel_id, kundId, Convert.ToInt32(v));


                        }
                    }

                    catch
                    {
                        Console.WriteLine("Var noga med att endast använda siffror på telefonnummer, postnummer och id.");
                        Console.WriteLine("Vänligen försök igen!");
                        Console.WriteLine("");
                    }
                    
                  /* Console.WriteLine("Vänligen skapa ett kund konto för att komma vidare: ");

                   Console.WriteLine("Förnamn: ");
                   string förnamn = Console.ReadLine();

                   Console.WriteLine("Efternamn: ");
                   string efternamn = Console.ReadLine();

                   Console.WriteLine("Email: ");
                   string email = Console.ReadLine();

                   Console.WriteLine("Telefonnummer (Endast siffror): ");
                   int telefonnummer = Convert.ToInt32(Console.ReadLine());

                   Console.WriteLine("Gatuadress: ");
                   string gatuadress = Console.ReadLine();

                   Console.WriteLine("postnummer (Endast siffror): ");
                   int postNummer = Convert.ToInt32(Console.ReadLine());

                   Console.WriteLine("Ort: ");
                   string ort = Console.ReadLine(); */

                 /*  int _kundId;
                   if (Program.admin.LäggTillKund(förnamn, efternamn, email, telefonnummer, gatuadress, postNummer, ort, out _kundId))
                   {
                       kundId = _kundId;
                   }

                            Program.admin.ListaMedCyklar();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();

                                Console.WriteLine("Skriv in cykel id på den cykel du vill köpa: ");
                                int Cykel_id = Convert.ToInt32(Console.ReadLine());

                                // det är för att se att det id som man skriver in verkligen finns i databasen

                                using (var context = new CykelAffärContext())
                                {
                                    var v = context.Cyklar.Where(context => context.Cykel_id == Cykel_id).Select(collumn => collumn.Pris).FirstOrDefault();

                                    Program.admin.CykelOrder(Cykel_id, kundId, Convert.ToInt32(v));


                                } */

                    break;

                case "3":

                Console.WriteLine("Lista med ordrar");
                Program.admin.ListaMedOrdrar();
                    break;
            case "4":
                Console.WriteLine("Ange cykel id för att ändra pris");
                int _cykel_id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ange nytt pris för cykeln");
                int price = Convert.ToInt32(Console.ReadLine());

                using (var context = new CykelAffärContext())
                {

                    var v = context.Cyklar.SingleOrDefault(b => b.Cykel_id == _cykel_id);
                    v.Pris = price;
                    context.SaveChanges();
                }
                break;

                case "5":

                    try
                    {
                        Console.WriteLine("Nu kan du lägga till en cykel");
                        Console.WriteLine("");
                        Console.WriteLine("Cykeltyp: ");
                        string cykeltyp = Console.ReadLine();

                        Console.WriteLine("Växlar: ");
                        int växlar = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Färg: ");
                        string färg = Console.ReadLine();

                        Console.WriteLine("Däckstorlek i tum: ");
                        int däckstorlek_tum = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Pris för cykel: ");
                        double pris = Convert.ToInt32(Console.ReadLine());


                        Program.admin.LäggTillCykel(cykeltyp, växlar, färg, däckstorlek_tum, pris);

                    }

                    catch
                    {
                        Console.WriteLine("Du får bara använda siffror på växlar, däckstorlek och pris. Vänligen försök igen!");
                        Console.WriteLine("");
                    }
                    
                  
                    break;


                case "6":

                    Console.WriteLine("Skriv id på den kund du vill ta bort");
                    Console.WriteLine("Kund Id: ");
                    int Kund_id = Convert.ToInt32(Console.ReadLine());

                    Program.admin.TaBortEnKund(Kund_id);
                    break;
            }
            
            this.VisaMeny();

           


        }
    }
}
