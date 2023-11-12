using POS.DAO.Customer;
using POS.Entities.Customer;
using System;
using System.Data;
namespace POS.Services.Customer
{
    public class CustomerService
    {
        /// <summary>
        /// Define Customer Dao..
        /// </summary>
        private CustomerDao customerDao = new CustomerDao();
        #region==========Customer========== 
        /// <summary>
        /// Get All.
        /// </summary>
        public DataTable GetAll()
        {
            DataTable dt = customerDao.GetAll();
            return dt;
        }
        /// <summary>
        /// Get.
        /// </summary> 
        /// <param name="id">.</param>
        /// <returns>.</returns>
        public DataTable Get(int id)
        {
            DataTable dt = customerDao.Get(id);
            return dt;
        }
        /// <summary>
        /// Get Customer by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetIdByName(string name)
        {
            return customerDao.GetIdByName(name);
        }
        /// <summary>
        /// GetUserCount
        /// </summary>
        /// <param name="email">.</param>
        /// <returns>.</returns>
        public int GetUserCount(string email)
        {
            int result = customerDao.GetUserCount(email);
            return result;
        }
        /// <summary>
        /// validate customer email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool GetCustomerEmail(string email, int id)
        {
            bool result = customerDao.GetCustomerEmail(email, id);
            return result;
        }
        /// <summary>
        /// Save customer.
        /// </summary>
        /// <param name="customerEntity">.</param>
        public bool Insert(CustomerEntity customerEntity)
        {
            return customerDao.Insert(customerEntity);
        }

        /// <summary>
        /// Update customer.
        /// </summary>
        /// <param name="customerEntity">.</param>
        public bool Update(CustomerEntity customerEntity)
        {
            return customerDao.Update(customerEntity);
        }
        /// <summary>
        /// Delete customer.
        /// </summary>
        /// <param name="id">.</param>
        public bool Delete(int id, int LoginStaffID, DateTime deleted_time)
        {
            return customerDao.Delete(id, LoginStaffID, deleted_time);
        }
        /// <summary>
        /// GetUserCount
        /// </summary>
        public int GetCustomerCount()
        {
            int result = customerDao.GetCustomerCount();
            return result;
        }
        /// <summary>
        /// Search By name
        /// </summary>
        /// <returns></returns>
        public DataTable GetWithName()
        {
            DataTable dt = customerDao.GetWithName();
            return dt;
        }
        #endregion
    }
}