using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DealerVehicle.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public virtual Model Model { get; set; }
        public virtual ICollection<DealerVehicles> DealerVehicles { get; set; }
    }
}