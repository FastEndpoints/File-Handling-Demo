using GridFSAltDemo.Entities;

namespace Inventory.RetrieveItem
{
    public static class Data
    {
        internal static Task<Response> RetrieveItem(string productID, string baseUrl)
        {
            return DB.Find<Product, Response>()
                .MatchID(productID)
                .Project(p => new()
                {
                    ProductID = p.ID,
                    ProductName = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Pics = p.ProductImages,
                    BaseUrl = baseUrl
                })
                .ExecuteSingleAsync();
        }
    }
}