using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.Dtos.TokenDtos
{
    public class TokenParamsDto
    {
        public AppUser User { get; set; }
        public string Role { get; set; }
    }
}
