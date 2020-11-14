using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class FactIntervention
    {
        public long Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? BuildingId { get; set; }
        public int? BatteryId { get; set; }
        public int? ColumnId { get; set; }
        public int? ElevatorId { get; set; }
        public DateTime? StartDateIntervention { get; set; }
        public DateTime? EndDateIntervention { get; set; }
        public string Result { get; set; }
        public string Report { get; set; }
        public string Status { get; set; }
    }
}
