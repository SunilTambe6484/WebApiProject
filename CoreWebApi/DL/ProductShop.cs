using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DL
{
    public class ProductShop
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> UpdationDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }

    }
}
