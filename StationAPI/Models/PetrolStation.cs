using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StationAPI.Models
{
    public class PetrolStation
    {
        [Key]
        public int StationId { get; set; }
        public string StationName { get; set; }
        public string Address { get; set; }
        public int NumberOfPumps { get; set; }
        public bool PumpActivation { get; set; }

        public int FuelId { get; set; }


    }
}
