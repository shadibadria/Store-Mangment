using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Control.Suppliers
{
    class Supplier_control:DataBase_Connection
    {
        /*****************************************************************/
        /*                       Control Center                         */
        /***************************************************************/

        private static string conString;
        private static Supplier_control instance;
        private Supplier_control(string conString) : base(conString)
        { }
        public static Supplier_control Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Supplier_control(conString);
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
        /*                      supplier control                         */
        /***************************************************************/
        ///*Get all suppliers data*/
        public Supplier[] Getsupplierinfo()
        {
            DataSet ds = new DataSet();
            ArrayList supplier_list = new ArrayList();
            string cmdStr = "SELECT * FROM Suppliers";
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
                Supplier supplier = new Supplier();
                supplier.Name = tTYPE[0].ToString();//name of supplier
                supplier.Adress = tTYPE[1].ToString();//supplier adress
                supplier.Phone = tTYPE[2].ToString();//supplier phone
                supplier.Email = tTYPE[3].ToString();//supplier email
                supplier.Id = tTYPE[4].ToString();//supplier id
                supplier_list.Add(supplier);
            }
            return (Supplier[])supplier_list.ToArray(typeof(Supplier));
        }
        /*function to insert new supplier to database*/
        public void Insertsupplier(Supplier item)
        {
            string cmdstr = "INSERT INTO Suppliers(supplier_name,supplier_adress,supplier_phone,supplier_email)VALUES(@name,@adress,@phone,@email)";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@name", item.Name.ToString());//insert name
                command.Parameters.AddWithValue("@adress", item.Adress);//insert adress
                command.Parameters.AddWithValue("@phone", item.Phone);//insert phone
                command.Parameters.AddWithValue("@email", item.Email);//insert email
                base.ExecuteSimpleQuery(command);
            }
        }
        /*Delete supplier*/
        public void deletesupplier(string item)
        {
            string cmdstr = "DELETE * FROM Suppliers WHERE supplier_name=@name";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@name", item);    //delete supplier by name(id)
                base.ExecuteSimpleQuery(command);
            }
        }
        /*update supplier information*/
        public void Updatesupplier(Supplier item)
        {
            string cmdstr = "UPDATE Suppliers SET supplier_name=@pname,supplier_adress=@adress,supplier_phone=@phone,supplier_email=@email WHERE supplier_id=@id";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@name", item.Name);//update name
                command.Parameters.AddWithValue("@adress", item.Adress);//update adress
                command.Parameters.AddWithValue("@phone", item.Phone);//update phone
                command.Parameters.AddWithValue("@email", item.Email);//update email
                command.Parameters.AddWithValue("@id", item.Id);//update id
                base.ExecuteSimpleQuery(command);
            }
        }

    }
}
