using AcademySystem.Domain.Entities;


namespace AcademySystem.Service.Services.Interfaces
{
    public interface IGroupService
    {
        Groups Create(Groups group);
        Groups Update(int id, Groups group);
        void Delete(int id); 
        Groups GetById(int id); 
        List<Groups> GetAll();
        List<Groups> GetByTeacher(string teacher);
        List<Groups> GetByRoom(int room);   
    }
}
