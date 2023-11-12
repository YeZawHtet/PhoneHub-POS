using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Entities.Purchase
{
    public class PurchaseEntity
    {

        public int purchaseId { get; set; }

        public int staffId { get; set; }

        public int supplierId { get; set; }
        public DateTime purchaseDate { get; set; }

        public decimal totalAmount { get; set; }

        public int createdStaffId { get; set; }

        public int updatedStaffId { get; set; }

        public DateTime createdDatetime { get; set; }

        public DateTime updatedDatetime { get; set; }
        public int isDeleted { get; set; }
        public PurchaseEntity()
        {
            InitializedObjectValue();
        }

        internal void InitializedObjectValue()
        {
            this.purchaseId = 0;
            this.staffId = 0;
            this.supplierId = 0;
            this.purchaseDate = DateTime.MinValue;
            this.totalAmount = 0;
            this.createdStaffId = 0;
            this.createdDatetime = DateTime.MinValue;
            this.updatedStaffId = 0;
            this.updatedDatetime = DateTime.MinValue;
            this.isDeleted = 0;
        }
    }
}
