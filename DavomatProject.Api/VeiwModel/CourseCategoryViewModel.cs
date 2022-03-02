using ProjectDavomat.Domain;
using System;

namespace DavomatProject.Api.VeiwModel
{
    public class CourseCategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator CourseCategoryViewModel(CourseCategory model)
        {
            return new CourseCategoryViewModel()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        public static explicit operator CourseCategory(CourseCategoryViewModel model)
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
