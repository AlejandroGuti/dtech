using AutoMapper;
using dTech.Infrastructure.Contexts;
using dTech.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Repositories.Interfaces
{
    public class PTaskRepository
    {
        private readonly DTechContext _context;
        private readonly IMapper _mapper;

        public PTaskRepository(DTechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(PTask data)
        {
            _context.PTasks.Add(data);
            await _context.SaveChangesAsync();
            return data.Id;
        }

        public async Task<int> Delete(int id)
        {
            PTask data = await _context.PTasks.FindAsync(id);
            if (data == null)
            {
                return 0;
            }
            if (data.Comments != null)
            {
                return 0;
            }

            _context.PTasks.Remove(data);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<ICollection<PTask>> FindAll()
        {
            return await _context.PTasks.ToListAsync();
        }

        public async Task<PTask> FindById(int id)
        {
            PTask data = await _context.PTasks
                .Include(o=>o.Comments)
                .ThenInclude(k=>k.Attachments)
                .Where(k=>k.Id==id)
                .FirstOrDefaultAsync();

            return data;
        }

        public async Task<int> Update(int id, PTask data)
        {
            PTask pTask = await _context.PTasks.FindAsync(id);
            if (pTask == null) { return 0; }
            PTask info = _mapper.Map<PTask>(data);
            _context.PTasks.Update(info);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
