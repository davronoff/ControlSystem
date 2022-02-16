using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectDavomat.Domain
{
    public class User
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Telefonraqam { get; set; }
    }
}
