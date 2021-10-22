namespace GridFSAltDemo.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<Picture> ProductImages { get; set; } = new(3);
    }
}
