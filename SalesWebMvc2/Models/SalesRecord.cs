using System;
using SalesWebMvc2.Models.Enuns;

namespace SalesWebMvc2.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SalesStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SalesStatus status, Seller s1)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
        }
    }
}
