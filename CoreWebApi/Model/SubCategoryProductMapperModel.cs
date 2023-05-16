using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Model
{
    public class SubCategoryProductMapperModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
