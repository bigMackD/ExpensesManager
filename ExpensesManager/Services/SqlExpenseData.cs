using ExpensesManager.Data;
using ExpensesManager.Models;
using System.Collections.Generic;
using System.Linq;

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

        public void Edit(Expense editedExpense)
        {
            _context.Expenses.Remove(_context.Expenses.FirstOrDefault(x => x.Id == editedExpense.Id));
            _context.Expenses.Add(editedExpense);
            _context.SaveChanges();
        }

        public Expense Get(int id)
        {
            return _context.Expenses.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _context.Expenses.OrderBy(x => x.Date).ToList();
        }

        public object GetExpensesByCategory(int value)
        {
            return _context.Expenses.Where(x => (int)x.Category == value).ToList();
        }

        public void Remove(Expense expense)
        {
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
        }
    }
}
