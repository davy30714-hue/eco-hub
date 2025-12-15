using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ExpeditionTeams
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        public string RoleInExpedition { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public virtual Employees Employee { get; set; }

        [ForeignKey("ExpeditionId")]
        public virtual Expeditions Expedition { get; set; }
        public int ExpeditionId { get; set; }
    }
}
