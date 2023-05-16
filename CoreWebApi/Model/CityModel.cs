using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Model
{
    public class CityModel
    {
        public int Id { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public string CityName { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> UpdationDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}
