using System;
using System.Collections.Generic;


#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Battery
    {
        public Battery()
        {
            Columns = new HashSet<Column>();
        }


        public long Id { get; set; }            
        public string TypeBuilding { get; set; }
        public string Status { get; set; }
        public DateTime? DateCommissioning { get; set; }
        public DateTime? DateLastInspection { get; set; }
        public string CertOpe { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }

        public long? BuildingId { get; set; }  
        public long? EmployeeId { get; set; }

        public virtual Building Building { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
    }
}
