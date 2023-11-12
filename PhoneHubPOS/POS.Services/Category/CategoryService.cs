using POS.DAO.Category;
using POS.Entities.Category;
using System.Data;

namespace POS.Services.Category
{
    public class CategorySercive
    {
        private CategoryDao categoryDao = new CategoryDao();

        public DataTable GetWithName()
        {
            DataTable dt = categoryDao.GetWithName();
            return dt;
        }

        public DataTable GetAll()
        {
            DataTable dt = categoryDao.GetAll();
            return dt;
        }

        public DataTable GetData()
        {
            DataTable dt = categoryDao.GetData();
            return dt;
        }

        public DataTable Get(int id)
        {
            DataTable dt = categoryDao.Get(id);
            return dt;
        }

        public bool Insert(CategoryEntity categoryEntity)
        {
            return categoryDao.Insert(categoryEntity);
        }

        public bool Update(CategoryEntity categoryEntity)
        {
            return categoryDao.Update(categoryEntity);
        }

        public int GetItemCount(string name)
        {
            int result = categoryDao.GetItemCount(name);
            return result;
        }

        public bool Delete(int id)
        {
            return categoryDao.Delete(id);
        }
    }
}