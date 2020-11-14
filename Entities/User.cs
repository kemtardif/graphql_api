using System;
using System.Collections.Generic;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class User
    {
        public User()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordSentAt { get; set; }
        public DateTime? RememberCreatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
