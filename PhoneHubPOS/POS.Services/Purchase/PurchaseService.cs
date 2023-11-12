using POS.DAO.Purchase;
using POS.Entities.Purchase;
using System;
using System.Data;

namespace POS.Services.Purchase
{
    public class PurchaseService
    {
        private PurchaseDao purchaseDao = new PurchaseDao();


        public DataTable GetWithName()
        {
            DataTable dt = purchaseDao.GetWithName();
            return dt;
        }
        public int GetLastPurchaseId()
        {
            return purchaseDao.GetLastPurchaseId();
        }
        public bool Insert(PurchaseEntity purchaseEntity)
        {
            return purchaseDao.Insert(purchaseEntity);
        }
        public bool Delete(int id)
        {
            return purchaseDao.Delete(id);
        }
        public DataTable GetPurchaseData(DateTime startOfWeek, DateTime endOfWeek)
        {
            DataTable dt = purchaseDao.GetPurchaseData(startOfWeek, endOfWeek);
            return dt;
        }

    }
}
