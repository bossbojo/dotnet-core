using System;
using System.Collections.Generic;

namespace AppApi.Entities.Table
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
