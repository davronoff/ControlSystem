using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDavomat.ViewModels
{
    public class AddStaffViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
