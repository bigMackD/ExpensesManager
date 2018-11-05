using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExpensesManager.Models;
using ExpensesManager.Services;
using ExpensesManager.ViewModels;

namespace ExpensesManager.Controllers
{
    public class HomeController : BaseController
    {
        IExpenseData _expenseData;

        public HomeController(IExpenseData expenseData)
        {
            _expenseData = expenseData;
        }
        public IActionResult Index()
        {
            var model = _expenseData.GetAllExpenses();
            return View(model);
        }

        public IActionResult Details(int id)
        {
           return View(_expenseData.Get(id));
        }

        [HttpPost]
        public IActionResult Create(AddExpenseViewModel expense)
        {
            if (ModelState.IsValid)
            {
                var newExpense = _expenseData.Add(expense);
                return RedirectToAction("Details", new { id = newExpense.Id });
            }
            return View(expense);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Remove(EditExpenseViewModel expense)
        {
            _expenseData.Remove(expense);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var expenseToRemove = _expenseData.Get(id);
            return View(expenseToRemove);
        }

        [HttpPost]
        public IActionResult Edit (EditExpenseViewModel expense)
        {
          
            if (ModelState.IsValid)
            {
                _expenseData.Edit(expense);
                return RedirectToAction("Index");
            }
            else
            {
                return View(expense);
            }
          
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            var expenseToBeEdited = _expenseData.Get(id);
            return View(expenseToBeEdited);
        }

        public IActionResult GetExpensesList(int? categoryId)
        {
            if (categoryId.HasValue)
            {
                var model = _expenseData.GetExpensesByCategory(categoryId.Value);
                return PartialView("_ExpensesList", model);
            }
            else
            {
                var model = _expenseData.GetAllExpenses();
                return PartialView("_ExpensesList", model);
            }
        }

        [HttpGet]
        public IActionResult GetModalChart()
        {
            return PartialView("_ChartPopup");
        }

        [HttpGet]
        public JsonResult GetChartData(int month)
        {
            var model = _expenseData.GetExpensesByMonth(month);
            return new JsonResult(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
