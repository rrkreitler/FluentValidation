using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace FluentValidation.Models
{
    public class Employee_Validation :AbstractValidator<Employee>
    {
        public Employee_Validation()
        {
            RuleFor(X => X.Name).NotEmpty().WithMessage("Employee Name is required");
            RuleFor(X => X.Mail_Id).NotEmpty().WithMessage("Employee Mail_Id is required");
            RuleFor(X => X.DOB).NotEmpty().WithMessage("Employee DOB is required");
            RuleFor(X => X.Password).NotEmpty().WithMessage("Employee Password is required");
            RuleFor(X => X.Confirm_Password).NotEmpty().WithMessage("Employee Password is required");
            RuleFor(X => X.Confirm_Password).Equal(x => x.Password).WithMessage("Passwords do not match");
            RuleFor(X => X.Mail_Id).EmailAddress().WithMessage("Email Address is not valid");
            RuleFor(X => X.DOB).Must(Validate_Age).WithMessage("Age must be 18 or older");
            RuleFor(X => X.Password).Must(Password_Length).WithMessage("Password must be 8 or more characters");
        }

        private bool Password_Length(string password)
        {
            return password.Length >= 8;
        }

        private bool Validate_Age(DateTime dob)
        {
            DateTime currentDate = DateTime.Today;
            return currentDate.Year - Convert.ToDateTime(dob).Year >= 18;
        }
    }
}