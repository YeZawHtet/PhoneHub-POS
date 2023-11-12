using POS.DAO.PurchaseDetail;
using POS.Entities.PurchaseDetail;
using System.Data;

namespace POS.Services.PurchaseDetail
{
    public class PurchaseDetailService
    {
    
        private PurchaseDetailDao purchaseDetailDao = new PurchaseDetailDao();

        public DataTable Get(int id)
        {
            DataTable dt = purchaseDetailDao.Get(id);
            return dt;
        }
        public DataTable GetDetail(int id)
        {
            DataTable dt = purchaseDetailDao.GetDetail(id);
            return dt;
        }
        public bool Insert(PurchaseDetailEntity purchaseDetailEntity)
        {
            return purchaseDetailDao.Insert(purchaseDetailEntity);
        }
        public bool Delete(int id)
        {
            return purchaseDetailDao.Delete(id);
        }
    }
}
