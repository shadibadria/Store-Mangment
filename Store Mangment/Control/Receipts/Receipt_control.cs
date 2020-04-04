using Store_Mangment.Model.Receipts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Control.Receipts
{
    class Receipt_control:DataBase_Connection
    {
        /*****************************************************************/
        /*                       Control Center                         */
        /***************************************************************/

        private static string conString;
        private static Receipt_control instance;
        private Receipt_control(string conString) : base(conString)
        { }
        public static Receipt_control Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Receipt_control(conString);
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
        /*                      Receipt control                         */
        /***************************************************************/
        ///*Get all employee data*/
        public Receipt[] getallReceipt()
        {
            DataSet ds = new DataSet();
            ArrayList receipt_list = new ArrayList();
            string cmdStr = "SELECT * FROM Receipt_List";
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
                Receipt receiptinfo = new Receipt();
                receiptinfo.Receipt_code = tTYPE[0].ToString();//receipt code
                DateTime oDate = DateTime.Parse(tTYPE[1].ToString());
                receiptinfo.Receipt_date = oDate.ToString("dd/MM/yyyy");
                receiptinfo.Receipt_info = tTYPE[2].ToString();
                receiptinfo.Receipt_return = bool.Parse(tTYPE[3].ToString());
                receiptinfo.Total_cost = double.Parse(tTYPE[4].ToString());//cost
                receiptinfo.Product_amounts = int.Parse(tTYPE[5].ToString());
                receiptinfo.Worker_name = tTYPE[6].ToString();


                receipt_list.Add(receiptinfo);
            }
            return (Receipt[])receipt_list.ToArray(typeof(Receipt));//return
        }
        /*function to insert new recipt to database*/
        public void insert_Receipt(Receipt item)
        {
            string cmdstr = "INSERT INTO Receipt_List(Receipt_date,Receipt_info,Receipt_returns,total_cost,product_amount,worker_name)VALUES(@date,@info,@returns,@cost,@amount,@worker)";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@date", item.Receipt_date);//insert date
                command.Parameters.AddWithValue("@info,", item.Receipt_info);//insert info
                command.Parameters.AddWithValue("@returns", item.Receipt_return);
                command.Parameters.AddWithValue("@cost", item.Total_cost);//cost
                command.Parameters.AddWithValue("@amount", item.Product_amounts);//amount
                command.Parameters.AddWithValue("@worker", item.Worker_name);//inset worker
                base.ExecuteSimpleQuery(command);
            }
        }
        /*update recipt info*/
        public void update_Receipt(Receipt item)
        {
            string cmdstr = "UPDATE Receipt_List SET Receipt_info=@info,Receipt_returns=@retstate WHERE Receipt_code=@code";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@info", item.Receipt_info);//update logindate
                command.Parameters.AddWithValue("@retstate", item.Receipt_return);//update record add to record login date.             
                command.Parameters.AddWithValue("@code", item.Receipt_code);//search by id
                base.ExecuteSimpleQuery(command);
            }
        }


    }
}
