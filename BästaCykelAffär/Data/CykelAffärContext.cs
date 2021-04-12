using BästaCykelAffär.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BästaCykelAffär.Data

    // eftersom jag kör en code first så håller jag nu på att göra mina
    // klasser till en databas
{
    public class CykelAffärContext : DbContext
    {
        // varje DbSet representerar en tabell i min databas
        public DbSet<Cykel> Cyklar { get; set; }
        public DbSet<Kund> Kunder { get; set; }
        public DbSet<Order> Ordrar { get; set; }
        public DbSet<CykelOrder> CyklarOrdrar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-MJFUKP6G\\SQLEXPRESS;Initial Catalog=BästaCykelAffär;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
