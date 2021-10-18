using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber {get;set;}
        public string Address{get;set;}
        public string Email{get;set;}
        public char Pasword{get;set;}   
    }
}