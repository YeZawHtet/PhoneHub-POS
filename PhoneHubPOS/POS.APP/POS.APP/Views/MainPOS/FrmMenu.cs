using POS.APP.Views.Category;
using POS.APP.Views.Customer;
using POS.APP.Views.Dashboard;
using POS.APP.Views.Item;
using POS.APP.Views.Login;
using POS.APP.Views.Purchases;
using POS.APP.Views.Sales;
using POS.APP.Views.Staff;
using POS.APP.Views.Supplier;
using POS.Services.Staff;
using System;
using System.Windows.Forms;

namespace POS.APP.Views.MainPOS
{
    public partial class FrmMenu : Form
    {
        private UCSales currentUCSales = null;
        public int staff_id { get; set; }

        public string staff_name { get; set; }

        public FrmMenu(int staff_id, string staffname)
        {
            InitializeComponent();
            this.staff_id = staff_id;
            this.staff_name = staffname;
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            StaffService staffService = new StaffService();
            lblStaffName.Text = staff_name;
            short staff_role = staffService.GetStaffRole(staff_id);
            if (staff_role == 0)
            {
                staffCRUDToolStripMenuItem.Enabled
                    = false;
            }
            else
            {
                salesToolStripMenuItem.Enabled = false;
            }
        }

        private void itemCRUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCItems ucItem = new UCItems(staff_id);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucItem);
            }
        }

        private void itemListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCItemList ucItemList = new UCItemList(staff_id);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucItemList);
            }
        }

        private void salesCRUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentUCSales = new UCSales(staff_id, staff_name);
            pnUC.Controls.Clear();
            pnUC.Controls.Add(currentUCSales);
        }
        private bool SwitchToOtherControl()
        {
            if (currentUCSales != null)
            {
                bool result = ((UCSales)currentUCSales).HandleSaleItems();

                // Return true if items were successfully handled, otherwise return false
                return result;
            }

            // Return true if there's no UCSales (no items to handle)
            return true;
        }
        private void salesListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCSalesList ucSalesList = new UCSalesList(staff_id, staff_name);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucSalesList);
            }
        }

        private void purchasesCRUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCPurchases ucPurchases = new UCPurchases(staff_id);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucPurchases);
            }
        }

        private void purchasesListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCPurchasesList ucPurchasesList = new UCPurchasesList(staff_id);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucPurchasesList);
            }
        }

        private void staffCRUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCStaff ucStaff = new UCStaff(staff_id);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucStaff);
            }
        }

        private void staffListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCStaffList ucStaffList = new UCStaffList(staff_id);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucStaffList);
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCDashboard cuDashboard = new UCDashboard(staff_id, staff_name);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(cuDashboard);
            }
        }

        private void customerCRUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCCustomer ucCustomer = new UCCustomer();
                ucCustomer.SetLoginID(staff_id);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucCustomer);
            }
        }

        private void customerListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCCustomerList ucCustomerList = new UCCustomerList();
                ucCustomerList.SetLoginID(staff_id);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucCustomerList);
            }
        }

        private void supplierCRUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCSupplier ucSupplier = new UCSupplier(staff_id);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucSupplier);
            }
        }

        private void supplierListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCSupplierList ucSupplierList = new UCSupplierList(staff_id);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucSupplierList);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                this.Hide();
                LoginForm login = new LoginForm();
                login.ShowDialog();
                login.FormClosed += (s, args) => this.Close();
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                UCCategory ucCategory = new UCCategory(staff_id);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucCategory);
            }
        }

        private void categoryListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SwitchToOtherControl())
            {
                // It's safe to proceed and show UCCategoryList
                UCCategoryList ucCategoryList = new UCCategoryList(staff_id);
                pnUC.Controls.Clear();
                pnUC.Controls.Add(ucCategoryList);
            }
        }
    }
}
