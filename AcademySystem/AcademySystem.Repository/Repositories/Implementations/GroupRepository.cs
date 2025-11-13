using AcademySystem.Domain.Entities;
using AcademySystem.Repository.Data;
using AcademySystem.Repository.Exceptions;
using AcademySystem.Repository.Repositories.Interfaces;

namespace AcademySystem.Repository.Repositories.Implementations
{
    public class GroupRepository : IRepository<Groups>
    {
        public void CreateGroup(Groups data)
        {
            try
            {
                if (data == null) throw new NotFoundException("Data Not Found");
                AppDbContext<Groups>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        } 

        public void DeleteGroup(Groups data)
        {
            AppDbContext<Groups>.datas.Remove(data);
        } 

        public Groups Get(Predicate<Groups> predicate)
        {
            return predicate != null ? AppDbContext<Groups>.datas.Find(predicate) : null;
        }
        public List<Groups> GetGroupTeacher(Predicate<Groups> predicate )
        {
            return predicate != null ? AppDbContext<Groups>.datas.FindAll(predicate) : AppDbContext<Groups>.datas;
        } 

        public List<Groups> GetAll(Predicate<Groups> predicate = null )
        {
            return predicate != null ? AppDbContext<Groups>.datas.FindAll(predicate) : AppDbContext<Groups>.datas;
        } 
         
        public List<Groups> GetGroupRoom(Predicate<Groups> predicate)
        {
            return predicate != null ? AppDbContext<Groups>.datas.FindAll(predicate) : AppDbContext<Groups>.datas;        } 

        public void UpdateGroup(Groups data)
        {
            Groups dbgroups = Get(l => l.Id == data.Id);
            dbgroups.Name = data.Name;
            dbgroups.Teacher = data.Teacher;
            dbgroups.Room = data.Room;
        }
    }
}
