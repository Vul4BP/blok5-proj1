﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok5_P1.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
