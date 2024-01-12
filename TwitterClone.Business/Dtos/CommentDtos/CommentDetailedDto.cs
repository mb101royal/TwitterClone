using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.AppUserDtos;

namespace TwitterClone.Business.Dtos.CommentDtos
{
    public class CommentDetailedDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public AppUserInfoDto AppUser { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
