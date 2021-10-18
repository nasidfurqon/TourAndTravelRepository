using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double NumbePhone {get;set;}
    }
}