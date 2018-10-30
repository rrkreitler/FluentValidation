using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Models;
using FluentValidation.Results;

namespace FluentValidation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Employee Emp)
        {
            Employee_Validation obj = new Employee_Validation();
            ValidationResult result = obj.Validate(Emp);

            if (!result.IsValid)
            {
                foreach (ValidationFailure error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View(Emp);
        }
    }
}