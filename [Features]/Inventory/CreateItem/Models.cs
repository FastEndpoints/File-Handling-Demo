using GridFSAltDemo.Entities;

namespace Inventory.CreateItem
{
    public class Request
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public IFormFile Image1 { get; set; }
        public IFormFile? Image2 { get; set; }
        public IFormFile? Image3 { get; set; }

        public Product ToEntity() => new()
        {
            Name = ProductName,
            Price = Price,
            Description = Description ?? string.Empty
        };
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("please enter a product name!");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("product price is required!")
                .GreaterThan(0).WithMessage("product price is invalid!");

            RuleFor(x => x.Image1).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("product image is required!")
                .Must(x => IsAllowedSize(x.Length)).WithMessage("too small!")
                .Must(x => IsAllowedType(x.ContentType)).WithMessage("file type is invalid!");

            When(x => x.Image2 != null, () =>
            {
                RuleFor(x => x.Image2).Must(x => IsAllowedSize(x.Length)).WithMessage("too small!");
                RuleFor(x => x.Image2).Must(x => IsAllowedType(x.ContentType)).WithMessage("file type is invalid!");
            });

            When(x => x.Image3 != null, () =>
            {
                RuleFor(x => x.Image3).Must(x => IsAllowedSize(x.Length)).WithMessage("too small!");
                RuleFor(x => x.Image3).Must(x => IsAllowedType(x.ContentType)).WithMessage("file type is invalid!");
            });
        }

        public bool IsAllowedType(string contentType)
            => (new[] { "image/jpeg", "image/png" }).Contains(contentType.ToLower());

        public bool IsAllowedSize(long fileLength)
            => fileLength >= 100 && fileLength <= 10485760;
    }

    public class Response
    {
        public string ProductID { get; set; }
        public string Message { get; set; }
    }
}