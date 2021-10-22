using GridFSAltDemo.Entities;

namespace Inventory.CreateItem
{
    public static class Data
    {
        internal static async Task<string> CreateNewItem(Product product, IFormFile[] images)
        {
            var img1 = new Picture { FileName = images[0].FileName };
            await img1.SaveAsync();
            await img1.Data.UploadAsync(images[0].OpenReadStream());

            var img2 = new Picture { FileName = images[1].FileName };
            await img2.SaveAsync();
            await img2.Data.UploadAsync(images[1].OpenReadStream());

            var img3 = new Picture { FileName = images[2].FileName };
            await img3.SaveAsync();
            await img3.Data.UploadAsync(images[2].OpenReadStream());

            product.ProductImages.AddRange(new[] { img1, img2, img3 });
            await product.SaveAsync();

            return product.ID;
        }
    }
}