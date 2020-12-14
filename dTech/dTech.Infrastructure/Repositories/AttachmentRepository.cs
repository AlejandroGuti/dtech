using dTech.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Repositories
{
    public class AttachmentRepository
    {
      /*  public async Task<int> Create(ICollection<Attachment> model)
        {
            ICollection<Attachment> attachments = _mapper.Map<ICollection<Attachment>>(model);
            int requestId = model.Select(o => o.RequestId).FirstOrDefault();
            foreach (var item in attachments)
            {
                item.Request = await _context.Requests.FindAsync(requestId);
                if (item.Request == null)
                {
                    return 0;
                }
                _context.Attachments.Add(item);
            }
            return await _context.SaveChangesAsync();




        }*/
    }
}
