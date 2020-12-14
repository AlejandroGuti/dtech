using dTech.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Repositories.Interfaces
{
    interface IPTaskRepository
    {
        Task<int> Create(PTask data);
        Task<int> Delete(int id);
        Task<ICollection<PTask>> FindAll();
        Task<PTask> FindById(int id);
        Task<int> Update(int id, PTask data);
    }
}
