﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XYZCorp.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public int Points { get; set; }

        [Required]
        public string Name { get; set; }
    }
}