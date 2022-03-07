using ProjectDavomat.Domain;
using System;

namespace ProjectDavomat.VeiwModel
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator CategoryViewModel(CourseCategory model)
        {
            return new CategoryViewModel()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        public static explicit operator CourseCategory(CategoryViewModel model)
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
