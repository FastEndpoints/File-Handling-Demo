namespace Inventory.RetrieveItem
{
    public class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("/inventory/retrieve-item/{ProductID}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            await SendAsync(
                await Data.RetrieveItem(r.ProductID, BaseURL));
        }
    }
}