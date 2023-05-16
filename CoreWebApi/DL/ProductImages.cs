
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DL
{
    public class ProductImages
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> UpdationDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Product Product { get; set; }

    }
}
