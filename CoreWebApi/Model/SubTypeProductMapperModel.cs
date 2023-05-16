using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Model
{
    public class SubTypeProductMapperModel
    {
        public int ID { get; set; }
        public int SubTypeId { get; set; }
        public int ProductId { get; set; }
    }
}
