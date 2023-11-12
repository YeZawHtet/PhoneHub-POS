using POS.DAO.Stock;
using POS.Entities.Stock;
namespace POS.Services.Stock
{
    public class StockService
    {
        /// <summary>
        /// Define Stock Dao..
        /// </summary>
        private stockDao stockDao = new stockDao();
        #region==========Stock========== 
        /// <summary>
        /// Getting Item's Quantity from stock
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetQuentity(int id)
        {
            return stockDao.GetQuantity(id);
        }
        /// <summary>
        /// Insert Stock
        /// </summary>
        /// <param name="stockEntity"></param>
        /// <returns></returns>
        public bool Insert(StockEntity stockEntity)
        {
            return stockDao.Insert(stockEntity);
        }
        public bool Delete(int itemID)
        {
            return stockDao.Delete(itemID);
        }
        /// <summary>
        /// Reduce Quantity after sale
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool ReduceQuantityBaseOnSale(int itemID, int quantity)
        {
            return stockDao.ReduceQuantityBaseOnSale(itemID, quantity);
        }
        /// <summary>
        /// add quantity after return payment
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool AddQuantityBaseOnSale(int itemID, int quantity)
        {
            return stockDao.AddQuantityBaseOnSale(itemID, quantity);
        }
        //PPK
        public bool IsStockAvailable(int itemID, int quantity)
        {
            return stockDao.IsStockAvailable(itemID, quantity);
        }
        #endregion
    }
}