using Microsoft.AspNetCore.Http;
using ProjectDavomat.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectDavomat.ViewModels
{
    public class AddServiceViewModel
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required]
        public string ServiceType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LifeTimeService { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public IFormFile NewImage { get; set; }
        [Required]
        public string Image { get; set; }
        public static explicit operator AddServiceViewModel(Service model)
        {
            return new AddServiceViewModel()
            {
                Id = model.Id,
                ServiceType = model.ServiceType,
                Name = model.Name,
                LifeTimeService = model.LifeTimeService,
                Price = model.Price,
                Image = model.Image

            };
        }
        public static explicit operator Service(AddServiceViewModel model)
        {
            return new Service()
            {
                Id = Guid.NewGuid(),
                ServiceType = model.ServiceType,
                Name = model.Name,
                LifeTimeService = model.LifeTimeService,
                Price = model.Price,
                Image = model.Image
            };
        }
    }
}
