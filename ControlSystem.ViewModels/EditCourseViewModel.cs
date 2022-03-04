using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectDavomat.ViewModels
{
    public class EditCourseViewModel
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }
        public Guid CourseCategoryId { get; set; }
    }
}
