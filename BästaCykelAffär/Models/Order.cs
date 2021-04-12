using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BästaCykelAffär.Models
{
    public class Order
    {

        public Order()
        {

        }
        public Order(DateTime timeStamp, double totalPrice, int kundId)
        {
            this.Order_gjord = timeStamp;
            this.Total_price = totalPrice;
            this.Kund_id = kundId;
        }

        [Key]
        public int Order_id { get; set; }
        public DateTime Order_gjord { get; set; }
        public double Total_price { get; set; }
        [ForeignKey("Kund")]
        public int Kund_id { get; set; }
        // en kund per order
        public Kund Kund { get; set; }

        //En mellan tabell för att möjliggöra en många till många relation
        public ICollection<CykelOrder> CyklarOrdrar { get; set; }
    }
}
