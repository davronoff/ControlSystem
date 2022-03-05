using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectDavomat.Domain
{
    public class Service
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public string ServiceType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LifeTimeService { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
