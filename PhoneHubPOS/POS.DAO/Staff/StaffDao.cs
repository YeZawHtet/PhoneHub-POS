using DAO.Common;
using POS.Entities.Staff;
using System;
using System.Data;
using System.Data.SqlClient;

namespace POS.DAO.Staff
{
    /// <summary>
    /// Defines the <see cref="StaffDao" />.
    /// </summary>
    public class StaffDao
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

        #region==========Staff========== 

        /// <summary>
        /// Get All
        /// </summary>
        public DataTable GetAll()
        {
            strSql = "SELECT * FROM Staff where is_deleted = 0";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM Staff " +
                      "WHERE  staff_id= " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// Get All
        /// </summary>
        public DataTable GetRowNumber(int first, int last)
        {
            strSql = "select staff_id, staffname, password, email,phone,address, staff_role from(select Row_Number() Over(Order By staff_id) As RowNumber, staff_id, staffname, password, email,phone,address, staff_role, is_deleted from staff where is_deleted=0 ) tablerow where  rownumber between " + first + " and " + last;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// GetUserCount
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int GetUserCount(string email)
        {
            strSql = "SELECT count(*) FROM Staff " +
                      "WHERE  Email=@email and is_deleted = 0";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@email", email)
                                      };
            existCount = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return existCount;
        }

        /// <summary>
        /// GetUserNameCount
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int GetUserNameCount(string name)
        {
            strSql = "SELECT count(*) FROM staff WHERE LOWER(REPLACE(staffname, ' ', '')) = @name and is_deleted = 0";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@name", name)
                                      };
            existCount = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return existCount;
        }

        /// <summary>
        /// GetStaffCount
        /// </summary>
        public int GetStaffCount()
        {
            strSql = "SELECT count(*) FROM staff " +
                      "WHERE is_deleted = 0";
            SqlParameter[] sqlParam = {
                                        new SqlParameter()
                                      };
            existCount = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return existCount;
        }

        /// <summary>
        /// GetStaffRole
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public short GetStaffRole(int id)
        {
            strSql = "SELECT staff_role FROM Staff " +
                        "WHERE  staff_id=@id ";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@id", id)
                                        };
            short result = (short)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return result;
        }

        /// <summary>
        /// GetStaffID
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int GetStaffID(string email)
        {
            strSql = "SELECT staff_id FROM Staff " +
                        "WHERE  Email=@email ";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@email", email)
                                        };
            existCount = (int)connection.ExecuteScalar(CommandType.Text, strSql, sqlParam);

            return existCount;
        }

        /// <summary>
        /// GetStaffPassword
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetStaffPassword(int id)
        {
            strSql = "SELECT * FROM Staff " +
                      "WHERE  staff_id=" + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        private string validateStaffRole(string searchData)
        {
            string staffRole = "";
            if (string.Equals(searchData, "admin", StringComparison.OrdinalIgnoreCase))
            {
                staffRole = "1";
            }
            else if (string.Equals(searchData, "cashier", StringComparison.OrdinalIgnoreCase))
            {
                staffRole = "0";
            }
            return staffRole;
        }

        /// <summary>
        /// GetSearchData
        /// </summary>
        /// <param name="searchData"></param>
        /// <returns></returns>
        public int GetSearchData(string searchData)
        {
            if (searchData.ToLower() == "admin" || searchData.ToLower() == "cashier")
            {
                string staffRole = validateStaffRole(searchData);
                strSql = "SELECT count(*) FROM staff WHERE is_deleted = 0 and (staffname LIKE '%" + searchData + "%' OR email LIKE '%" + searchData + "%' OR phone LIKE '%" + searchData + "%' OR address LIKE '%" + searchData + "%' OR staff_role LIKE '%" + staffRole + "%')";
            }
            else
            {
                strSql = "SELECT count(*) FROM staff WHERE is_deleted = 0 and (staffname LIKE '%" + searchData + "%' OR email LIKE '%" + searchData + "%' OR phone LIKE '%" + searchData + "%' OR address LIKE '%" + searchData +"%')";                                                                                                                                                                                                                                                                                                  
            }
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
            if (searchData.ToLower() == "admin" || searchData.ToLower() == "cashier")
            {
                string staffRole = validateStaffRole(searchData);
                strSql = "SELECT * FROM staff WHERE is_deleted = 0 and (staffname LIKE '%" + searchData + "%' OR email LIKE '%" + searchData + "%' OR staff_role LIKE '%" + staffRole + "%')";
            }
            else
            {
                strSql = "SELECT * FROM staff WHERE is_deleted = 0 and (staffname LIKE '%" + searchData + "%' OR email LIKE '%" + searchData + "%')";                                                                                                                                       
            }
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
            if (searchData.ToLower() == "admin" || searchData.ToLower() == "cashier")
            {
                string staffRole = validateStaffRole(searchData);
                strSql = "SELECT staff_id, staffname, password, email,phone,address, staff_role " +
                   "FROM (SELECT ROW_NUMBER() OVER (ORDER BY staff_id) AS RowNumber, " +
                   "staff_id, staffname, password, email,phone,address, staff_role, is_deleted " +
                   "FROM staff WHERE is_deleted = 0 AND (staffname LIKE '%" + @searchData + "%' OR " +
                   "email LIKE '%" + @searchData + "%' OR " +
                   "phone LIKE '%" + @searchData + "%' OR " +
                   "address LIKE '%" + @searchData + "%' OR " +
                   "staff_role LIKE '%" + staffRole + "%')) AS tablerow " +
                   "WHERE RowNumber BETWEEN " + first + " AND " + last;
            }
            else
            {
                strSql = "SELECT staff_id, staffname, password, email,phone,address, staff_role " +
                         "FROM (SELECT ROW_NUMBER() OVER (ORDER BY staff_id) AS RowNumber, " +
                         "staff_id, staffname, password, email,phone,address, staff_role, is_deleted " +
                         "FROM staff WHERE is_deleted = 0 AND (staffname LIKE '%" + @searchData + "%' OR " +
                         "email LIKE '%" + @searchData + "%' OR " +
                         "phone LIKE '%" + @searchData + "%' OR " +
                         "address LIKE '%" + @searchData + "%')) AS tablerow " +
                         "WHERE RowNumber BETWEEN " + first + " AND " + last;
            }
             return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// Create Staff
        /// </summary>
        /// <param name="staffEntity">.</param>
        public bool Insert(StaffEntity staffEntity)
        {
            strSql = "INSERT INTO Staff(staffname, password, email,phone,address, staff_role, created_staff_id, updated_staff_id, created_datetime, updated_datetime)" +
                     "VALUES(@name, @password, @email,@phone,@address, @staff_role, @created_staff_id, @updated_staff_id , @created_datetime , @updated_datetime)";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@name", staffEntity.staffname),
                                        new SqlParameter("@password", staffEntity.password),
                                        new SqlParameter("@email", staffEntity.email),
                                        new SqlParameter("@phone", staffEntity.phone),
                                        new SqlParameter("@address", staffEntity.address),
                                        new SqlParameter("@staff_role", staffEntity.staff_role),
                                        new SqlParameter("@created_staff_id", staffEntity.created_staff_id),
                                        new SqlParameter("@updated_staff_id", staffEntity.updated_staff_id),
                                        new SqlParameter("@created_datetime",staffEntity.created_datetime),
                                        new SqlParameter("@updated_datetime",staffEntity.updated_datetime)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        /// <summary>
        /// Create Staff
        /// </summary>
        /// <param name="staffEntity">.</param>
        public bool Update(StaffEntity staffEntity)
        {
            strSql = "UPDATE Staff set staffname=@name,password=@password,email=@email,phone=@phone,address=@address,staff_role=@staff_role,updated_staff_id=@updated_staff_id,updated_datetime=@updated_datetime WHERE staff_id = @staff_id";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@staff_id", staffEntity.staff_id),
                                        new SqlParameter("@name", staffEntity.staffname),
                                        new SqlParameter("@password", staffEntity.password),
                                        new SqlParameter("@email", staffEntity.email),
                                        new SqlParameter("@phone", staffEntity.phone),
                                        new SqlParameter("@address", staffEntity.address),
                                        new SqlParameter("@staff_role", staffEntity.staff_role),
                                        new SqlParameter("@updated_staff_id", staffEntity.updated_staff_id),
                                        new SqlParameter("@updated_datetime", staffEntity.updated_datetime)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        /// <summary>
        /// UpdatePassword
        /// </summary>
        /// <param name="staffEntity">.</param>
        public bool UpdatePassword(StaffEntity staffEntity)
        {
            strSql = "UPDATE staff set password=@password,updated_staff_id=@updated_staff_id,updated_datetime=@updated_datetime WHERE staff_id = @staff_id";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@staff_id", staffEntity.staff_id),
                                        new SqlParameter("@password", staffEntity.password),
                                        new SqlParameter("@updated_staff_id", staffEntity.updated_staff_id),
                                        new SqlParameter("@updated_datetime", staffEntity.updated_datetime)
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
            strSql = "UPDATE Staff set updated_staff_id=@updated_staff_id,updated_datetime=@updated_datetime,is_deleted =1  WHERE staff_id = @staff_id";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@staff_id", id),
                                        new SqlParameter("@updated_staff_id", LoginStaffID),
                                        new SqlParameter("@updated_datetime", deleted_time)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }

        #endregion

    }
}
