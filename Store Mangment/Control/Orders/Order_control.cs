using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Control.Orders
{
    class Order_control:DataBase_Connection
    {
        /*****************************************************************/
        /*                       Control Center                         */
        /***************************************************************/

        private static string conString;
        private static Order_control instance;
        private Order_control(string conString) : base(conString)
        { }
        public static Order_control Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Order_control(conString);
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
        /*                      orders control                          */
        /***************************************************************/
        ///*Get all order data*/
        public Order[] getorderdata()
        {
            DataSet ds = new DataSet();
            ArrayList order_list = new ArrayList();
            string cmdStr = "SELECT * FROM Orders";
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
                Order Orders = new Order();
                Orders.Order_id = tTYPE[0].ToString();//order id
                Orders.Order_name = tTYPE[1].ToString();//order name
                Orders.Order_date = tTYPE[2].ToString();//order date
                Orders.Order_information = tTYPE[3].ToString();//order information
                Orders.Supplier_name = tTYPE[4].ToString();//supplier name

                order_list.Add(Orders);
            }
            return (Order[])order_list.ToArray(typeof(Order));
        }
        /*function to insert new order to database*/
        public void insert_order(Order item)
        {
            string cmdstr = "INSERT INTO Orders(order_name,order_date,order_information,supplier_name)VALUES(@ordername,@date,@information,@suppliername)";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@ordername", item.Order_name);//insert name
                command.Parameters.AddWithValue("@date", item.Order_date);//insert date
                command.Parameters.AddWithValue("@information", item.Order_information);//insert information
                command.Parameters.AddWithValue("@suppliername", item.Supplier_name);//insert supplier name

                base.ExecuteSimpleQuery(command);
            }
        }
        /*Delete order*/
        public void delete_order(string item)
        {
            string cmdstr = "DELETE * FROM Orders WHERE order_id=@id";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@id", item);    //delete order by (id)
                base.ExecuteSimpleQuery(command);
            }
        }
        /*update Order information*/
        public void Update_order(Order item)
        {
            string cmdstr = "UPDATE Orders SET order_name=@name,order_information=@info,supplier_name=@suppliername WHERE order_id=@id";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@name", item.Order_name);//update name
                command.Parameters.AddWithValue("@info", item.Order_information);//update information
                command.Parameters.AddWithValue("@suppliername", item.Supplier_name);//update supplier name
                command.Parameters.AddWithValue("@id", item.Order_id);//update id
                base.ExecuteSimpleQuery(command);
            }
        }

    }
}
