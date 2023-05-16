using CoreWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DL
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal SavedPrice { get; set; }
        public decimal Price { get; set; }
        public int PaymentMethodId { get; set; }
        public int DeliveryAddressId { get; set; }
        public DateTime DeliveryDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual DeliveryAddress DeliveryAddress { get; set; }

    }
}
