using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Tempat
    {
        public int Id { get; set; }
        public string Kota { get; set; }
        public string NamaTempat { get; set; }
    }
}