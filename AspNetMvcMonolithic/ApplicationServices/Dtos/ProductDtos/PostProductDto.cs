namespace AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos
{
    public class PostProductDto
    {
        public Guid Id { get; private set; }
        public PostProductDto()
        {
            Id= Guid.NewGuid();
        }
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public string ProductDescription { get; set; }

    }
}
