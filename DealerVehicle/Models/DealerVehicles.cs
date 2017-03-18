using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DealerVehicle.Models
{
    public class DealerVehicles
    {
        [Key]
        public int DealerVehicleId { get; set; }
        public int VehicleId { get; set; }
        public int DealerId { get; set; }
        [ForeignKey("DealerId")]
        public virtual Dealer Dealer { get; set; }
        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }

    }
}