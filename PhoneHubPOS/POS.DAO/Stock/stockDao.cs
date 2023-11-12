using DAO.Common;
using POS.Entities.Stock;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS.DAO.Stock
{
    public class stockDao
    {
        /// <summary>
        /// Defines Database Connection..
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines strSql..
        /// </summary>
        private string strSql = String.Empty;

        /// <summary>
        /// Defines the resultDataTable.
        /// </summary>
        private DataTable resultDataTable = new DataTable();

        /// <summary>
        /// Defines the existCount.
        /// </summary>
        private int existCount;

        #region==========stock========== 
        /// <summary>
        /// Retrieve item's quantity from stock
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetQuantity(int id)
        {
            strSql = "SELECT quantity FROM Stock " +
                      "WHERE  item_id= " + @id;
            SqlParameter[] sqlParam = { new SqlParameter("@id", id) };
            object result = connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Insert Stock
        /// </summary>
        /// <param name="stockEntity"></param>
        /// <returns></returns>
        public bool Insert(StockEntity stockEntity)
        {

            strSql = "INSERT INTO Stock (item_id,quantity, created_staff_id , updated_staff_id, created_datetime, updated_datetime) " +
                    "VALUES (@item_id , @quantity, @created_staff_id ,@updated_staff_id ,@created_datetime ,@updated_datetime)";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@item_id", stockEntity.item_id),
                                        new SqlParameter("@quantity", stockEntity.quantity),
                                        new SqlParameter("@created_staff_id", stockEntity.created_staff_id),
                                        new SqlParameter("@updated_staff_id", stockEntity.updated_staff_id),
                                        new SqlParameter("@created_datetime", stockEntity.created_datetime),
                                        new SqlParameter("@updated_datetime", stockEntity.updated_datetime)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }
        /// <summary>
        /// reduce quantity after sale
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool ReduceQuantityBaseOnSale(int itemID, int quantity)
        {

            strSql = "UPDATE Stock SET quantity=(quantity-@SaleQuantity) WHERE item_id = @ItemID";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@ItemID", itemID),
                                        new SqlParameter("@SaleQuantity", quantity)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }
        /// <summary>
        /// add quantity after return payment
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool AddQuantityBaseOnSale(int itemID, int quantity)
        {

            strSql = "UPDATE Stock SET quantity=(quantity + @SaleQuantity) WHERE item_id = @ItemID";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@ItemID", itemID),
                                        new SqlParameter("@SaleQuantity", quantity)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }
        /// <summary>
        /// Delete Item from stock
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            strSql = "Delete From Stock WHERE item_id =@item_id";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@item_id", id),
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }


        //PPK
        public bool IsStockAvailable(int itemID, int quantity)
        {
            strSql = "SELECT quantity FROM Stock WHERE item_id = @itemId";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@itemId", itemID)
                                      };
            int availableQuantity = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);
            if (availableQuantity >= quantity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    #endregion
}

