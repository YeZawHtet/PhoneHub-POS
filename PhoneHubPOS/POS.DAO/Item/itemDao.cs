using DAO.Common;
using POS.Entities.Item;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS.DAO.Item
{
    public class ItemDao
    {
        private DbConnection connection = new DbConnection();

        private string strSql = String.Empty;

        private DataTable resultDataTable = new DataTable();

        private int existCount;

        // Retrieve all items that are not deleted, ordered by name
        public DataTable GetAll()
        {
            strSql = "SELECT * FROM Item Where is_deleted=0 Order by name";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // Retrieve an item by its ID
        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM Item " +
                      "WHERE  item_id= " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // Get the last item's ID
        public int GetLastItem()
        {
            strSql = "SELECT IDENT_CURRENT('Item')";
            SqlParameter[] sqlParam = { new SqlParameter() };
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, sqlParam));
        }

        // Get an item's ID by its name
        public int GetIdByName(string name)
        {
            strSql = "SELECT item_id FROM Item WHERE name = @itemName";
            SqlParameter[] sqlParam = { new SqlParameter("@itemName", name) };
            object result = connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                return -1;
            }
        }

        // Get an item's name by its ID
        public string GetNameById(int ID)
        {
            strSql = "SELECT name FROM Item WHERE item_id = @itemID";
            SqlParameter[] sqlParam = { new SqlParameter("@itemID", ID) };
            object result = connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToString(result);
            }
            else
            {
                return string.Empty;
            }
        }

        // Retrieve items with row numbers, including category name (not deleted)
        public DataTable GetWithName()
        {
            strSql = "SELECT ROW_NUMBER() OVER(ORDER BY i.item_id) AS RowNum, "
                      + "i.item_id, i.name, i.description , i.price, s.quantity, c.name AS category_name "
                      + " FROM Item AS i "
                      + " JOIN Category AS c ON i.category_id = c.category_id "
                      + " LEFT JOIN Stock AS s ON i.item_id = s.item_id " 
                      + " WHERE i.is_deleted = " + 0;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // Generate an item report with various details (not deleted)
        public DataTable GetItemReport()
        {
            strSql = "SELECT " +
                    "ROW_NUMBER() OVER (ORDER BY ISNULL(SD.total_sell_quantity, 0) DESC) AS RowNum, " +
                    "I.name AS item_name, " +
                    "I.price AS price, " +
                    "S.quantity AS quantity, " +
                    "ISNULL(SD.total_sell_quantity, 0) AS sell, " +
                    "ISNULL(SD.total_sell_quantity, 0) * I.price AS earning " +
                    "FROM Item I " +
                    "INNER JOIN Stock S ON I.item_id = S.item_id " +
                    "LEFT JOIN (SELECT SD.item_id, SUM(SD.quantity) AS total_sell_quantity " +
                    "FROM SaleDetail SD " +
                    "INNER JOIN Sale SA ON SD.sale_id = SA.sale_id " +
                    "WHERE SA.is_deleted = 0 " +
                    "GROUP BY SD.item_id) SD " +
                    "ON I.item_id = SD.item_id " +
                    "WHERE I.is_deleted = 0 "+
                    "ORDER BY sell DESC"; ;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // Get the count of items with a specific name and category ID
        public int GetItemCount(string name, int category_id)
        {
            strSql = "SELECT count(*) FROM Item " +
                      "WHERE  name=@Name AND category_id = @Category_id";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@Name", name),
                                        new SqlParameter("@Category_id", category_id)
                                      };
            existCount = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return existCount;
        }

        // Insert a new item
        public bool Insert(ItemEntity itemEntity)
        {
            strSql = "INSERT INTO Item (name, description, price, category_id, created_staff_id, created_datetime, updated_staff_id, updated_datetime) " +
                     "VALUES (@name, @description, @price, @category_id, @created_staff_id, @created_datetime, @updated_staff_id, @updated_datetime)";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@name", itemEntity.name),
                                        new SqlParameter("@description", itemEntity.description),
                                        new SqlParameter("@price", itemEntity.price),
                                        new SqlParameter("@category_id", itemEntity.categoryId),
                                        new SqlParameter("@created_staff_id", itemEntity.createdStaffId),
                                        new SqlParameter("@created_datetime", itemEntity.createdDatetime),
                                        new SqlParameter("@updated_staff_id", itemEntity.updatedStaffId),
                                        new SqlParameter("@updated_datetime", itemEntity.updatedDatetime),

                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        // Update an existing item
        public bool Update(ItemEntity itemEntity)
        {
            strSql = "UPDATE Item SET name = @name, description = @description, price = @price, category_id = @category_id, updated_staff_id = @updated_staff_id, updated_datetime = @updated_datetime WHERE item_id = @item_id";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@item_id", itemEntity.itemId),
                                        new SqlParameter("@name", itemEntity.name),
                                        new SqlParameter("@description", itemEntity.description),
                                        new SqlParameter("@price", itemEntity.price),
                                        new SqlParameter("@category_id", itemEntity.categoryId),
                                        new SqlParameter("@updated_staff_id", itemEntity.updatedStaffId),
                                        new SqlParameter("@updated_datetime", itemEntity.updatedDatetime),

                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        // Delete an item (mark as deleted)
        public bool Delete(int id)
        {
            strSql = "UPDATE Item SET is_deleted =@is_deleted  WHERE item_id =@item_id";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@item_id", id),
                                         new SqlParameter("@is_deleted",1),
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
    }
}
