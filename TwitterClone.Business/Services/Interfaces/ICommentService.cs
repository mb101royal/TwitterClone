using TwitterClone.Business.Dtos.CommentDtos;

namespace TwitterClone.Business.Services.Interfaces
{
    public interface ICommentService
    {
        Task Create(CommentCreateDto dto);
        IEnumerable<CommentDetailsDto> GetAll();
        CommentDetailedDto GetById(int id);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task SoftDeleteRevertAsync(int id);
        /*Task Update(int id, CommentUpdateDto dto);
        Task React(int id, ReactionTypes type);*/
    }
}
