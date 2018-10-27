using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManager.Validators
{
    public interface IValidator<TModel>
    {
        IEnumerable<ValidateResult> Validate(TModel model);
    }

    public class ValidateResult
    {
        public string Key { get; set; }
        public string Message { get; set; }
    }
}
