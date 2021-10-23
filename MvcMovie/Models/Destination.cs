using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Destination
    {
        public int Id { get; set; }
        [RegularExpression(@"^[0-9]*$")]
        [Required]
        public int CategoryId{get;set;}
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Place{get;set;}
        [Range(1, 100000), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price{get;set;}
        [Required]
        public string Deskripsi {get;set;}
        public Category Category {get;set;}
    }
}