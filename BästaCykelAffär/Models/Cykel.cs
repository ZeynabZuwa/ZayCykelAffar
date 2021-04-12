using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BästaCykelAffär.Models
{
    
    
    public class Cykel
    {
    public Cykel(string cykeltyp, int växlar, string färg, int däckstorlek_tum, double pris)
    {
        Cykeltyp = cykeltyp;
        Växlar = växlar;
        Färg = färg;
        Däckstorlek_tum = däckstorlek_tum;
        Pris = pris;
    }

    [Key]
        public int Cykel_id { get; set; }
        [MaxLength(50)]
        public string Cykeltyp { get; set; }
        [MaxLength(50)]
        public int Växlar { get; set; }
        [MaxLength(50)]
        public string Färg { get; set; }
        [MaxLength(50)]
        public int Däckstorlek_tum { get; set; }
        [Required]
        public double Pris { get; set; }
    }
}
