﻿using System;
using DataAccess;
using Domain;

namespace Services
{
    public class StudentRegistrationService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IStudentValidator studentValidator;

        public StudentRegistrationService(IStudentRepository studentRepository, IStudentValidator studentValidator)
        {
            this.studentRepository = studentRepository;
            this.studentValidator = studentValidator;
        }

        public void RegisterNewStudent(Student toRegister)
        {
            if (studentValidator.ValidateStudent(toRegister))
            {
                studentRepository.Save(toRegister);
            }
            else
            {
                throw new Exception($"Invalid student: {toRegister}.");
            }
        }

        public void RegisterNewStudent(int studentId, string firstName, string lastName)
        {
            var toRegister = new Student {StudentId = studentId, FirstName = firstName, LastName = lastName};
            RegisterNewStudent(toRegister);
        }
    }
}
