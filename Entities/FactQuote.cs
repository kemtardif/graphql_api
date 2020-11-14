using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class FactQuote
    {
        public long Id { get; set; }
        public int? QuoteId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int? AmountElevator { get; set; }
    }
}
