using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Model
{
    public class ProductAvailibilityMapperModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
    }
}
