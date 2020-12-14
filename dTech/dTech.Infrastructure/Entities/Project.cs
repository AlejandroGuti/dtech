using dTech.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dTech.Infrastructure.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
        public DateTime CreationDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
        public DateTime EndDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public ICollection<PTask> MyProperty { get; set; }
    }
}
