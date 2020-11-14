using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class FactContact
    {
        public long Id { get; set; }
        public int? ContactId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string ProjectName { get; set; }
    }
}
