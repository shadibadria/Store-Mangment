using Store_Mangment.Control.Orders;
using Store_Mangment.Control.Suppliers;
using Store_Mangment.Control.Users;
using Store_Mangment.Model.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Mangment.view.Mails
{
    public partial class Mail_form : Form
    {
        private string filepath = "";
        private User_control User_data;//database
        private Supplier_control Supplier_data;//database
        private Order_control Order_data;//database
        private User[] user;//employee array
        private Order[] orders;//employee array
        private string order_info;
        private Supplier[] supplier;//suppliers array
        private string manger_mail;
        private string To;
        public Mail_form()
        {
            InitializeComponent();
            string dbpath = Application.StartupPath + @"\StoreData.accdb";//database path
            User_control.ConnectionString = dbpath;
            User_data = User_control.Instance;
            Supplier_control.ConnectionString = dbpath;
            Supplier_data = Supplier_control.Instance;
            Order_control.ConnectionString = dbpath;
            Order_data = Order_control.Instance;
            manger_email();

        }
        public void supplier_mail(string supplier_name)
        {

            supplier = Supplier_data.Getsupplierinfo();

            for (int i = 0; i < supplier.Length; i++)
            {
                if (supplier[i].Name.Equals(supplier_name))
                {
                    this.To = supplier[i].Email;
                    to.Text = this.To;
                    return;
                }
            }
        }

        public void Order_info(string orderid)
        {

            orders = Order_data.getorderdata();

            for (int i = 0; i < orders.Length; i++)
            {
                if (orders[i].Order_id.Equals(orderid))
                {
                   body.Text = orders[i].Order_information;
                   
                    return;
                }
            }
        }
        private void manger_email()
        {
            user = User_data.getemployeedata();

            for (int i = 0; i < user.Length; i++)
            {
                if (user[i].Id == "admin")
                {
                    manger_mail = user[i].Email;
                    from.Text = manger_mail;
                    return;
                }
            }

        }
        private void Mail_form_Load(object sender, EventArgs e)
        {

        }

        private void send_Click(object sender, EventArgs e)
        {
            if (from.Text.Contains("@gmail.com") == false || to.Text.Contains("@gmail.com") == false)
            {
                MessageBox.Show("עובד רק עם @gmail");
                return;
            }
            if ( from.Text.Length == 0 || pass.Text.Length == 0 || to.Text.Length == 0 || subject.Text.Length == 0 || body.Text.Length == 0)
            {
                MessageBox.Show("חובה להכניס כל הפרטים");
                return;
            }
            Mail mail = new Mail(this.filepath, from.Text, pass.Text, to.Text, subject.Text, body.Text);
            if (mail.Sent_mail() == 1)
            {
                MessageBox.Show("נשלח");
                this.Close();
            }
            else
            {
                MessageBox.Show(" לא נשלח");

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void from_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
