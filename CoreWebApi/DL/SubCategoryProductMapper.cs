using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DL
{
    public class SubCategoryProductMapper
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SubCategoryId { get; set; }

        public virtual Product Product { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
