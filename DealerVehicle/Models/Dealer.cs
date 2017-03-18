using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DealerVehicle.Models
{
    public class Dealer
    {
        [Key]
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string DealerCity { get; set; }
        public string DealerCountry { get; set; }
        public string DealerPhoneNumber { get; set; }

        public virtual ICollection<DealerVehicles> DealerVehicles { get; set; }
    }
}