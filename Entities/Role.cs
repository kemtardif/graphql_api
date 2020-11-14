using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ResourceType { get; set; }
        public long? ResourceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
