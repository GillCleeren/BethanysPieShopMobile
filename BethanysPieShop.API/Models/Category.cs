using System.Collections.Generic;
using Newtonsoft.Json;

namespace BethanysPieShop.API.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<Pie> Pies { get; set; }
    }
}
