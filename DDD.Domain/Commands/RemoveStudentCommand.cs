using DDD.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Commands
{
    /// <summary>
    /// 注册一个添加 Student 命令
    /// 基础抽象学生命令模型
    /// </summary>
    public class RemoveStudentCommand : StudentCommand
    {
        public RemoveStudentCommand(Guid id)
        {
            Id = id;
            //AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
