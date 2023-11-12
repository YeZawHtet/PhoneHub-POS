using DAO.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entities.Supplier;

namespace POS.DAO.Supplier
{
    public class SupplierDao
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

        

        /// <summary>
        /// Get All
        /// </summary>
        public DataTable GetAll()
        {
            strSql = "SELECT * FROM Supplier WHERE is_deleted="+ 0;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM Supplier " +
                      "WHERE  supplier_id = " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetRowNumber
        /// </summary>
        public DataTable GetRowNumber(int first, int last)
        {
            // strSql = "select staff_id,staffname,password,email,staff_role from (select Row_Number() Over (Order By staff_id) As RowNumber,staff_id,staffname,password,email,staff_role from staff) tablerow where rownumber between "+first+" and "+last;

            strSql = "select supplier_id, name, email, phone, address from(select Row_Number() Over(Order By supplier_id) As RowNumber, supplier_id, name, email, phone,address, is_deleted from supplier where is_deleted=0 ) tablerow where  rownumber between " + first + " and " + last;



            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSupplierCount
        /// </summary>
        public int GetSupplierCount()
        {
            strSql = "SELECT count(*) FROM supplier " +
                      "WHERE is_deleted = 0";
            SqlParameter[] sqlParam = {
                                        new SqlParameter()
                                      };
            existCount = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return existCount;
        }

        /// <summary>
        /// GetNameCount
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetNameCount(string name)
        {
            /*    strSql = "SELECT count(*) FROM supplier " +
                          "WHERE  Name=@name and is_deleted = 0";*/
            strSql = "SELECT count(*) FROM supplier WHERE LOWER(REPLACE(name, ' ', '')) = @name and is_deleted = 0";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@name", name)
                                      };
            existCount = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return existCount;
        }

        /// <summary>
        /// GetSupplierCount
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetSupplierCount(string email)
        {
            strSql = "SELECT count(*) FROM supplier " +
                      "WHERE  Email=@email and is_deleted = 0";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@email", email)
                                      };
            existCount = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return existCount;
        }

        /// <summary>
        /// GetSearchData
        /// </summary>
        /// <param name="searchData"></param>
        /// <returns></returns>
        public int GetSearchData(string searchData)
        {
            strSql = "SELECT count(*) FROM supplier WHERE is_deleted = 0 and (name LIKE '%" + searchData + "%' OR address LIKE '%" + searchData + "%' OR email LIKE '%" + searchData + "%' OR phone LIKE '%" + searchData + "%')";
            SqlParameter[] sqlParam = {
                                        new SqlParameter()
                                        };
            int result = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return result;
        }

        /// <summary>
        /// GetSearchDataWithAll
        /// </summary>
        /// <param name="searchData"></param>
        /// <returns></returns>
        public DataTable GetSearchDataWithAll(string searchData)
        {
            strSql = "SELECT * FROM supplier WHERE is_deleted = 0 and (name LIKE '%" + searchData + "%' OR address LIKE '%" + searchData + "%' OR email LIKE '%" + searchData + "%' OR phone LIKE '%" + searchData + "%')";
            SqlParameter[] sqlParam = {
                                        new SqlParameter()
                                        };
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetSearchDataWithPage
        /// </summary>
        /// <param name="searchData"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public DataTable GetSearchDataWithPage(string searchData, int first, int last)
        {
            strSql = "SELECT supplier_id, name, phone, email, address " +
                     "FROM (SELECT ROW_NUMBER() OVER (ORDER BY supplier_id) AS RowNumber, " +
                     "supplier_id, name, phone, email, address, is_deleted " +
                     "FROM supplier WHERE is_deleted = 0 AND (name LIKE '%" + @searchData + "%' OR " +
                     "address LIKE '%" + @searchData + "%' OR " +
                     "email LIKE '%" + @searchData + "%' OR " +
                     "phone LIKE '%" + @searchData + "%')) AS tablerow " +
                     "WHERE RowNumber BETWEEN " + first + " AND " + last;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// Create Supplier
        /// </summary>
        /// <param name="supplierEntity">.</param>
        public bool Insert(SupplierEntity supplierEntity)
        {
            strSql = "INSERT INTO Supplier (name,email,phone,address,created_staff_id,updated_staff_id,created_datetime,updated_datetime)" +
                     "VALUES(@name, @email, @phone, @address, @created_staff_id, @updated_staff_id , @created_datetime , @updated_datetime)";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@name", supplierEntity.name),
                                        new SqlParameter("@email", supplierEntity.email),
                                        new SqlParameter("@phone", supplierEntity.phone),
                                        new SqlParameter("@address", supplierEntity.address),
                                        new SqlParameter("@created_staff_id", supplierEntity.createdStaffId),
                                        new SqlParameter("@updated_staff_id", supplierEntity.updatedStaffId),
                                        new SqlParameter("@created_datetime",supplierEntity.createdDatetime),
                                        new SqlParameter("@updated_datetime",supplierEntity.updatedDatetime)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="staffEntity">.</param>
        public bool Update(SupplierEntity supplierEntity)
        {
            strSql = "UPDATE supplier set name=@name,email=@email,phone=@phone,address=@address,updated_staff_id=@updated_staff_id,updated_datetime=@updated_datetime WHERE supplier_id = @supplier_id";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@supplier_id", supplierEntity.supplierId),
                                        new SqlParameter("@name", supplierEntity.name),
                                        new SqlParameter("@phone", supplierEntity.phone),
                                        new SqlParameter("@email", supplierEntity.email),
                                        new SqlParameter("@address", supplierEntity.address),
                                        new SqlParameter("@updated_staff_id", supplierEntity.updatedStaffId),
                                        new SqlParameter("@updated_datetime", supplierEntity.updatedDatetime)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id">.</param>
        /// /// <param name="LoginStaffID">.</param>
        /// /// <param name="deleted_time">.</param>
        public bool Delete(int id, int LoginStaffID, DateTime deleted_time)
        {
            strSql = "UPDATE supplier set updated_staff_id=@updated_staff_id,updated_datetime=@updated_datetime,is_deleted = 1  WHERE supplier_id = @supplier_id";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@supplier_id", id),
                                        new SqlParameter("@updated_staff_id", LoginStaffID),
                                        new SqlParameter("@updated_datetime", deleted_time)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
    }
}

