using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManager.Models
{
    public class Expense
    {
            [Key]
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            public decimal Amout { get; set; }

            [Required]
            public DateTime Date { get; set; }

            [Required]
            public CategoryType Category { get; set; }
    }
}
