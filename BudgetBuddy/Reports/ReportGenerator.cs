using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetBuddy.Models;

namespace BudgetBuddy.Reports
{
    public class ReportGenerator
    {
        public static void GenerateMonthlyReport(List<Transaction> transactions)
        {
            Console.Clear();
            Console.Write("Enter month (1–12): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            var filtered = transactions
                .Where(t => t.Date.Month == month && t.Date.Year == year)
                .ToList();

            if (filtered.Count == 0)
            {
                Console.WriteLine("\nNo transactions found for that month.");
                Console.ReadKey();
                return;
            }

            decimal income = filtered.Where(t => t.Type.ToLower() == "income").Sum(t => t.Amount);
            decimal expense = filtered.Where(t => t.Type.ToLower() == "expense").Sum(t => t.Amount);
            Console.WriteLine($"\n=== Report for {month}/{year} ===");
            Console.WriteLine($"Total Income : £{income:F2}");
            Console.WriteLine($"Total Expense: £{expense:F2}");
            Console.WriteLine($"Net Balance  : £{income - expense:F2}");
            Console.ReadKey();
        }
    }
}
