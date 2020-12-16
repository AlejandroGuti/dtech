using dTech.Common.DTOs;
using dTech.Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Domain.Services.Interfaces
{
    public interface IAttachmentService
    {
        Task<Response> SaveFiles(AttachmentRequest model);
    }
}
