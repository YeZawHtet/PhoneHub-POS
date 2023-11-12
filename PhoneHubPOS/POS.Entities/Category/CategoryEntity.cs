using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Entities.Category
{
    public class CategoryEntity
    {

        public int categoryId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int createdStaffId { get; set; }

        public int updatedStaffId { get; set; }

        public DateTime createdDatetime { get; set; }

        public DateTime updatedDatetime { get; set; }
        public int isDeleted { get; set; }

        public CategoryEntity()
        {
            InitializedObjectValue();
        }

        internal void InitializedObjectValue()
        {
            this.categoryId = 0;
            this.name = String.Empty;
            this.description = String.Empty;
            this.createdStaffId = 0;
            this.createdDatetime = DateTime.MinValue;
            this.updatedStaffId = 0;
            this.updatedDatetime = DateTime.MinValue;
            this.isDeleted = 0;
        }
    }
}