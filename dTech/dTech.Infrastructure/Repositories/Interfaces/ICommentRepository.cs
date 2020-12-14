using dTech.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Repositories.Interfaces
{
    interface ICommentRepository
    {
        Task<int> Create(Comment data);
        Task<int> Delete(int id);
        Task<ICollection<Comment>> FindAll();
        Task<Comment> FindById(int id);
        Task<int> Update(int id, Comment data);
    }
}
