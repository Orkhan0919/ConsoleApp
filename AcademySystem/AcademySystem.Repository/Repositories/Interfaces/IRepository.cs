using AcademySystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademySystem.Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void CreateGroup(T data); 
        void UpdateGroup(T data);
        void DeleteGroup(T data);
        T Get(Predicate<T> predicate); 
        List<T> GetAll(Predicate<T>predicate);
    }
}
