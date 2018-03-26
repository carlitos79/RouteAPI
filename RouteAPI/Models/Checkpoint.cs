using System;
using System.ComponentModel.DataAnnotations;

namespace RouteAPI.Models
{
    public class Checkpoint
    {
        [Key]
        public int CheckpointID { get; set; }
        public string RouteID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime CPDateTime { get; set; }
    }
}
