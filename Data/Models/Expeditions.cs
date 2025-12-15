using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Expeditions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExpeditionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? WeatherConditions { get; set; }
        public string Status { get; set; }
        public string? Notes { get; set; }

        [ForeignKey("LocationId")]
        public virtual Locations Location { get; set; }
        public int LocationId { get; set; }
        public virtual ICollection<ExpeditionTeams> ExpeditionTeams { get; set; } = new HashSet<ExpeditionTeams>();
        public virtual ICollection<Measurements> Measurements { get; set; } = new HashSet<Measurements>();
        public virtual ICollection<ExpeditionReports> ExpeditionReport { get; set; } = new HashSet<ExpeditionReports>();
    }
}
