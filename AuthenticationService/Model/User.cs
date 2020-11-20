﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Model
{
    public class User
    {
        [Key]
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
