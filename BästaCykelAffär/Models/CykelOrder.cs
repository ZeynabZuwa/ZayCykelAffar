using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BästaCykelAffär.Models
{
    public class CykelOrder
    {
        public CykelOrder(int cykel_id, int order_id)
        {
            Cykel_id = cykel_id;
            Order_id = order_id;
        }

        [Key]
        public int CykelOrder_id { get; set; }
        [ForeignKey("Cykel_id")]
        public int Cykel_id { get; set; }
        [ForeignKey("Order_id")]
        public int Order_id { get; set; }

        public Cykel Cykel { get; set; }
        public Order Order { get; set; }
    }
}
