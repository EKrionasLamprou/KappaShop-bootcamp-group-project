namespace KappaCreations.Models
{
    public class Comment : IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// The text content of the comment.
        /// </summary>
        public string Content { get; set; }

        int upvotes = 0;
        /// <summary>
        /// The number of upvotes the comment has received.
        /// Returns 0 if assigned to negative values.
        /// </summary>
        public int Upvotes {
            get => upvotes;
            set
            {
                upvotes = value;
                if (upvotes < 0)
                    upvotes = 0;
            }
        }

        /// <summary>
        /// The foreign key of the user who made the comment.
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// The user who made the comment..
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Product foreign key.
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// The product that is commented on.
        /// </summary>
        public Product Product { get; set; }
    }
}