using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class BuildingsDetail
    {
        public long Id { get; set; }
        public string InfoKey { get; set; }
        public string Value { get; set; }
        public long? BuildingId { get; set; }

        public virtual Building Building { get; set; }
    }
}
