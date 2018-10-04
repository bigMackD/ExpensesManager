using ExpensesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManager.Services
{
    public interface IExpenseData
    {
        IEnumerable<Expense> GetAllExpenses();
        Expense Get(int id);
        Expense Add(Expense newExpense);
        void Remove(Expense expense);
    }
}
