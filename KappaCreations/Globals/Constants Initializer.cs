using KappaCreations.Models;

namespace KappaCreations
{
    public static partial class Constants
    {
        /// <summary>
        /// Initializes the constant fields.
        /// </summary>
        static Constants()
        {
            #region Initialize PRODUCT_CATEGORIES
            PRODUCT_CATEGORIES = new ProductCategory[]
            {
                new ProductCategory("Ashtrays", 8),
                new ProductCategory("Bags", 10),
                new ProductCategory("Bed Sheets", 30),
                new ProductCategory("Canvas", 20),
                new ProductCategory("Door Mats", 10),
                new ProductCategory("Hoodies", 30),
                new ProductCategory("Magnets", 5),
                new ProductCategory("Mousepads", 7),
                new ProductCategory("Mugs", 7),
                new ProductCategory("Phone Cases", 20),
                new ProductCategory("Pillows", 20),
                new ProductCategory("Plates", 10),
                new ProductCategory("T-Shirts", 15),
                new ProductCategory("Thermos Bottles", 10),
                new ProductCategory("Tissues", 3),
            };
            #endregion
        }
    }
}