using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BästaCykelAffär.Models
{
    public class Kund
    {

        public Kund(int kund_id)
        {
            Kund_id = kund_id;
        }

        public Kund(string förnamn, string efternamn, string email, int telefonnummer, string gatuadress, int postnummer, string ort)
        {
            Förnamn = förnamn;
            Efternamn = efternamn;
            Email = email;
            Telefonnummer = telefonnummer;
            Gatuadress = gatuadress;
            Postnummer = postnummer;
            Ort = ort;
        }

        [Key]
        public int Kund_id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Förnamn { get; set; }
        [MaxLength(50)]
        [Required]
        public string Efternamn { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(12)]
        public int Telefonnummer { get; set; }
        [MaxLength(50)]
        public string Gatuadress { get; set; }
        [MaxLength(5)]
        public int Postnummer { get; set; }
        [MaxLength(20)]
        public string Ort { get; set; }

        // visar att en kund kan ha många ordrar, en till många relation
        public ICollection<Order> Ordrar { get; set; }
    }
}

