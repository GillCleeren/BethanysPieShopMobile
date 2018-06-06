using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShop.Mobile.Core.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Pie> Pies { get; set; }
    }
}
