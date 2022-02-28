using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectDavomat.Domain
{
    public class Service
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string MyService { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
