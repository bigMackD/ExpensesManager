﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesManager.Models;

namespace ExpensesManager.Services
{
    public class MemoryExpansesData : IExpenseData
    {
        List<Expense> _expenses = new List<Expense>
        {
            new Expense{ Id = 1, Name = "test", Amount=2, Category= CategoryType.Education,},
             new Expense{ Id = 1, Name = "test2", Amount=2, Category= CategoryType.Travel, }
        };
        public Expense Add(Expense newExpense)
        {
            throw new NotImplementedException();
        }

        public Expense Get(int id)
        {
            return _expenses.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _expenses.OrderBy(x => x.Name).ToList();
        }

        public void Remove(Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}
