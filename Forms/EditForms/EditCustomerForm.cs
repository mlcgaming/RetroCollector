using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RetroCollector.Models;
using RetroCollector.Data.Management;

namespace RetroCollector {
    public partial class EditCustomerForm : Form {
        private UserAccount activeUser;

        public EditCustomerForm(UserAccount activeUser, Customer selectedCustomer) {
            InitializeComponent();
        }
    }
}
