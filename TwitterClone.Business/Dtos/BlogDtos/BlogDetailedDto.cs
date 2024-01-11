using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.Dtos.BlogDtos
{
    public class BlogDetailedDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public int TimesUpdated { get; set; }
    }
}
