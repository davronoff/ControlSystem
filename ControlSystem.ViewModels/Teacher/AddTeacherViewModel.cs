using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDavomat.ViewModels
{
    public class AddTeacherViewModel
    {
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
