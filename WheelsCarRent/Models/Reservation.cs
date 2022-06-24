using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WheelsCarRent.Enums;

namespace WheelsCarRent.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [DisplayName("Email")]
        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        [DisplayName("Age")]
        [Required]
        public int Age { get; set; }

        [DisplayName("Phone Number")]
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [DisplayName("City")]
        [Required]
        [StringLength(10)]
        public string City { get; set; }

        [DisplayName("Street Name")]
        [Required]
        [StringLength(30)]
        public string StreetName { get; set; }

        [DisplayName("Build Number")]
        [Required]
        [StringLength(10)]
        public string BuildNumber { get; set; }

        [DisplayName("Pickup Date")]
        [Required]
        public DateTime PickDate { get; set; }

        [DisplayName("Return Date")]
        [Required]
        public DateTime ReturnDate { get; set; }

        [DisplayName("No.of Days")]
        public int NumberofDays { get; set; }

        [DisplayName("Total Amount")]
        public double TotalAmount { get; set; }
       
        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }

    }

}
