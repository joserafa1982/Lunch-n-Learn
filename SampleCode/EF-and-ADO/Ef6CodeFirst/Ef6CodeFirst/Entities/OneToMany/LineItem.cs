using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ef6CodeFirst.Entities.OneToMany
{
    public class LineItem
    {
        public int LineItemId { get; set; }
        public string ItemCode { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ParentOrderId { get; set; }
        public Order Order { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
