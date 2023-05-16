using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DL
{
    public class OrderHistory
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DeliveryDetailsId { get; set; }

        public virtual OrderDetails Order { get; set; }
        public virtual DeliveryDetails DeliveryDetails { get; set; }

    }
}
