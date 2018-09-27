using ExpensesManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManager.Data
{
    public class ExpensesManagerDbContext : DbContext
    {
        public ExpensesManagerDbContext(DbContextOptions options)
           : base(options)
        {

        }
        public DbSet<Expense> Expenses { get; set; }
    }
}
