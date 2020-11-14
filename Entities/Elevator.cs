using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Elevator
    {
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string TypeBuilding { get; set; }
        public string Status { get; set; }
        public DateTime? DateCommissioning { get; set; }
        public DateTime? DateLastInspection { get; set; }
        public string CertOpe { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public long? ColumnId { get; set; }

        public virtual Column Column { get; set; }
    }
}
