using System;
namespace POS.Entities.Customer
{
    public class CustomerEntity
    {
        public int customer_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int created_staff_id { get; set; }
        public int updated_staff_id { get; set; }
        public DateTime created_datetime { get; set; }
        public DateTime updated_datetime { get; set; }
        public short is_deleted { get; set; }

    }
}