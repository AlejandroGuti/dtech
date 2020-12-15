using dTech.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<int> Create(Comment data, int PTaskId);
        Task<int> Delete(int id);
        Task<ICollection<Comment>> FindAll();
        Task<Comment> FindById(int id);
        Task<int> Update(Comment data);
    }
}
