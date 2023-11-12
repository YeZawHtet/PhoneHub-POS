using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Entities.Supplier
{
    public class SupplierEntity
    {

        public int supplierId { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string address { get; set; }

        public int createdStaffId { get; set; }

        public int updatedStaffId { get; set; }

        public DateTime createdDatetime { get; set; }

        public DateTime updatedDatetime { get; set; }
        public int isDeleted { get; set; }
        public SupplierEntity()
        {
            InitializedObjectValue();
        }

        internal void InitializedObjectValue()
        {
            this.supplierId = 0;
            this.name = String.Empty;
            this.email = String.Empty;
            this.phone = String.Empty;
            this.address = String.Empty;
            this.createdStaffId = 0;
            this.createdDatetime = DateTime.MinValue;
            this.updatedStaffId = 0;
            this.updatedDatetime = DateTime.MinValue;
            this.isDeleted = 0;
        }
    }
}
