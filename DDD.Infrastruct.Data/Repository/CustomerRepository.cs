using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using DDD.Infrastruct.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Infrastruct.Data.Repository
{
    /// <summary>
    /// Customer仓储，操作对象还是领域对象
    /// </summary>
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StudyContext context) : base(context)
        {
        }

        //对特例接口进行实现
        public Customer GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}
