namespace Images.Retrieve
{
    public class Endpoint : Endpoint<Request>
    {
        public override void Configure()
        {
            Get("/images/retrieve/{@img}.jpg", r => new { r.ImageID });
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken ct)
        {
            try
            {
                HttpContext.MarkResponseStart();
                HttpContext.Response.StatusCode = 200;
                HttpContext.Response.ContentType = "image/jpeg";
                await Data.ReadImageFromStorage(r.ImageID, HttpContext.Response.Body, ct);
            }
            catch (Exception)
            {
                await SendNotFoundAsync();
            }
        }
    }
}