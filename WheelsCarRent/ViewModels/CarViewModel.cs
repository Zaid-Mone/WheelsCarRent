using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WheelsCarRent.Enums;
using WheelsCarRent.Models;

namespace WheelsCarRent.ViewModels
{
    public class CarViewModel
    {
        public int CarId { get; set; }
        [DisplayName("Car Name")]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [DisplayName("Plate Number")]
        [Required]
        [StringLength(20)]
        public string PlateNumber { get; set; }
        [DisplayName("Car Color")]
        [Required]
        [StringLength(20)]
        public string Color { get; set; }
        [DisplayName("Car Model")]
        [Required]
        [StringLength(20)]
        public string Model { get; set; }
        [DisplayName("Car Year")]
        [Required]
        public int Year { get; set; }

        [DisplayName("Car Description")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Price per Day")]
        [Required]
        public int Price { get; set; }
        [DisplayName("Driver Type")]
        [Required]
        public DriverType DriverType { get; set; }
        [DisplayName("Car Image")]
        public string Image { get; set; }
        public IFormFile File { get; set; }
        public int CarTypeId { get; set; }
        [ForeignKey(nameof(CarTypeId))]
        public List<CarType> CarTypes { get; set; }
    }

}
