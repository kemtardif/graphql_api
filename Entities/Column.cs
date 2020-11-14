using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Column
    {
        public Column()
        {
            Elevators = new HashSet<Elevator>();
        }

        public long Id { get; set; }
        public string TypeBuilding { get; set; }
        public int? AmountFloorsServed { get; set; }
        public string Status { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public long? BatteryId { get; set; }

        public virtual Battery Battery { get; set; }
        public virtual ICollection<Elevator> Elevators { get; set; }
    }
}
