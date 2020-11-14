using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class DimCustomer
    {
        public long Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CompanyName { get; set; }
        public string CpyContactName { get; set; }
        public string CpyContactEmail { get; set; }
        public int? AmountElevator { get; set; }
        public string CustomerCity { get; set; }
    }
}
