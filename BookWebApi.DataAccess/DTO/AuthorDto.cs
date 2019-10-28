namespace BookWebApi.DataAccess.DTO
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BookId { get; set; }
    }
}