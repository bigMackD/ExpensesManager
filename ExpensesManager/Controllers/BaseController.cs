using System;
using ExpensesManager.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesManager.Controllers
{
    public abstract class BaseController : Controller
    {
         public IServiceProvider Services { get; set; }

        public void Validate<TModel>(TModel model)
        {
            var validator = Services.GetService<IValidator<TModel>>();
            var result = validator.Validate(model);

            foreach (var res in result)
            {
                ModelState.AddModelError(res.Key, res.Message);
            }
        }


    }
}