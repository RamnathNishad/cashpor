using System;
using System.Collections.Generic;

namespace UsersAPI.Models
{
    public partial class TblUser
    {        
        public int Id { get; set; }
        public string? Uname { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Phone { get; set; }
        public string? Pin { get; set; }
        public string? Picture { get; set; }
    }
}
