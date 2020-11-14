using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Batteries = new HashSet<Battery>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public long? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
    }
}
