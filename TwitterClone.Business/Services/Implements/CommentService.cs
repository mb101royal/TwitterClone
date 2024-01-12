using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.BlogDtos;
using TwitterClone.Business.Dtos.CommentDtos;
using TwitterClone.Business.Repositories.Interfaces;
using TwitterClone.Business.Services.Interfaces;

namespace TwitterClone.Business.Services.Implements
{
    public class CommentService : ICommentService
    {
        ICommentRepository _commentRepo { get; }
        IMapper _mapper { get; }

        public CommentService(ICommentRepository commentRepo, IMapper mapper)
        {
            _commentRepo = commentRepo;
            _mapper = mapper;
        }

        public Task Create(CommentCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDetailsDto> GetAll()
        {
            var commentFromRepo = _commentRepo.GetAll().Where(t => t.IsDeleted == false);

            var mappedCommentFromRepo = _mapper.Map<IEnumerable<CommentDetailsDto>>(commentFromRepo);

            return mappedCommentFromRepo;
        }

        public CommentDetailedDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteRevertAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
