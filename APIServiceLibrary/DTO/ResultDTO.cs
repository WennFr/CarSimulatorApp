using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServiceLibrary.DTO
{
    public class ResultDTO
    {
        public string Gender { get; set; }
        public NameDTO Name { get; set; }
        public LocationDTO Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
    }
}
