namespace GraphQLDeneme.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    public class Entity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
