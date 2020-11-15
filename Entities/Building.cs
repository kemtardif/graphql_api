using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace GraphQL_API.Entities
{
    public partial class Building
    {
        public Building()
        {
            Batteries = new HashSet<Battery>();
            BuildingsDetails = new HashSet<BuildingsDetail>();
        }
        
        public long Id { get; set; }                  
        public string AdmContactName { get; set; }
        public string AdmContactMail { get; set; }
        public string AdmContactPhone { get; set; }
        public string TectContactName { get; set; }
        public string TectContactEmail { get; set; }
        public string TectContactPhone { get; set; }
        public long? CustomerId { get; set; }
        public long? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
        public virtual ICollection<BuildingsDetail> BuildingsDetails { get; set; }


    }
}
