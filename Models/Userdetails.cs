using System;
using System.Collections.Generic;


namespace MyMedicine.Models
{
    public partial class Userdetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool enable{get; set;}=false;
    }
}