namespace POS.Entities.SaleDetail
{
    public class SaleDetailEntity
    {
        public int sale_detail_id { get; set; }
        public int sale_id { get; set; }
        public int item_id { get; set; }
        public int quantity { get; set; }
        public decimal unit_price { get; set; }
    }
}