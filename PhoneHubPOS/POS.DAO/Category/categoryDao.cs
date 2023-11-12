using System;
using System.Data.SqlClient;
using System.Data;
using DAO.Common;
using POS.Entities.Category;

namespace POS.DAO.Category
{
    public class CategoryDao
    {
        private DbConnection connection = new DbConnection();


        private string strSql = String.Empty;


        private DataTable resultDataTable = new DataTable();


        private int existCount;

        // Retrieve all categories
        public DataTable GetAll()
        {
            strSql = "SELECT * FROM Category ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // Retrieve non-deleted categories
        public DataTable GetData()
        {
            strSql = "SELECT * FROM Category WHERE is_deleted =" + 0;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // Get the count of categories with a specific name (not deleted)
        public int GetItemCount(string name)
        {
            strSql = "SELECT count(*) FROM Category " +
                      "WHERE  name=@Name AND is_deleted =" + 0;
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@Name", name)
                                      };
            existCount = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return existCount;
        }

        // Retrieve categories with row numbers (not deleted)
        public DataTable GetWithName()
        {
            strSql = "SELECT ROW_NUMBER() OVER(ORDER BY category_id) AS RowNum, "
                  + " category_id, name, description FROM Category WHERE is_deleted = " + 0;
            
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // Retrieve a specific category by its ID
        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM Category " +
                      "WHERE  category_id = " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        // Insert a new category
        public bool Insert(CategoryEntity categoryEntity)
        {
            strSql = "INSERT INTO Category (name, description, created_staff_id, created_datetime, updated_staff_id, updated_datetime) " +
                     "VALUES (@name, @description, @created_staff_id, @created_datetime, @updated_staff_id, @updated_datetime)";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@name", categoryEntity.name),
                                        new SqlParameter("@description", categoryEntity.description),
                                        new SqlParameter("@created_staff_id", categoryEntity.createdStaffId),
                                        new SqlParameter("@created_datetime", categoryEntity.createdDatetime),
                                        new SqlParameter("@updated_staff_id", categoryEntity.updatedStaffId),
                                        new SqlParameter("@updated_datetime", categoryEntity.updatedDatetime),

                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        // Update an existing category
        public bool Update(CategoryEntity categoryEntity)
        {
            strSql = "UPDATE Category SET name = @name, description = @description, updated_staff_id = @updated_staff_id, updated_datetime = @updated_datetime WHERE category_id = @category_id";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@category_id", categoryEntity.categoryId),
                                        new SqlParameter("@name", categoryEntity.name),
                                        new SqlParameter("@description", categoryEntity.description),
                                        new SqlParameter("@updated_staff_id", categoryEntity.updatedStaffId),
                                        new SqlParameter("@updated_datetime", categoryEntity.updatedDatetime),

                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        // Delete a category (mark as deleted)
        public bool Delete(int id)
        {
            strSql = "UPDATE Category SET is_deleted =@is_deleted  WHERE category_id =@category_id";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@category_id", id),
                                         new SqlParameter("@is_deleted",1),
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
    }
}