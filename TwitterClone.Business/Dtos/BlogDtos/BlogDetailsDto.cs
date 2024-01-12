using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Business.Dtos.BlogDtos
{
    public class BlogDetailsDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
