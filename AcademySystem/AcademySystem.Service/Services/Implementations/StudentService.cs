using AcademySystem.Domain.Entities;
using AcademySystem.Repository.Repositories.Implementations;
using AcademySystem.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademySystem.Service.Services.Implementations
{
    public class StudentService : IStudentService

    {
        StudentRepository _studentRepository;
        GroupRepository _groupRepository;
        int count = 1;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }
        public Student Create(int GroupId ,Student student)
        {
            var group = _groupRepository.Get(l => l.Id == GroupId);
            if (group is null) return null;

            student.Id = count;
            student.Group = group;

            _studentRepository.CreateGroup(student);
            count++;
            return student;
        }

        public void Delete(int Studentid)
        {
            Student student = GetById(Studentid);
            _studentRepository.DeleteGroup(student);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public List<Student> GetByAge(int age)
        {
            return _studentRepository.GetByAge(l => l.Age == age);
        }

        public Student GetById(int Studentid)
        {
            Student student = _studentRepository.Get(l => l.Id == Studentid);
            if (student is null) return null;
            return student;
        }

        public List<Student> GetByGroupId(int groupId)
        {
            return _studentRepository.GetByGroupId(s => s.Group.Id == groupId);
        }

        public List<Student> Search(string name)
        {
            return _studentRepository.GetAll(l => l.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public Student Update(int id, Student student)
        {
            Student dbstudent = GetById(id);
            if (dbstudent is null) return null;
            student.Id = dbstudent.Id;
            _studentRepository.UpdateGroup(student);
            return student;
        }
    }
}
