namespace TwitterClone.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Message { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int BlogId { get; set; }
        public Blog Blog{ get; set; }
        public int? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public IEnumerable<Comment>? Comments { get; set; }
    }
}
