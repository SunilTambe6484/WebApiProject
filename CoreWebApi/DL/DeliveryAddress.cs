using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DL
{
    public class DeliveryAddress
    {
        public int Id { get; set; }
        public int AddressTypeId { get; set; }
        public string PermanentAddress { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> UpdationDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
