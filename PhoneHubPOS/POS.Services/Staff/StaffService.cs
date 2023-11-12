using POS.DAO.Staff;
using POS.Entities.Staff;
using System;
using System.Data;

namespace POS.Services.Staff
{
    /// <summary>
    public class StaffService
    {
        /// Defines the <see cref="StaffService" />.
        /// </summary>
        /// <summary>
        /// Define Item Dao..
        /// </summary>
        private StaffDao staffDao = new StaffDao();


        #region==========Staff========== 
        /// <summary>
        /// Get All.
        /// </summary>
        public DataTable GetAll()
        {
            DataTable dt = staffDao.GetAll();
            return dt;
        }
        #endregion

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="id">.</param>
        /// <returns>.</returns>
        public DataTable Get(int id)
        {
            DataTable dt = staffDao.Get(id);
            return dt;
        }


        /// <summary>
        /// GetRowNumber
        /// </summary>
        public DataTable GetRowNumber(int first, int last)
        {
            DataTable dt = staffDao.GetRowNumber(first, last);
            return dt;
        }

        /// <summary>
        /// GetUserCount
        /// </summary>
        /// <param name="email">.</param>
        /// <returns>.</returns>
        public int GetUserCount(string email)
        {
            int result = staffDao.GetUserCount(email);
            return result;
        }

        /// <summary>
        /// GetUserNameCount
        /// </summary>
        /// <param name="email">.</param>
        /// <returns>.</returns>
        public int GetUserNameCount(string name)
        {
            int result = staffDao.GetUserNameCount(name);
            return result;
        }

        /// <summary>
        /// GetUserCount
        /// </summary>
        public int GetStaffCount()
        {
            int result = staffDao.GetStaffCount();
            return result;
        }

        /// <summary>
        /// GetStaffID
        /// </summary>
        /// <param name="email">.</param>
        /// <returns>.</returns>
        public int GetStaffID(string email)
        {
            int result = staffDao.GetStaffID(email);
            return result;
        }

        /// <summary>
        /// GetStaffPassword
        /// </summary>
        /// <param name="id">.</param>
        /// <returns>.</returns>
        public DataTable GetStaffPassword(int id)
        {
            DataTable dt = staffDao.GetStaffPassword(id);
            return dt;
        }

        /// <summary>
        /// GetStaffRole
        /// </summary>
        /// <param name="id">.</param>
        /// <returns>.</returns>
        public short GetStaffRole(int id)
        {
            short result = staffDao.GetStaffRole(id);
            return result;
        }

        /// <summary>
        /// GetSearchData
        /// </summary>
        /// <param name="id">.</param>
        /// <returns>.</returns>
        public int GetSearchData(string searchData)
        {
            int result = staffDao.GetSearchData(searchData);
            return result;
        }

        /// <summary>
        /// GetSearchDataWithAll
        /// </summary>
        /// <param name="searchData">.</param>
        /// <returns>.</returns>
        public DataTable GetSearchDataWithAll(string searchData)
        {
            DataTable dt = staffDao.GetSearchDataWithAll(searchData);
            return dt;
        }

        /// <summary>
        /// GetSearchDataWithPage
        /// </summary>
        /// <param name="searchData">.</param>
        /// <param name="first">.</param>
        ///  <param name="last">.</param>
        /// <returns>.</returns>
        public DataTable GetSearchDataWithPage(string searchData, int first, int last)
        {
            DataTable dt = staffDao.GetSearchDataWithPage(searchData, first, last);
            return dt;
        }

        /// <summary>
        /// Save Staff.
        /// </summary>
        /// <param name="staffEntity">.</param>
        public bool Insert(StaffEntity staffEntity)
        {
            return staffDao.Insert(staffEntity);
        }

        /// <summary>
        /// Update Staff.
        /// </summary>
        /// <param name="staffEntity">.</param>
        public bool Update(StaffEntity staffEntity)
        {
            return staffDao.Update(staffEntity);
        }

        /// <summary>
        /// Update Staff.
        /// </summary>
        /// <param name="staffEntity">.</param>
        public bool UpdatePassword(StaffEntity staffEntity)
        {
            return staffDao.UpdatePassword(staffEntity);
        }

        /// <summary>
        /// Delete Employee.
        /// </summary>
        /// <param name="id">.</param>
        public bool Delete(int id, int LoginStaffID, DateTime deleted_time)
        {
            return staffDao.Delete(id, LoginStaffID, deleted_time);
        }
    }
}
