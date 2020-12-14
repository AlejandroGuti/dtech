using dTech.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dTech.Common.DTOs
{
    public class UserRequest
    {
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Document { get; set; }
        [Required]
        public UserType UserType { get; set; }
    }
}
