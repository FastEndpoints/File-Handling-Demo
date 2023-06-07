namespace Inventory.RetrieveItem
{
    public class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("/inventory/retrieve-item/{@pid}", r => new { r.ProductID });
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var item = await Data.RetrieveItem(r.ProductID, BaseURL);

            if (item is null)
                await SendNotFoundAsync();
            else
                await SendAsync(item);
        }
    }
}