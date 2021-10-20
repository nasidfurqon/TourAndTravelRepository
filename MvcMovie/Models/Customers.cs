using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Customers
    {
        public int Id { get; set; }
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [RegularExpression(@"^(\+62|62|0)8[0-9]*$")]
        [Required]
        [StringLength(14)]
        public string PhoneNumber {get;set;}
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(50)]
        public string Address{get;set;}
        
        [RegularExpression(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")]
        [Required]
        [StringLength(50)]
        public string Email{get;set;}
    
        [RegularExpression(@"^[a-zA-Z0-9]*$")]
        [Required]
        [StringLength(30)] 
        public string Pasword{get;set;}  
    }
}