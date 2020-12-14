using AutoMapper;
using dTech.Infrastructure.Contexts;
using dTech.Infrastructure.Entities;
using dTech.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Repositories
{
    public class CommentRepository: ICommentRepository
    {
        private readonly DTechContext _context;
        private readonly IMapper _mapper;

        public CommentRepository(DTechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(Comment data)
        {
            _context.Comment.Add(data);
            await _context.SaveChangesAsync();
            return data.Id;
        }

        public async Task<int> Delete(int id)
        {
            Comment data = await _context.Comment.FindAsync(id);
            if (data == null)
            {
                return 0;
            }
            if (data.Attachments != null)
            {
                return 0;
            }

            _context.Comment.Remove(data);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<ICollection<Comment>> FindAll()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment> FindById(int id)
        {
            Comment data = await _context.Comment
                .Include(k=>k.Attachments)
                .Where(o=>o.Id==id)
                .FirstOrDefaultAsync();

            return data;
        }

        public async Task<int> Update(int id, Comment data)
        {
            Comment comment = await _context.Comment.FindAsync(id);
            if (comment == null) { return 0; }
            Comment info = _mapper.Map<Comment>(data);
            _context.Comment.Update(info);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
