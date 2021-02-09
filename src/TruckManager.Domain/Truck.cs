using System;
using System.Text.Json.Serialization;

namespace TruckManager.Domain
{
    public class Truck
    {
        public string Chassis { get; set; }
        public int TruckModelId { get; set; }
        public int BuildingYear { get; set; }
        public int ModelYear { get; set; }

        [JsonIgnore]
        public virtual TruckModel TruckModel { get; set; }
    }
}
