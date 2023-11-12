namespace POS.APP.Views.Customer
{
    public class CustomerInfo
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        public string DisplayText { get; set; } // New property for formatted display text
        /// <summary>
        /// Display text 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="name"></param>
        /// <param name="displayText"></param>
        public CustomerInfo(string phone, string name, string displayText)
        {
            Phone = phone;
            Name = name;
            DisplayText = displayText; // Initialize the DisplayText property
        }
    }
}