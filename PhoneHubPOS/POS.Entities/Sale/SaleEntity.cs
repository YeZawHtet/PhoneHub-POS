using System;
namespace POS.Entities.Sale
{
    public class SaleEntity
    {
        public int sale_id { get; set; }
        public string invoice_no { get; set; }
        public int staff_id { get; set; }
        public int customer_id { get; set; }
        public DateTime sale_date { get; set; }
        public decimal total_amount { get; set; }
        public int created_staff_id { get; set; }
        public int updated_staff_id { get; set; }
        public DateTime created_datetime { get; set; }
        public DateTime updated_datetime { get; set; }
        public short is_deleted { get; set; }
    }
}