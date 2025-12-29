namespace AspNetMvcMonolithic.ApplicationServices.Dtos
{
    public class PutPersonDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
