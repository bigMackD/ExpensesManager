using ExpensesManager.Models;
using System;

namespace ExpensesManager.ViewModels
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    
        public CategoryType Category { get; set; }
       
    }
}
