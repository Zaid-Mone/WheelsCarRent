using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WheelsCarRent.Models
{
    public class CarType
    {   
        [Key]
        public int Id { get; set; }
        [DisplayName("Car Type")]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [DisplayName("CarType Image")]
        public string Image { get; set; }
    }

}
