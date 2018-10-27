using ExpensesManager.Data;
using ExpensesManager.Models;
using ExpensesManager.ViewModels;
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
    
        public Expense Add(AddExpenseViewModel newExpenseViewModel)
        {
            Expense newExpense = new Expense
            {
                Name = newExpenseViewModel.Name,
                Amount = newExpenseViewModel.Amount.Value,
                Category = newExpenseViewModel.Category.Value,
                Date = newExpenseViewModel.Date.Value,
            };

            _context.Expenses.Add(newExpense);
            _context.SaveChanges();

            return newExpense;
        }

        public void Edit(EditExpenseViewModel editedExpense)
        {
            _context.Expenses.Remove(_context.Expenses.FirstOrDefault(x => x.Id == editedExpense.Id));
            Expense newEditedExpense = new Expense
            {
                Id = editedExpense.Id,
                Name = editedExpense.Name,
                Amount = editedExpense.Amount.Value,
                Category = editedExpense.Category.Value,
                Date = editedExpense.Date.Value,
            };
            _context.Expenses.Add(newEditedExpense);
            _context.SaveChanges();
        }

        public EditExpenseViewModel Get(int id)
        {
            var expense = _context.Expenses.FirstOrDefault(x => x.Id == id);

            var editViewModel = new EditExpenseViewModel()
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Date = expense.Date,
                Name = expense.Name,
                Category = expense.Category
            };

            return editViewModel;
        }

        public IEnumerable<ExpenseViewModel> GetAllExpenses()
        {
            return _context.Expenses.Select(x => new ExpenseViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                Date = x.Date,
                Name = x.Name,
                Category = x.Category,
               
            }).ToList();
        }

        public object GetExpensesByCategory(int value)
        {
            return _context.Expenses.Where(x => (int)x.Category == value).Select(x => new ExpenseViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                Date = x.Date,
                Name = x.Name,
                Category = x.Category,
            }).ToList();
        }

        public void Remove(Expense expense)
        {
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
        }

        public Dictionary<CategoryType,decimal> GetExpensesByMonth(int month)
        {
            month++;
            Dictionary<CategoryType, decimal> raport = new Dictionary<CategoryType, decimal>();
             raport = _context.Expenses
                        .Where(x =>x.Date.Month == month)
                            .GroupBy(x => x.Category)
                                 .ToDictionary(x => x.Key, x => x.Sum(n => n.Amount));
            return raport;
        }
    }
}
