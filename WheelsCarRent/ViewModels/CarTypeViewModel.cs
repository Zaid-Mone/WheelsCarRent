using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WheelsCarRent.ViewModels
{
    public class CarTypeViewModel
    {
        public int CarTypeId { get; set; }
        [DisplayName("Car Type")]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [DisplayName("CarType Image")]
        public string Image { get; set; }
        public IFormFile File { get; set; }
    }

}
