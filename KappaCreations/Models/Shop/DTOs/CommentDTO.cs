using System.Linq;

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

        public object MapToCamelCase() => new
        {
            id = Id ?? 0,
            content = Content,
            upvotes = Upvotes,
            userId = UserId,
            productId = ProductId,
        };

        /// <summary>
        /// Returns a <see cref="CommentDTO"/> object, by mapping the properties of
        /// a <see cref="Comment"/> object.
        /// </summary>
        /// <param name="comment">An instance of a <see cref="Comment"/> entity.</param>
        /// <returns>An instance of a <see cref="CommentDTO"/> object.</returns>
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