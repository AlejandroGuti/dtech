using dTech.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dTech.Common.DTOs
{
    public class PTaskRequest
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public PTaskStatus PTaskStatus { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
        public DateTime EndDate { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}
