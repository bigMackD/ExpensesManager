using ExpensesManager.Data;
using ExpensesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManager.Services
{
    public class SqlExpenseData : IExpenseData
    {
        private ExpensesManagerDbContext _context;

        public SqlExpenseData(ExpensesManagerDbContext context)
        {
            _context = context;
        }
    
        public Expense Add(Expense newExpense)
        {
            _context.Expenses.Add(newExpense);
            _context.SaveChanges();
            return newExpense;
        }

        public Expense Get(int id)
        {
            return _context.Expenses.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _context.Expenses.OrderBy(x => x.Date).ToList();
        }

        public void Remove(Expense expense)
        {
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
        }
    }
}
