namespace Inventory.CreateItem
{
    public class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("/inventory/create-item");
            AllowFileUploads();
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var id = await Data.CreateNewItem(
                product: r.ToEntity(),
                files: new[] { r.Image1, r.Image2, r.Image3 });

            await SendAsync(new()
            {
                ProductID = id,
                Message = "new product created!"
            });
        }
    }
}