using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.BlogDtos;

namespace TwitterClone.Business.Services.Interfaces
{
    public interface IBlogService
    {
        Task Create(BlogCreateDto dto);
    }
}
