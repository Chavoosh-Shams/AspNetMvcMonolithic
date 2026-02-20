namespace AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos
{
    public class PostProductDto
    {
        public Guid Id { get; private set; }
        public PostProductDto()
        {
            Id = Guid.NewGuid();
        }

        public string Title { get; set; }

        public string DescriptionRecord { get; set; }

        public decimal UnitPrice { get; set; }

    }
}
