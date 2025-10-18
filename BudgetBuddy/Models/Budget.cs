using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBuddy.Models
{
    public class Budget
    {
        public string Category { get; set; }
        public decimal Planned { get; set; }
        public decimal Actual { get; set; }
        public Budget(string category, decimal planned)
        {
            Category = category;
            Planned = planned;
            Actual = 0;
        }
        public decimal Remaining => Planned - Actual;
        public override string ToString()
        {
            return $"{Category}: Planned £{Planned}, Actual £{Actual}, Remaining £{Remaining}";
        }
    }
}
