using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TruckManager.Domain
{
    public class TruckModel
    {
        public int Id { get; set; }
        public string ModelCode { get; set; }

        [JsonIgnore]
        public virtual ICollection<Truck> Trucks { get; set; }
    }
}
