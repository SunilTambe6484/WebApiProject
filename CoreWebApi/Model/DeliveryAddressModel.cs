using CoreWebApi.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Model
{
    public class DeliveryAddressModel
    {
        public int Id { get; set; }
        [Required]
        public int AddressTypeId { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        [Required]
        public string ShippingAddress { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> UpdationDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}
