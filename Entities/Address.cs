using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Address
    {
        public Address()
        {
            Buildings = new HashSet<Building>();
            Customers = new HashSet<Customer>();
        }

        public long Id { get; set; }
        public string TypeAddress { get; set; }
        public string Status { get; set; }
        public string Entite { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string FullStreetAddress { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
