using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Control.Users
{
    class User_control:DataBase_Connection
    {
        /*****************************************************************/
        /*                       Control Center                         */
        /***************************************************************/

        private static string conString;
        private static User_control instance;
        private User_control(string conString) : base(conString)
        { }
        public static User_control Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new User_control(conString);
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
        /*                      employee control                         */
        /***************************************************************/
        ///*Get all employee data*/
        public User[] getemployeedata()
        {
            DataSet ds = new DataSet();
            ArrayList employee_list = new ArrayList();
            string cmdStr = "SELECT * FROM employees";
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
                User employee = new User();
                DateTime oDate = DateTime.Parse(tTYPE[3].ToString());

                employee.Fullname = tTYPE[0].ToString();//employee name
                employee.Id = tTYPE[1].ToString();//employee id
                employee.Phone = tTYPE[2].ToString();//employee phone
                employee.Birthdate = oDate.ToString("dd/MM/yyyy");//employee birthday
                employee.Email = tTYPE[4].ToString();//employee email
                employee.Password = tTYPE[5].ToString();//employee password
                employee.Lastlogindate = tTYPE[6].ToString();//employee last login date
                employee.Login_record = tTYPE[7].ToString();//employee login record dates
                employee.Work_days = tTYPE[8].ToString();//employee login record dates
                employee_list.Add(employee);
            }
            return (User[])employee_list.ToArray(typeof(User));//return
        }
        /*function to insert new employee to database*/
        public void insert_employee(User item)
        {
            string cmdstr = "INSERT INTO employees(employee_name,employee_id,employee_phone,employee_dateofbirth,employee_email,employee_password)VALUES(@name,@id,@phone,@birhtdate,@email,@password)";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@name", item.Fullname);//insert name
                command.Parameters.AddWithValue("@id,", item.Id);//insert id
                command.Parameters.AddWithValue("@phone", item.Phone);//insert phone
                command.Parameters.AddWithValue("@birhtdate", item.Birthdate);//insert birthday
                command.Parameters.AddWithValue("@email", item.Email);//insert password
                command.Parameters.AddWithValue("@password", item.Password);//insert 

                base.ExecuteSimpleQuery(command);
            }
        }
        /*Delete employee*/
        public void delete_employee(string item)
        {
            string cmdstr = "DELETE * FROM employees WHERE employee_id=@id";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@id", item);    //delete employee by id
                base.ExecuteSimpleQuery(command);
            }
        }

        public void Update_employee_workdays(User employee)
        {
            string cmdstr = "UPDATE employees SET employee_workdays=@days WHERE employee_id=@id";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@days", employee.Work_days);//update fullname            
                command.Parameters.AddWithValue("@id", employee.Id);//sent id
                base.ExecuteSimpleQuery(command);
            }
        }
        /*update employee */
        public void Update_employee(User item, string oldid)
        {
            string cmdstr = "UPDATE employees SET employee_name=@name,employee_id=@id,employee_phone=@phone,employee_dateofbirth=@birth,employee_email=@email,employee_password=@pass WHERE employee_id=@oldid";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {

                command.Parameters.AddWithValue("@name", item.Fullname);//update fullname
                command.Parameters.AddWithValue("@id", item.Id);//update id
                command.Parameters.AddWithValue("@phone", item.Phone);//update phone
                command.Parameters.AddWithValue("@birth", item.Birthdate);//update birthday
                command.Parameters.AddWithValue("@email", item.Email);//update email
                command.Parameters.AddWithValue("@pass", item.Password);//update password
                command.Parameters.AddWithValue("@oldid", oldid);//sent id

                base.ExecuteSimpleQuery(command);
            }
        }

        /*update employee */
        public void Update_employee_loginrecord(string id, string loginrecord, string logindate, string exit_date)
        {
            string cmdstr = "UPDATE employees SET employee_lastlogin=@logindate,employee_login_record=@loginrecord WHERE employee_id=@id";
            using (OleDbCommand command = new OleDbCommand(cmdstr))
            {
                command.Parameters.AddWithValue("@logindate", logindate);//update logindate
                command.Parameters.AddWithValue("@loginrecord", loginrecord);//update record add to record login date.             
                command.Parameters.AddWithValue("@id", id);//search by id
                base.ExecuteSimpleQuery(command);
            }
        }


    }
}
