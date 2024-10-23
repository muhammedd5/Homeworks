namespace BlogApp.Models
{
    public class Blog
    {
        public Blog(int ıd, string title, string description, string author, string ımage)
        {
            Id = ıd;
            Title = title;
            Description = description;
            Author = author;
            Image = ımage;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
    }
}
