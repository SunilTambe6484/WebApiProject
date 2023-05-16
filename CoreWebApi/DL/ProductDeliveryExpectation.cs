using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DL
{
    public class ProductDeliveryExpectation
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public DateTime DeliveryExpectatedDate { get; set; }
        public bool IsDeliveryFree { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> UpdationDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}
