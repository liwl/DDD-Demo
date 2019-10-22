using DDD.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Models
{
    public class Student: Entity
    {
        protected Student() { }
        public Student(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        //public Guid Id { get; private set; }//模型的唯一标识
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime BirthDate { get; private set; }


        public Address Address { get; set; }
    }
}
