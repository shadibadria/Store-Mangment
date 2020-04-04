using Store_Mangment.Model.Taxes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Control.Taxes
{
    class Tax_control:DataBase_Connection
    {
        /*****************************************************************/
        /*                       Control Center                         */
        /***************************************************************/

        private static string conString;
        private static Tax_control instance;
        private Tax_control(string conString) : base(conString)
        { }
        public static Tax_control Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Tax_control(conString);
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
        /*                      Tax control                              */
        /***************************************************************/
        /*update tax info*/
        public void update_sale_tax(Tax item)
        {
            string cmdstr = "UPDATE taxes SET sales_tax=@tax WHERE index=@ind";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@tax", item.Sell_tax);//tax
                command.Parameters.AddWithValue("@ind", 1);//update index

                base.ExecuteSimpleQuery(command);
            }
        }
        /*get tax info data*/
        public Tax[] get_sale_tax()
        {
            DataSet ds = new DataSet();
            ArrayList sales_tax_list = new ArrayList();
            string cmdStr = "SELECT * FROM taxes";
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
                Tax taxes = new Tax();
                taxes.Sell_tax = int.Parse(tTYPE[0].ToString());//receipt code

                sales_tax_list.Add(taxes);
            }
            return (Tax[])sales_tax_list.ToArray(typeof(Tax));//return
        }

    }
}
