using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class UsersRole
    {
        public long? UserId { get; set; }
        public long? RoleId { get; set; }
    }
}
