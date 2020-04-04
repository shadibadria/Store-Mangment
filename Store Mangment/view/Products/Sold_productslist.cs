using Store_Mangment.Control.Products_control;
using Store_Mangment.Model;
using Store_Mangment.Model.Reportmaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Mangment.view.products
{
    public partial class Sold_productslist : Form
    {
        /*database*/
        private Product_control Product_data;//database
        private string dbpath;//database path
        /*Products*/
        private Product[] products;//product data
        private int product_count = 0;
        private int row_index = 0;
        public Sold_productslist()
        {
            InitializeComponent();
            /*database path&&connection*/
            dbpath = Application.StartupPath + @"\Database\StoreData.accdb";
            Product_control.ConnectionString = dbpath;
            Product_data = Product_control.Instance;
            show_productlist();
        }

        private void show_productlist()
        {
            product_list.Rows.Clear();
            products = Product_data.Getonlysold();//get data from database
            product_count = 0;
            row_index = 0;//row index
            for (int i = 0; i < products.Length; i++)//add to table
            {
                if (products[i].Sold == true)
                {
                    product_list.Rows.Add();//add new row
                    product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                    product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                    product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                    product_list.Rows[row_index].Cells[3].Value = products[i].Product_amount.ToString();//add product count how many in inventory
                    product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                    product_list.Rows[row_index++].Cells[5].Value = products[i].Solddate;//add product supplier
                    product_count += products[i].Product_amount;//count products
                }
     
            }
            productcount.Text = product_count.ToString();//add to label 
        }
        private void Sold_productslist_Load(object sender, EventArgs e)
        {

        }

        private void searchbyname_TextChanged(object sender, EventArgs e)
        {
            product_list.Rows.Clear();
            /*getting data products and add it to the cells*/
            row_index = 0;
            product_list.Rows.Clear();
            products = Product_data.GetsoldproductData();//get data from database
            product_count = 0;
            row_index = 0;//row index
            for (int i = 0; i < products.Length; i++)//add to table
            {
                if (products[i].Product_name.StartsWith(searchbyname.Text))
                    {
                    product_list.Rows.Add();//add new row
                    product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                    product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                    product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                    product_list.Rows[row_index].Cells[3].Value = products[i].Product_amount.ToString();//add product count how many in inventory
                    product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                    product_list.Rows[row_index++].Cells[5].Value = products[i].Solddate;//add product supplier
                    product_count += products[i].Product_amount;//count products
                }
            }
            productcount.Text = product_count.ToString();//add to label 

        }

        private void searchbycode_TextChanged(object sender, EventArgs e)
        {
            product_list.Rows.Clear();
            /*getting data products and add it to the cells*/
            row_index = 0;
            product_list.Rows.Clear();
            products = Product_data.GetsoldproductData();//get data from database
            product_count = 0;
            row_index = 0;//row index
            for (int i = 0; i < products.Length; i++)//add to table
            {
                if (products[i].Product_id.StartsWith(searchbycode.Text))
                {
                    product_list.Rows.Add();//add new row
                    product_list.Rows[row_index].Cells[0].Value = products[i].Product_id.ToString();//add product id
                    product_list.Rows[row_index].Cells[1].Value = products[i].Product_name.ToString();//add product name
                    product_list.Rows[row_index].Cells[2].Value = products[i].Price.ToString();// add product price
                    product_list.Rows[row_index].Cells[3].Value = products[i].Product_amount.ToString();//add product count how many in inventory
                    product_list.Rows[row_index].Cells[4].Value = products[i].Suppliername;//add product supplier
                    product_list.Rows[row_index++].Cells[5].Value = products[i].Solddate;//add product supplier
                    product_count += products[i].Product_amount;//count products
                }
            }
            productcount.Text = product_count.ToString();//add to label 
        }

        private void soldp_btn_Click(object sender, EventArgs e)
        {
           string dateforfilename = DateTime.Today.ToString("dd,MM,yyyy");

            string title = "  מוצרים שאוזלו: ";
            string filename = "(" + dateforfilename + ")    " + "מוצרים .pdf";
            Product[] products_data;
            Reportmaker report = new Reportmaker();
            products_data = Product_data.Getonlysold();
            ArrayList temp = new ArrayList();
            double sumofproducts = 0;
            DateTime startdate = DateTime.Parse(soldproducts_sdate.Value.ToShortDateString());
            DateTime enddate = DateTime.Parse(soldproducts_edate.Value.ToShortDateString());
            int counter = 0;

            if (soldproducts_sdate.Value.CompareTo(soldproducts_edate.Value) > 0)//check if dates are correct
            {
                MessageBox.Show("לא יכול להיות תאריך התחלה יותר גדול מתאריך סוף");
                return;
            }

            for (int i = 0; i < products_data.Length; i++)
            {
                if (products_data[i].Sold == true)
                {

                    DateTime oDate = DateTime.Parse(products_data[i].Solddate.ToString());
                    int s_date = DateTime.Compare(startdate, oDate);
                    int e_date = DateTime.Compare(enddate, oDate);
                    if (s_date <= 0 && e_date >= 0)
                    {
                        temp.Add(products_data[i]);
                        sumofproducts += products_data[i].Price * products_data[i].Product_count;
                        counter++;
                    }
                }
            }
            products_data = (Product[])temp.ToArray(typeof(Product));
            report.product_report(title, filename, products_data, counter, 2, sumofproducts);//report
        }
    }
}
