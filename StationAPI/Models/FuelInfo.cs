using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StationAPI.Models
{
    public class FuelInfo
    {
        [Key]
        public int FuelId { get; set; }
        public string Type { get; set; }
        public decimal FuelPrice { get; set; }
    }
}
