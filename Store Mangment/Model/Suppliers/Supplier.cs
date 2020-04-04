using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Control.Suppliers
{
    public class Supplier
    {
        private string name;//supplier name
        private string adress;//supplier adress
        private string phone;//supplier phone
        private string email;//supplier email
        private string id;//supplier id

        /*Empty Constructor for Suppliers*/
        public Supplier()
        {

        }
        /*Supplier Constructor*/
        public string Name { get => name; set => name = value; }
        public string Adress { get => adress; set => adress = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Id { get => id; set => id = value; }
    }
}
