using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RouteAPI.Models
{
    public class Checkpoint
    {
        [Key]
        public int CheckpointID { get; set; }
        public int RouteID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime CPDateTime { get; set; }
    }
}
