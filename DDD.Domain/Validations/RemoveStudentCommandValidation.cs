using DDD.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Validations
{
    public class RemoveStudentCommandValidation : StudentValidation<RemoveStudentCommand>
    {
        public RemoveStudentCommandValidation()
        {
            ValidateId();

            //可以自定义增加新的验证
        }
    }
}
