using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Quote
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string BuildingType { get; set; }
        public int? AppsQty { get; set; }
        public int? FloorsQty { get; set; }
        public int? BasementsQty { get; set; }
        public int? ParkingsQty { get; set; }
        public int? ElevatorsQty { get; set; }
        public int? BusinessQty { get; set; }
        public int? OccupantsFloorsQty { get; set; }
        public int? HoursActivity { get; set; }
        public string Game { get; set; }
        public int? ElevatorNeeded { get; set; }
        public int? TotalPrice { get; set; }
        public string Email { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
