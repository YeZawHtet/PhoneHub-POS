using DAO.Common;
using POS.Entities.SaleDetail;
using System;
using System.Data;
using System.Data.SqlClient;
namespace POS.DAO.SaleDetail
{
    public class SaleDetailDao
    {
        /// <summary>
        /// Defines Database Connection..
        /// </summary>
        private DbConnection connection = new DbConnection();
        /// <summary>
        /// Defines strSql..
        /// </summary>
        private string strSql = String.Empty;
        #region==========SaleDetail========== 
        /// <summary>
        /// Insert SaleDetail
        /// </summary>
        /// <param name="saleDetailEntity"></param>
        /// <returns></returns>
        public bool Insert(SaleDetailEntity saleDetailEntity)
        {
            strSql = "INSERT INTO SaleDetail(sale_id,item_id,quantity,unit_price)" +
                     "VALUES(@SaleID, @ItemID, @Quantity, @UnitPrice)";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@SaleID", saleDetailEntity.sale_id),
                                        new SqlParameter("@ItemID", saleDetailEntity.item_id),
                                        new SqlParameter("@Quantity", saleDetailEntity.quantity),
                                        new SqlParameter("@UnitPrice", saleDetailEntity.unit_price)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }
        /// <summary>
        /// Getting SaleDetail According to LastSaleID
        /// </summary>
        /// <param name="saleID"></param>
        /// <returns></returns>
        public DataTable GetSaleDetailsBySaleId(int lastSaleID)
        {
            strSql = "SELECT ROW_NUMBER() OVER(ORDER BY Sale.sale_id) AS RowNum, Sale.sale_id, Sale.staff_id, Sale.sale_date, Sale.invoice_no, Sale.total_amount," +
                " SaleDetail.quantity, SaleDetail.unit_price, SaleDetail.quantity * SaleDetail.unit_price As SubTotal," +
                "Customer.name AS CustomerName, Item.name AS ItemName, " +
                "Staff.staffname, Staff.staff_role " +
                "FROM Sale " +
                "INNER JOIN SaleDetail ON Sale.sale_id = SaleDetail.sale_id " +
                "INNER JOIN Customer ON Sale.customer_id = Customer.customer_id " +
                "INNER JOIN Item ON SaleDetail.item_id = Item.item_id " +
                "INNER JOIN Staff ON Sale.staff_id = Staff.staff_id " +
                "WHERE Sale.sale_id = " + lastSaleID;
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
        /// <summary>
        /// Retrieve All Sale Data
        /// </summary>
        /// <returns></returns>
        public DataTable GetWithName()
        {
            strSql = "SELECT ROW_NUMBER() OVER(ORDER BY Sale.sale_id desc) AS RowNum, "
                 + "Sale.sale_id, Sale.staff_id, Sale.invoice_no, Staff.staffname, Customer.name AS CustomerName, " +
                " Item.name AS ItemName, SaleDetail.quantity, SaleDetail.unit_price, FORMAT(SaleDetail.unit_price, '0') As formatted_unit_price, FORMAT(SaleDetail.quantity * SaleDetail.unit_price, '0') As formatted_SubTotal, (SaleDetail.quantity * SaleDetail.unit_price) AS SubTotal, " +
                " FORMAT(Sale.total_amount, '0') As formatted_total_amount,  Sale.total_amount,  Sale.sale_date, " +
                " Staff.staff_role " +
                "FROM Sale " +
                "INNER JOIN SaleDetail ON Sale.sale_id = SaleDetail.sale_id " +
                "INNER JOIN Customer ON Sale.customer_id = Customer.customer_id " +
                "INNER JOIN Item ON SaleDetail.item_id = Item.item_id " +
                "INNER JOIN Staff ON Sale.staff_id = Staff.staff_id " +
                "Where Sale.is_deleted=0 Order By sale_id DESC";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
        #endregion
    }
}