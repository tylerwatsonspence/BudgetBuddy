using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBuddy.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } // Income / Expense
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public Transaction(DateTime date, string type, string category, decimal amount, string description)
        {
            Id = Guid.NewGuid();
            Date = date;
            Type = type;
            Category = category;
            Amount = amount;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Date:dd/MM/yyyy} | {Type,-8} | £{Amount,-8:F2} | {Category,-12} | {Description}";
        }
    }
}
    

