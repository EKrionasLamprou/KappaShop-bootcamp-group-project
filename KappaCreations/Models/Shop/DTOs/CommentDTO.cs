namespace KappaCreations.Models.Shop.DTOs
{
    public class CommentDTO : IDataTransferObject<Comment>
    {
        public int? Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public Comment Map() => new Comment
        {
            Content = Content,
            UserId = UserId,
            ProductId = ProductId,
        };

        public static CommentDTO MapFrom(Comment comment) => new CommentDTO
        {
            Id = comment.Id,
            Content = comment.Content,
            UserId = comment.UserId,
            ProductId = comment.ProductId,
        };
    }
}