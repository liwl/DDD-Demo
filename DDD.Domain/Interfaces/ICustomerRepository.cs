using DDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Interfaces
{
    /// <summary>
    /// ICustomerRepository 接口
    /// 注意，这里我们用到的业务对象，是领域对象
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        //一些Customer独有的接口
        Customer GetByEmail(string email);
    }
}
