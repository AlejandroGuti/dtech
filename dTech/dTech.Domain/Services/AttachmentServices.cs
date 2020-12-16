using dTech.Common.DTOs;
using dTech.Common.Enums;
using dTech.Common.Responses;
using dTech.Domain.Services.Interfaces;
using dTech.Infrastructure.Entities;
using dTech.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace dTech.Domain.Services
{
    public class AttachmentServices : IAttachmentService
    {
        private readonly IConfiguration _configuration;
        private readonly ICommentRepository _commentRepository;
        private readonly IAttachmentRepository _attachmentRepository;

        public AttachmentServices(IConfiguration configuration, 
            ICommentRepository commentRepository, 
            IAttachmentRepository attachmentRepository)
        {
            _configuration = configuration;
            _commentRepository = commentRepository;
            _attachmentRepository = attachmentRepository;
        }
        public async Task<Response> SaveFiles(AttachmentRequest model)
        {
            ICollection<Attachment> attachmentDTO = await UploadAttachments(model);
            int result = await _attachmentRepository.Create(attachmentDTO);
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
        private async Task<ICollection<Attachment>> UploadAttachments(AttachmentRequest request)
        {
            ICollection<IFormFile> files = request.FormFiles;
            ICollection<Attachment> response = new List<Attachment>();
            Attachment model;
            long size = files.Sum(f => f.Length);
            string storagePath = _configuration["StoragePath:Key"];
            foreach (IFormFile formFile in files)
            {
                if (formFile.Length > 0)
                {
                    Guid g = Guid.NewGuid();
                    string guidString = g.ToString("N");
                    string originalFilename = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                    string[] parts = originalFilename.Split(".");
                    string filename = $"{guidString}.{parts[parts.Length - 1]}";
                    using (FileStream stream = File.Create(Path.Combine(storagePath, filename)))
                    {
                        await formFile.CopyToAsync(stream);
                        model = new Attachment
                        {
                            Comment = await _commentRepository.FindById( request.CommentId),
                            Route = storagePath,
                            Name = filename
                        };

                    }
                    response.Add(model);


                }

            }
            return response;
        }


    }
}
