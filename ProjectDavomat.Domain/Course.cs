using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectDavomat.Domain
{
    public class Course
    {
        [Required, Key]
        public Guid Id { get; set; }
        public string Price { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Duration { get; set; }
        //[Required]
        //public string Description{ get; set; }
        [Required]    
        public string Image { get; set; }
        public Guid CourseCategoryId { get; set; }
    }
}
