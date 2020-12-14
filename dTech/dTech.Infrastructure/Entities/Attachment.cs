using System;
using System.Collections.Generic;
using System.Text;

namespace dTech.Infrastructure.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }
        public Comment Comment { get; set; }
    }
}
