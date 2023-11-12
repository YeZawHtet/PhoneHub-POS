using DAO.Common;
using POS.Entities.Purchase;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS.DAO.Purchase
{
    public class PurchaseDao
    {
        private DbConnection connection = new DbConnection();

        private string strSql = String.Empty;


        // Retrieve purchases with row numbers, including staff and supplier names (not deleted)
        public DataTable GetWithName()
        {
            strSql = "SELECT ROW_NUMBER() OVER(ORDER BY P.purchase_date DESC) AS RowNum, "
                  + " P.purchase_id,P.invoice_no, S.staffname AS staff_name, SP.name AS supplier_name, P.purchase_date, P.total_amount "
                  + " FROM Purchase AS P INNER JOIN Staff AS S ON P.staff_id = S.staff_id "
                  + " INNER JOIN Supplier AS SP ON P.supplier_id = SP.supplier_id "
                  + " WHERE P.is_deleted = " + 0;
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // Get the last purchase ID
        public int GetLastPurchaseId()
        {
            string selectLastIDQuery = "SELECT IDENT_CURRENT('Purchase')";
            SqlParameter[] sqlParam = { new SqlParameter() };
            object result = connection.ExecuteScalar(CommandType.Text, selectLastIDQuery, sqlParam);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                return 0;
            }
        }

        // Insert a new purchase with an automatically generated invoice number
        public bool Insert(PurchaseEntity purchaseEntity)
        {

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            int purchaseId = GetLastPurchaseId();
            string invoiceNumber = $"{currentYear}/P{currentMonth}000{purchaseId}";

            strSql = "INSERT INTO Purchase (invoice_no, staff_id, supplier_id, purchase_date, total_amount, created_staff_id, created_datetime, updated_staff_id, updated_datetime) " +
                     "VALUES (@InvoiceNo, @staff_id, @supplier_id, @purchase_date, @total_amount, @created_staff_id, @created_datetime, @updated_staff_id, @updated_datetime)";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@InvoiceNo", invoiceNumber),
                                        new SqlParameter("@staff_id", purchaseEntity.staffId),
                                        new SqlParameter("@supplier_id", purchaseEntity.supplierId),
                                        new SqlParameter("@purchase_date", purchaseEntity.purchaseDate),
                                        new SqlParameter("@total_amount", purchaseEntity.totalAmount),
                                        new SqlParameter("@created_staff_id", purchaseEntity.createdStaffId),
                                        new SqlParameter("@created_datetime", purchaseEntity.createdDatetime),
                                        new SqlParameter("@updated_staff_id", purchaseEntity.updatedStaffId),
                                        new SqlParameter("@updated_datetime", purchaseEntity.updatedDatetime),

                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        // Delete a purchase (mark as deleted)
        public bool Delete(int id)
        {
            strSql = "UPDATE Purchase SET is_deleted =@is_deleted  WHERE purchase_id =@purchase_id";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@purchase_id", id),
                                         new SqlParameter("@is_deleted",1),
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }

        // Retrieve purchase data for a specific date range
        public DataTable GetPurchaseData(DateTime startOfWeek, DateTime endOfWeek)
        {
            strSql = "SELECT DATEPART(WEEKDAY, purchase_date) AS DayOfWeek, SUM(total_amount) AS TotalAmount " +
                     "FROM Purchase " +
                     "WHERE purchase_date BETWEEN @StartWeek AND @EndWeek " +
                     "AND is_deleted = 0 " + 
                     "GROUP BY DATEPART(WEEKDAY, purchase_date) " +
                     "ORDER BY DayOfWeek";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@StartWeek", startOfWeek),
                                         new SqlParameter("@EndWeek",endOfWeek),
                                      };
            DataTable purchaseData = connection.ExecuteDataTable(CommandType.Text, strSql, sqlParam);

            if (purchaseData != null)
            {
                return purchaseData;
            }
            else
            {
                return new DataTable();
            }
        }
    }
}
