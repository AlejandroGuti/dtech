﻿using AutoMapper;
using dTech.Infrastructure.Contexts;
using dTech.Infrastructure.Entities;
using dTech.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dTech.Infrastructure.Repositories
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly DTechContext _context;
        private readonly IMapper _mapper;

        public ProjectRepository(DTechContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(Project data)
        {
            _context.Projects.Add(data);
            await _context.SaveChangesAsync();
            return data.Id;
        }

        public async Task<int> Delete(int id)
        {
            Project data = await _context.Projects.FindAsync(id);
            if (data == null)
            {
                return 0;
            }
            if (data.PTasks != null)
            {
                return 0;
            }

            _context.Projects.Remove(data);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<ICollection<Project>> FindAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> FindById(int id)
        {
            Project data = await _context.Projects
                .Include(T=>T.PTasks)
                .ThenInclude(o=>o.Comments)
                .ThenInclude(k=>k.Attachments)
                .Where(p=>p.Id==id)
                .FirstOrDefaultAsync();

            return data;
        }

        public async Task<int> Update(int id, Project data)
        {
            Project project = await _context.Projects.FindAsync(id);
            if (project == null) { return 0; }
            Project info = _mapper.Map<Project>(data);
            _context.Projects.Update(info);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
