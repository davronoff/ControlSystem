using ProjectDavomat.Domain.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDavomat.Domain
{
    public class Service
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public MyServiceMonth MyService { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
