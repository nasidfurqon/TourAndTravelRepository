using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Tempat
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(15)]
        public string Kota { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(20)]
        public string NamaTempat { get; set; }
    }
}