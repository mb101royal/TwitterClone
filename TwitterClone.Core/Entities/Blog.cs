namespace TwitterClone.Core.Entities
{
    public class Blog : BaseEntity
    {
        public string Content { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int TimesUpdated { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public IEnumerable<Comment>? Comments{ get; set; }
    }
}
