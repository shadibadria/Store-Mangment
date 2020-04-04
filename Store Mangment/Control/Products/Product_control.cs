using Store_Mangment.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Control.Products_control
{
    class Product_control : DataBase_Connection
    {
        /*****************************************************************/
        /*                       Control Center                         */
        /***************************************************************/

        private static string conString;
        private static Product_control instance;
        private Product_control(string conString) : base(conString)
        { }
        public static Product_control Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Product_control(conString);
                }
                return instance;
            }
        }
        public static string ConnectionString
        {
            get
            {
                return conString;
            }
            set
            {
                conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + value + ";Persist Security Info=False;";
            }
        }


        /*****************************************************************/
        /*                      product control                          */
        /***************************************************************/

        /*function to add product to products list*/
        public void InsertProduct(Product item)
        {
            string cmdstr = "INSERT INTO Products(Product_code,Product_name,Product_price,Category,supplier_name,Product_count,monthly_sold,sold,Product_amount,product_adddate,weekly_sold)VALUES(@productcode,@productname,@productprice,@categoryname,@suppliername,@productcount,@monthlysold,@sold,@amount,@adddate,@weekly_sold)";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@productcode", item.Product_id);//insert product id
                command.Parameters.AddWithValue("@productname", item.Product_name.ToString());//insert product name
                command.Parameters.AddWithValue("@productprice", item.Price.ToString());//insert price of product
                command.Parameters.AddWithValue("@categoryname", item.Categoryname.ToString());//insert category of product
                command.Parameters.AddWithValue("@suppliername", item.Suppliername.ToString());//insert supplier of product
                command.Parameters.AddWithValue("@productcount", item.Product_count.ToString());//insert product count(how mach products exsist)
                command.Parameters.AddWithValue("@monthlysold", 0);//count how mach sold in month
                command.Parameters.AddWithValue("@sold", item.Sold);//checks if product is sold 
                command.Parameters.AddWithValue("@amount", item.Product_amount.ToString());//insert amount of product , it never change
                command.Parameters.AddWithValue("@adddate", item.Adddate);//insert the add date of product
                command.Parameters.AddWithValue("@weeklysold", 0);//count how mach sold in weeks

                base.ExecuteSimpleQuery(command);
            }
        }

        /*Get all product Info(but not sold product)*/
        public Product[] GetproductData()
        {
            DataSet ds = new DataSet();
            ArrayList products_list = new ArrayList();//list of product
            string cmdStr = "SELECT * FROM Products  WHERE sold=false";
            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultiPleQuery(command);
            }
            DataTable dt = new DataTable();
            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tTYPE in dt.Rows)
            {
               
                    Product product = new Product();
                    product.Product_id = tTYPE[1].ToString();//product code/id
                    product.Price = Convert.ToDouble(tTYPE[2].ToString());//price of product
                    product.Categoryname = tTYPE[3].ToString();//name of category
                    product.Product_name = tTYPE[4].ToString();//name of product
                    product.Suppliername = tTYPE[5].ToString();//name of supplier
                    product.Product_count = int.Parse(tTYPE[6].ToString());//count of product in inventory
                    product.Product_monthlycount = int.Parse(tTYPE[7].ToString());//monthly product sold
                    product.Sold = bool.Parse(tTYPE[8].ToString());//sold status
                    product.Product_amount = int.Parse(tTYPE[9].ToString());//amount of product
                    product.Adddate = tTYPE[10].ToString();//the add date of product + time
                    product.Product_weeklycount = int.Parse(tTYPE[12].ToString());//weekly product sold
                    product.Product_sellrecord = tTYPE[13].ToString();
                    products_list.Add(product);//add to list
                

            }
            return (Product[])products_list.ToArray(typeof(Product));
        }

        /*Get all product data with sold products*/
        public Product[] GetsoldproductData()
        {
            DataSet ds = new DataSet();
            ArrayList products_list = new ArrayList();
            string cmdStr = "SELECT * FROM Products";
            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultiPleQuery(command);
            }
            DataTable dt = new DataTable();
            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tTYPE in dt.Rows)
            {


                Product product = new Product();
                product.Product_id = tTYPE[1].ToString();//product code/id
                product.Price = Convert.ToDouble(tTYPE[2].ToString());//price of product
                product.Categoryname = tTYPE[3].ToString();//name of category
                product.Product_name = tTYPE[4].ToString();//name of product
                product.Suppliername = tTYPE[5].ToString();//name of supplier
                product.Product_count = int.Parse(tTYPE[6].ToString());//count of product in inventory
                product.Product_monthlycount = int.Parse(tTYPE[7].ToString());//monthly product sold
                product.Sold = bool.Parse(tTYPE[8].ToString());//sold status
                product.Product_amount = int.Parse(tTYPE[9].ToString());//amount of product
                product.Adddate = tTYPE[10].ToString();//the add date of product + time
                product.Solddate = tTYPE[11].ToString();//the add date of product + time

                product.Product_weeklycount = int.Parse(tTYPE[12].ToString());//weekly product sold
                product.Product_sellrecord = tTYPE[13].ToString();
                products_list.Add(product);//add to list

            }
            return (Product[])products_list.ToArray(typeof(Product));
        }

        /*Get all product data with sold products*/
        public Product[] Getonlysold()
        {
            DataSet ds = new DataSet();
            ArrayList products_list = new ArrayList();
            string cmdStr = "SELECT * FROM Products WHERE sold=true";
            using (OleDbCommand command = new OleDbCommand(cmdStr))
            {
                ds = GetMultiPleQuery(command);
            }
            DataTable dt = new DataTable();
            try
            {
                dt = ds.Tables[0];
            }
            catch { }
            foreach (DataRow tTYPE in dt.Rows)
            {


                Product product = new Product();
                product.Product_id = tTYPE[1].ToString();//product code/id
                product.Price = Convert.ToDouble(tTYPE[2].ToString());//price of product
                product.Categoryname = tTYPE[3].ToString();//name of category
                product.Product_name = tTYPE[4].ToString();//name of product
                product.Suppliername = tTYPE[5].ToString();//name of supplier
                product.Product_count = int.Parse(tTYPE[6].ToString());//count of product in inventory
                product.Product_monthlycount = int.Parse(tTYPE[7].ToString());//monthly product sold
                product.Sold = bool.Parse(tTYPE[8].ToString());//sold status
                product.Product_amount = int.Parse(tTYPE[9].ToString());//amount of product
                product.Adddate = tTYPE[10].ToString();//the add date of product + time
              //  DateTime oDate = DateTime.Parse(tTYPE[11].ToString());

                product.Solddate = tTYPE[11].ToString();//get date of last sell of the product
                product.Product_weeklycount = int.Parse(tTYPE[12].ToString());//weekly product sold
                product.Product_sellrecord = tTYPE[13].ToString();
                products_list.Add(product);//add to list

            }
            return (Product[])products_list.ToArray(typeof(Product));
        }

        /*Delete product in database forever */
        public void deleteproduct(string item)
        {
            string cmdstr = "DELETE * FROM Products WHERE Product_code=@productcode";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@productcode", item);//sending values to delete by code
                base.ExecuteSimpleQuery(command);
            }
        }
        /*update product count function */
        public void updateproductcount(string code, int count, string selldate)//update product count
        {
            string cmdstr = "UPDATE Products SET Product_count=@count,product_solddate=@date WHERE Product_code=@productcode";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@count", count);//update count of product
                command.Parameters.AddWithValue("@date", selldate);//update last time there was a sell
                command.Parameters.AddWithValue("@productcode", code);//use code to search for product
                base.ExecuteSimpleQuery(command);
            }
        }
        /*update sold record*/
        public void update_productsoldrecord(string code, string record)
        {
            string cmdstr = "UPDATE Products SET product_soldrecord=@date WHERE Product_code=@productcode";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@date", record);//update count of product
                command.Parameters.AddWithValue("@productcode", code);//use code to search for product
                base.ExecuteSimpleQuery(command);
            }
        }
        /*update product monthly sold*/
        public void updatemonthlysold(string code, int monthlysold)//update product count
        {
            string cmdstr = "UPDATE Products SET monthly_sold=@monthlysold WHERE Product_code=@productcode";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {

                command.Parameters.AddWithValue("@monthlysold", monthlysold);//use code to search for product            
                command.Parameters.AddWithValue("@productcode", code);//use code to search for product           
                base.ExecuteSimpleQuery(command);
            }
        }
        /*update product weekly sold*/
        public void updateweeklysold(string code, int weeklysold)//update product count
        {
            string cmdstr = "UPDATE Products SET weekly_sold=@weeklysold WHERE Product_code=@productcode";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@weeklysold", weeklysold);//use code to search for product            
                command.Parameters.AddWithValue("@productcode", code);//use code to search for product           
                base.ExecuteSimpleQuery(command);
            }
        }
        /*update selected product */
        public void updateproduct(Product item)
        {
            string cmdstr = "UPDATE Products SET supplier_name=@suppliername,Product_price=@productprice,Category=@categoryname,Product_name=@productname,Product_count=@productcount WHERE Product_code=@productcode";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@suppliername", item.Suppliername.ToString());//update supplier name
                command.Parameters.AddWithValue("@productprice", item.Price.ToString());//update price of product
                command.Parameters.AddWithValue("@categoryname", item.Categoryname.ToString());//update category of product
                command.Parameters.AddWithValue("@productname", item.Product_name.ToString());//update product name
                command.Parameters.AddWithValue("@productcount", item.Product_count.ToString());//update product count(how mach products exsist)
                command.Parameters.AddWithValue("@productcode", item.Product_id.ToString());//update supplier of product
                base.ExecuteSimpleQuery(command);
            }
        }
        /*update product status to sold when reach 0 */
        public void updateproductsold(string code, bool status, string solddate)
        {
            string cmdstr = "UPDATE Products SET sold=@sold,product_solddate=@date WHERE Product_code=@productcode";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@sold", status);    //update status sold 
                command.Parameters.AddWithValue("@date", solddate);    //update status sold date
                command.Parameters.AddWithValue("@productcode", code);    //code to search for product
                base.ExecuteSimpleQuery(command);
            }
        }

    }
}
