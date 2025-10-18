using BudgetBuddy.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetBuddy.Models;
namespace BudgetBuddy.Services
{
    public class BudgetManager
    {
        private List<Transaction> transactions;
        private FileService fileService;
        public BudgetManager()
        {
            fileService = new FileService();
            transactions = fileService.LoadTransactions();
        }
        public List<Transaction> GetTransactions() => transactions;
        private List<string> expenseCategories = new()
{
    "Food",
    "Transport",
    "Bills",
    "Entertainment",
    "Shopping",
    "Other"
};

        private List<string> incomeCategories = new()
{
    "Salary",
    "Gift",
    "Investment",
    "Freelance",
    "Other"
};
        private string SelectCategory(string type)
        {
            List<string> list = type.ToLower() == "income" ? incomeCategories : expenseCategories;

            Console.WriteLine($"\nSelect a category for {type}:");
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"{i + 1}. {list[i]}");

            Console.Write("Enter number: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > list.Count)
            {
                Console.Write("Invalid choice, try again: ");
            }

            return list[choice - 1];
        }
        public void AddTransaction()
        {
            Console.Clear();
            Console.WriteLine("=== Add Transaction ===");
            Console.Write("Enter date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Type (Income/Expense): ");
            string type = Console.ReadLine();

            string category = SelectCategory(type);

            Console.Write("Amount: £");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Description: ");
            string desc = Console.ReadLine();

            transactions.Add(new Transaction(date, type, category, amount, desc));

            Console.WriteLine("\nTransaction added successfully!");
            Console.ReadKey();
        }
        public void ListTransactions()
        {
            Console.Clear();
            Console.WriteLine("Date       | Type     | Amount    | Category     | Description");
            Console.WriteLine("---------------------------------------------------------------");

            foreach (var t in transactions)
                Console.WriteLine(t);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void ShowSummaryWithGraph()
        {
            Console.Clear();
            decimal totalIncome = transactions.Where(t => t.Type.ToLower() == "income").Sum(t => t.Amount);
            decimal totalExpense = transactions.Where(t => t.Type.ToLower() == "expense").Sum(t => t.Amount);
            decimal balance = totalIncome - totalExpense;

            Console.WriteLine("=== Summary ===");
            Console.WriteLine($"Total Income : £{totalIncome:F2}");
            Console.WriteLine($"Total Expense: £{totalExpense:F2}");
            Console.WriteLine($"Balance      : £{balance:F2}");
            Console.WriteLine();

            GraphHelper.DisplayCategoryGraph(transactions);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void DeleteTransaction()
        {
            Console.Clear();
            ListTransactions();
            Console.Write("\nEnter date of transaction to delete (yyyy-mm-dd): ");
            string dateStr = Console.ReadLine();

            var toRemove = transactions.Find(t => t.Date.ToString("yyyy-MM-dd") == dateStr);
            if (toRemove != null)
            {
                transactions.Remove(toRemove);
                Console.WriteLine("Transaction deleted.");
            }
            else
            {
                Console.WriteLine("No transaction found on that date.");
            }

            Console.ReadKey();
        }
        public void SaveData()
        {
            fileService.SaveTransactions(transactions);
        }
    }
}
