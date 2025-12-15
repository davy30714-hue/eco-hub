using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string? ContactInfo { get; set; }
        public string Status { get; set; }
        public virtual ICollection<ExpeditionTeams> ExpeditionTeams { get; set; } = new HashSet<ExpeditionTeams>();
        public virtual ICollection<Equipment> Equipment { get; set; } = new HashSet<Equipment>();
    }
}
