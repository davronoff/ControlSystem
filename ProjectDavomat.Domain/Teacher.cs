using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDavomat.Domain
 {
     public class Teacher
     {
         [Required, Key]
         public Guid Id { get; set; }
         [Required]
         public string FirstName { get; set; }
         [Required]
         public string LastaName { get; set; }
         [Required]
         public string Skills { get; set; }
         [Required]
         public string Image { get; set; }
         [Required]
         public string Experince { get; set; }

    }
 }