using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Control.Users
{
    public class User
    {
        private string id;//employee id
        private string fullname;//employee name
        private string phone;//employee phone 
        private string birthdate;//employee birthday
        private string email;//employee mail
        private string password;//employee password
        private string lastlogindate;//employee lastlogindate
        private string exit_hour;//time that emoloyee finishwork
        private string login_record;//employee
        private string work_days;
        /*constructor*/
        public User()
        {
            this.lastlogindate = DateTime.Now.ToString();//add today date
        }
        /*Getters && Setters*/
        public string Id { get => id; set => id = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
        public string Lastlogindate { get => lastlogindate; set => lastlogindate = value; }
        public string Login_record { get => login_record; set => login_record = value; }
        public string Exit_hour { get => exit_hour; set => exit_hour = value; }
        public string Work_days { get => work_days; set => work_days = value; }
    }
}
