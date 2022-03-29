namespace KappaCreations.Models
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        int upvotes = 0;
        public int Upvotes {
            get => upvotes;
            set
            {
                upvotes = value;
                if (upvotes < 0)
                    upvotes = 0;
            }
        }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}