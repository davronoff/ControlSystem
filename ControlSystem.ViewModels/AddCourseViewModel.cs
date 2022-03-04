using Microsoft.AspNetCore.Http;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectDavomat.ViewModels
{
    public class AddCourseViewModel
    {
        [Required]
        public string Price { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string CourseCategoryName { get; set; }

        public List<string> Categories { get; set; }
    }
}
