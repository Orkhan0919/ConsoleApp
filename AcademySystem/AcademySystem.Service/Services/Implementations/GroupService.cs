using System.Runtime.InteropServices;
using AcademySystem.Repository.Repositories.Implementations;
using AcademySystem.Service.Services.Interfaces;
using AcademySystem.Domain.Entities;


namespace AcademySystem.Service.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        private int _count = 1;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }
        public Groups Create(Groups group)
        {
            
            group.Id = _count;
            _groupRepository.CreateGroup(group);
            _count++;
            return group;
        } 
        public void Delete(int id)
        {
            Groups group = GetById(id);
            _groupRepository.DeleteGroup(group);
        } 

        public List<Groups> GetAll() 
        {
           return _groupRepository.GetAll();
        } 

        public Groups GetById(int id)
        {
            Groups group = _groupRepository.Get(l => l.Id == id);
            if (group is null) return null;
            return group;
        }

        public List<Groups> GetByRoom(int room)
        {
            return _groupRepository.GetGroupRoom(l => l.Room == room);
        }

        public List<Groups> GetByTeacher(string teacher)
        {
            return _groupRepository.GetGroupTeacher(l => l.Teacher == teacher);
        }

        public List<Groups> Search(string name)
        {
            return _groupRepository.GetAll(l => l.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public Groups Update(int id, Groups group)
        {
            Groups dbgroups = GetById(id);
            if (dbgroups is null) return null;
            group.Id = dbgroups.Id;
            _groupRepository.UpdateGroup(group);
            return group;
        }

     
    }
}
