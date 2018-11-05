using ExpensesManager.Models;
using ExpensesManager.ViewModels;
using System.Collections.Generic;

namespace ExpensesManager.Services
{
    public interface IExpenseData
    {
        IEnumerable<ExpenseViewModel> GetAllExpenses();
        EditExpenseViewModel Get(int id);
        AddExpenseViewModel Add(AddExpenseViewModel newExpense);
        void Remove(EditExpenseViewModel expense);
        void Edit(EditExpenseViewModel editedExpense);
        object GetExpensesByCategory(int value);
        Dictionary<CategoryType,decimal> GetExpensesByMonth(int month);
    }
}
