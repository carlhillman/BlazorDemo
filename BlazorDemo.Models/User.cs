using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public List<Pet> Pets { get; set; }
        public User()
        {
            Pets = new List<Pet>();
        }
    }
}
