using Microsoft.AspNetCore.Http;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectDavomat.ViewModels
{
    public class AddServiceViewModel
    {
        [Required]
        public string ServiceType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LifeTimeService { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
