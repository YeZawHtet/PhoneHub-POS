using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Entities.PurchaseDetail
{
    public class PurchaseDetailEntity
    {
        public int purchaseDetailId { get; set; }
        public int purchaseId { get; set; }
        public int itemId { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public PurchaseDetailEntity()
        {
            InitializedObjectValue();
        }

        internal void InitializedObjectValue()
        {
            this.purchaseDetailId = 0;
            this.purchaseId = 0;
            this.itemId = 0;
            this.quantity = 0;
            this.unitPrice = 0;
        }
    }
}
