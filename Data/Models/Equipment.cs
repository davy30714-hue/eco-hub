using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Equipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public string? SerialNumber { get; set; }
        public string EquipmentType { get; set; }
        public string Status { get; set; }
        public DateTime? LastCalibrationDate { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employees? Employee { get; set; }
        public int? EmployeeId { get; set; }
    }
}
