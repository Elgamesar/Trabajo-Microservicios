using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCustomerDomain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required][EmailAddress]
        public string Email { get; set; }
        public DateTime DateOfRegistration { get; set; } = DateTime.Now;
    }
}