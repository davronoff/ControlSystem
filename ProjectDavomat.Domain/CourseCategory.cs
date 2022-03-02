using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectDavomat.Domain
{
    public class CourseCategory
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Course> Courses { get; set; }

    }
}
