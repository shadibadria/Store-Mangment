using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Control.Orders
{
    public class Order
    {
        private string order_id;//order id
        private string order_name;//order rname
        private string order_date = DateTime.Now.ToString();//order date
        private string order_information;//order information
        private string supplier_name;//supplier name
                                     /*Getters && setters*/
        public string Order_id { get => order_id; set => order_id = value; }
        public string Order_date { get => order_date; set => order_date = value; }
        public string Supplier_name { get => supplier_name; set => supplier_name = value; }
        public string Order_information { get => order_information; set => order_information = value; }
        public string Order_name { get => order_name; set => order_name = value; }
    }
}
