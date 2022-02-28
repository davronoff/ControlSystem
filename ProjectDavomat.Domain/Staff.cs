using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectDavomat.Domain
{
    public class Staff
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
