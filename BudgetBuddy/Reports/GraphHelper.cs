using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetBuddy.Models;

namespace BudgetBuddy.Reports
{
    public static class GraphHelper
    {
        public static void DisplayCategoryGraph(List<Transaction> transactions)
        {
            var expenseData = transactions
                .Where(t => t.Type.ToLower() == "expense")
                .GroupBy(t => t.Category)
                .Select(g => new { Category = g.Key, Total = g.Sum(t => t.Amount) })
                .OrderByDescending(g => g.Total)
                .ToList();

            if (expenseData.Count == 0)
            {
                Console.WriteLine("No expenses to display.");
                return;
            }

            decimal max = expenseData.Max(e => e.Total);
            Console.WriteLine("=== Category Spending ===");

            foreach (var e in expenseData)
            {
                int barLength = (int)((e.Total / max) * 30);
                Console.WriteLine($"{e.Category,-12} | {new string('█', barLength)} £{e.Total:F2}");
            }

            Console.WriteLine("==========================");
        }
    }
}
