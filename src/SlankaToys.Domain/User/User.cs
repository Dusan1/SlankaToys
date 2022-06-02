using System;
using System.ComponentModel.DataAnnotations;

namespace SlankaToys.Domain.User
{
    public class User : IAggregate
    {
        public User()
        {
        }

        public int Id { get; set; }
       
        public string Forename { get; set; }
        
        public string Surname { get; set; }
        
        public string Email { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string PostalCode { get; set; }
        
        public string Password { get; set; }
    }
}
