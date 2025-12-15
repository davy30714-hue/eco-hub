using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Locations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public double GpsLatitude { get; set; }
        public double GpsLongitude { get; set; }
        public string EcosystemType { get; set; }
        public string? Description { get; set; }
    }
}
