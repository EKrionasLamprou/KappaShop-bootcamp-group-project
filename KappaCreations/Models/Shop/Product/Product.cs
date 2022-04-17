using System;
using System.Collections.Generic;

namespace KappaCreations.Models
{
    public class Product : IEntity
    {
        /// <summary>
        /// Initiates a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product() 
        {
            Comments = new HashSet<Comment>();
            UsersUpvoted = new HashSet<ApplicationUser>();
            SubmitDate = DateTime.Now;
        }

        public int Id { get; set; }

        /// <summary>
        /// The date and time the design was submited to the database.
        /// </summary>
        public DateTime SubmitDate { get; set; }

        /// <summary>
        /// The <see cref="Design"/> foreign key.
        /// </summary>
        public int DesignId { get; set; }
        /// <summary>
        /// Represents a user-made design, printed on the product.
        /// </summary>
        public Design Design { get; set; }
        /// <summary>
        /// The <see cref="BackDesign"/> foreign key.
        /// </summary>
        public int? BackDesignId { get; set; }
        /// <summary>
        /// Represents a user-made design, printed on the back side of the product. 
        /// <see langword="null"/> by default.
        /// </summary>
        public Design BackDesign { get; set; }

        /// <summary>
        /// The id of the category this product belongs to.
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// The category this product belongs to.
        /// </summary>
        public ProductCategory Category { get; set; }

        /// <summary>
        /// The <see cref="Designer"/> foreign key.
        /// </summary>
        public string DesignerId { get; set; }
        /// <summary>
        /// The user who made the product.
        /// </summary>
        public ApplicationUser Designer { get; set; }

        /// <summary>
        /// The users who upvoted the product.
        /// </summary>
        public ICollection<ApplicationUser> UsersUpvoted { get; set; }

        /// <summary>
        /// The number of users who upvoted the product.
        /// </summary>
        public int Upvotes { get => UsersUpvoted.Count; }

        /// <summary>
        /// Represents the number of reports the product has received from users.
        /// </summary>
        public int Reports { get; set; }

        public ICollection<Comment> Comments { get; set; }

        // To add:
        // Size for clothes
    }
}