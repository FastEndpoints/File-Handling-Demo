using GridFSAltDemo.Entities;

namespace Inventory.CreateItem
{
    public static class Data
    {
        internal static async Task<string> CreateNewItem(Product product, IFormFile[] files)
        {
            var pictures = new List<Picture>(3);

            foreach (var file in files)
            {
                var pic = new Picture() { FileName = file.FileName };
                await pic.SaveAsync();
                await pic.Data.UploadAsync(file.OpenReadStream());
                pictures.Add(pic);
            }

            product.ProductImages = pictures;
            await product.SaveAsync();

            return product.ID;
        }
    }
}
