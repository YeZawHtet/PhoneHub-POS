using DAO.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entities.PurchaseDetail;

namespace POS.DAO.PurchaseDetail
{
    public class PurchaseDetailDao
    {
        private DbConnection connection = new DbConnection();
   
        private string strSql = String.Empty;
     

        // Retrieve purchase details by purchase ID
        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM PurchaseDetail " +
                      "WHERE  purchase_id= " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // Insert a new purchase detail
        public bool Insert(PurchaseDetailEntity purchaseDetailEntity)
        {

            strSql = "INSERT INTO PurchaseDetail (purchase_id ,item_id,quantity,unit_price)" +
                     "VALUES(@PurchaseID, @ItemID, @Quantity, @UnitPrice)";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@PurchaseID", purchaseDetailEntity.purchaseId),
                                        new SqlParameter("@ItemID", purchaseDetailEntity.itemId),
                                        new SqlParameter("@Quantity", purchaseDetailEntity.quantity),
                                        new SqlParameter("@UnitPrice", purchaseDetailEntity.unitPrice)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        // Retrieve purchase details with row numbers for a specific purchase
        public DataTable GetDetail(int id)
        {
            strSql = "SELECT ROW_NUMBER() OVER (ORDER BY PD.item_id) AS RowNum, " +
                "PD.purchase_id, " +
                "I.name AS item_name, " +
                "PD.quantity, " +
                "PD.unit_price " +
                "FROM PurchaseDetail AS PD " +
                "INNER JOIN Item AS I ON PD.item_id = I.item_id " +
                "WHERE PD.purchase_id = " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // Delete a purchase detail
        public bool Delete(int id)
        {

            strSql = "Delete From PurchaseDetail WHERE purchase_detail_id= @Purchase_detail_id";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@Purchase_detail_id", id),
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }
    }
}
