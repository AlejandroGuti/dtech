using dTech.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Repositories.Interfaces
{
    interface IAttachmentRepository
    {
        Task<int> Create(ICollection<Attachment> model);
        Task<int> Delete(int id);

    }
}
