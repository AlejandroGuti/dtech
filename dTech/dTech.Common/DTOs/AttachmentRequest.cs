using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace dTech.Common.DTOs
{
    public class AttachmentRequest
    {
        public int CommentId { get; set; }
        public ICollection<IFormFile> FormFiles { get; set; }
    }
}
