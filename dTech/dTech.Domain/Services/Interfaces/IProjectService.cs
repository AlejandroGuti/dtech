using dTech.Common.DTOs;
using dTech.Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Domain.Services.Interfaces
{
    public interface IProjectService
    {
        Task<Response> Create(ProjectRequest model);
        Task<Response> Delete(int id);
        Task<Response> FindAll();
        Task<Response> FindById(int id);
        Task<Response> Update(int id, ProjectRequest request);
    }
}
