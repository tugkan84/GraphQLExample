using System.Collections.Generic;

namespace GraphQLDeneme.Models
{
    public class Category : Entity
    {
        public string Description { get; set; }

        public List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}
