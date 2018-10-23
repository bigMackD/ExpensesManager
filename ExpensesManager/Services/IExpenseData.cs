using ExpensesManager.Models;
using ExpensesManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManager.Services
{
    public interface IExpenseData
    {
        IEnumerable<ExpenseViewModel> GetAllExpenses();
        Expense Get(int id);
        Expense Add(Expense newExpense);
        void Remove(Expense expense);
        void Edit(Expense editedExpense);
        object GetExpensesByCategory(int value);
        Dictionary<CategoryType,decimal> GetExpensesByMonth(int month);
    }
}
