namespace GraphQLDeneme.Models
{
    public class Product : Entity
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        Category Category { get; set; }
    }
}