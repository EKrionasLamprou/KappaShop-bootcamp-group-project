using System.Collections.Generic;
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

        #region MapFrom
        /// <summary>
        /// Returns an <see cref="object"/> that matches the properties of <see cref="CommentDTO"/>.
        /// </summary>
        /// <param name="comment">An instance of a <see cref="Comment"/> entity.</param>
        /// <param name="camelCase"><see langword="true"/> for returning an object with cameCase style, 
        /// <see langword="false"/> for PascalCase.</param>
        /// <returns>An object with <see cref="CommentDTO"/> properties.</returns>
        public static object MapFrom(Comment comment, bool camelCase = false)
            => camelCase ? MapFromWithCamelCase(comment)
                         : MapFromWithPascalCase(comment);
        /// <summary>
        /// Returns an <see cref="object"/> that matches the properties of <see cref="CommentDTO"/>.
        /// </summary>
        /// <param name="comments">A collection of <see cref="Comment"/> entities.</param>
        /// <param name="camelCase">for returning an object with cameCase style, 
        /// <see langword="false"/> for PascalCase.</param>
        /// <returns>A collection of objects with <see cref="CommentDTO"/> properties.</returns>
        public static object MapFrom(IEnumerable<Comment> comments, bool camelCase = false)
            => camelCase ? comments.Select(comment => MapFromWithCamelCase(comment))
                         : comments.Select(comment => MapFromWithPascalCase(comment));

        private static object MapFromWithPascalCase(Comment comment)
            => new
            {
                Id = comment.Id,
                Content = comment.Content,
                Upvotes = comment.Upvotes,
                UserId = comment.UserId,
                ProductId = comment.ProductId,
            };

        private static object MapFromWithCamelCase(Comment comment)
            => new
            {
                id = comment.Id,
                content = comment.Content,
                upvotes = comment.Upvotes,
                userId = comment.UserId,
                productId = comment.ProductId,
            };
        #endregion
    }
}