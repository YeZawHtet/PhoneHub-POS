using POS.DAO.Item;
using POS.DAO.Supplier;
using POS.Entities.Supplier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Services.Supplier
{
    public class SupplierService
    {
        /// <summary>
        /// Define Item Dao..
        /// </summary>
        private SupplierDao supplierDao = new SupplierDao();

        /// <summary>
        /// Get All.
        /// </summary>
        public DataTable GetAll()
        {
            DataTable dt = supplierDao.GetAll();
            return dt;
        }
        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="id">.</param>
        /// <returns>.</returns>
        public DataTable Get(int id)
        {
            DataTable dt = supplierDao.Get(id);
            return dt;
        }

        /// <summary>
        /// Get All.
        /// </summary>
        public DataTable GetRowNumber(int first, int last)
        {
            DataTable dt = supplierDao.GetRowNumber(first, last);
            return dt;
        }

        /// <summary>
        /// GetUserCount
        /// </summary>
        /// <param name="email">.</param>
        /// <returns>.</returns>
        public int GetSupplierCount(string email)
        {
            int result = supplierDao.GetSupplierCount(email);
            return result;
        }

        /// <summary>
        /// GetNameCount
        /// </summary>
        /// <param name="email">.</param>
        /// <returns>.</returns>
        public int GetNameCount(string name)
        {
            int result = supplierDao.GetNameCount(name);
            return result;
        }

        /// <summary>
        /// GetUserCount
        /// </summary>
        /// <param name="email">.</param>
        /// <returns>.</returns>
        public int GetSupplierCount()
        {
            int result = supplierDao.GetSupplierCount();
            return result;
        }

        /// <summary>
        /// GetSearchData
        /// </summary>
        /// <param name="id">.</param>
        /// <returns>.</returns>
        public int GetSearchData(string searchData)
        {
            int result = supplierDao.GetSearchData(searchData);
            return result;
        }

        /// <summary>
        /// GetSearchDataWithAll
        /// </summary>
        /// <param name="searchData">.</param>
        /// <returns>.</returns>
        public DataTable GetSearchDataWithAll(string searchData)
        {
            DataTable dt = supplierDao.GetSearchDataWithAll(searchData);
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
            DataTable dt = supplierDao.GetSearchDataWithPage(searchData, first, last);
            return dt;
        }

        /// <summary>
        /// Save Staff.
        /// </summary>
        /// <param name="supplierEntity">.</param>
        public bool Insert(SupplierEntity supplierEntity)
        {
            return supplierDao.Insert(supplierEntity);
        }

        /// <summary>
        /// Update Staff.
        /// </summary>
        /// <param name="supplierEntity">.</param>
        public bool Update(SupplierEntity supplierEntity)
        {
            return supplierDao.Update(supplierEntity);
        }

        /// <summary>
        /// Delete Employee.
        /// </summary>
        /// <param name="id">.</param>
        public bool Delete(int id, int LoginStaffID, DateTime deleted_time)
        {
            return supplierDao.Delete(id, LoginStaffID, deleted_time);
        }

    }
}
