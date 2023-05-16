using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DL
{
    public class ProductAvailibilityMapper
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductShop Shop { get; set; }

    }
}
