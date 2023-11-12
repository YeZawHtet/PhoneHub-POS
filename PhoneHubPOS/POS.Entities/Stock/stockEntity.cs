using System;
namespace POS.Entities.Stock
{
    public class StockEntity
    {
        public int stock_id { get; set; }
        public int item_id { get; set; }
        public int quantity { get; set; }
        public int created_staff_id { get; set; }
        public int updated_staff_id { get; set; }
        public DateTime created_datetime { get; set; }
        public DateTime updated_datetime { get; set; }
    }
}
