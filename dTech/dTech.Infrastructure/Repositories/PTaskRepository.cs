using AutoMapper;
using dTech.Infrastructure.Contexts;
using dTech.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Repositories.Interfaces
{
    public class PTaskRepository :IPTaskRepository
    {
        private readonly DTechContext _context;

        public PTaskRepository(DTechContext context)
        {
            _context = context;
        }
        public async Task<int> Create(PTask data, int ProjectId)
        {
            data.Project= await _context.Projects.FindAsync(ProjectId);
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

        public async Task<int> Update(PTask data)
        {
            _context.PTasks.Update(data);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
