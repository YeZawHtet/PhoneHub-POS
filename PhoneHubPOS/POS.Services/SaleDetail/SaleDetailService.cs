using POS.DAO.SaleDetail;
using POS.Entities.SaleDetail;
using System.Collections.Generic;
using System.Data;
namespace POS.Services.SaleDetail
{
    public class SaleDetailService
    {
        /// <summary>
        /// Define SaleDetail Dao..
        /// </summary>
        private SaleDetailDao saleDetailDao = new SaleDetailDao();
        #region==========SaleDetail========== 
        /// <summary>
        /// Insert Sale Data
        /// </summary>
        /// <param name="saleDetailEntities"></param>
        /// <returns></returns>
        public bool Insert(List<SaleDetailEntity> saleDetailEntities)
        {
            bool success = true;

            foreach (SaleDetailEntity saledetailEntity in saleDetailEntities)
            {
                if (!saleDetailDao.Insert(saledetailEntity))
                {
                    success = false;
                    break;
                }
            }
            return success;
        }
        /// <summary>
        /// Retrieve Sale Data By LastSaleId
        /// </summary>
        /// <param name="lastSaleID"></param>
        /// <returns></returns>
        public DataTable GetSaleDetailsBySaleId(int lastSaleID)
        {
            DataTable dt = saleDetailDao.GetSaleDetailsBySaleId(lastSaleID);
            return dt;
        }
        /// <summary>
        /// Retrieve All Sale Data
        /// </summary>
        /// <returns></returns>
        public DataTable GetWithName()
        {
            DataTable dt = saleDetailDao.GetWithName();
            return dt;
        }
        #endregion
    }
}