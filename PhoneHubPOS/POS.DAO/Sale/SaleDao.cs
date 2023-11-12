using DAO.Common;
using POS.Entities.Sale;
using System;
using System.Data;
using System.Data.SqlClient;
namespace POS.DAO.Sale
{
    public class SaleDao
    {
        /// <summary>
        /// Defines Database Connection..
        /// </summary>
        private DbConnection connection = new DbConnection();
        /// <summary>
        /// Defines strSql..
        /// </summary>
        private string strSql = String.Empty;
        #region==========Sale========== 
        /// <summary>
        /// Sale Data Insert
        /// </summary>
        /// <param name="saleEntity"></param>
        /// <returns></returns>
        public bool Insert(SaleEntity saleEntity)
        {
            // Get the current year
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            // Get the sale ID from the SaleEntity
            int saleId = GetLastInsertID();
            // Create the invoice number using the formula
            string invoiceNumber = $"{currentYear}/S{currentMonth}000{saleId}";
            strSql = "INSERT INTO Sale(invoice_no, staff_id, customer_id, sale_date, total_amount, created_staff_id, updated_staff_id, created_datetime, updated_datetime) " +
                     "VALUES(@InvoiceNo, @StaffID, @CustomerID, @SaleDate, @TotalAmount, @CreatedStaffID, @UpdatedStaffID, @CreatedDateTime, @UpdatedDateTime)";

            SqlParameter[] sqlParam = {
        new SqlParameter("@InvoiceNo", invoiceNumber), // Use the generated invoice number
        new SqlParameter("@StaffID", saleEntity.staff_id),
        new SqlParameter("@CustomerID", saleEntity.customer_id),
        new SqlParameter("@SaleDate", saleEntity.sale_date),
        new SqlParameter("@TotalAmount", saleEntity.total_amount),
        new SqlParameter("@CreatedStaffID", saleEntity.created_staff_id),
        new SqlParameter("@UpdatedStaffID", saleEntity.updated_staff_id),
        new SqlParameter("@CreatedDateTime", saleEntity.created_datetime),
        new SqlParameter("@UpdatedDateTime", saleEntity.updated_datetime)
    };

            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
        /// <summary>
        /// Retrieve Last Sale ID
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int GetLastInsertID()
        {
            string selectLastIDQuery = "SELECT IDENT_CURRENT('Sale')";
            SqlParameter[] sqlParam = { new SqlParameter() };
            object result = connection.ExecuteScalar(CommandType.Text, selectLastIDQuery, sqlParam);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                // Handle the case where the last insert ID is not found.
                throw new Exception("Failed to get the last inserted ID.");
            }
        }
        /// <summary>
        /// Return Payment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ReturnPayment(int id)
        {
            strSql = "UPDATE Sale SET is_deleted =@is_deleted  WHERE sale_id =@sale_id";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@sale_id", id),
                                         new SqlParameter("@is_deleted",1),
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
        //PPK
        public DataTable GetSalesData(DateTime startOfWeek, DateTime endOfWeek)
        {
            strSql = "SELECT DATEPART(WEEKDAY, sale_date) AS DayOfWeek, SUM(total_amount) AS TotalAmount " +
                    "FROM Sale " +
                    "WHERE sale_date BETWEEN @StartOfWeek AND @EndOfWeek " +
                    "AND is_deleted = 0 " +
                    "GROUP BY DATEPART(WEEKDAY, sale_date) " +
                    "ORDER BY DayOfWeek";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@StartOfWeek", startOfWeek),
                                         new SqlParameter("@EndOfWeek",endOfWeek),
                                      };
            DataTable saleData = connection.ExecuteDataTable(CommandType.Text, strSql, sqlParam);

            if (saleData != null)
            {
                return saleData;
            }
            else
            {
                return new DataTable();
            }
        }
        public decimal GetTotalSalesForToday()
        {
            DateTime today = DateTime.Today;
            strSql = "SELECT SUM(total_amount) AS TotalAmount " +
                     "FROM Sale WHERE is_deleted = 0 AND sale_date >= @StartDate " +
                      "AND sale_date < @EndDate";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@StartDate", today),
                                         new SqlParameter("@EndDate",today.AddDays(1)),
                                      };
            object saleToday = connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);
            if (saleToday != DBNull.Value)
            {
                return Convert.ToDecimal(saleToday);
            }
            else
            {
                return 0;
            }
        }
        public string BestSellingForlastWeek()
        {
            DateTime today = DateTime.Now;
            DateTime lastWeek = today.AddDays(-7);

            strSql = "SELECT TOP 1 i.name AS BestSellingItem " +
                     "FROM SaleDetail sd INNER JOIN Item i ON sd.item_id = i.item_id " +
                     "WHERE sd.sale_id IN (SELECT sale_id FROM Sale WHERE sale_date >= @StartDate " +
                     "AND sale_date < @EndDate AND is_deleted = 0) " +
                     "GROUP BY i.name ORDER BY SUM(sd.quantity) DESC";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@StartDate", lastWeek),
                                         new SqlParameter("@EndDate",today),
                                      };
            object bestSale = connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);
            if (bestSale != DBNull.Value)
            {
                return Convert.ToString(bestSale);
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }
}