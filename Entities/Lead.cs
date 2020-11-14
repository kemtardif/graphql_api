using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Lead
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string Department { get; set; }
        public string Message { get; set; }
        public byte[] AttachedFile { get; set; }
        public DateTime? CreateAt { get; set; }
        public long? CustomerId { get; set; }
        public string NameAttachedFile { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
