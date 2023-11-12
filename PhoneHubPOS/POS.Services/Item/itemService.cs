using POS.DAO.Item;
using POS.Entities.Item;
using System.Data;

namespace POS.Services.Item
{
    public class ItemService
    {
        private ItemDao itemDao = new ItemDao();


        public DataTable GetAll()
        {
            DataTable dt = itemDao.GetAll();
            return dt;
        }
        public DataTable Get(int id)
        {
            DataTable dt = itemDao.Get(id);
            return dt;
        }
        public int GetIdByName(string name)
        {
            return itemDao.GetIdByName(name);
        }
        public string GetNameById(int id)
        {
            return itemDao.GetNameById(id);
        }
        public DataTable GetWithName()
        {
            DataTable dt = itemDao.GetWithName();
            return dt;
        }
        public DataTable GetItemReport()
        {
            DataTable dt = itemDao.GetItemReport();
            return dt;
        }
        public int GetLastItem()
        {
            return itemDao.GetLastItem();
        }
        public bool Insert(ItemEntity itemEntity)
        {
            return itemDao.Insert(itemEntity);
        }
        public bool Update(ItemEntity itemEntity)
        {
            return itemDao.Update(itemEntity);
        }
        public int GetItemCount(string name, int category_id)
        {
            int result = itemDao.GetItemCount(name, category_id);
            return result;
        }
        public bool Delete(int id)
        {
            return itemDao.Delete(id);
        }
    }
}
