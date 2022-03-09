using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using ProjectDavomat.Domain;


namespace ProjectDavomat.ViewModels
{
    public class EditStaffViewModel
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Position { get; set; }
        public string Social { get; set; }

        public static explicit operator EditStaffViewModel(Staff model)
        {
            return new EditStaffViewModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Image = model.Image,
                About = model.About,
                Position = model.Position,
                Social = model.Social
            };
        }

        public static explicit operator Staff(EditStaffViewModel viewModel)
        {
            return new Staff()
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Image = viewModel.Image,
                About = viewModel.About,
                Position = viewModel.Position,
                Social = viewModel.Social
            };
        }
    }
}
