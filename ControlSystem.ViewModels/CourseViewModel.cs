using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDavomat.ViewModels
{
    public class CourseViewModel
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
        public Guid CourseCategoryId { get; set; }


        public static explicit operator CourseViewModel(Course model)
        {
            return new CourseViewModel()
            {
                Id = Guid.NewGuid(),
                Price = model.Price,
                Name = model.Name,
                Duration = model.Duration,
                Description = model.Description,


            };
        }
        public static explicit operator Course(CourseViewModel model)
        {
            return new CourseCategory()
            {
                Id = model.Id,
                Name = model.Name,
                Courses = null
            };
        }
    }
}
