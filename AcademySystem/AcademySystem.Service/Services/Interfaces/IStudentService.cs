using AcademySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademySystem.Service.Services.Interfaces
{
    public interface IStudentService
    {
        Student Create(int GroupId, Student student);
        Student Update(int id, Student student);
        void Delete(int Studentid);
        Student GetById(int Studentid);
        List<Student> GetAll();
        List<Student> GetByAge(int age);

    }
}
