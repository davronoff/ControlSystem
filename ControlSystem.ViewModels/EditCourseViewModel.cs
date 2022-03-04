using Microsoft.AspNetCore.Http;
using ProjectDavomat.Domain;
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

        public static explicit operator EditCourseViewModel(Course model)
        {
            return new EditCourseViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Duration = model.Duration,
                Description = model.Description,
                Image = model.Image,
                CourseCategoryId = model.CourseCategoryId
            };
        }

        public static explicit operator Course(EditCourseViewModel model)
        {
            return new Course()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Duration = model.Duration,
                Description = model.Description,
                Image = model.Image,
                CourseCategoryId = model.CourseCategoryId
            };
        }
    }
}
