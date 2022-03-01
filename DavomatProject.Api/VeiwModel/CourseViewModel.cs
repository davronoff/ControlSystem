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
          public static explicit operator CourseViewModel(Course v)
        {            
            return  new CourseViewModel()
            {
                Id = v.Id,
                Name = v.Name,
                Duration = v.Duration,
                Image = v.Image
            };
        }
         public static explicit operator Course(CourseViewModel v)
        {
            return new Course()
            {
                Id = v.Id,
                Name = v.Name,
                Duration = v.Duration,
                Image = v.Image,
                Teacher = null
            };
        }
    }
} 