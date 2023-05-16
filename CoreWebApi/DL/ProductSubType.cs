using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DL
{
    public class ProductSubType
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string SubTypeName { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> UpdationDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ProductType ProductType { get; set; }

    }
}
