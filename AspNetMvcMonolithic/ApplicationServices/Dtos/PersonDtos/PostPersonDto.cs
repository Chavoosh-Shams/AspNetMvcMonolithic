namespace AspNetMvcMonolithic.ApplicationServices.Dtos.PersonDtos
{
    public class PostPersonDto
    {
        public Guid Id { get; private set; }
        public PostPersonDto()
        {
            Id= Guid.NewGuid();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
