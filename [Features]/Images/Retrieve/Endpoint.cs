namespace Images.Retrieve
{
    public class Endpoint : Endpoint<Request>
    {
        public override void Configure()
        {
            Get("/images/retrieve/{ImageID}.jpg");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken ct)
        {
            try
            {
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