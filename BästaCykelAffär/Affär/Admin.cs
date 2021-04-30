using BästaCykelAffär.Data;
using BästaCykelAffär.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BästaCykelAffär.Affär
{
    class Admin
    {
        // metod för att hämta en samling data som är filtrerad med where, används dock inte i 
        // min konsol applikation men den funkar. Blev excited när jag lite längre ner gjorde en 
        // ToList för att anropa alla cyklar så jag använde den istället i min meny. Den
        // funkar bättre då poängen är att visa alla cyklar oavsett vad dom har för
        // färg, däckstorlek, växlar etc.
        // VisaAllaCyklar() visar bara alla cyklar med däckstorlek som är större än 1 så man
        // hade kunnat ändra metoden så att den endast hämtar exepelvis cyklar som är svarta 
        public void VisaAllaCyklar()
        {
            {
                using CykelAffärContext context = new CykelAffärContext();


                var cyklar = from Cykel in context.Cyklar
                             where Cykel.Däckstorlek_tum > 1
                             orderby Cykel.Cykel_id
                             select Cykel;

                foreach (Cykel c in cyklar)
                {

                    Console.WriteLine("Id: " + c.Cykel_id + "\nCykeltyp: " + c.Cykeltyp + "\nVäxlar: " + c.Färg + "\nDäckstorlek i tum: " + c.Däckstorlek_tum + "\nPris per dag: " + c.Pris );
                    
                }
                
            }
        }

        // en metod för att lägga till data, lägga till en kund 
        public bool LäggTillKund(string Förnamn, string Efternamn, string Email, int Telefonnummer, string Gatuadress, int Postnummer, string Ort, out int kundid)
        {
            using (var context = new CykelAffärContext())
            {
                var nykund = new Kund(Förnamn, Efternamn, Email, Telefonnummer, Gatuadress, Postnummer, Ort);

                context.Kunder.Add(nykund);

                context.SaveChanges();

                kundid = nykund.Kund_id;
                return true;
            }

            kundid = 0;
            return false;
        }

        // en metod för att lägga till data, lägga till en cykel.
        public void LäggTillCykel(string Cykeltyp, int Växlar, string Färg, int Däckstorlek_tum, double Pris)
        {
            using (var context = new CykelAffärContext())
            {
                var nycykel = new Cykel(Cykeltyp, Växlar, Färg, Däckstorlek_tum, Pris);

                context.Cyklar.Add(nycykel);

                context.SaveChanges();            

            }
            
        }

        // en metod för att ta bort data, tar bort en kund
        public void TaBortEnKund(int Kund_id)
        {
            try
            {
                using (var context = new CykelAffärContext())
                {
                    var tabort = new Kund(Kund_id);


                    context.Kunder.Remove(tabort);

                    context.SaveChanges();


                }
            }
            catch
            {
                Console.WriteLine("Du har valt ett id som inte finns, vänligen försök igen!");
                Console.WriteLine("");
            }

          

        }

        // metod för att hämta en samling data
        public void ListaMedCyklar()
        {
            using (var ckl = new CykelAffärContext())
            {
                var cykelLista = ckl.Cyklar.Where(ckl => ckl.Cykel_id > 0).ToList();


                foreach (Cykel b in cykelLista)
                {

                    Console.WriteLine("Cykel Id: " + b.Cykel_id + "\nCykeltyp: " + b.Cykeltyp + "\nVäxlar: " + b.Färg + "\nDäckstorlek i tum: " + b.Däckstorlek_tum + "\nPris per dag: " + b.Pris);
                    Console.WriteLine("");  
                }

             
            }


        }

        // metod för att hämta en samling data
        public void ListaMedOrdrar()
        {
            using (var ord = new CykelAffärContext())
            {
                var orderLista = ord.Ordrar.Where(ord => ord.Order_id > 0).ToList();


                foreach (Order o in orderLista)
                {

                    Console.WriteLine("Order Id: " + o.Order_id + "\nDagen då ordern blev gjord: " + o.Order_gjord + "\nTotalpris: " + o.Total_price + "\nKund Id: " + o.Kund_id +"\n"+ o.CyklarOrdrar);
                }


            }


        }

        // Del två av metoden av att köpa cykel
        public void CykelOrder(int Cykel_id, int kund_id, int price)
        {
            using (var context = new CykelAffärContext())
            {
                var cykelorder = new Order(DateTime.Now, price, kund_id);

                context.Ordrar.Add(cykelorder);

                context.SaveChanges();

                CykeliCykelOrder(Cykel_id, cykelorder.Order_id);
            }

        }
        
        // del ett av metoden att köpa cykel
        public void CykeliCykelOrder(int Cykel_id, int Order_id)
        {
            using (var context = new CykelAffärContext())
            {
                var cykelorder = new CykelOrder(Cykel_id, Order_id);

                context.CyklarOrdrar.Add(cykelorder);

                context.SaveChanges();
            }

        }
    }
}
