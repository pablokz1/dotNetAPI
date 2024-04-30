namespace dotNetAPI.Models
{
    public class Pessoas
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Pessoas(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
