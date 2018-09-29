using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            [DataType(DataType.Currency)]
            [Column(TypeName = "decimal(10,2)")]
            public decimal Amount { get; set; }
            
            [Required]
            public DateTime Date { get; set; }
     
            [Required]
            public CategoryType Category { get; set; }
    }
}
