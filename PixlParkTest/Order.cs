namespace PixlParkTest
{
    public class Order
    {
        public int? Id { get; set; }
        public string CustomId { get; set; }
        public int? SourceOrderId { get; set; }
        public string Title { get; set; }
        public string TrackingUrl { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
        public string RenderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public Shipping Shipping { get; set; }
        public int? CommentsCount { get; set; }
        public string DownloadLink { get; set; }
        public string PreviewImageUrl { get; set; }
        public float? Price { get; set; }
        public float? DiscountPrice { get; set; }
        public float? DeliveryPrice { get; set; }
        public float? TotalPrice { get; set; }
        public int UserId { get; set; }
        public int? UserCompanyAccountId { get; set; }
        public int? DiscountId { get; set; }
        public string DiscountTitle { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string DatePaid { get; set; }
    }

    public class DeliveryAddress
    {
        public int? ZipCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

    }

    public class Shipping
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ShippingType { get; set; }
    }
}
