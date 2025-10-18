using BudgetBuddy.Reports;
using BudgetBuddy.Services;
using BudgetBuddy.Models;
namespace BudgetBuddy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "BudgetBuddy - Personal Finance Tracker";
            BudgetManager manager = new BudgetManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== BudgetBuddy ===");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Transactions");
                Console.WriteLine("3. View Summary (with Graph)");
                Console.WriteLine("4. Delete Transaction");
                Console.WriteLine("5. Generate Monthly Report");
                Console.WriteLine("6. Save & Exit");
                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        manager.AddTransaction();
                        break;
                    case "2":
                        manager.ListTransactions();
                        break;
                    case "3":
                        manager.ShowSummaryWithGraph();
                        break;
                    case "4":
                        manager.DeleteTransaction();
                        break;
                    case "5":
                        ReportGenerator.GenerateMonthlyReport(manager.GetTransactions());
                        break;
                    case "6":
                        manager.SaveData();
                        Console.WriteLine("Data saved. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
