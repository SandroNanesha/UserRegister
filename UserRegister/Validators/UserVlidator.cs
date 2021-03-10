using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegister.Model;

namespace UserRegister.Validators
{
    public class UserVlidator : AbstractValidator<User>
    {
        public UserVlidator()
        {
            RuleFor(u => u.Id).Cascade(CascadeMode.StopOnFirstFailure)
                                .NotEmpty().WithMessage("User Id field is empty")
                                .Length(11).WithMessage("Length of {TotalLength} of {PropertyName} Invalid")
                                .Must(IsDigitsOnly).WithMessage("{PropertyName} contains Invalid characters");
            
            RuleFor(u => u.PhoneNumber).Cascade(CascadeMode.StopOnFirstFailure)
                                        .NotEmpty().WithMessage("Phone number filed is empty")
                                        .Length(9).WithMessage("Length of {TotalLength} of {PropertyName} Invalid")
                                .Must(IsDigitsOnly).WithMessage("{PropertyName} contains Invalid characters");
            
             
            RuleFor(u => u).Must(IsAcceptableSalary).WithMessage("{PropertyName} is Invalid");
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {  
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private bool IsAcceptableSalary(User u)
        {
            float f;
            if (!u.hasJob) return true;
            return u.hasJob && float.TryParse(u.monthlyIncome, out f) && f > 0;
        }
    }
}
