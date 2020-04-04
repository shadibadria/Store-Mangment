using Store_Mangment.Control.Users;
using Store_Mangment.Model.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Mangment.view
{
    public partial class Login : Form
    {
        private Thread th;//thread
        private User_control User_data;//database

        private User[] user;//employee array
        private User logininfo;//employee info
        private string user_password;
        private string manger_id;//manger id 
        private string user_email;
        public Login()
        {
            InitializeComponent();
            string dbpath;
            dbpath = Application.StartupPath + @"\Database\StoreData.accdb";

            User_control.ConnectionString = dbpath;
            User_data = User_control.Instance;
            manger_id = "admin";//manger id cant be changed
            user = User_data.getemployeedata();//get users info

        }

        private void Login_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void enterybtn_Click(object sender, EventArgs e)
        {
            if (username.Text.Length == 0 || password.Text.Length == 0)
            {
                MessageBox.Show("חובה להזין פרטים תז וסיסמה");
                return;
            }
            for (int i = 0; i < user.Length; i++)
            {
                if (username.Text.Equals(manger_id) && user[i].Id == manger_id)//if user is manger
                {
                    if (user[i].Password.Equals(password.Text))//if password correct
                    {
                        logininfo = user[i];//add to array
                        logininfo.Lastlogindate = DateTime.Now.ToString();//entery date
                        this.Close();
                        th = new Thread(adminform);//thread works and start form admin form
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();//start thread
                    }
                }
                else//not manger 
                {
                    if (user[i].Password.Equals(password.Text) && user[i].Id.Equals(username.Text))//if username is same and password
                    {
                        logininfo = user[i];
                        logininfo.Lastlogindate = DateTime.Now.ToString();//update logindate for record
                        this.Close();
                        th = new Thread(workerform);//new thread
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();//thread start
                        
                    }
                }
            }
            MessageBox.Show("אחד או יותר מהנתונים לא נכון");
            username.Text = "";
            password.Text = "";
        }

        private void adminform()
        {
            Application.Run(new Main(0, logininfo));//go to admin form
        }

        private void workerform()
        {
            Application.Run(new Main(1, logininfo));//go to worker form
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            clock.Text = DateTime.Now.ToLongTimeString();
            date.Text = DateTime.Now.ToLongDateString();
        }

        private void extbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string get_admin_mail()
        {
            for (int i = 0; i < user.Length; i++)
            {
                if(user[i].Id.Equals("admin"))
                {
                    return user[i].Email;
                }
            }
            return null;
        }
        /*check user info*/
        private int check_info()
        {
            for (int i = 0; i < user.Length; i++)
            {
                if(user[i].Id.Equals(email_addr.Text))
                {
                    user_password = user[i].Password;
                    user_email = user[i].Email;
                    return 1;
                }
            }
                return 0;
        }
        /*send mail*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (check_info() == 1)
            {
                string email = get_admin_mail();

                Mail newmail =new Mail("no", email, "sh1481963", user_email,"Password ",user_password);
                newmail.Sent_mail();
                MessageBox.Show("נשלח לדואר אלקטרוני");
                email_addr.Text = "";
            }
            else
            {
                if (email_addr.Text.Length == 0)
                {
                    MessageBox.Show("חובה להזין תעודת זהות");
                    email_addr.Text = "";

                }
                else
                {
                    MessageBox.Show("פרטים לא נכונים");
                    email_addr.Text = "";

                }

            }
        }
    }
}
