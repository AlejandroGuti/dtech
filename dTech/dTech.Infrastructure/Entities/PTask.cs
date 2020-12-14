using dTech.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dTech.Infrastructure.Entities
{
    public class PTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PTaskStatus PTaskStatus { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
        public DateTime EndDate { get; set; }
        public Project Project { get; set; }
        public ICollection<Attachment> MyProperty { get; set; }
    }
}
