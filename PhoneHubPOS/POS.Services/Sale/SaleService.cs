using POS.DAO.Sale;
using POS.Entities.Sale;
using System;
using System.Data;
namespace POS.Services.Sale
{
    public class SaleService
    {
        /// <summary>
        /// Define Sale Dao..
        /// </summary>
        private SaleDao saleDao = new SaleDao();
        #region==========Sale========== 
        /// <summary>
        /// insert sale
        /// </summary>
        /// <param name="saleEntity"></param>
        /// <returns></returns>
        public bool Insert(SaleEntity saleEntity)
        {
            return saleDao.Insert(saleEntity);
        }
        /// <summary>
        /// Get sale by last sale_id
        /// </summary>
        /// <returns></returns>
        public int GetLastInsertID()
        {
            return saleDao.GetLastInsertID();
        }
        /// <summary>
        /// Return Payment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ReturnPayment(int id)
        {
            return saleDao.ReturnPayment(id);
        }
        //ppk
        public DataTable GetSalesData(DateTime startOfWeek, DateTime endOfWeek)
        {
            DataTable dt = saleDao.GetSalesData(startOfWeek, endOfWeek);
            return dt;
        }
        public decimal GetTotalSalesForToday()
        {
            decimal totalSales = saleDao.GetTotalSalesForToday();
            return totalSales;
        }
        public string BestSellingForlastWeek()
        {
            string bestSellingItem = saleDao.BestSellingForlastWeek();
            return bestSellingItem;
        }
        #endregion
    }
}