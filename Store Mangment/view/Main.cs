using Store_Mangment.Control.Categorys;
using Store_Mangment.Control.Orders;
using Store_Mangment.Control.Products_control;
using Store_Mangment.Control.Receipts;
using Store_Mangment.Control.Suppliers;
using Store_Mangment.Control.Taxes;
using Store_Mangment.Control.Users;
using Store_Mangment.Model;
using Store_Mangment.Model.Mail;
using Store_Mangment.Model.Receipts;
using Store_Mangment.Model.Reportmaker;
using Store_Mangment.Model.Taxes;
using Store_Mangment.view;
using Store_Mangment.view.Categorys;
using Store_Mangment.view.Mails;
using Store_Mangment.view.Orders;
using Store_Mangment.view.products;
using Store_Mangment.view.Suppliers;
using Store_Mangment.view.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Mangment
{
    public partial class Main : Form
    {
        /*database*/
        private string dbpath;//database path
        private Product_control product_data;//database
        private Category_control Category_data;//database
        private Supplier_control Supplier_data;//database
        private Order_control Order_data;//database
        private Receipt_control Receipt_data;//database
        private User_control User_data;//database
        private Tax_control Tax_data;//database

        /*data*/
        private Product[] products;//product data
        private Category[] categorys;//category data
        private Supplier[] suppliers;//supplier data
        private Order[] orders;//order data
        private Receipt[] receipt;//order data
        private User[] users;//order data
        private Tax[] taxes;
        private User login_info;//login data


        private int counter = 0;
        private int row_index = 0;
        private int sell_dataviewsize = 0;
        private Thread th;//threading


        /*Dates*/
        private string month;
        private string today;
        private string dateforfilename;

        private int flag_inuse=0;


        public Main(int workerflag, User login_info)
        {
            InitializeComponent();
            this.login_info = login_info;//save employee
            if (workerflag == 1)//if it is worker not manger
            {
                worker();//disable manger stuff
            }

            /*database path&&connection*/
            dbpath = Application.StartupPath + @"\Database\StoreData.accdb";
            control();
            Show_productlist();
            Show_Categorylist();
            Show_supplierlist();
            Show_orderlist();
            Showreceiptlist();
            Show_employeelist();
            displaydataboxs();
            get_sale_tax();
            programsboot();
        }
       
        /*starting of the program function*/
        private void programsboot()
        {
        

            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            monthCalendar1.MaxDate = endDate;
            monthCalendar1.MinDate = startDate;
            /*dates set*/
            month = DateTime.Today.ToString("/MM/yyyy");
            today = DateTime.Today.ToString("dd/MM/yyyy");
            dateforfilename = DateTime.Today.ToString("dd,MM,yyyy");
            checkdate();//check data if week is passed 
            check_ifmonthpassed();
            add_user_info(login_info);//add user info to user tab
            messages();
            warningnum.SelectedIndex = 0;


        }
        /*get max /min of product that been sold weekly or momth*/
        private void product_soldmessage()
        {

            Monthly_max_min();//get max and min sold by month  
            Weekly_max_min();//get max and min sold           
        }
        /*Check if Today there is a birthday and display it*/
        private void check_birthday()
        {
            int birthdayflag = 0;//flag to check if employee has birthday
            for (int i = 0; i < users.Length; i++)//add to table
            {
                if (users[i].Id != "admin")//if not manger
                {
                    DateTime oDate = Convert.ToDateTime(users[i].Birthdate);//convert to datetime
                    if (oDate.Day.Equals(DateTime.Today.Day) && oDate.Month.Equals(DateTime.Today.Month))//if today is the employee birthday
                    {
                        if (birthdayflag == 0)//if first time
                        {
                            system_messages.Items.Add("ימי הולדת:\n");
                            system_messages.Items.Add("------------------------- ");
                            birthdayflag = 1;
                        }
                        system_messages.Items.Add(users[i].Fullname);//add employee birthday
                    }
                }
            }
        }
        /*set login information*/
        private void set_logininfo()
        {
            DateTime oDate = DateTime.Parse(login_info.Birthdate);//convert time
            login_info.Fullname = user_fullname.Text;//add name
            login_info.Id = user_id.Text;//add id
            login_info.Email = user_mail.Text;//add main
            login_info.Phone = user_phone.Text;//add phone
            login_info.Birthdate = datepicker.Value.ToString("dd/MM/yyyy");//add date
            login_info.Password = user_oldpassword.Text;//add user password
        }
        /*Get monthly max and min sold*/
        private void Monthly_max_min()
        {
            int max = 0, min = 0, flag = 0;
            Product[] product;
            product = product_data.GetsoldproductData();
            for (int i = 0; i < product.Length; i++)
            {
                if (flag == 0 && product[i].Product_monthlycount != 0)
                {
                    max = min = product[i].Product_monthlycount;
                    flag = 1;
                }
                if (product[i].Product_monthlycount != 0 && max < product[i].Product_monthlycount)
                {
                    max = product[i].Product_monthlycount;
                }
                if (product[i].Product_monthlycount != 0 && min > product[i].Product_monthlycount)
                {
                    min = product[i].Product_monthlycount;
                }
            }
            Display_soldmessage_bymonth(max, min, product);//add to message box
        }
        /*add to message box*/
        private void Display_soldmessage_bymonth(int max, int min, Product[] product)
        {

            system_messages.Items.Add("המוצרים שהכי נמכר החודש: ");
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].Product_monthlycount == max && product[i].Product_monthlycount != 0)//if product is max
                {
                    system_messages.Items.Add(product[i].Product_name);
                }
            }
            system_messages.Items.Add("\n");

            system_messages.Items.Add("המוצרים הכי פחות נמכרו החודש: ");
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].Product_monthlycount == min && product[i].Product_monthlycount != 0)//if product is min
                {
                    system_messages.Items.Add(product[i].Product_name);
                }
            }
            system_messages.Items.Add("\n");
        }
        /*Get weekly max and min sold*/
        private void Weekly_max_min()
        {
            int max = 0, min = 0;
            int flag = 0;
            Product[] product;
            product = product_data.GetsoldproductData();
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].Product_weeklycount != 0 && flag == 0)
                {
                    max = min = product[i].Product_weeklycount;
                    flag = 1;
                }
                if (product[i].Product_weeklycount != 0 && max < product[i].Product_weeklycount)
                {
                    max = product[i].Product_weeklycount;
                }
                if (product[i].Product_weeklycount != 0 && min > product[i].Product_weeklycount)
                {
                    min = product[i].Product_weeklycount;
                }
            }
            Display_soldmessage_week(max, min, product);//display weekly max and min
        }
        /*Display weekly max and min proc*/
        private void Display_soldmessage_week(int max, int min, Product[] product)
        {
            system_messages.Items.Add("המוצרים שהכי נמכר השבוע: \n");
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].Product_weeklycount == max && product[i].Product_weeklycount != 0)//if max
                {
                    system_messages.Items.Add(product[i].Product_name);
                }
            }
            system_messages.Items.Add("\n");

            system_messages.Items.Add("המוצרים הכי פחות נמכרו השבוע: \n");
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].Product_weeklycount == min && product[i].Product_weeklycount != 0)//if min
                {
                    system_messages.Items.Add(product[i].Product_name);
                }
            }
            system_messages.Items.Add("\n");
        }

        /*Display message of the System*/
        public void messages()
        {
            system_messages.Items.Clear();//clear message list
            product_messages.Items.Clear();//clear produt list
            product_soldmessage();//get all sold products by month and by week /get the min and the max
            check_birthday();//check if employee has birthday today

            if (warningnum.Text.Length == 0)//Error Prevent
            {
                return;
            }
            for (int i = 0; i < products.Length; i++)//add product below the amount needed
            {
                if (products[i].Product_count < (int.Parse(warningnum.Text)))//if product below then add
                {
                    product_messages.Items.Add(products[i].Product_name);//display product
                }
            }
        }
        /*add user info to user tab*/
        public void add_user_info(User login_info)
        {
            DateTime oDate = DateTime.Parse(login_info.Birthdate);//convert date to datetime
            user_fullname.Text = login_info.Fullname;//add name
            user_id.Text = login_info.Id;//add id
            user_mail.Text = login_info.Email;//add email
            user_phone.Text = login_info.Phone;//add phone
            datepicker.Value = oDate;//add to date picker
            re_password.Enabled = false;//repassword is false
            password_l.Enabled = false;//label is false
        }
        /*check if two dates are in the same week*/
        private bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
            var d2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));
            return d1 == d2;
        }

        /*update week/month if it is passed product counter to 0*/
        public void check_ifmonthpassed()
        {
            DateTime d = DateTime.Now;
            d = d.AddMonths(-1);
            DateTime first = new DateTime(d.Year, d.Month, 1);
            DateTime prev_month = first;
            while (first.Month == prev_month.Month)
            {

                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i].Work_days.Contains(first.ToShortDateString()))
                    {
                        users[i].Work_days = "";
                        User_data.Update_employee_workdays(users[i]);
                    }

                }
                first = first.AddDays(1);
            }
        }

        /*update week/month if it is passed product counter to 0*/
        public void checkdate()
        {
            Product[] soldproducts;
            soldproducts = product_data.GetsoldproductData();
            for (int i = 0; i < soldproducts.Length; i++)
            {
                if (soldproducts[i].Solddate.Contains(month))
                {
                    DateTime oDate = DateTime.Parse(soldproducts[i].Solddate);
                    if (DatesAreInTheSameWeek(DateTime.Today, oDate) == false)//check if week is passed
                    {
                        product_data.updateweeklysold(soldproducts[i].Product_id, 0);//if passed  week update 
                    }
                }
                else
                {
                    product_data.updatemonthlysold(soldproducts[i].Product_id, 0);//if passed month update

                }
            }
        }
        public void worker()
        {
            worker_panel.Hide();
            message_label.Hide();
            message_label2.Hide();
            message_label3.Hide();
            warningnum.Hide();
            product_messages.Hide();
            system_messages.Hide();
            updateproduct.Hide();
            delete_product.Hide();
            update_category.Hide();
            del_category.Hide();
            update_supplierbtn.Hide();
            delete_supplierbtn.Hide();
            addneworder.Hide();
            update_order.Hide();
            delete_order.Hide();
            tab.TabPages.Remove(report);//hide reports tab
            tab.TabPages.Remove(employees);//hide employee tab
            update_tax.Hide();
            tax.ReadOnly = true;
            worker_list.Hide();
            update_workdays.Hide();
            remove_worker.Hide();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            clock1.Text = DateTime.Now.ToLongTimeString();
            date1.Text = DateTime.Now.ToLongDateString();
            clock2.Text = DateTime.Now.ToLongTimeString();
            date2.Text = DateTime.Now.ToLongDateString();
            clock9.Text = DateTime.Now.ToLongTimeString();
            date9.Text = DateTime.Now.ToLongDateString();
            clock3.Text = DateTime.Now.ToLongTimeString();
            date3.Text = DateTime.Now.ToLongDateString();
            clock4.Text = DateTime.Now.ToLongTimeString();
            date4.Text = DateTime.Now.ToLongDateString();
            clock5.Text = DateTime.Now.ToLongTimeString();
            date5.Text = DateTime.Now.ToLongDateString();
            clock7.Text = DateTime.Now.ToLongTimeString();
            date7.Text = DateTime.Now.ToLongDateString();
            timer1.Start();//start timer


        }

        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Start();//start timer for  clock and date

        }
        /*function to display all boxs*/
        public void displaydataboxs()
        {
            displaycategory.Items.Clear();
            display_categoryreport.Items.Clear();
            displaycategory.Items.Add("הכל");
            categorys = Category_data.GetCategory();
            for (int i = 0; i < categorys.Length; i++)//add to categroy list
            {
                displaycategory.Items.Add(categorys[i].Name.ToString());
                display_categoryreport.Items.Add(categorys[i].Name.ToString());
            }
            displaysupplier.Items.Clear();
            displaysupplier.Items.Add("הכל");
            suppliers = Supplier_data.Getsupplierinfo();
            for (int i = 0; i < suppliers.Length; i++)//add to supplier list
            {
                displaysupplier.Items.Add(suppliers[i].Name);
            }
            displaysupplier.SelectedIndex = 0;//display supplier first index
            displaycategory.SelectedIndex = 0;//reset combo box of category
        }
        /*Data control*/
        private void control (){
            Product_control.ConnectionString = dbpath;
            product_data = Product_control.Instance;

            Category_control.ConnectionString = dbpath;
            Category_data = Category_control.Instance;

            Supplier_control.ConnectionString = dbpath;
            Supplier_data = Supplier_control.Instance;

           Order_control.ConnectionString = dbpath;
           Order_data = Order_control.Instance;

            Receipt_control.ConnectionString = dbpath;
            Receipt_data = Receipt_control.Instance;

            User_control.ConnectionString = dbpath;
            User_data = User_control.Instance;

            Tax_control.ConnectionString = dbpath;
            Tax_data = Tax_control.Instance;
        }
        /*****************************************************************/
        /*                      Products View                            */
        /***************************************************************/

        private void Reload_productlist()
        {
            /*clear search text*/
            searchbyid.Text = "";
            searchbyname.Text = "";
            serch_bycode.Text = "";
            search_byname.Text = "";
            Show_productlist();
        }
        /*display products */
        private void Show_productlist()
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            product_list.Rows.Clear();
            products = product_data.GetproductData();//get data from database
            sell_list.Items.Clear();//clear all sell  list item
            counter = 0;
            row_index = 0;//row index
            for (int i = 0; i < products.Length; i++)//add to table
            {
                sell_list.Items.Add(products[i].Product_name);//add to sell list product name
                product_list.Rows.Add();//add new row
                product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                product_list.Rows[row_index].Cells[3].Value = products[i].Product_count.ToString();//add product count how many in inventory
                product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                product_list.Rows[row_index++].Cells[5].Value = products[i].Adddate;//add product date
                counter += products[i].Product_count;//count products
            }
            productcount.Text = counter.ToString();//add to label 
            productsamounts.Text = counter.ToString();
        }


        /*add product*/
        private void add_productbtn_Click_1(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            Add_product addproduct = new Add_product();
            addproduct.ShowDialog();//add product form   
            Reload_productlist();
            Show_Categorylist();
            displaydataboxs();
        
            Show_supplierlist();
            messages();

        }
        /*Delete product*/
        private void delete_product_Click_1(object sender, EventArgs e)
        {
            if (product_list.RowCount == 0)//if list is empty
            {
                MessageBox.Show("אין מוצרים ברשימה");
                return;
            }
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            string value1 = product_list.SelectedCells[0].Value.ToString();//value of selected product id
            if (check_product_ifuse(value1) == 1)
            {
                string message = "האם אתה בטוח למחוק את המוצר?";//delete message
                string title = "מחיקת מוצר";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;//options yes , no in message
                DialogResult result = MessageBox.Show(message, title, buttons);//add message to the user
                if (result == DialogResult.Yes)//if yes to delete
                {
                    product_data.deleteproduct(value1);//delete product
                    MessageBox.Show("המוצר נמחק בהצלחה");
                    Reload_productlist();
                    Show_Categorylist();
                    displaydataboxs();

                    Show_supplierlist();
                    messages();

                }
            }
        }
        /*check if product is in use*/
        private int check_product_ifuse(string code)
        {
            for (int i = 0; i < products.Length; i++)//search for product in products by id
            {
                if (products[i].Product_id.Equals(code))//check if product is in use 
                {
                    if (products[i].In_use == true)//if product is in use
                    {
                        MessageBox.Show("מוצר בשימוש בקופה נש לשחרר אותו קודם");
                        return 0;
                    }
                }
            }
            return 1;
        }
        /*update product*/
        private void updateproduct_Click_1(object sender, EventArgs e)
        {
            if (product_list.RowCount == 0)//if not products
            {
                MessageBox.Show("אין מוצרים ברשימה");
                return;
            }
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            Update_product updateproduct = new Update_product(products);//update product form
            string value1 = product_list.SelectedCells[0].Value.ToString();//value of product
            if (check_product_ifuse(value1) == 1)
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].Product_id == value1)
                    {
                        updateproduct.display_product(products[i]);//update selected product                       
                    }
                }
                updateproduct.ShowDialog();//go to update form
                displaydataboxs();
                Show_Categorylist();
                Show_supplierlist();
                Reload_productlist();
                messages();

            }
        }
        /*Display category data to box */
        private void displaycategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /*clear search boxes*/
            searchbyid.Text = "";
            searchbyname.Text = "";
            serch_bycode.Text = "";
            search_byname.Text = "";
            getproductbycategory();//get products by category
        }
        /*get product info by category*/
        private void getproductbycategory()
        {
            if (displaycategory.Text != "הכל")//so it dont cost confiosion
                displaysupplier.SelectedIndex = 0;//reset combo box to add all category

            if (displaycategory.Text.Equals("הכל"))//if equal to all then add all products
            {
                serch_bycode.Enabled = true;
                search_byname.Enabled = true;
                displaysupplier.Enabled = true;
                Show_productlist();//load list of products
            }
            else //add products that has  category wanted
            {
                serch_bycode.Enabled = false;
                search_byname.Enabled = false;
                displaysupplier.Enabled = false;
                find_product_bycategory();//find product by category
            }
        }
        /*display product by category*/
        private void find_product_bycategory()
        {
            row_index = 0;
            counter = 0;//product counter
            product_list.Rows.Clear();//clear product list

            for (int i = 0; i < products.Length; i++)
            {
                if (displaycategory.Text.Equals(products[i].Categoryname))//add products by selected category
                {
                    product_list.Rows.Add();//add new row
                    product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                    product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                    product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                    product_list.Rows[row_index].Cells[3].Value = products[i].Product_count.ToString();//add product count how many in inventory
                    product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                    product_list.Rows[row_index++].Cells[5].Value = products[i].Adddate;//add product date
                    counter += products[i].Product_count;//count products
                }
            }
            productcount.Text = counter.ToString();//add to product count label
            productsamounts.Text = counter.ToString();
        }


        /*get product by supplier */
        private void getproductbysupplier()
        {
            if (displaysupplier.Text != "הכל")//so it dont cost confiosion
                displaycategory.SelectedIndex = 0;//reset combo box of category         

            if (displaysupplier.Text.Equals("הכל"))//if equal to all then add all products
            {
                searchbyid.Enabled = true;
                searchbyname.Enabled = true;
                displaycategory.Enabled = true;
                Show_productlist();
            }
            else//if not equal to all then add products by selected supplier
            {
                searchbyid.Enabled = false;
                searchbyname.Enabled = false;
                displaycategory.Enabled = false;
                find_product_supplier();
            }
        }
        private void find_product_supplier()
        {
            product_list.Rows.Clear();//clear product list
            row_index = 0;
            counter = 0;//product counter
            for (int i = 0; i < products.Length; i++)
            {
                if (displaysupplier.Text.Equals(products[i].Suppliername))//if equal to selected supplier the add
                {
                    product_list.Rows.Add();//add new row
                    product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                    product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                    product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                    product_list.Rows[row_index].Cells[3].Value = products[i].Product_count.ToString();//add product count how many in inventory
                    product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                    product_list.Rows[row_index++].Cells[5].Value = products[i].Adddate;//add product date
                    counter += products[i].Product_count;//count products    
                }
            }
            productcount.Text = counter.ToString();//add to counter label.
            productsamounts.Text = counter.ToString();
        }

        private void displaysupplier_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /*reset all search text*/
            searchbyid.Text = "";
            searchbyname.Text = "";
            serch_bycode.Text = "";
            search_byname.Text = "";
            getproductbysupplier();//get product by selected supplier
        }
  
        /*search*/
        /*search for product using id*/
        private void find_product_byid()
        {
            product_list.Rows.Clear();//clear product list
            row_index = 0;
            counter = 0;//product counter
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Product_id.StartsWith(searchbyid.Text))//if products start with search id text
                {
                    product_list.Rows.Add();//add new row
                    product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                    product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                    product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                    product_list.Rows[row_index].Cells[3].Value = products[i].Product_count.ToString();//add product count how many in inventory
                    product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                    product_list.Rows[row_index++].Cells[5].Value = products[i].Adddate;//add product date
                    counter += products[i].Product_count;//count products
                }
            }
            productcount.Text = counter.ToString();
            productsamounts.Text = counter.ToString();
        }
        /*Search for product using id and category*/
        private void find_product_byid_category()
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Categoryname.Equals(displaycategory.Text))//if category equal to selected category
                    if (products[i].Product_id.StartsWith(searchbyid.Text))//if current product start with text
                    {
                        product_list.Rows.Add();//add new row
                        product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                        product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                        product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                        product_list.Rows[row_index].Cells[3].Value = products[i].Product_count.ToString();//add product count how many in inventory
                        product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                        product_list.Rows[row_index++].Cells[5].Value = products[i].Adddate;//add product date
                        counter += products[i].Product_count;//count products
                    }
            }

        }

        /*search product by id*/
        private void searchbyid_TextChanged_1(object sender, EventArgs e)
        {
            displaysupplier.SelectedIndex = 0;//reset combo box to add all category
            counter = 0;//product counter
            product_list.Rows.Clear();//clear product list
            row_index = 0;
            if (displaycategory.Text.Equals("הכל"))//add all products
            {
                find_product_byid();
            }
            else//if category is something else 
            {
                find_product_byid_category();
            }
        }
       
        /*find product using name*/
        public void find_product_byname()
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Product_name.StartsWith(searchbyname.Text))
                {
                    product_list.Rows.Add();//add new row
                    product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                    product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                    product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                    product_list.Rows[row_index].Cells[3].Value = products[i].Product_count.ToString();//add product count how many in inventory
                    product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                    product_list.Rows[row_index++].Cells[5].Value = products[i].Adddate;//add product date
                    counter += products[i].Product_count;//count products
                }
            }
            productcount.Text = counter.ToString();
            productsamounts.Text = counter.ToString();
        }
        /*find product by name and category*/
        public void find_product_byname_category()
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Categoryname.Equals(displaycategory.Text))
                    if (products[i].Product_name.StartsWith(searchbyname.Text))
                    {
                        product_list.Rows.Add();//add new row
                        product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                        product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                        product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                        product_list.Rows[row_index].Cells[3].Value = products[i].Product_count.ToString();//add product count how many in inventory
                        product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                        product_list.Rows[row_index++].Cells[5].Value = products[i].Adddate;//add product date
                        counter += products[i].Product_count;//count products
                    }
            }

            productcount.Text = counter.ToString();
            productsamounts.Text = counter.ToString();
        }
        /*search for product by name*/
        private void searchbyname_TextChanged_1(object sender, EventArgs e)
        {
            displaysupplier.SelectedIndex = 0;//reset combo box to add all category
            /*getting product list from database*/
            counter = 0;
            product_list.Rows.Clear();
            /*getting data products and add it to the cells*/
            row_index = 0;
            if (displaycategory.Text.Equals("הכל"))
            {
                find_product_byname();
            }
            else
            {
                find_product_byname_category();
            }
        }
       

        /*search by code and supplier*/
        public void search_product_bycode_withsupplier()
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Suppliername.Equals(displaysupplier.Text))

                    if (products[i].Product_id.StartsWith(serch_bycode.Text))
                    {
                        product_list.Rows.Add();//add new row
                        product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                        product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                        product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                        product_list.Rows[row_index].Cells[3].Value = products[i].Product_count.ToString();//add product count how many in inventory
                        product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                        product_list.Rows[row_index++].Cells[5].Value = products[i].Adddate;//add product date
                        counter += products[i].Product_count;//count products
                    }
            }
            productcount.Text = counter.ToString();//update count of product
            productsamounts.Text = counter.ToString();
        }
        /*search product by code and supplier*/
        private void serch_bycode_TextChanged_1(object sender, EventArgs e)
        {
            displaycategory.SelectedIndex = 0;//reset combo box to add all category
            counter = 0;

            product_list.Rows.Clear();
            /*getting data products and add it to the cells*/
            row_index = 0;
            if (displaysupplier.Text.Equals("הכל"))//if we want all products
            {
                search_product_bycode_supplier();
            }
            else//display supplier with product 
            {
                search_product_bycode_withsupplier();
            }
            productcount.Text = counter.ToString();//update count of product
            productsamounts.Text = counter.ToString();

        }

        /*find product by code*/
        public void search_product_bycode_supplier()
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Product_id.StartsWith(serch_bycode.Text))//if product found 
                {
                    product_list.Rows.Add();//add new row
                    product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                    product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                    product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                    product_list.Rows[row_index].Cells[3].Value = products[i].Product_count.ToString();//add product count how many in inventory
                    product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                    product_list.Rows[row_index++].Cells[5].Value = products[i].Adddate;//add product date
                    counter += products[i].Product_count;//count products
                }
            }
        }
        private void search_byname_TextChanged(object sender, EventArgs e)
        {
            displaycategory.SelectedIndex = 0;//reset combo box to add all category
            /*getting product list from database*/
            counter = 0;
            product_list.Rows.Clear();
            /*getting data products and add it to the cells*/
            row_index = 0;
            if (displaysupplier.Text.Equals("הכל"))
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].Product_name.StartsWith(search_byname.Text))
                    {
                        product_list.Rows.Add();//add new row
                        product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                        product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                        product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                        product_list.Rows[row_index].Cells[3].Value = products[i].Product_count.ToString();//add product count how many in inventory
                        product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                        product_list.Rows[row_index++].Cells[5].Value = products[i].Adddate;//add product date
                        counter += products[i].Product_count;//count products
                    }
                }
            }
            else
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].Suppliername.Equals(displaysupplier.Text))

                        if (products[i].Product_name.StartsWith(search_byname.Text))
                        {
                            product_list.Rows.Add();//add new row
                            product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                            product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                            product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                            product_list.Rows[row_index].Cells[3].Value = products[i].Product_count.ToString();//add product count how many in inventory
                            product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                            product_list.Rows[row_index++].Cells[5].Value = products[i].Adddate;//add product date
                            counter += products[i].Product_count;//count products
                        }
                }
            }
            productcount.Text = counter.ToString();
            productsamounts.Text = counter.ToString();
        }
        /*sold product list*/
        private void sold_products_Click(object sender, EventArgs e)
        {
            Sold_productslist sold_list = new Sold_productslist();
            sold_list.ShowDialog();
        }
        /*product report*/
        private void product_report_Click(object sender, EventArgs e)
        {
            /*set search box*/
            searchbyid.Text = "";
            searchbyname.Text = "";
            serch_bycode.Text = "";
            search_byname.Text = "";
           
            string title = "  רשימת מוצרים: ";
            string filename = "(" + dateforfilename + ")    " + "רשימת מוצרים .pdf";
            Product[] products_data;
            Reportmaker report = new Reportmaker();
            products_data = products;
            ArrayList temp = new ArrayList();
            double sumofproducts = 0;
            for (int i = 0; i < products_data.Length; i++)
            {
                temp.Add(products_data[i]);
                sumofproducts += products_data[i].Price * products_data[i].Product_count;
            }
            products_data = (Product[])temp.ToArray(typeof(Product));
            report.product_report(title, filename, products_data, int.Parse(productcount.Text), 0, sumofproducts);//report
        }

        /*****************************************************************/
        /*                      Category View                            */
        /***************************************************************/

        /*display all categorys*/

        private void Show_Categorylist()
        {
            category_list.Rows.Clear();//clear rows
            counter = 0;
            categorys = Category_data.GetCategory();//get category data from database
            row_index = 0;

            for (int i = 0; i < categorys.Length; i++)//add to list 
            {
                category_list.Rows.Add();
                category_list.Rows[row_index].Cells[0].Value = categorys[i].Code.ToString();//add code
                category_list.Rows[row_index].Cells[1].Value = categorys[i].Name;// add name
                category_list.Rows[row_index++].Cells[2].Value = categorys[i].Info;// add information
                counter++;//count categorys
            }
            count_category.Text = counter.ToString();//update label of count
            categoryamount.Text = counter.ToString();
        }

        /*Add new category*/
        private void add_category_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            category_name.Text = "";
            Add_category category_add_update = new Add_category();//add category form

            category_add_update.ShowDialog();//open form
            Show_Categorylist();
            displaydataboxs();//update boxes
        }

        /*Update Category*/
        private void update_category_Click(object sender, EventArgs e)
        {
            if (category_list.RowCount == 0)//if category list is empty
            {
                MessageBox.Show("אין קטגוריות ברשימה");
                return;
            }
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            Add_category category_add_update = new Add_category();
            string value1 = category_list.SelectedCells[1].Value.ToString();//get category name
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Categoryname.Equals(value1))//if category name is used
                {
                    MessageBox.Show("לא ניתן לעדכן סוג קטגוריה זה כי יתכן שמשתמשים בו על ידי מוצרים אחרים");
                    return;
                }
            }
            value1 = category_list.SelectedCells[0].Value.ToString();//get category id
            category_name.Text = "";
            for (int i = 0; i < categorys.Length; i++)
            {
                if (categorys[i].Code == value1)//if category found
                {
                    category_add_update.updatecategory(categorys[i]);//category update
                    break;
                }
            }
            category_add_update.ShowDialog();//show category form
            Show_Categorylist();
            displaydataboxs();//update boxs
        }



        /*Delete category*/
        private void del_category_Click(object sender, EventArgs e)
        {
            category_name.Text = "";
            if (category_list.RowCount == 0)//if categorylist is empty
            {
                MessageBox.Show("אין קטגוריות ברשימה");
                return;
            }
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            string message = "האם אתה בטוח שתרצה למחוק את הקטגוריה ?";
            string title = "מחיקת קטגוריה";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            string value1 = category_list.SelectedCells[1].Value.ToString();//get name value it is like id
            for (int i = 0; i < products.Length; i++)//seach for categoey if it is used by other product
            {
                if (products[i].Categoryname.Equals(value1))//if category is used by order product
                {
                    MessageBox.Show("לא ניתן למחוק סוג מוצר זה כי יתכן שמשתמשים בו על ידי מוצרים אחרים");
                    return;
                }
            }
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                value1 = category_list.SelectedCells[0].Value.ToString();//get value
                Category_data.deletecategory(value1);//delete category
                MessageBox.Show("הקטגוריה נמחקה בהצלחה");
                Show_Categorylist();
                displaydataboxs();//update data boxs
            }
        }

        /*Report maker*/
        private void get_categorytable_Click(object sender, EventArgs e)
        {
            /*set search box*/
            category_name.Text = "";
            string title = "  רשימת קטגוריות: ";
            string filename = "(" + dateforfilename + ")    " + "רשימת קטגוריות .pdf";
            Category[] category_data;
            Reportmaker report = new Reportmaker();
            category_data = categorys;
            ArrayList temp = new ArrayList();
            for (int i = 0; i < category_data.Length; i++)
            {
                temp.Add(category_data[i]);
            }
            category_data = (Category[])temp.ToArray(typeof(Category));//convert to array
            report.category_report(title, filename, category_data, int.Parse(count_category.Text));//report
        }

        /*search by name*/
        private void category_name_TextChanged(object sender, EventArgs e)
        {
            row_index = 0;
            category_list.Rows.Clear();//clear category list
            counter = 0;
            for (int i = 0; i < categorys.Length; i++)
            {
                if (categorys[i].Name.StartsWith(category_name.Text))//if category foubd
                {
                    category_list.Rows.Add();
                    category_list.Rows[row_index].Cells[0].Value = categorys[i].Code;//add code
                    category_list.Rows[row_index].Cells[1].Value = categorys[i].Name;//add name
                    category_list.Rows[row_index++].Cells[2].Value = categorys[i].Info;//add information
                    counter++;//category counter
                }
            }
            count_category.Text = counter.ToString();//update category at label
            categoryamount.Text = counter.ToString();
        }



        /*****************************************************************/
        /*                      Suppliers View                            */
        /***************************************************************/

            /*Display supplier list*/
        private void Show_supplierlist()
        {
            supplier_list.Rows.Clear();
            suppliers = Supplier_data.Getsupplierinfo();
            counter = 0;
            row_index = 0;
            for (int i = 0; i < suppliers.Length; i++)//add table to list
            {
                supplier_list.Rows.Add();
                supplier_list.Rows[row_index].Cells[0].Value = suppliers[i].Name;//add name
                supplier_list.Rows[row_index].Cells[1].Value = suppliers[i].Adress;//add adress
                supplier_list.Rows[row_index].Cells[2].Value = suppliers[i].Phone;//add phone
                supplier_list.Rows[row_index++].Cells[3].Value = suppliers[i].Email;//add email
                counter++;//supplier count
            }
            supcount.Text = counter.ToString();
            countofsupplier.Text = counter.ToString();
        }

        /*add new supplier*/
        private void add_supplierbtn_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            suppliername.Text = "";
            Add_supplier supplier = new Add_supplier();
            supplier.ShowDialog();//add new supplier form
            Show_supplierlist();
            displaydataboxs();
        }

        /*update supplier*/
        private void update_supplierbtn_Click(object sender, EventArgs e)
        {
            if (supplier_list.RowCount == 0)//if list is empty
            {
                MessageBox.Show("אין ספקים ברשימה");
                return;
            }
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            Add_supplier supplier = new Add_supplier();
            string value1 = supplier_list.SelectedCells[0].Value.ToString();//get name
            suppliername.Text = "";
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Suppliername.Equals(value1))//check if name exsist
                {
                    MessageBox.Show("לא ניתן לעדכן ספק זה כי  יתכן שמשתמשים בו על ידי מוצרים אחרים");
                    return;
                }
            }
            for (int i = 0; i < orders.Length; i++)
            {
                if (orders[i].Supplier_name.Equals(value1))//check if name exsist
                {
                    MessageBox.Show("לא ניתן לעדכן ספק זה כי  יתכן שמשתמשים בו על ידי הזמנות ");
                    return;
                }
            }
            for (int i = 0; i < suppliers.Length; i++)//if every thing is ok
            {
                if (suppliers[i].Name == value1)
                {
                    supplier.updatesupplier(suppliers[i]);//update
                    break;
                }
            }
            supplier.ShowDialog();//show supplier add form
            Show_supplierlist();//update supplie list
            displaydataboxs();//update data boxs
        }
        /*Delete supplier*/
        private void delete_supplierbtn_Click(object sender, EventArgs e)
        {
            suppliername.Text = "";

            if (supplier_list.RowCount == 0)//if list is empty
            {
                MessageBox.Show("אין ספקים ברשימה");
                return;
            }
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            string message = "האם אתה בטוח שתרצה למחוק את הספק ?";
            string title = "מחיקת ספק";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            string value1 = supplier_list.SelectedCells[0].Value.ToString();

            for (int i = 0; i < products.Length; i++)//check if supplier is used  by other products
            {
                if (products[i].Suppliername.Equals(value1))
                {
                    MessageBox.Show("לא ניתן למחוק ספק זה כי יתכן שמשתמשים בו על ידי מוצרים אחרים");
                    return;
                }


            }
            for (int i = 0; i < orders.Length; i++)
            {
                if (orders[i].Supplier_name.Equals(value1))//check if name exsist
                {
                    MessageBox.Show("לא ניתן לעדכן ספק זה כי  יתכן שמשתמשים בו על ידי הזמנות ");
                    return;
                }
            }
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                value1 = supplier_list.SelectedCells[0].Value.ToString();//get supplier id

                Supplier_data.deletesupplier(value1);//delete supplier
                MessageBox.Show("הספק נמחק בהצלחה");
                displaydataboxs();
            }
            Show_supplierlist();//update supplier list
        }

        /*search supplier name*/
        private void suppliername_TextChanged(object sender, EventArgs e)
        {
            supplier_list.Rows.Clear();//clear list
            counter = 0;
            row_index = 0;

            for (int i = 0; i < suppliers.Length; i++)//add table to list
            {
                if (suppliers[i].Name.StartsWith(suppliername.Text))//search for supplier
                {
                    supplier_list.Rows.Add();
                    supplier_list.Rows[row_index].Cells[0].Value = suppliers[i].Name;//add supplier name
                    supplier_list.Rows[row_index].Cells[1].Value = suppliers[i].Adress;//add supplier adress
                    supplier_list.Rows[row_index].Cells[2].Value = suppliers[i].Phone;//add supplier phone
                    supplier_list.Rows[row_index++].Cells[3].Value = suppliers[i].Email;//add supplier email
                    counter++;//counter for supplier
                }

            }
            supcount.Text = counter.ToString();//update suppleir count
            countofsupplier.Text = counter.ToString();
        }



        /*****************************************************************/
        /*                      Orders View                            */
        /***************************************************************/
            
            /*Display orders*/

        private void Show_orderlist()
        {
            order_data.Rows.Clear();//clear order data list
            orders = Order_data.getorderdata();//get data from database
            counter = 0;
            row_index = 0;//row index
            for (int i = 0; i < orders.Length; i++)//add to table
            {
                order_data.Rows.Add();
                order_data.Rows[row_index].Cells[0].Value = orders[i].Order_id;//order id
                order_data.Rows[row_index].Cells[1].Value = orders[i].Order_name;//order name
                order_data.Rows[row_index].Cells[2].Value = orders[i].Order_date;//order date
                order_data.Rows[row_index++].Cells[3].Value = orders[i].Supplier_name;//supplier name
                counter++;//count orders
            }
            orderamount.Text = counter.ToString();//add to label ordercount
            ordersamount.Text = counter.ToString();
        }

        /*add new order*/
        private void addneworder_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            order_name.Text = "";
            Add_orders add_order = new Add_orders();
            add_order.ShowDialog();//add order form
            Show_orderlist();
            Show_supplierlist();
            displaydataboxs();//update data box
            order_list.Items.Clear();
        }
        /*update order*/
        private void update_order_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            order_list.Items.Clear();
            if (order_data.RowCount == 0)//if list is empty
            {
                MessageBox.Show("אין הזמנות ברשימה");
                return;
            }
            Add_orders updateorder = new Add_orders();
            for (int i = 0; i < orders.Length; i++)
            {
                if (order_data.SelectedCells[0].Value.ToString().Equals(orders[i].Order_id))//if order found
                {
                    updateorder.Orderaupdate(orders[i]);//update it
                    updateorder.ShowDialog();
                    break;
                }
                order_name.Text = "";
            }
            Show_orderlist();
            Show_supplierlist();
            displaydataboxs();//update data boxs
        }
        /*delete order*/
        private void delete_order_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            order_name.Text = "";
            order_list.Items.Clear();

            if (order_data.RowCount == 0)//if list is empty
            {
                MessageBox.Show("אין הזמנות ברשימה");
                return;
            }
            string message = "האם אתה בטוח שתרצה למחוק את ההזמנה ?";
            string title = "מחיקת הזמנה";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            string value1 = order_data.SelectedCells[0].Value.ToString();
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Order_data.delete_order(value1);//delete order
                MessageBox.Show("הזמנה נמחקה בהצלחה");
                Show_orderlist();
            }
        }
        /*double click event to view data*/
        private void order_data_DoubleClick(object sender, EventArgs e)
        {
            if (order_data.Rows.Count != 0)//if it is not empty
            {
                for (int i = 0; i < orders.Length; i++)
                {
                    if (order_data.SelectedCells[0].Value.ToString().Equals(orders[i].Order_id))//if order found
                    {
                        order_list.Items.Clear();//clear all order  list item
                        /*add text to the box ordername,orderdata..*/
                        string text;
                        text = "שם הזמנה: " + orders[i].Order_name;
                        order_list.Items.Add(text);
                        text = "תאריך הזמנה: " + orders[i].Order_date;
                        order_list.Items.Add(text);
                        text = "ספק: " + orders[i].Supplier_name;
                        order_list.Items.Add(text);
                        text = "----------------- " + "\n";
                        order_list.Items.Add(text);
                        text = "תוכן ההזמנה: " + "\n";
                        order_list.Items.Add(text);
                        text = "----------------- " + "\n";
                        order_list.Items.Add(text);
                        text = orders[i].Order_information;//split new line in the string
                        foreach (string s in Regex.Split(text, "\n"))
                            order_list.Items.Add(s);
                    }
                }
            }
        }

        /*search */
        private void order_name_TextChanged(object sender, EventArgs e)
        {
            int orders_count = 0;
            order_data.Rows.Clear();//clear list of order
            row_index = 0;
            for (int i = 0; i < orders.Length; i++)//add to table
            {
                if (orders[i].Order_name.StartsWith(order_name.Text))//seach for order
                {
                    order_data.Rows.Add();
                    order_data.Rows[row_index].Cells[0].Value = orders[i].Order_id;//add id
                    order_data.Rows[row_index].Cells[1].Value = orders[i].Order_name;//add name
                    order_data.Rows[row_index].Cells[2].Value = orders[i].Order_date;//add date
                    order_data.Rows[row_index++].Cells[3].Value = orders[i].Supplier_name;//add supplier name
                    orders_count++;//count order
                }
            }
            orderamount.Text = orders_count.ToString();//add it to count label
            ordersamount.Text = orders_count.ToString();
        }



        /*****************************************************************/
        /*                      User View                            */
        /***************************************************************/
        private void  view_userlist(User[] users)
        {
            monthCalendar1.RemoveAllBoldedDates();
            monthCalendar1.UpdateBoldedDates();
            worker_list.Rows.Clear();

            row_index = 0;//row index

            for (int i = 0; i < users.Length; i++)//add to table
            {
                worker_list.Rows.Add();//add new row
                string temp = "";
                foreach (char s in users[i].Work_days)
                {
                    if (s != '-')
                    {
                        temp += s;
                    }
                    if (s == '-' && temp != "")
                    {
                        DateTime oDate = DateTime.Parse(temp);
                        temp = "";
                        monthCalendar1.AddBoldedDate(oDate);
                    }
                }
                monthCalendar1.UpdateBoldedDates();
                worker_list.Rows[row_index].Cells[1].Value = users[i].Fullname;//add name
                worker_list.Rows[row_index++].Cells[0].Value = users[i].Id;//add id 
            

            }
        }
        /*Display employeees*/
        private void Show_employeelist()
        {
            employee_list.Rows.Clear();
            users = User_data.getemployeedata();//get data from database
            counter = 0;

            view_userlist(users);
            row_index = 0;//row index

            for (int i = 0; i < users.Length; i++)//add to table
            {
               
                
            
                if (users[i].Id != "admin")
                {
                    employee_list.Rows.Add();//add new row
                    employee_list.Rows[row_index].Cells[0].Value = users[i].Fullname;//add name
                    employee_list.Rows[row_index].Cells[1].Value = users[i].Id;//add id 
                    employee_list.Rows[row_index].Cells[2].Value = users[i].Phone;//add phone
                    employee_list.Rows[row_index].Cells[3].Value = users[i].Birthdate;//add birthday
                    employee_list.Rows[row_index].Cells[4].Value = users[i].Email;//add email
                    employee_list.Rows[row_index++].Cells[5].Value = users[i].Password;//add password
                    counter++;
                }
                
            }
            employee_count.Text = counter.ToString();//add to label 
            workeramount.Text = counter.ToString();
        }
        /*Add employee*/
        private void add_employee_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            /*clear searching datatext*/
            employee_list.Text = "";
            Add_user add_employee = new Add_user();
            add_employee.ShowDialog();//add employee form
            Show_employeelist();
            messages();

            worker_record.Items.Clear();//clear list

        }
        /*Update employee*/

        private void upd_emplyee_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            if (employee_list.RowCount == 0)//if list is empty
            {
                MessageBox.Show(" הרשימה ריקה");
                return;
            }
            Add_user update_employee = new Add_user();
            for (int i = 0; i < users.Length; i++)//search for employee
            {
                if (employee_list.SelectedCells[1].Value.ToString().Equals(users[i].Id))//if employee found
                {
                    update_employee.employee_update(users[i]);//update it send info
                    update_employee.ShowDialog();
                    break;
                }
            }
            search_employee.Text = "";//rest search
            Show_employeelist();
            messages();
            worker_record.Items.Clear();//clear list
        }
        /*Del employee*/

        private void del_employe_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            /*clear searching datatext*/
            search_employee.Text = "";
            if (employee_list.RowCount == 0)//if list is empty
            {
                MessageBox.Show("הרשימה ריקה");
                return;
            }
            string value1 = employee_list.SelectedCells[1].Value.ToString();//value of selected employee id
            string message = "האם אתה בטוח למחוק את העובד?";//delete message
            string title = "מחיקת עובד";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;//options yes , no in message
            DialogResult result = MessageBox.Show(message, title, buttons);//add message to the user
            if (result == DialogResult.Yes)//if yes to delete
            {
                User_data.delete_employee(value1);//delete user
                MessageBox.Show("העובד נמחק בהצלחה");
            }
            /*load list*/
            Show_employeelist();
            messages();

            worker_record.Items.Clear();
        }


        /*search*/
        private void search_employee_TextChanged(object sender, EventArgs e)
        {
            int employee_counter = 0;
            employee_list.Rows.Clear();//clear list of employee
            row_index = 0;
            for (int i = 0; i < users.Length; i++)//add to table
            {
                if (users[i].Fullname.StartsWith(search_employee.Text))//seach for employee
                {
                    if (users[i].Id != "admin")
                    {

                        employee_list.Rows.Add();//add new row
                        employee_list.Rows[row_index].Cells[0].Value = users[i].Fullname;//add name
                        employee_list.Rows[row_index].Cells[1].Value = users[i].Id;//add id
                        employee_list.Rows[row_index].Cells[2].Value = users[i].Phone;//add phone
                        employee_list.Rows[row_index].Cells[3].Value = users[i].Birthdate;//add birthday
                        employee_list.Rows[row_index].Cells[4].Value = users[i].Email;//add mail
                        employee_list.Rows[row_index++].Cells[5].Value = users[i].Password;//add password                   
                        employee_counter++;//count employees
                    }
                }
            }
            employee_count.Text = employee_counter.ToString();//add it to count label
            workeramount.Text = employee_counter.ToString();
        }
        /*user info*/
     
        /*seach for user*/
        private User find_employeebyid(string id)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (id.Equals(users[i].Id))//if employee found by id
                {
                    return users[i];

                }
            }
            return null;
        }


        /*****************************************************************/
        /*                      sell-list View                            */
        /***************************************************************/

            /*sell list*/
        public void loadselllist()
        {
            sell_list.Items.Clear();//clear all sell  list item
            counter = 0;
            row_index = 0;//row index
            for (int i = 0; i < products.Length; i++)//add to table
            {
                if (products[i].In_use == false)//if products is not in use then add it to the list
                    sell_list.Items.Add(products[i].Product_name);
            }
        }

        /*Search by name*/
        private void sell_searchpname_TextChanged(object sender, EventArgs e)
        {
            if (sell_searchpname.Text.Length != 0)//if text not equal to 0
            {
                sell_list.Items.Clear();//clear list list
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].Product_name.StartsWith(sell_searchpname.Text) && products[i].In_use == false)//serch by name
                    {
                        sell_list.Items.Add(products[i].Product_name);
                    }
                }
            }
            else//load all sell list when there is no text
            {
                loadselllist();
            }
        }

        /*search by id*/




        private void clear_producttosell_items()
        {
            /*clear search text*/
            sell_productname.Text = "";
            sell_productprice.Text = "";
            sell_pcroductcode.Text = "";
            pcount.Text = "";
            pcountinfo.Text = "";
        }

        /*add products to pending products*/
        private void addprodutstosell()
        {
            flag_inuse = 1;
            row_index = 0;
            if (sell_productname.Text == "")// if nothing is selected 
            {
                return;
            }
            if (int.Parse(pcount.Text) <= 0 || int.Parse(pcount.Text) > int.Parse(pcountinfo.Text))//if count is correct
            {
                MessageBox.Show("המספר חייב להיות גדול מ 0 וגם קטן מ " + pcountinfo.Text);
                return;
            }
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Product_id.Equals(sell_pcroductcode.Text))//adding to the list
                {
                    products[i].In_use = true;//in use so we cant delete it or update it
                    /*add colors and set font*/
                    sell_productlist.Rows.Add();//add new row
                    string t = "0." + tax.Text;
                    sell_productlist.Rows[sell_dataviewsize].Cells[0].Value = products[i].Product_id.ToString();//add product id
                    sell_productlist.Rows[sell_dataviewsize].Cells[1].Value = products[i].Product_name.ToString();//add product name
                    double _tax = double.Parse(t) * (double.Parse(pcount.Text) * products[i].Price);
                    sell_productlist.Rows[sell_dataviewsize].Cells[2].Value = (_tax + (double.Parse(pcount.Text) * products[i].Price)).ToString();//add total price
                    sell_productlist.Rows[sell_dataviewsize++].Cells[3].Value = pcount.Text;//add product count user choice
                    totalprice.Text = (double.Parse(totalprice.Text) + (_tax + (double.Parse(pcount.Text)) * products[i].Price)).ToString();//update total price
                }
            }
            clear_producttosell_items();
        }

        private void pcount_TextChanged(object sender, EventArgs e)
        {
            sell_list.Items.Clear();
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].In_use == false)//only adds products that are not in use 
                {
                    sell_list.Items.Add(products[i].Product_name);
                }
            }
        }

        private void sell_addtolist_Click(object sender, EventArgs e)
        {
            sell_searchpname.Text = "";
            sell_searchpcode.Text = "";
            if (pcount.Text.Length == 0 && sell_pcroductcode.Text.Length > 0)//checking if we enter product count
            {
                MessageBox.Show("חובה להזין כמות מוצר");
                pcount.Text = "1";
                return;
            }
            if (sell_pcroductcode.Text.Length == 0)//check if we choose a product
            {
                MessageBox.Show("חובה לבחור מוצר");
                return;
            }
            if (tax.Text.Length == 0)//check if we choose a product
            {
                MessageBox.Show("חובה להוסיף מע \"מ");
                get_sale_tax();

                return;
            }
            addprodutstosell();//add product ot sell list
            load_product_tosell_list();//load all product to list
        }
        /*load product sell*/
        private void load_product_tosell_list()
        {
            sell_list.Items.Clear();
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].In_use == false)//only adds products that are not in use 
                {
                    sell_list.Items.Add(products[i].Product_name);
                }
            }
        }
        public void get_sale_tax()
        {
            taxes = Tax_data.get_sale_tax();
            tax.Text = taxes[0].Sell_tax.ToString();
        }

        private void reload_sellproducttab()
        {
            sell_dataviewsize = 0;
            Showreceiptlist();
            sell_productlist.Rows.Clear();//clear list
            Show_productlist();
        }


        /*sell prodcuts function*/
        private void sell_products()
        {
        Receipt receipt = new Receipt();
            receipt.Receipt_info = "";
           string today = DateTime.Today.ToString("dd/MM/yyyy");
           double totalcost = 0;
           int total_products = 0;
           totalprice.Text = "0";//update price to 0
           string pcode;
            for (row_index = 0; row_index < sell_dataviewsize; row_index++)//looping throw the rows and adding to database
            {
                pcode = sell_productlist.Rows[row_index].Cells[0].Value.ToString();//getting the product code
                for (int i = 0; i < products.Length; i++)//searching for product
                {
                    if (pcode.Equals(products[i].Product_id))//product found
                    {
                        receipt.Receipt_info += "\nשם מוצר: " + products[i].Product_name + " \n    כמות: " + sell_productlist.Rows[row_index].Cells[3].Value.ToString() + "\n" + "   (₪)מחיר: " + sell_productlist.Rows[row_index].Cells[2].Value.ToString() + "\n";
                        receipt.Receipt_info += "--------------------------";
                        totalcost += double.Parse(sell_productlist.Rows[row_index].Cells[2].Value.ToString());
                        total_products += int.Parse(sell_productlist.Rows[row_index].Cells[3].Value.ToString());
                        products[i].Product_sellrecord += "-" + DateTime.Today.ToShortDateString() + ",";
                        product_data.update_productsoldrecord(pcode, products[i].Product_sellrecord);
                        products[i].Product_count = products[i].Product_count - int.Parse(sell_productlist.Rows[row_index].Cells[3].Value.ToString());//Update count
                        if (products[i].Product_count != 0)//if there is more products left
                        {
                            products[i].In_use = false;//turn in use to false
                            products[i].Product_monthlycount += int.Parse(sell_productlist.Rows[row_index].Cells[3].Value.ToString());//update monthly sold
                            product_data.updatemonthlysold(products[i].Product_id, products[i].Product_monthlycount);
                            products[i].Product_weeklycount += int.Parse(sell_productlist.Rows[row_index].Cells[3].Value.ToString());//update weekly sold
                            product_data.updateweeklysold(products[i].Product_id, products[i].Product_weeklycount);
                        }
                        else//if the product is over
                        {
                            products[i].Product_monthlycount += int.Parse(sell_productlist.Rows[row_index].Cells[3].Value.ToString());//u[date monthly sold
                            product_data.updatemonthlysold(products[i].Product_id, products[i].Product_monthlycount);
                            products[i].Product_weeklycount += int.Parse(sell_productlist.Rows[row_index].Cells[3].Value.ToString());//update weekly sold
                            product_data.updateweeklysold(products[i].Product_id, products[i].Product_weeklycount);
                            product_data.updateproductsold(products[i].Product_id, true, products[i].Solddate);//update sold option to true no left
                        }
                        product_data.updateproductcount(products[i].Product_id, products[i].Product_count, today);//update product counter                             
                    }
                }

            }

            //  sell_report(receipt, totalcost, total_products);
            sell_report(receipt, totalcost, total_products);

            reload_sellproducttab();
        }
        /*Create sell report*/
        private void sell_report(Receipt receipts, double totalcost, int total_products)
        {
            Reportmaker sellreport = new Reportmaker();
            receipts.Receipt_date = DateTime.Now.ToString();
            receipts.Total_cost = totalcost;
            receipts.Worker_name = login_info.Fullname;
            receipts.Product_amounts = total_products;
            Receipt_data.insert_Receipt(receipts);
            Showreceiptlist();
            receipts.Receipt_code = receipt[receipt.Length - 1].Receipt_code;
            sellreport.sell_report("file", "Uniqe Gifts", receipts, total_products, totalcost, int.Parse(tax.Text));
        }



















        private void sell_cancelproduct_Click(object sender, EventArgs e)
        {
            clear_producttosell_items();//clear items
            get_sale_tax();


        }

        private void sell_list_DoubleClick(object sender, EventArgs e)
        {
            if (sell_list.Text.Length != 0)//if the list is not empty
            {
                counter = 0;
                for (int i = 0; i < products.Length; i++)
                {
                    if (sell_list.Text.Equals(products[i].Product_name))//add info to check box text
                    {
                        sell_productname.Text = products[i].Product_name;
                        sell_productprice.Text = products[i].Price.ToString();
                        counter = int.Parse(products[i].Product_count.ToString());
                        sell_pcroductcode.Text = products[i].Product_id;
                    }
                }
                pcount.Text = "1";//add to count box 1 
                pcountinfo.Text = counter.ToString();
            }
        }

        private void sell_searchpcode_TextChanged(object sender, EventArgs e)
        {
            if (sell_searchpcode.Text.Length != 0)
            {
                sell_list.Items.Clear();//clear product list in sell tab
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].Product_id.StartsWith(sell_searchpcode.Text) && products[i].In_use == false)//if it is the same product and not in use
                    {
                        sell_list.Items.Add(products[i].Product_name);
                    }
                }
            }
            else
            {
                loadselllist();//load list 
            }
        }

        private void sell_cancelall_Click(object sender, EventArgs e)
        {
            flag_inuse = 0;
            if (sell_dataviewsize != 0)//must not be empty
            {
                for (row_index = 0; row_index < sell_dataviewsize; row_index++)//going throw the list
                {
                    for (int i = 0; i < products.Length; i++)//searching for the first product that comes up
                    {
                        if (sell_productlist.Rows[row_index].Cells[0].Value.ToString().Equals(products[i].Product_id))//if products is in the list 
                        {
                            products[i].In_use = false;//we cancel it and put it not in use
                        }
                    }
                }
                sell_productlist.Rows.Clear();//clear pending list
                sell_dataviewsize = 0;//dataview size to 0
                load_product_tosell_list();//load product list
                totalprice.Text = "0";//price is 0
            }
            else
            {
                MessageBox.Show("אין מוצרים לבחור");

            }

        }

        private void addproductbtn_Click(object sender, EventArgs e)
        {
            ArrayList soldlist = new ArrayList();
            flag_inuse = 0;
            if (totalprice.Text != "0")//if there is product
            {
                string message = "מחיר לתשלום \n" + totalprice.Text;//message 
                string title = "מכירת מוצרים";//title of message
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)//if user choose yes option
                {
                    sell_products();
                    messages();
                }
            }
            else//if no product in the list
            {
                MessageBox.Show("אין מוצרים");
            }
        }

        private void cancelfrompendlist_Click(object sender, EventArgs e)
        {
            if (sell_productlist.RowCount == 1)
            {
                flag_inuse = 0;
            }
            if (sell_productlist.RowCount != 0)
            {
               double product_cost = 0;
                for (int i = 0; i < products.Length; i++)//searching for product we want to cancle
                {
                    if (products[i].Product_id.Equals(sell_productlist.SelectedCells[0].Value.ToString()))//if found turn in use to false
                        products[i].In_use = false;
                    product_cost = double.Parse(sell_productlist.SelectedCells[2].Value.ToString());//update product cost to update all product cost
                }
                sell_productlist.Rows.RemoveAt(sell_productlist.CurrentCell.RowIndex);//remove product
                sell_dataviewsize = sell_productlist.Rows.Count;//update row count
                load_product_tosell_list();//load list
                totalprice.Text = (double.Parse(totalprice.Text) - product_cost).ToString();//update total price
            }
            else
            {
                MessageBox.Show("אין מוצרים לבחור");

            }
        }

        private void update_tax_Click(object sender, EventArgs e)
        {
            if (tax.Text.Length == 0)//check if we choose a product
            {
                MessageBox.Show("חובה להוסיף מע \"מ");
                get_sale_tax();
                return;
            }
            if (int.Parse(tax.Text) <= 0 || int.Parse(tax.Text) > 100)
            {
                MessageBox.Show("  מספר חייב להיו בין 1-100");
                get_sale_tax();
                return;
            }
            Tax sell_tax = new Tax();
            sell_tax.Sell_tax = int.Parse(tax.Text);
            tax.Text = "";
            Tax_data.update_sale_tax(sell_tax);
            get_sale_tax();
            MessageBox.Show("עודכן בהצלחה");
        }

        private void tax_TextChanged(object sender, EventArgs e)
        {
            if (tax.Text.All(char.IsDigit) == false)
            {
                MessageBox.Show("חובה להזין מספר");
                get_sale_tax();
                return;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        /*****************************************************************/
        /*                   Receipt_list view                           */
        /***************************************************************/

        /*Display Recipt list*/
        private void Showreceiptlist()
        {
            receipt_list.Rows.Clear();
            receipt = Receipt_data.getallReceipt();//get data from database
            int receipt_count = 0;
            row_index = 0;//row index
            for (int i = 0; i < receipt.Length; i++)//add to table
            {
                receipt_list.Rows.Add();//add new row
                receipt_list.Rows[row_index].Cells[0].Value = receipt[i].Receipt_code;//add receipt id
                receipt_list.Rows[row_index].Cells[1].Value = receipt[i].Receipt_date;//ad receipt date
                if (receipt[i].Receipt_return == false)//if not return add -
                    receipt_list.Rows[row_index++].Cells[2].Value = "-";
                else
                    receipt_list.Rows[row_index++].Cells[2].Value = " הוחזר";//else add 
                receipt_count++;
            }
            receipt_counter.Text = receipt_count.ToString();//add to label 
        }

        /*search receipt by code*/
        private void receipt_code_TextChanged(object sender, EventArgs e)
        {
            receipt_list.Rows.Clear();//clear list
            int counter = 0;
            row_index = 0;
            for (int i = 0; i < receipt.Length; i++)//add table to list
            {
                if (receipt[i].Receipt_code.StartsWith(receipt_code.Text))//search for recipt
                {
                    receipt_list.Rows.Add();
                    receipt_list.Rows[row_index].Cells[0].Value = receipt[i].Receipt_code;//add recipt code
                    receipt_list.Rows[row_index].Cells[1].Value = receipt[i].Receipt_date;//add recipt date
                    if (receipt[i].Receipt_return == false)
                        receipt_list.Rows[row_index++].Cells[2].Value = "-";
                    else
                        receipt_list.Rows[row_index++].Cells[2].Value = " הוחזר";
                    counter++;//counter for supplier
                }
            }
            receipt_counter.Text = counter.ToString();//update Recipt count
        }

        /*return product*/
        private void return_product_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            if (receipt_info.Items.Count == 0)//check if list is empty
            {
                MessageBox.Show(" חובה לבחור קבלה");
                return;
            }
            Products_return product_ret = new Products_return(receipt_list.SelectedCells[0].Value.ToString());
            product_ret.ShowDialog();
        
                Showreceiptlist();
        }

        private void receipt_list_DoubleClick(object sender, EventArgs e)
        {
            if (receipt_list.Rows.Count != 0)//if it is not empty
            {
                for (int i = 0; i < receipt.Length; i++)
                {
                    if (receipt_list.SelectedCells[0].Value.ToString().Equals(receipt[i].Receipt_code))//if order found
                    {
                        receipt_info.Items.Clear();//clear all order  list item
                        receipt_info.Items.Add("קופאי: " + receipt[i].Worker_name + " \n");
                        receipt_info.Items.Add("-----------------------------------------");
                        receipt_info.Items.Add("מוצרים שנמכרו: \n");
                        foreach (string s in Regex.Split(receipt[i].Receipt_info, "\n"))
                            receipt_info.Items.Add(s);
                        receipt_info.Items.Add("-----------------------------------------");
                        receipt_info.Items.Add("כמות:     " + receipt[i].Product_amounts);
                        receipt_info.Items.Add("(₪)מחיר כולל:     " + receipt[i].Total_cost);
                    }
                }
            }
        }








            /*****************************************************************/
            /*                     Logout                                    */
            /***************************************************************/

            /*thread exit*/
            private void log_out()
        {
            this.Close();
            th = new Thread(opennewForm);//open new form
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        /*go to login page*/
        private void opennewForm()
        {
            Application.Run(new Login());
        }

        private void exitbtn1_Click(object sender, EventArgs e)
        {
            log_out();

        }

        private void extbtn9_Click(object sender, EventArgs e)
        {
            log_out();

        }
        private void exitbtn2_Click(object sender, EventArgs e)
        {
            log_out();
        }

        private void get_suppliertable_Click(object sender, EventArgs e)
        {
            /*set search box*/
            suppliername.Text = "";
            string title = "  רשימת ספקים : ";
            string filename = "(" + dateforfilename + ")    " + "רשימת ספקים .pdf";
            Supplier[] supplier_data;
            Reportmaker report = new Reportmaker();
            supplier_data = suppliers;
            ArrayList temp = new ArrayList();
            for (int i = 0; i < supplier_data.Length; i++)
            {
                temp.Add(supplier_data[i]);//add to list
            }
            supplier_data = (Supplier[])temp.ToArray(typeof(Supplier));//convert to array
            report.supplier_report(title, filename, supplier_data, int.Parse(supcount.Text));//report
        }

        private void get_orderstable_Click(object sender, EventArgs e)
        {
            /*set search box*/
            order_name.Text = "";
            order_list.Items.Clear();
            string title = "רשימת הזמנות:";
            string filename = "(" + dateforfilename + ")    " + "רשימת הזמנות.pdf";
            Order[] order_data;
            Reportmaker report = new Reportmaker();
            order_data = orders;
            ArrayList temp = new ArrayList();
            for (int i = 0; i < order_data.Length; i++)
            {
                temp.Add(order_data[i]);//add 
            }
            order_data = (Order[])temp.ToArray(typeof(Order));//convert to array
            report.order_report(title, filename, order_data, int.Parse(orderamount.Text));//make report
        }

        private void order_report_Click(object sender, EventArgs e)
        {
            if (order_list.Items.Count == 0)//check if list is empty
            {
                MessageBox.Show("אין הזמנות חובה לבחור הזמנה");
                return;
            }
            order_list.Items.Clear();
            string value = order_data.SelectedCells[1].Value.ToString();//get order name         
            string title = " הזמנה: " + value;
            Reportmaker report = new Reportmaker();
            ArrayList temp = new ArrayList();
            value = order_data.SelectedCells[0].Value.ToString();//get order id
            for (int i = 0; i < orders.Length; i++)
            {
                if (orders[i].Order_id.Equals(value))//if id found
                {
                    temp.Add(orders[i]);//add order 
                    report.order_out(title, "(" + dateforfilename + ")    " + orders[i].Order_name, orders[i]);//make order report for 1 order
                    return;
                }
            }
        }

        private void send_order_Click(object sender, EventArgs e)
        {
            if (order_list.Items.Count == 0)//check if list is empty
            {
                MessageBox.Show("אין הזמנות חובה לבחור הזמנה");
                return;
            }
            string sup_name = "";
            order_list.Items.Clear();
            string value = order_data.SelectedCells[1].Value.ToString();//get order name         
            string title = " הזמנה: " + value;
            Reportmaker report = new Reportmaker();
            ArrayList temp = new ArrayList();
            value = order_data.SelectedCells[0].Value.ToString();//get order id
            for (int i = 0; i < orders.Length; i++)
            {
                if (orders[i].Order_id.Equals(value))//if id found
                {
                    temp.Add(orders[i]);//add order 
                    sup_name = orders[i].Supplier_name;
                }
            }
            Mail_form new_mail = new Mail_form();
            new_mail.supplier_mail(sup_name);
            new_mail.Order_info(order_data.SelectedCells[0].Value.ToString());
            new_mail.ShowDialog();
        }

        private void soldreportbtn_Click(object sender, EventArgs e)
        {
            string title = " דוח מכירות ";
            string filename = "(" + dateforfilename + ")       " + "דוח מכירות .pdf";
            Product[] soldproducts;
            Reportmaker report = new Reportmaker();
            soldproducts = product_data.GetsoldproductData();//get all product include sold
            ArrayList solddate = new ArrayList();
            ArrayList soldamount = new ArrayList();
            double sumofproducts = 0;
            int productcount = 0;
            if (sold_startdate.Value.CompareTo(sold_enddate.Value) > 0)//check if dates are correct
            {
                MessageBox.Show("לא יכול להיות תאריך התחלה יותר גדול מתאריך סוף");
                return;
            }

            solddate = get_daterecord(soldproducts);
            report.soldproduct_report(title, filename, soldproducts, productcount, sumofproducts, sold_startdate.Value, sold_enddate.Value, solddate);//report of product
        }

        /*get product sold record*/
        private ArrayList get_daterecord(Product[] soldproducts)
        {
            ArrayList temp = new ArrayList();
            string record;
            string date = "";
            for (int i = 0; i < soldproducts.Length; i++)
            {
                record = soldproducts[i].Product_sellrecord;

                for (int j = 0; j < record.Length; j++)
                {
                    date = "";

                    if (record[j] == '-')
                    {
                        j++;
                        while (record[j] != ',')
                        {
                            date += record[j];
                            Console.WriteLine(record[j]);
                            j++;
                        }
                        if (record[j] == ',')
                        {
                            temp.Add(date);
                        }
                    }
                }
            }
            return temp;
        }

        private void sellreport_weekly_Click(object sender, EventArgs e)
        {
            string title = " דוח מכירות שבועי";
            string filename = "(" + dateforfilename + ")       " + "דוח מכירות שבועי.pdf";
            Product[] soldproducts;
            Reportmaker report = new Reportmaker();
            soldproducts = product_data.GetsoldproductData();//get all product include sold
            ArrayList temp = new ArrayList();
            double sumofproducts = 0;
            int productcount = 0;
            for (int i = 0; i < soldproducts.Length; i++)
            {
                Console.WriteLine(soldproducts[i].Solddate);

                if (soldproducts[i].Solddate != "")
                {

                    DateTime oDate = DateTime.Parse(soldproducts[i].Solddate.ToString());
                    if (DatesAreInTheSameWeek(DateTime.Today, oDate) == true)//if dates are in the same week count and sum it
                    {
                        productcount += soldproducts[i].Product_weeklycount;
                        temp.Add(soldproducts[i]);
                        sumofproducts += soldproducts[i].Price * soldproducts[i].Product_weeklycount;//sum products
                    }
                }
            }
            soldproducts = (Product[])temp.ToArray(typeof(Product));
            report.product_report(title, filename, soldproducts, productcount, 1, sumofproducts);//report of product
        }

        private void sellreport_monthly_Click(object sender, EventArgs e)
        {
            string title = " דוח מכירות חודשי";
            string filename = "(" + dateforfilename + ")       " + "דוח מכירות חודשי.pdf";
            Reportmaker report = new Reportmaker();
            Product[] soldproducts;
            soldproducts = product_data.GetsoldproductData();//get all products no metter if it is sold
            ArrayList temp = new ArrayList();
            double sumofproducts = 0;
            int productcount = 0;
            for (int i = 0; i < soldproducts.Length; i++)
            {
                if (soldproducts[i].Solddate.Contains(month))//if product sold this month
                {
                    productcount += soldproducts[i].Product_monthlycount;//count product
                    temp.Add(soldproducts[i]);//add to arraylist
                    sumofproducts += soldproducts[i].Price * soldproducts[i].Product_monthlycount;//sum product
                }
            }
            Console.WriteLine(productcount);
            soldproducts = (Product[])temp.ToArray(typeof(Product));//sold product array
            report.product_report(title, filename, soldproducts, productcount, 1, sumofproducts);//get report
        }

        private void category_reportout_Click(object sender, EventArgs e)
        {
            if (display_categoryreport.Text.Length == 0)//check if category is selected
            {
                MessageBox.Show("חובה לבחור קטגוריה");
                return;
            }
            string title = "קטגוריה: " + display_categoryreport.Text;
            string filename = "(" + dateforfilename + ")    " + "מוצרים לפי קטגוריה .pdf";
            Product[] products_data;
            Reportmaker report = new Reportmaker();
            products_data = products;
            ArrayList temp = new ArrayList();//list of product
            double sumofproducts = 0;//sum of products
            int product_counter = 0;//products counter
            for (int i = 0; i < products_data.Length; i++)//seach for products that have selected category
            {
                if (products_data[i].Categoryname == display_categoryreport.Text)//if found add to list
                {
                    temp.Add(products_data[i]);
                    sumofproducts += products_data[i].Price * products_data[i].Product_count;//sum price of products
                    product_counter += products_data[i].Product_count;//count product
                }
            }
            products_data = (Product[])temp.ToArray(typeof(Product));//make array

            report.product_report(title, filename, products_data, product_counter, 0, sumofproducts);//send to make report
        }

        private void manger_report_Click(object sender, EventArgs e)
        {
            string value = user_fullname.Text;//get manger name
            string title = " דוח נוכחות לעובד: " + value;
            string filename = "(" + dateforfilename + ")    " + value + "דוח נוכחות.pdf";
            Reportmaker report = new Reportmaker();
            ArrayList temp = new ArrayList();
            value = user_id.Text;// manger id

            if (start_time.Value.CompareTo(end_time.Value) > 0)//check if dates are correct
            {
                MessageBox.Show("לא יכול להיות תאריך התחלה יותר גדול מתאריך סוף");
                return;
            }

            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Id.Equals(value))//if id found
                {
                    report.employee_report(title, filename, users[i], start_time.Value, end_time.Value);//make report
                    return;
                }
            }
        }



        private void backupbtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd;
            sfd = new SaveFileDialog();
            sfd.Filter = "accdb File |*.accdb";
            sfd.FileName = "StoreData";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(dbpath, Path.GetFullPath(sfd.FileName), true);//COPY FILE TO DISTINATION AND OVERWRITE IT          
                }
                catch
                {
                    MessageBox.Show("  הקובץ בשימוש בבקשה לסגור את הקובץ או לשנות את השם");
                }
            }
            else
            {
                return;
            }
        }

        private void pic_products_Click(object sender, EventArgs e)
        {
            tab.SelectTab(2);

        }

        private void pic_categorys_Click(object sender, EventArgs e)
        {
            tab.SelectTab(3);

        }

        private void pic_suppliers_Click(object sender, EventArgs e)
        {
            tab.SelectTab(4);

        }

        private void pic_orders_Click(object sender, EventArgs e)
        {
            tab.SelectTab(5);

        }

        private void pic_workers_Click(object sender, EventArgs e)
        {
            tab.SelectTab(7);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            log_out();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log_out();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            log_out();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            log_out();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            log_out();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            log_out();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            log_out();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            log_out();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            log_out();

        }
        /*get employee login hour*/
        private ArrayList get_employee_loginhour(string record)
        {
            /*login hour*/
            ArrayList loginhour = new ArrayList();
            string login = "";
            int count = 0;
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ' ')
                {
                    count++;
                }
                if (count % 2 != 0 && record[i] == ' ')
                {
                    i++;
                    if (i > record.Length)
                        break;
                    while (record[i] != ',')
                    {
                        login += record[i];
                        i++;
                        if (i > record.Length)
                            break;
                    }
                    if (i > record.Length)
                        break;
                    loginhour.Add(login);
                    login = "";
                }
                if (i > record.Length)
                    break;
            }
            return loginhour;
        }
        private void employee_list_DoubleClick(object sender, EventArgs e)
        {
            if (employee_list.Rows.Count != 0)//if list is not empty
            {
                User employeeinfo = find_employeebyid(employee_list.SelectedCells[1].Value.ToString());
                ArrayList logindate = new ArrayList();
                ArrayList loginhour = new ArrayList();
                ArrayList exithour = new ArrayList();
                ArrayList hoursworked = new ArrayList();
                worker_record.Items.Clear();//clear all employe record list

                /*add text to the record name and dates*/
                worker_record.Items.Add("שם עובד: " + employeeinfo.Fullname);
                worker_record.Items.Add(" תאריכי כניסה: ");//add dates
                worker_record.Items.Add("----------------- ");
                logindate = get_employee_date(employeeinfo.Login_record);//get login dates
                loginhour = get_employee_loginhour(employeeinfo.Login_record);//get login hours
                exithour = get_employee_exithour(employeeinfo.Login_record);//get exit hours
                hoursworked = get_employee_hourworked(loginhour, exithour);//get shift time
                get_emplyoee_logininfo(logindate, loginhour, exithour, hoursworked);

            }
        }
        /*display employee_logininfo*/
        private void get_emplyoee_logininfo(ArrayList logindate, ArrayList loginhour, ArrayList exithour, ArrayList hoursworked)
        {
            string str = "";
            for (int i = 0; i < loginhour.Count; i++)
            {
                str += "\nתאריך :" + logindate[i].ToString() + "\n" + "משעה:" + loginhour[i].ToString() + " עד :" + exithour[i].ToString() + "\n" + "זמן :" + hoursworked[i].ToString();
                str += "\n--------------------------------------\n";
            }
            foreach (string s in Regex.Split(str, "\n"))
                worker_record.Items.Add(s);
        }
        /*get employee exithour*/
        private ArrayList get_employee_exithour(string record)
        {
            ArrayList exithour = new ArrayList();
            /*exit hour  */
            string login = "";
            int count = 0;
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ' ')
                {
                    count++;
                }
                if (count != 0 && count % 2 == 0 && record[i] == ' ')
                {
                    i++;
                    if (i > record.Length)
                        break;
                    while (record[i] != ',')
                    {
                        login += record[i];
                        i++;
                        if (i > record.Length)
                            break;
                    }
                    if (i > record.Length)
                        break;
                    exithour.Add(login);
                    login = "";
                }
                if (i > record.Length)
                    break;
            }
            return exithour;
        }
        /*Get employee hour shift duration*/
        private ArrayList get_employee_hourworked(ArrayList loginhour, ArrayList exithour)
        {
            ArrayList hoursworked = new ArrayList();
            for (int i = 0; i < loginhour.Count; i++)
            {
                DateTime startTime = Convert.ToDateTime(loginhour[i]);
                DateTime endtime = Convert.ToDateTime(exithour[i]);
                TimeSpan duration = startTime - endtime;
                string hours = duration.ToString().Replace("-", string.Empty);
                hoursworked.Add(hours);
            }
            return hoursworked;
        }
        private ArrayList get_employee_date(string record)
        {
            ArrayList logindate = new ArrayList();
            /*Login date*/
            string login = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ' ')
                {
                    logindate.Add(login);
                    login = "";
                    while (i < record.Length && record[i] != '\n')
                    {
                        i++;
                    }
                    i++;
                }
                if (i > record.Length)
                    break;
                login += record[i];
            }
            return logindate;
        }

        private void warningnum_SelectedIndexChanged(object sender, EventArgs e)
        {
            messages();

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void userupdatedone_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            if (check_user_fields() == 0)//check the user input
                return;

            if (login_info.Password.Equals(user_oldpassword.Text))//if user password is typed check if it is correct
            {
                check_password();
            }
            else//if user password is not correct
            {
                MessageBox.Show("סיסמה לא נכונה");
                add_user_info(login_info);
                user_oldpassword.Text = "";
                user_newpassword.Text = "";
            }
            messages();

        }
        /*check user passwords*/
        private void check_password()
        {
            set_logininfo();
            if (user_newpassword.Text.Length > 0)//check if new password is typed 
            {
                if (user_newpassword.Text.Equals(re_password.Text))//if new password is typed check if two passwords are correct
                {
                    login_info.Password = user_newpassword.Text;//change password information
                }
                else//if new two password are not equal then return
                {
                    MessageBox.Show("חובה להזין אותה סיסמה");
                    add_user_info(login_info);
                    user_newpassword.Text = "";
                    re_password.Text = "";
                    return;
                }
            }
            User_data.Update_employee(login_info, login_info.Id);//update information
            MessageBox.Show("פרטים שונו");
            user_oldpassword.Text = "";
            user_newpassword.Text = "";
            re_password.Text = "";
            Show_employeelist();//load list
            add_user_info(login_info);//re add new info
        }
        /*check user input fields*/
        private int check_user_fields()
        {
            /*check if everything is typed*/
            if (user_fullname.Text.Length == 0 || user_id.Text.Length == 0 || user_phone.Text.Length == 0 || user_mail.Text.Length == 0)
            {
                MessageBox.Show("חובה להזין את כל השדות");
                return 0;
            }
            if (user_oldpassword.Text.Length == 0)//check if userpassword is typed
            {
                MessageBox.Show("חובה להזין את הסיסמה הישנה");
                return 0;
            }
            return 1;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.login_info.Exit_hour = DateTime.Now.ToString();//exit date date
            update_loginrecords(login_info);//update login record in user
        }
        /*function to update login record */
        public void update_loginrecords(User login_info)
        {
            login_info.Login_record += "\n";//add newline between dates
            login_info.Login_record += login_info.Lastlogindate + "," + login_info.Exit_hour + ",";//add to record new date
            User_data.Update_employee_loginrecord(login_info.Id, login_info.Login_record, login_info.Lastlogindate, login_info.Exit_hour);//update login records 
            Show_employeelist();
        }

        private void worker_report_Click(object sender, EventArgs e)
        {
            if (worker_record.Items.Count == 0)//check if list is empty
            {
                MessageBox.Show("  חובה לבחור עובד");
                return;
            }
            if (worker_startshift.Value.CompareTo(worker_endshift.Value) > 0)
            {
                MessageBox.Show("לא יכול להיות תאריך התחלה יותר גדול מתאריך סוף");
                return;
            }
            worker_record.Items.Clear();
            string value = employee_list.SelectedCells[0].Value.ToString();//get employee name 
            string title = " דוח נוכחות לעובד: " + value;
            string filename = "(" + dateforfilename + ")    " + value + "דוח נוכחות.pdf";
            Reportmaker report = new Reportmaker();
            value = employee_list.SelectedCells[1].Value.ToString();//get employee id
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Id.Equals(value))//if id found
                {
                    report.employee_report(title, filename, users[i], worker_startshift.Value, worker_endshift.Value);//make report
                    return;
                }
            }
        }

        private void update_workdays_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            if (worker_list.RowCount == 0)//if list is empty
            {
                MessageBox.Show("חובה לבחור עובד");
                return;
            }
            int counter = 0;
            for (int i = 0; i < users.Length; i++)//check if there is more than two worker in the shift
            {
                if (users[i].Work_days.Contains(monthCalendar1.SelectionRange.Start.ToShortDateString()))
                {
                    counter++;
                }
            }
            if (counter >= 2)//shift has only 2 workers
            {
                MessageBox.Show("לא ניתן להוסיף יותר מ 2 עובדים למשמרת");
                return;
            }
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Id.Equals(worker_list.SelectedCells[0].Value.ToString()))
                {
                    users[i].Work_days += "-";
                    users[i].Work_days += monthCalendar1.SelectionRange.Start.ToShortDateString();
                    users[i].Work_days += "-";
                    User_data.Update_employee_workdays(users[i]);
                }
            }
            Show_employeelist();
            work_list.Items.Clear();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            work_list.Items.Clear();
            work_list.Items.Add(monthCalendar1.SelectionRange.Start.ToShortDateString());
            int flag = 1;
            work_list.Items.Add(" ");

            for (int i = 0; i < users.Length; i++)
            {

                if (users[i].Work_days.Contains(monthCalendar1.SelectionRange.Start.ToShortDateString()))
                {
                    if (flag == 1)
                    {
                        work_list.Items.Add("בוקר");
                        work_list.Items.Add("7:00 - 14:00");
                        work_list.Items.Add("---------------\n");
                        flag = 0;
                    }
                    else
                    {
                        work_list.Items.Add("ערב");
                        work_list.Items.Add("14:00 - 22:00");
                        work_list.Items.Add("---------------\n");
                        flag = 1;
                    }
                    work_list.Items.Add(users[i].Fullname);
                    work_list.Items.Add(" ");
                }
            }
        }

        private void remove_worker_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            int found_flag = 0;
            if (worker_list.RowCount == 0)//if list is empty
            {
                MessageBox.Show("חובה לבחור עובד");
                return;
            }
            work_list.Items.Clear();
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Id.Equals(worker_list.SelectedCells[0].Value.ToString()) && users[i].Work_days.Contains(monthCalendar1.SelectionRange.Start.ToShortDateString()))
                {
                    users[i].Work_days = users[i].Work_days.Replace(monthCalendar1.SelectionRange.Start.ToShortDateString(), "");
                    User_data.Update_employee_workdays(users[i]);
                    found_flag = 1;
                }
            }
            if (found_flag == 0)
            {
                MessageBox.Show(worker_list.SelectedCells[1].Value.ToString() + "\nאין לו משמרת ביום הזה");
                return;
            }
            Show_employeelist();
        }

        private void user_fullname_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(user_fullname.Text))//if only contains white spaces or null
            {
                user_fullname.Text = "";
            }
        }

        private void user_phone_TextChanged(object sender, EventArgs e)
        {
            long count;//for check only

            if (user_phone.Text.Length != 0)
            {
                bool isint = long.TryParse(user_phone.Text, out count);//check
                if (!isint)
                {
                    MessageBox.Show(" !חובה להזין רק מספרים ");
                    user_phone.Text = "";
                    return;
                }
            }
        }

        private void user_mail_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(user_mail.Text))//if only contains white spaces or null
            {
                user_mail.Text = "";
            }
        }

        private void user_newpassword_TextChanged(object sender, EventArgs e)
        {
            if (user_newpassword.Text.Length == 0)//if password is 0
            {
                re_password.Enabled = false;
                password_l.Enabled = false;
                return;
            }
            /*active re type password field*/
            re_password.Enabled = true;
            password_l.Enabled = true;
        }

        private void print_workdays_Click(object sender, EventArgs e)
        {
            Reportmaker report = new Reportmaker();
            
            report.workschedule_report(" סידור עבודה חודשי", dateforfilename, users);
        }

        private void Reset_btn_Click(object sender, EventArgs e)
        {
            if (flag_inuse == 1)
            {
                MessageBox.Show("חובה לשחרר קופה כדי לשתמש");
                return;
            }
            messages();
            Show_employeelist();
            add_user_info(login_info);//re add new info
            user_oldpassword.Text = "";
            user_newpassword.Text = "";
            re_password.Text = "";
        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void print_rec_Click(object sender, EventArgs e)
        {
            if (receipt_info.Items.Count == 0)//check if list is empty
            {
                MessageBox.Show(" חובה לבחור קבלה");
                return;
            }

            Reportmaker print = new Reportmaker();
            print.printPDFWithAcrobat(receipt_list.SelectedCells[0].Value.ToString());

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
    }



