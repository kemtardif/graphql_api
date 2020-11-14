using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Buildings = new HashSet<Building>();
            Leads = new HashSet<Lead>();
        }

        public long Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public string CompanyName { get; set; }
        public string CpyContactName { get; set; }
        public string CpyContactPhone { get; set; }
        public string CpyContactEmail { get; set; }
        public string CpyDescription { get; set; }
        public string StaName { get; set; }
        public string StaPhone { get; set; }
        public string StaMail { get; set; }
        public long? UserId { get; set; }
        public long? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Lead> Leads { get; set; }
    }
}
