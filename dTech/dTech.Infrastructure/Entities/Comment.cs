using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dTech.Infrastructure.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public PTask PTask { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
}
