﻿using DataAccess;
using Domain;

namespace View
{
    public class StudentRegistrationPresenter
    {
        private IStudentView studentView;
        private IStudentRepository studentRepository;

        public StudentRegistrationPresenter(IStudentView studentView, IStudentRepository studentRepository)
        {
            this.studentView = studentView;
            this.studentRepository = studentRepository;
        }

        public void RegisterNewStudent(Student newStudent)
        {
            if (newStudent == null || !studentView.ShouldSaveStudent)
            {
                studentView.WasStudentSaved = false;
            }
            else if (studentView.ShouldSaveStudent)
            {
                studentRepository.Save(newStudent);
                studentView.WasStudentSaved = true;
            }
        }
    }
}
