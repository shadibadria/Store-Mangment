using Store_Mangment.Control;
using Store_Mangment.Control.Categorys;
using Store_Mangment.Control.Products_control;
using Store_Mangment.Control.Suppliers;
using Store_Mangment.Model;
using Store_Mangment.view.Categorys;
using Store_Mangment.view.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Mangment.view.products
{
    public partial class Update_product : Form
    {

        private Product_control Product_data;
        private Category_control Category_data;
        private Supplier_control Supplier_data;

        private Product[] product_list;
        private Category[] categorys_list;
        private Supplier[] suppliers_list;

        public Update_product(Product[] product)
        {
            InitializeComponent();
            /*database path&&connection*/
            string dbpath = Application.StartupPath + @"\StoreData.accdb";
            Product_control.ConnectionString = dbpath;
            Product_data = Product_control.Instance;
            Category_control.ConnectionString = dbpath;
            Category_data = Category_control.Instance;

            Supplier_control.ConnectionString = dbpath;
            Supplier_data = Supplier_control.Instance;
            this.product_list = product;
           
            displaydataboxs();
        }

        /*display data boxs category ,supplier*/
        public void displaydataboxs()
        {
            categorys_list = Category_data.GetCategory();//get category data
            suppliers_list = Supplier_data.Getsupplierinfo();//get supplier data
            display_category.Items.Clear();
            /*get category to box*/
            for (int i = 0; i < categorys_list.Length; i++)
            {
                display_category.Items.Add(categorys_list[i].Name.ToString());
            }
            display_category.SelectedIndex = 0;//get the first value in category list

            displaysupplier.Items.Clear();

            /*display suppliers list in box*/
            for (int i = 0; i < suppliers_list.Length; i++)
            {
                displaysupplier.Items.Add(suppliers_list[i].Name);
            }
            displaysupplier.SelectedIndex = 0;//display first supplier index
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
        /*only dispaly categorybox*/
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
        /*display product selected*/
        public void display_product(Product product)
        {
            display_category.Text = (product.Categoryname);
            displaysupplier.Text = product.Suppliername;
            product_code.Text = product.Product_id;
            product_name.Text = product.Product_name;
            product_price.Text = product.Price.ToString();
            product_count.Text = product.Product_count.ToString();
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;//get image
            barcodepictrue.Image = barcode.Draw(product_code.Text, 20);
        }

        private void newcategory_Click(object sender, EventArgs e)
        {
            Add_category newcategory = new Add_category();
            newcategory.ShowDialog();
            display_categorybox();
        }

        private void newsupplier_Click(object sender, EventArgs e)
        {
            Add_supplier newsupplier = new Add_supplier();
            newsupplier.ShowDialog();
            display_supplierbox();
        }

        private void print_barcode_Click(object sender, EventArgs e)
        {
            PrintDialog print_barcode = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            print_barcode.Document = doc;
            if (print_barcode.ShowDialog() == DialogResult.OK)
                doc.Print();
        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(barcodepictrue.Width, barcodepictrue.Height);
            barcodepictrue.DrawToBitmap(bm, new Rectangle(0, 0, barcodepictrue.Width, barcodepictrue.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }
        private void donebtn_Click(object sender, EventArgs e)
        {
            if (product_name.Text.Length == 0 || product_price.Text.Length == 0 || product_count.Text.Length == 0 || displaysupplier.Text.Length == 0 || display_category.Text.Length == 0)//check if all fields are inserted
            {
                MessageBox.Show("חובה להזין כל הפרטים");
                return;
            }


            Product product = new Product();
            product.Product_id = product_code.Text;
            product.Product_name = product_name.Text;
            product.Categoryname = display_category.Text;
            product.Price = double.Parse(product_price.Text);
            product.Suppliername = displaysupplier.Text;
            product.Product_count = int.Parse(product_count.Text);
           Product_data.updateproduct(product);
            MessageBox.Show("המוצר עודכן בהצלחה");

            this.Close();
        }

        private void product_count_TextChanged(object sender, EventArgs e)
        {
            long count;
            if (product_count.Text.Length != 0)
            {
                bool isint = long.TryParse(product_count.Text, out count);//if count filed only number
                if (!isint)
                {
                    MessageBox.Show(" !חובה להזין רק מספרים ");
                    product_count.Text = "";
                    return;
                }

                if (long.Parse(product_count.Text) <= 0)
                {
                    MessageBox.Show(" כמות חייבת להיות יותר מ 0 ");
                    product_count.Text = "";
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
                    MessageBox.Show(" מחיר חייב להיות יותר מ 0 ");
                    product_price.Text = "";
                    return;
                }
            }
        }

        private void product_name_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(product_name.Text))//if only contains white spaces or null
            {
                product_name.Text = "";
            }
        }

        private void Update_product_Load(object sender, EventArgs e)
        {

        }
    }
}
