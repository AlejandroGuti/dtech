using dTech.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<int> Create(Project data);
        Task<int> Delete(int id);
        Task<ICollection<Project>> FindAll();
        Task<Project> FindById(int id);
        Task<int> Update(int id, Project data);
    }
}
