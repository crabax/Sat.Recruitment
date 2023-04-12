using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sat.Recruitment.Application.Input
{
    public class CreateUserInput
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        [MinLength(1)]
        public string Email { get; set; }
        [Required]
        [MinLength(1)]
        public string Address { get; set; }
        [Required]
        [MinLength(1)]
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
    }
}
