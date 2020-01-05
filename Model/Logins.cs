using System;
using System.Collections.Generic;

namespace IQMVCProject.Model
{
    public partial class Logins
    {
        public int LoginId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte IsActive { get; set; }
    }
}
