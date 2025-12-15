using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Measurements
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeasurementId { get; set; }
        public DateTime Timestamp { get; set; }
        public string ParameterType { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }
        public double? Depth { get; set; }
        public string? Notes { get; set; }

        [ForeignKey("LocationId")]
        public virtual Locations Location { get; set; }
        public int LocationId { get; set; }

        [ForeignKey("ExpeditionId")]
        public virtual Expeditions Expedition { get; set; }
        public int ExpeditionId { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }
        public int EquipmentId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employees Employee { get; set; }
        public int EmployeeId { get; set; }

    }
}
