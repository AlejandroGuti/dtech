using AutoMapper;
using dTech.Infrastructure.Contexts;
using dTech.Infrastructure.Entities;
using dTech.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly DTechContext _context;
        private readonly IMapper _mapper;

        public AttachmentRepository(DTechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(ICollection<Attachment> model)
        {
            ICollection<Attachment> attachments = _mapper.Map<ICollection<Attachment>>(model);
            int commentId = model.Select(o => o.Comment.Id).FirstOrDefault();
            foreach (var item in attachments)
            {
                item.Comment = await _context.Comment.FindAsync(commentId);
                if (item.Comment == null)
                {
                    return 0;
                }
                _context.Attachments.Add(item);
            }
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            Attachment data = await _context.Attachments.FindAsync(id);
            if (data == null)
            {
                return 0;
            }
            _context.Attachments.Remove(data);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
