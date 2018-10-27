using ExpensesManager.ViewModels;
using System;
using System.Collections.Generic;

namespace ExpensesManager.Validators
{
    public class AddExpenseValidator : IValidator<AddExpenseViewModel>
    {
        public IEnumerable<ValidateResult> Validate(AddExpenseViewModel model)
        {
            var result = new List<ValidateResult>();
            var difference = model.Date.Value.Year - DateTime.UtcNow.Year;

            if (difference > 5)
            {
                result.Add(new ValidateResult()
                {
                    Key = nameof(model.Date),
                    Message = "Can't register expenses older than 5 years!"
                });
            }

           
            throw new NotImplementedException();
        }
    }
}
