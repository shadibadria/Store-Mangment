using Store_Mangment.Control.Categorys;
using Store_Mangment.Control.Products_control;
using Store_Mangment.Control.Suppliers;
using Store_Mangment.Model;
using Store_Mangment.view.Categorys;
using Store_Mangment.view.Suppliers;
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

namespace Store_Mangment.view
{
    public partial class Add_product : Form
    {
        private Product_control product_data;//database
        private ArrayList productinthelist = new ArrayList();//product arraylist
        private Category_control Category_data;//database
        private Supplier_control Supplier_data;//database
        private int rowsize = 0;
        private Product[] products;
      //  private Products[] products;//product array

        public Add_product()
        {
            InitializeComponent();
            string dbpath = Application.StartupPath + @"\StoreData.accdb";
            Product_control.ConnectionString = dbpath;
            product_data = Product_control.Instance;
            Category_control.ConnectionString = dbpath;
            Category_data = Category_control.Instance;

            Supplier_control.ConnectionString = dbpath;
            Supplier_data = Supplier_control.Instance;

            Displayboxs();//display boxs         
        }
        /*Display boxs combobox*/
        private void Displayboxs()
        {
            Category[] category_arr;
            category_arr = Category_data.GetCategory();//category data
            products = product_data.GetproductData();//product data
            displaysupplier.Items.Clear();//clear suppliers
            Supplier[] supplierinfo = Supplier_data.Getsupplierinfo();//get supplier data
            foreach (Supplier i in supplierinfo)
            {
                displaysupplier.Items.Add(i.Name);//add supplier name to box
            }
            display_category.Items.Clear();
            /*getting data category and add it to the cells*/
            foreach (Category i in category_arr)
            {
                display_category.Items.Add(i.Name.ToString());//add to category box name of category
            }
        }
        /*Only Display Supplier box*/
        private void display_supplierbox()
        {
            displaysupplier.Items.Clear();//clear suppliers
            Supplier[] supplierinfo = Supplier_data.Getsupplierinfo();//get supplier data
            foreach (Supplier i in supplierinfo)
            {
                displaysupplier.Items.Add(i.Name);//add supplier name to box
            }
        }
        /*only display categorybox*/
        private void display_categorybox()
        {
            Category[] category_arr;
            display_category.Items.Clear();
            category_arr = Category_data.GetCategory();//category data
            /*getting data category and add it to the cells*/
            foreach (Category i in category_arr)
            {
                display_category.Items.Add(i.Name.ToString());//add to category box name of category
            }
        }
        private void add_product_Load(object sender, EventArgs e)
        {

        }
        /*add to pending list*/
        private void add_producttolist()
        {           /*check if all is filled*/

            if (display_category.Text.Length == 0 || displaysupplier.Text.Length == 0 || product_name.Text.Length == 0
             || product_price.Text.Length == 0 || productcount.Text.Length == 0 || productcode.Text.Length == 0)
            {
                MessageBox.Show("! חובה להזין כל השדות");
                return;
            }
            if (int.Parse(productcount.Text) <= 0)
            {
                MessageBox.Show("כמות חייבת להיות 1 או יותר");
                return;
            }

            Product product = new Product();
            addproductbtn.Enabled = true;
            product.Product_name = product_name.Text;//add name
            product.Price = double.Parse(product_price.Text);//add price
            product.Categoryname = display_category.Text;//add category
            product.Product_count = int.Parse(productcount.Text);//add product count
            product.Product_amount = int.Parse(productcount.Text);//add product amount
            product.Suppliername = displaysupplier.Text;//add product supplier
            product.Product_id = productcode.Text;//add product id

            for (int i = 0; i < products.Length; i++)//check if product exsist in the dataBase
            {
                if (products[i].Product_id.Equals(productcode.Text))//if exsist
                {
                    MessageBox.Show("! קוד מוצר קיים כבר");
                    productcode.Text = "";
                    return;
                }
                if (products[i].Product_name.Equals(product_name.Text))//if exsist
                {
                    MessageBox.Show("! שם מוצר קיים כבר");
                    product_name.Text = "";
                    return;
                }
            }

            foreach (Product i in productinthelist)//check if product exsist in the pending list
            {
                if (i.Product_id.Equals(productcode.Text))
                {
                    MessageBox.Show("! קוד מוצר קיים כבר");
                    productcode.Text = "";
                    return;
                }
                if (i.Product_name.Equals(product_name.Text))
                {
                    MessageBox.Show("! שם מוצר קיים כבר");
                    product_name.Text = "";
                    return;
                }
            }
            productinthelist.Add(product);//add product
                                          /*add to list*/
            add_productlist.Rows.Add();//add new row
            add_productlist.Rows[rowsize].Cells[0].Value = product.Product_id.ToString();
            add_productlist.Rows[rowsize].Cells[1].Value = product.Product_name.ToString();
            add_productlist.Rows[rowsize].Cells[2].Value = product.Price.ToString();
            add_productlist.Rows[rowsize].Cells[3].Value = product.Product_amount;
            add_productlist.Rows[rowsize++].Cells[4].Value = product.Suppliername;
            product_name.Text = "";
            product_price.Text = "";
            productcode.Text = "";
            productcount.Text = "";

        }

        /*remove single product from list*/
        private void remove_productfromlist()
        {
            if (add_productlist.RowCount != 0)
            {
                foreach (Product i in productinthelist)//find the product we want to remove
                {
                    if (i.Product_id.Equals(add_productlist.SelectedCells[0].Value.ToString()))
                    {
                        productinthelist.Remove(i);//remove 
                        break;
                    }
                }
                add_productlist.Rows.RemoveAt(add_productlist.CurrentCell.RowIndex);//remove from list
                add_productlist.Refresh();
                rowsize = add_productlist.Rows.Count;//update rowsize
            }
            else
            {
                MessageBox.Show("אין מוצרים");
            }
        }
     

        private void addtolistbtn_Click_1(object sender, EventArgs e)
        {
            add_producttolist();//call function

        }
     

        
        private void removefromlist_Click_1(object sender, EventArgs e)
        {
            remove_productfromlist();

        }

        private void addproductbtn_Click_1(object sender, EventArgs e)
        {
            if (add_productlist.RowCount != 0)//if list is not empty
            {
                string message = "האם אתה בטוח להוסיף את המוצרים?";//message
                string title = "הוספת מוצרים ";//title
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    foreach (Product i in productinthelist)//add to inventory 
                    {
                        product_data.InsertProduct(i);//insert product
                    }
                    MessageBox.Show("!!המוצרים נוספו בהצלחה");
                    this.Close();
                }
            }
            else//list is empty
            {
                MessageBox.Show("אין מוצרים ברשימה");
            }
        }

        private void cancelallproduct_Click_1(object sender, EventArgs e)
        {
            if (add_productlist.RowCount != 0)
            {
                productinthelist.Clear();
                add_productlist.Rows.Clear();//cllear all products
                add_productlist.Refresh();
                rowsize = add_productlist.Rows.Count;//update row size
            }
            else
            {
                MessageBox.Show("אין מוצרים לבטל");
            }
        }

        private void add_newcategory_Click_1(object sender, EventArgs e)
        {
            Add_category addcategory = new Add_category();

            addcategory.ShowDialog();
            display_categorybox();
        }

        private void newsupplier_Click_1(object sender, EventArgs e)
        {
            Add_supplier newsupplier = new Add_supplier();
            newsupplier.ShowDialog();
            display_supplierbox();
        }

        private void productcount_TextChanged_1(object sender, EventArgs e)
        {
            long count;
            if (productcount.Text.Length != 0)
            {
                bool isint = long.TryParse(productcount.Text, out count);//if count filed only number
                if (!isint)
                {
                    MessageBox.Show(" !חובה להזין רק מספרים ");
                    productcount.Text = "";
                    return;
                }
            }
        }

        private void product_price_TextChanged(object sender, EventArgs e)
        {
            double price;
            if (product_price.Text.Length != 0)
            {
                bool isDouble = Double.TryParse(product_price.Text, out price);//if price is double
                if (!isDouble)
                {
                    MessageBox.Show(" ! חובה להזין רק מספרים ");
                    product_price.Text = "";
                    return;
                }

                if (double.Parse(product_price.Text) <= 0)
                {
                    MessageBox.Show(" מחיר חייב להיות גדול מ0 ");
                    product_price.Text = "";
                    return;
                }
            }
        }

        private void add_productlist_DoubleClick(object sender, EventArgs e)
        {
            foreach (Product i in productinthelist)
            {
                if (i.Product_id.Equals(add_productlist.SelectedCells[0].Value.ToString()))//if product found
                {
                    /*add fields*/
                    product_name.Text = i.Product_name;
                    product_price.Text = i.Price.ToString();
                    display_category.Text = i.Categoryname;
                    productcount.Text = i.Product_count.ToString();
                    displaysupplier.Text = i.Suppliername;
                    productcode.Text = i.Product_id;
                    break;
                }
            }
            remove_productfromlist();//remove product from list
        }

        private void product_name_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(product_name.Text))//if only contains white spaces or null
            {
                product_name.Text = "";
            }
        }

        private void productcode_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(productcode.Text))//if only contains white spaces or null
            {
                productcode.Text = "";
            }
        }
    }
}
