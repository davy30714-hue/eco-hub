using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ExpeditionReports
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportId { get; set; }
        public string? Summary { get; set; }
        public string? Issues { get; set; }
        public DateTime ReportDate { get; set; }

        [ForeignKey("Expedition")]
        public int ExpeditionId { get; set; }
        public virtual Expeditions Expedition { get; set; }

    }
}
