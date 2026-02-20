namespace AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos
{
    public class ProductDetail
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string DescriptionRecord { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
