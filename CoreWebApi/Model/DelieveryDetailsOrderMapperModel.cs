using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Model
{
    public class DeliveryDetailsOrderMapperModel
    {
        public int Id { get; set; }
        public int DeliveryDetailsId { get; set; }
        public int OrderId { get; set; }
    }
}
