using AutoMapper;
using AutoMapper.QueryableExtensions;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Commands;
using DDD.Domain.Core.Bus;
using DDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.Services
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly IMediatorHandler Bus;
        public StudentAppService(IMapper mapper,
                                  IStudentRepository studentRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            Bus = bus;


        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return _studentRepository.GetAll().ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider);
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_studentRepository.GetById(id));
        }

        public void Register(StudentViewModel StudentViewModel)
        {
            //_studentRepository.Add(_mapper.Map<Student>(StudentViewModel));
            //_studentRepository.SaveChanges();


            var registerCommand = _mapper.Map<RegisterStudentCommand>(StudentViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(StudentViewModel StudentViewModel)
        {
            //var updateCommand = _mapper.Map<UpdateStudentCommand>(StudentViewModel);
            //Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            //var removeCommand = new RemoveStudentCommand(id);
            //Bus.SendCommand(removeCommand);
        }

        public IList<StudentViewModel> GetAllHistory(Guid id)
        {
            return null;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
