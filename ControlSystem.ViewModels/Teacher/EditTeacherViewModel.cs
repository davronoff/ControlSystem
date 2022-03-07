using Microsoft.AspNetCore.Http;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDavomat.ViewModels
{
    public class EditTeacherViewModel
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
        public IFormFile NewImage { get; set; }
        [Required]
        public string Experince { get; set; }

        public static explicit operator EditTeacherViewModel(Teacher model)
        {
            return new EditTeacherViewModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastaName = model.LastaName,
                Skills = model.Skills,
                Image = model.Image,
                Experince = model.Experince

            };
        }
        public static explicit operator Teacher(EditTeacherViewModel viewModel)
        {
            return new Teacher()
            {
                Id = viewModel.Id,
                FirstName = viewModel.LastaName,
                Skills = viewModel.Skills,
                Image = viewModel.Image,
                Experince = viewModel.Image
            };
        }
    }
}
