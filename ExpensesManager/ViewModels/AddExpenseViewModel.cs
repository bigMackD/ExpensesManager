using ExpensesManager.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ExpensesManager.ViewModels
{
    public class AddExpenseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="You must enter name of your expense!")]
        [MinLength(3,ErrorMessage = "Expense name can't be shorter than 3 chars!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter expense value!")]
        [DataType(DataType.Currency)]
        public decimal? Amount { get; set; }

        [Required(ErrorMessage = "You must enter date of your expense!")]
        public DateTime? Date { get; set; }

        [Required]
        public CategoryType? Category { get; set; }
    }
}
