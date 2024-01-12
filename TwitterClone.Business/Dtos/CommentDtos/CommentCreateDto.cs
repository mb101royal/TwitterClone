namespace TwitterClone.Business.Dtos.CommentDtos
{
    public class CommentCreateDto
    {
        public string Message { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
