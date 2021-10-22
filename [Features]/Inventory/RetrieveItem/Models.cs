using GridFSAltDemo.Entities;
using System.Text.Json.Serialization;

namespace Inventory.RetrieveItem
{
    public class Request
    {
        public string ProductID { get; set; }
    }

    public class Response
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public string ImageUrl1 => $"{BaseUrl}images/retrieve/{Pics[0].ID}.jpg";
        public string? ImageUrl2 => $"{BaseUrl}images/retrieve/{Pics[1].ID}.jpg";
        public string? ImageUrl3 => $"{BaseUrl}images/retrieve/{Pics[2].ID}.jpg";

        [JsonIgnore] public string BaseUrl { get; set; }
        [JsonIgnore] public List<Picture> Pics { get; set; }
    }
}