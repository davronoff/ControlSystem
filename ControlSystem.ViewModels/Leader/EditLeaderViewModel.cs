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
    public class EditLeaderViewModel
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }

        public static explicit operator EditLeaderViewModel(Leader model)
        {
            return new EditLeaderViewModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Position = model.Position,
                Image = model.Image
            };
        }
        public static explicit operator Leader(EditLeaderViewModel model)
        {
            return new Leader()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Position = model.Position,
                Image = model.Image
            };
        }
    }
}
