using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int DestinationID { get; set; }
        public int CustomersId{get;set;}
        [DataType(DataType.Date)]
        public DateTime Date { get; set;}
        public decimal Price{get;set;}
        public Customers customers{get;set;}
        public Destination destination{get;set;}
    }
}