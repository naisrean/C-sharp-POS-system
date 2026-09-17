using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__POS_System.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public List<OrderItem> Items = new List<OrderItem>();
        public decimal Total { get; set; }
        
    }
}
