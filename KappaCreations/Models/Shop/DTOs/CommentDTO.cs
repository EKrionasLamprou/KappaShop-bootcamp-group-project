namespace KappaCreations.Models.Shop.DTOs
{
    public class CommentDTO : IDataTransferObject<Comment>
    {
        public int? Id { get; set; }
        public string Content { get; set; }
        public int Upvotes { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public bool HasId => Id.HasValue && Id > 0;

        public Comment Map() => new Comment
        {
            Id = Id ?? 0,
            Content = Content,
            UserId = UserId,
            Upvotes = Upvotes,
            ProductId = ProductId,
        };

        public static CommentDTO MapFrom(Comment comment) => new CommentDTO
        {
            Id = comment.Id,
            Content = comment.Content,
            Upvotes = comment.Upvotes,
            UserId = comment.UserId,
            ProductId = comment.ProductId,
        };
    }
}