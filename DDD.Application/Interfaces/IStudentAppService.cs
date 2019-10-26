using DDD.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.Interfaces
{
   public interface IStudentAppService : IDisposable
    {
        void Register(StudentViewModel studentViewModel);
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel GetById(Guid id);
        void Update(StudentViewModel studentViewModel);
        void Remove(Guid id);
        IList<StudentViewModel> GetAllHistory(Guid id);
    }
}
