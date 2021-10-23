using GridFSAltDemo.Entities;

namespace Inventory.CreateItem
{
    public static class Data
    {
        public static async Task<string> CreateNewItem(Product product, IFormFile?[] files)
        {
            foreach (var file in files)
            {
                var pic = new Picture();

                if (file is not null)
                {
                    pic.FileName = file.FileName;
                    await pic.SaveAsync();
                    await pic.Data.UploadAsync(file.OpenReadStream());
                }
                else
                {
                    pic.ID = "product-placeholder-image";
                }

                product.ProductImages.Add(pic);
            }

            await product.SaveAsync();

            return product.ID;
        }
    }
}
