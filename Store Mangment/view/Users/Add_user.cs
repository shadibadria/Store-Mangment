using Store_Mangment.Control.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Mangment.view.Users
{
    public partial class Add_user : Form
    {
        private User_control User_data;//database
        private User[] all_employee;//order data
        private User employee;//order data
        private string old_id;//old id to hellp us update new id at worker

        public Add_user()
        {
            InitializeComponent();
            string dbpath = Application.StartupPath + @"\StoreData.accdb";//database path
            User_control.ConnectionString = dbpath;
            User_data = User_control.Instance;
            all_employee = User_data.getemployeedata();//get employee data

        }
        public void employee_update(User update)
        {
            DateTime oDate = DateTime.Parse(update.Birthdate);//convert date to  DateTime 

            name.Text = update.Fullname;//display name
            id.Text = update.Id;//display id
            phone.Text = update.Phone;//display phone
            datepicker.Value = oDate;//display date
            mail.Text = update.Email;//email
            password.Text = update.Password;//password
            old_id = update.Id;//id
            done.Text = "עדכן";//change button to update
            header.Text = "עדכון עובד:";
            employee = update;
        }
        private void Add_user_Load(object sender, EventArgs e)
        {

        }
        private void add_user()
        {

            for (int i = 0; i < all_employee.Length; i++)
            {
                if (all_employee[i].Id.Equals(id.Text) || (all_employee[i].Phone.Equals(phone.Text)))//if employee exsist
                {
                    MessageBox.Show(" ! עובד קיים כבר");
                    id.Text = "";
                    return;
                }
            }
            User newemployee = new User();
            /*add info to employee*/
            newemployee.Fullname = name.Text;//add name
            newemployee.Id = id.Text;//add id
            newemployee.Phone = phone.Text;//add text
            newemployee.Birthdate = datepicker.Value.ToString("dd/MM/yyyy");//add date
            newemployee.Email = mail.Text;//add mail
            newemployee.Password = password.Text;//add password
            User_data.insert_employee(newemployee);//add new employee
            MessageBox.Show("עובד נוסף בהצלחה");
            this.Close();
        }

        private void done_Click(object sender, EventArgs e)
        {
            /*check if all fields are insert*/
            if (name.Text.Length <= 0 || id.Text.Length <= 0 || phone.Text.Length <= 0 || mail.Text.Length <= 0 || password.Text.Length <= 0)
            {
                MessageBox.Show("חובה להזין כל השדות");
                return;
            }

            if (done.Text == "עדכן")//if button update
            {
                /*add values to new employee*/
                employee.Fullname = name.Text;
                employee.Id = id.Text;
                employee.Phone = phone.Text;
                employee.Birthdate = datepicker.Value.ToString("dd/MM/yyyy");
                employee.Email = mail.Text;
                employee.Password = password.Text;

                for (int i = 0; i < all_employee.Length; i++)
                {
                    if (employee.Id.Equals(all_employee[i].Id) && old_id != all_employee[i].Id)//search if emoloyee exsist in database
                    {
                        MessageBox.Show(" ! עובד קיים כבר");
                        id.Text = "";
                        return;
                    }
                }
                User_data.Update_employee(employee, old_id);//update employee data
                MessageBox.Show("עובד עודכן בהצלחה");
                this.Close();

            }
            else//add employee
            {
                add_user();
            }
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            long count;

            if (id.Text.Length != 0)
            {
                bool isint = long.TryParse(id.Text, out count);//check if only digits
                if (!isint)
                {
                    MessageBox.Show(" !חובה להזין רק מספרים ");
                    id.Text = "";
                    return;

                }
            }
        }

        private void phone_TextChanged(object sender, EventArgs e)
        {
            long count;

            if (phone.Text.Length != 0)
            {
                bool isint = long.TryParse(phone.Text, out count);//if only digts
                if (!isint)
                {
                    MessageBox.Show(" !חובה להזין רק מספרים ");
                    phone.Text = "";
                    return;

                }
            }
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(name.Text))//if only contains white spaces or null
            {
                name.Text = "";
            }
        }

        private void mail_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(mail.Text))//if only contains white spaces or null
            {
                mail.Text = "";
            }
        }
    }
    }

