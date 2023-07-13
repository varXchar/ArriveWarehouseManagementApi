using System.Text.Json.Serialization;

namespace ArriveWarehouseManagementApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; }

        public bool CanCreate() => !string.IsNullOrEmpty(Name);
    }
}
