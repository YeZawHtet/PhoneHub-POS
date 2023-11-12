using System;

namespace POS.Entities.Staff
{
    /// <summary>
    /// Defines the <see cref="StaffEntity" />.
    /// </summary>
    ///
    public class StaffEntity
    {
        /// <summary>
        /// Gets or sets the staff id.
        /// </summary>
        public int staff_id { get; set; }

        /// <summary>
        /// Gets or Sets staffname
        /// </summary>
        public string staffname { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Gets or Sets phone
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// Gets or Sets address
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// Gets or Sets staff_role
        /// </summary>
        public short staff_role { get; set; }

        /// <summary>
        /// Gets or sets created_staff_id
        /// </summary>
        public int created_staff_id { get; set; }

        /// <summary>
        /// Gets or sets updated_staff_id
        /// </summary>
        public int updated_staff_id { get; set; }

        /// <summary>
        /// Gets or sets created_datetime
        /// </summary>
        public DateTime created_datetime { get; set; }

        /// <summary>
        /// Gets or sets updated_datetime
        /// </summary>
        public DateTime updated_datetime { get; set; }

        /// <summary>
        /// Gets or sets is_deleted
        /// </summary>
        public short is_deleted { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="StaffEntity"/> class.
        /// </summary>
        public StaffEntity()
        {
            InitializedObjectValue();
        }

        /// <summary>
        /// The InitializedObjectValue.
        /// </summary>
        internal void InitializedObjectValue()
        {
            this.staff_id = 0;
            this.staffname = String.Empty;
            this.password = String.Empty;
            this.email = String.Empty;
            this.staff_role = 0;
            this.created_staff_id = 0;
            this.updated_staff_id = 0;
            this.created_datetime = DateTime.Now;
            this.updated_datetime = DateTime.Now;
            this.is_deleted = 0;
        }
    }
}
