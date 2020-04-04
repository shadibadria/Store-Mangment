using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Control.Categorys
{
    class Category_control:DataBase_Connection
    {

        /*****************************************************************/
        /*                       Control Center                         */
        /***************************************************************/

        private static string conString;
        private static Category_control instance;
        private Category_control(string conString) : base(conString)
        { }
        public static Category_control Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Category_control(conString);
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
        /*                      Category control                         */
        /***************************************************************/

        /*insert new categroy*/
        public void Insertcategory(Category item)
        {
            string cmdstr = "INSERT INTO Category(Category_name,Category_info)VALUES(@categoryname,@categoryinfo)";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                
                command.Parameters.AddWithValue("@categoryname", item.Name.ToString());//insert categoryname
                command.Parameters.AddWithValue("@categoryinfo", item.Info.ToString());//insert category info    
                base.ExecuteSimpleQuery(command);
            }
        }

        /*Delete category perment*/
        public void deletecategory(string item)
        {
            string cmdstr = "DELETE * FROM Category WHERE Category_code=@categorycode";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@categorycode", item);//delete by code
                base.ExecuteSimpleQuery(command);
            }
        }
        /*update selected category*/
        public void Updatecategory(Category item)
        {
            string cmdstr = "UPDATE Category SET Category_name=@name,Category_info=@info WHERE Category_code=@code";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@name", item.Name);//update name
                command.Parameters.AddWithValue("@info", item.Info);//update info
                command.Parameters.AddWithValue("@code", item.Code);//update code
                base.ExecuteSimpleQuery(command);
            }
        }

        /*Get all Category data */
        public Category[] GetCategory()
        {
            DataSet ds = new DataSet();
            ArrayList products_list = new ArrayList();
            string cmdStr = "SELECT * FROM Category";
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
                Category category = new Category();
                category.Name = tTYPE[0].ToString();//name of Category
                category.Code = tTYPE[1].ToString();//id/code of category
                category.Info = tTYPE[2].ToString();//info of category             
                products_list.Add(category);//add categorys
            }
            return (Category[])products_list.ToArray(typeof(Category));
        }





    }
}
