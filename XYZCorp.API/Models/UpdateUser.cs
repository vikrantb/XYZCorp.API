using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XYZCorp.API.Models
{
    public class UpdateUser
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Points { get; set; }
    }
}