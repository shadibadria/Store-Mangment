using Store_Mangment.Control.Orders;
using Store_Mangment.Control.Suppliers;
using Store_Mangment.view.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Mangment.view.Orders
{
    public partial class Add_orders : Form
    {
        private Supplier_control Supplier_data;//database
        private Order_control Order_data;//database
        private Supplier[] suppliers;

        private Order order;

        public Add_orders()
        {
            InitializeComponent();
            string dbpath = Application.StartupPath + @"\StoreData.accdb";//database path

            Supplier_control.ConnectionString = dbpath;
            Supplier_data = Supplier_control.Instance;
            Order_control.ConnectionString = dbpath;
            Order_data = Order_control.Instance;
            load_supplierlist();//load  suppluer list
        }
        /*load supplier list add to box to choose */
        public void load_supplierlist()
        {
            suppliers = Supplier_data.Getsupplierinfo();//get supplier data
            displaysupplier.Items.Clear();
            for (int i = 0; i < suppliers.Length; i++)//add to supplier list
            {
                displaysupplier.Items.Add(suppliers[i].Name);//add to box
            }
            if (displaysupplier.Items.Count != 0)
            {
                displaysupplier.SelectedIndex = 0;//display supplier first index
            }

        }

        /*update order function*/
        public void Orderaupdate(Order ordertoupdate)
        {
            order_name.Text = ordertoupdate.Order_name;//add name
            order_info.Text = ordertoupdate.Order_information;//add info    
            displaysupplier.Text = ordertoupdate.Supplier_name;//add supplier
            add_orderbtn.Text = "עדכן";//update button
            header.Text = "עדכון הזמנה:";
            order = ordertoupdate;
        }



        private void Add_orders_Load(object sender, EventArgs e)
        {

        }

        private void add_orderbtn_Click(object sender, EventArgs e)
        {
            if (order_name.Text.Length != 0 && order_info.Text.Length != 0 && displaysupplier.Text.Length != 0)//check if user fill all 
            {
                if (add_orderbtn.Text == "עדכן")//ifthe button is update
                {
                    order.Order_information = order_info.Text;//add order info
                    order.Supplier_name = displaysupplier.Text;//add supplier
                    order.Order_name = order_name.Text;//add order name          
                    Order_data.Update_order(order);//update order
                    MessageBox.Show("הזמנה עודכנה בהצלחה");
                    this.Close();
                }
                else//button is not update it is add
                {
                    Order neworder = new Order();
                    neworder.Order_name = order_name.Text;//order name 
                    neworder.Supplier_name = displaysupplier.Text;//add supplier
                    neworder.Order_information = order_info.Text;//order information
                    Order_data.insert_order(neworder);//add order
                    MessageBox.Show("הזמנה נוספה בהצלחה");
                    this.Close();
                }
            }
            else//must fill all 
            {
                MessageBox.Show("חובה להזין כל השדות");
            }
        }

        private void newsupplier_Click(object sender, EventArgs e)
        {

            Add_supplier supplier = new Add_supplier();
            supplier.ShowDialog();
            load_supplierlist();//update supplier list
        }

        private void order_name_TextChanged(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(order_name.Text))//if only contains white spaces or null
            {
                order_name.Text = "";
            }
        }

        private void order_info_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(order_info.Text))//if only contains white spaces or null
            {
                order_info.Text = "";
            }
        }
    }
    }

