using BästaCykelAffär.Affär;
using BästaCykelAffär.Data;
using BästaCykelAffär.Models;
using System;

namespace BästaCykelAffär
{
    class Program

    {
        public static Meny meny = new Meny();
        public static Admin admin = new Admin();
        static void Main(string[] args)
        {
            using CykelAffärContext context = new CykelAffärContext();

            meny.VisaMeny();


            //Om du kör koden nedan så kommer databasen att bemannas med 6 cyklar och det blir 
            //lättare att börja så
            /*Cykel damcykel1 = new Cykel()
            {
                Cykeltyp = "Damcykel",
                Växlar = 3,
                Färg = "Röd",
                Däckstorlek_tum = 28,
                Pris = 2500
                
            };
            context.Cyklar.Add(damcykel1);

            Cykel damcykel2 = new Cykel()
            {
                Cykeltyp = "Damcykel",
                Växlar = 5,
                Färg = "Svart",
                Däckstorlek_tum = 28,
                Pris = 3000

            };
            context.Add(damcykel2);

            Cykel elcykel1 = new Cykel()
            {
                Cykeltyp = "Elcykel",
                Växlar = 6,
                Färg = "Svart",
                Däckstorlek_tum = 28,
                Pris = 5000

            };
            context.Add(elcykel1);

            Cykel elcykel2 = new Cykel()
            {
                Cykeltyp = "Elcykel",
                Växlar = 8,
                Färg = "Rosa",
                Däckstorlek_tum = 28,
                Pris = 5500

            };
            context.Add(elcykel2);

            Cykel mountainbike1 = new Cykel()
            {
                Cykeltyp = "Mountainbike",
                Växlar = 10,
                Färg = "Svart",
                Däckstorlek_tum = 27,
                Pris = 350

            };
            context.Add(mountainbike1);

            Cykel mountainbike2 = new Cykel()
            {
                Cykeltyp = "Mountainbike",
                Växlar = 21,
                Färg = "Brun",
                Däckstorlek_tum = 27,
                Pris = 4000

            };
            context.Add(mountainbike2);




            context.SaveChanges();
            */
            
        }
    }
}
