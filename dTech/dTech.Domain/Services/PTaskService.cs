using AutoMapper;
using dTech.Common.DTOs;
using dTech.Common.Enums;
using dTech.Common.Responses;
using dTech.Domain.Services.Interfaces;
using dTech.Infrastructure.Entities;
using dTech.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Domain.Services
{
    public class PTaskService: IPTaskService
    {
        private readonly IPTaskRepository _pTaskRepository;
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;

        public PTaskService(IPTaskRepository pTaskRepository, IMapper mapper, IProjectRepository projectRepository)
        {
            _pTaskRepository = pTaskRepository;
            _mapper = mapper;
            _projectRepository = projectRepository;
        }
        public async Task<Response> Create(PTaskRequest model)
        {

            PTask info = _mapper.Map<PTask>(model);
            info.PTaskStatus = PTaskStatus.New;
            int result = await _pTaskRepository.Create(info,model.ProjectId);

            if (result > 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = Messages.Created.ToString(),
                    Result = result
                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotCreated.ToString()
                };
            }
        }
        public async Task<Response> Delete(int id)
        {
            int result = await _pTaskRepository.Delete(id);

            if (result > 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = Messages.Delete.ToString(),
                    Result = result

                };
            }

            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotDelete.ToString()
                };
            }
        }
        public async Task<Response> FindAll()
        {
            ICollection<PTask> result = await _pTaskRepository.FindAll();

            if (result.Count > 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = Messages.Found.ToString(),
                    Result = result

                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotFound.ToString()
                };
            }
        }
        public async Task<Response> FindById(int id)
        {
            PTask result = await _pTaskRepository.FindById(id);

            if (result != null)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = Messages.Found.ToString(),
                    Result = result

                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotFound.ToString()
                };
            }
        }
        public async Task<Response> Update(int id, PTaskRequest request)
        {
            PTask pTask = await _pTaskRepository.FindById(id);
            if (pTask == null)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotFound.ToString()
                };
            }
            pTask.Title = request.Title;
            pTask.Description = request.Description;
            pTask.EndDate = request.EndDate;
            pTask.PTaskStatus = request.PTaskStatus;
            int result = await _pTaskRepository.Update(pTask);

            if (result > 0)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = Messages.Updated.ToString(),
                    Result = result

                };
            }
            else
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Messages.NotUpdated.ToString()
                };
            }
        }
    }
}
