using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int DestinationID { get; set; }
        public string CustomersId{get;set;}
        [DataType(DataType.Date)]
        public DateTime Date { get; set;}
        public double Price{get;set;}
        public string UserName {get;set;}
        public virtual Customers Customers{get;set;}
        public virtual Destination Destination{get;set;}
    }
}