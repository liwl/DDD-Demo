using DDD.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Validations
{
    public class RegisterNewCustomerCommandValidation : StudentValidation<RegisterStudentCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();

            //可以自定义增加新的验证
        }
    }
}
