namespace WebApiAutores.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Autor Author { get; set; }
    }
}
