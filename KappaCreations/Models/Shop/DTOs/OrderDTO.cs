namespace KappaCreations.Models.Shop.DTOs
{
    public class OrderDTO : IDataTransferObject<Order>
    {
        public int? Id { get; set; }
        public string UserId { get; set; }
        public int BillingAddressId { get; set; }
        public string SubmitDate { get; set; }

        public bool HasId => Id.HasValue && Id > 0;

        public Order Map()
        {
            throw new System.NotImplementedException();
        }
    }
}