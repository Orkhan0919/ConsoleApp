using AcademySystem.Domain.Entities;
using AcademySystem.Repository.Data;
using AcademySystem.Repository.Exceptions;
using AcademySystem.Repository.Repositories.Interfaces;

namespace AcademySystem.Repository.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        public void CreateGroup(Student data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Student is not found");
                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteGroup(Student data)
        {
            AppDbContext<Student>.datas.Remove(data);
        }

        public Student Get(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;       
        }

        public List<Student> GetAll(Predicate<Student> predicate = null)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate): AppDbContext<Student>.datas;
        }

        public List<Student> GetByAge(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }

        public List<Student> GetByGroupId(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas ;
        }

        
        public void UpdateGroup(Student data)
        {
            Student dbstudent = Get(l => l.Id == data.Id);
            dbstudent.Name = data.Name;
            dbstudent.Surname = data.Surname;
            dbstudent.Age = data.Age;
        }
    }
}
