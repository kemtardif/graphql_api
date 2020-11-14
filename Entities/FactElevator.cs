using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class FactElevator
    {
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? CommissioningDate { get; set; }
        public string BuildingId { get; set; }
        public string CustomerId { get; set; }
        public string BuildingCity { get; set; }
    }
}
