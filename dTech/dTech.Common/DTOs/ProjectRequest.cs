﻿using dTech.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dTech.Common.DTOs
{
    public class ProjectRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
        public DateTime EndDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
    }
}
