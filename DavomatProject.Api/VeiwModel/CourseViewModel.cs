using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectDavomat.Domain;

namespace DavomatProject.Api.ViewModel
{
    public class CourseViewModel
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]    
        public string Image { get; set; }
        public List<Teacher> Teacher { get; set; }
          public static explicit operator CourseViewModel(Course model)
        {            
            return  new CourseViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Duration = model.Duration,
                Image = model.Image
            };
        }
         public static explicit operator Course(CourseViewModel model)
        {
            return new Course()
            {
                Id = model.Id,
                Name = model.Name,
                Duration = model.Duration,
                Image = model.Image,
                Teacher = null
            };
        }
    }
} 