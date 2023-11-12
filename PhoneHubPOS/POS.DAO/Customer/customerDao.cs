using DAO.Common;
using POS.Entities.Customer;
using System;
using System.Data;
using System.Data.SqlClient;
namespace POS.DAO.Customer
{
    public class CustomerDao
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
        /// Defines the existCount.
        /// </summary>
        private int existCount;
        #region==========Customer========== 
        /// <summary>
        /// Get All
        /// </summary>
        public DataTable GetAll()
        {
            strSql = "SELECT * FROM Customer where is_deleted=0 Order By name";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM Customer " +
                      "WHERE  customer_id= " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
        public int GetIdByName(string name)
        {
            strSql = "SELECT customer_id FROM Customer WHERE name = @CustomerName";
            SqlParameter[] sqlParam = { new SqlParameter("@CustomerName", name) };
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
        /// <summary>
        /// GetUserCount
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int GetUserCount(string email)
        {
            strSql = "SELECT count(*) FROM Customer " +
                      "WHERE  email=@email and is_deleted = 0";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@email", email)
                                      };
            existCount = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return existCount;
        }
        /// <summary>
        /// GetUserCount
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool GetCustomerEmail(string email, int id)
        {
            string strSql = "SELECT COUNT(*) FROM Customer " +
                     "WHERE email = @email AND customer_id = @id AND is_deleted = 0";
            SqlParameter[] sqlParam = {
        new SqlParameter("@email", email),
        new SqlParameter("@id", id),
    };

            int count = Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, sqlParam));

            return count > 0;
        }
        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="customerEntity">.</param>
        public bool Insert(CustomerEntity customerEntity)
        {
            strSql = "INSERT INTO Customer(name, email, phone, address, created_staff_id, updated_staff_id, created_datetime, updated_datetime)" +
                     "VALUES(@name, @email, @phone, @address, @created_staff_id, @updated_staff_id , @created_datetime , @updated_datetime)";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@name", customerEntity.name),
                                        new SqlParameter("@email", customerEntity.email),
                                        new SqlParameter("@phone", customerEntity.phone),
                                        new SqlParameter("@address", customerEntity.address),
                                        new SqlParameter("@created_staff_id", customerEntity.created_staff_id),
                                        new SqlParameter("@updated_staff_id", customerEntity.updated_staff_id),
                                        new SqlParameter("@created_datetime",customerEntity.created_datetime),
                                        new SqlParameter("@updated_datetime",customerEntity.updated_datetime)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }
        /// <summary>
        /// update Customer
        /// </summary>
        /// <param name="customerEntity">.</param>
        public bool Update(CustomerEntity customerEntity)
        {
            strSql = "UPDATE Customer set name=@name,email=@email,phone=@phone,address=@address,updated_staff_id=@updated_staff_id,updated_datetime=@updated_datetime WHERE customer_id = @customer_id";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@customer_id", customerEntity.customer_id),
                                        new SqlParameter("@name", customerEntity.name),
                                        new SqlParameter("@email", customerEntity.email),
                                        new SqlParameter("@phone", customerEntity.phone),
                                        new SqlParameter("@address", customerEntity.address),
                                        new SqlParameter("@updated_staff_id", customerEntity.updated_staff_id),
                                        new SqlParameter("@updated_datetime", customerEntity.updated_datetime)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }
        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id">.</param>
        public bool Delete(int id, int LoginStaffID, DateTime deleted_time)
        {
            strSql = "UPDATE Customer set updated_staff_id=@updated_staff_id,updated_datetime=@updated_datetime,is_deleted =1  WHERE customer_id = @customer_id";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@customer_id", id),
                                        new SqlParameter("@updated_staff_id", LoginStaffID),
                                        new SqlParameter("@updated_datetime", deleted_time)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
        /// <summary>
        /// GetCustomerCount
        /// </summary>
        public int GetCustomerCount()
        {
            strSql = "SELECT count(*) FROM Customer " +
                      "WHERE is_deleted = 0";
            SqlParameter[] sqlParam = {
                                        new SqlParameter()
                                      };
            existCount = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return existCount;
        }
        /// <summary>
        /// Search by Name
        /// </summary>
        /// <returns></returns>
        public DataTable GetWithName()
        {
            strSql = "SELECT ROW_NUMBER() OVER(ORDER BY customer_id desc) AS RowNum, "
                  + "customer_id, name, email , phone, address "
                  + " FROM Customer"
                  + " WHERE is_deleted = 0 ORDER BY customer_id DESC";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }
        #endregion
    }
}