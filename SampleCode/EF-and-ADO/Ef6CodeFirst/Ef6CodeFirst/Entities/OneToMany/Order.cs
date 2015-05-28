using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ef6CodeFirst.Entities.OneToMany
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ClientCode { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<LineItem> LineItems { get; set; }
    }
}
