﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExpensesManager.Models;
using ExpensesManager.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpensesManager.Controllers
{
    public class HomeController : Controller
    {
        IExpenseData _expenseData;
        private CategoryType _categoryType = new CategoryType();

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
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                var newExpense = _expenseData.Add(expense);
                return RedirectToAction("Details", new { id = expense.Id });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
           // CategoryType[] category = (CategoryType[])Enum.GetValues(typeof(CategoryType));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
