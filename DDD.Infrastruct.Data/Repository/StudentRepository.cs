using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using DDD.Infrastruct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Infrastruct.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudyContext context) : base(context)
        {
        }

        public Student GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    
}
}
