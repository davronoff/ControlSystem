using Microsoft.AspNetCore.Http;
using ProjectDavomat.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectDavomat.ViewModels
{
    public class EditServiceViewModel
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
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }

        public static explicit operator EditServiceViewModel(Service model)
        {
            return new EditServiceViewModel()
            {
                Id = model.Id,
                ServiceType = model.ServiceType,
                Name = model.Name,
                LifeTimeService = model.LifeTimeService,
                Price = model.Price,
                Image = model.Image
            };
        }
        public static explicit operator Service(EditServiceViewModel model)
        {
            return new Service()
            {
                Id = model.Id,
                ServiceType = model.ServiceType,
                Name = model.Name,
                LifeTimeService = model.LifeTimeService,
                Price = model.Price,
                Image = model.Image
            };
        }
    }
}