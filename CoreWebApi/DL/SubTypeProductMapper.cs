using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DL
{
    public class SubTypeProductMapper
    {
        public int ID { get; set; }
        public int SubTypeId { get; set; }
        public int ProductId { get; set; }

        public virtual ProductSubType ProductSubType { get; set; }
        public virtual Product Product { get; set; }

    }
}
