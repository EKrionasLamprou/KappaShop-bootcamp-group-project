using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models.Shop.DTOs
{
    public class CommentDTO : IDataTransferObject<Comment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentDTO"/> class.
        /// </summary>
        public CommentDTO() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentDTO"/> class.
        /// </summary>
        /// <param name="comment">A <see cref="Comment"/> object to be mapped to DTO.</param>
        public CommentDTO(Comment comment)
        {
            Id = comment.Id;
            Content = comment.Content;
            Upvotes = comment.Upvotes;
            UserId = comment.UserId;
            ProductId = comment.ProductId;
        }

        public int? Id { get; set; }
        public string Content { get; set; }
        public int Upvotes { get; set; }
        public string UserId { get; set; }
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

        /// <summary>
        /// Maps a <see cref="Comment"/> instance to an object that matches the properties of a
        /// <see cref="CommentDTO"/> using the camelCase style.
        /// </summary>
        /// <param name="comment">The object to be mapped to camelCase DTO.</param>
        /// <returns>An object with camelCase properties that match a <see cref="CommentDTO"/>.</returns>
        public static object MapToCamelCase(Comment comment) => new
        {
            id = comment.Id,
            content = comment.Content,
            upvotes = comment.Upvotes,
            userId = comment.UserId,
            productId = comment.ProductId,
        };
        /// <summary>
        /// Maps a collection of <see cref="Comment"/> instances to objects that matche the properties of
        /// <see cref="CommentDTO"/> using the camelCase style.
        /// </summary>
        /// <param name="comments">The collection of objects to be mapped to camelCase DTO.</param>
        /// <returns>A collection of objects with camelCase properties that match <see cref="CommentDTO"/>.</returns>
        public static object MapToCamelCase(IEnumerable<Comment> comments)
            => comments.Select(comment => MapToCamelCase(comment));
    }
}