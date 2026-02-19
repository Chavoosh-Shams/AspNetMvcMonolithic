namespace AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos
{
    public class DeleteProductDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductDescription { get; set; }
    }
}
