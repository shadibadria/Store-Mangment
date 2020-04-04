using Store_Mangment.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Model
{
    public class Product
    {
      
        private string product_name;//product name
        private string product_id;//product id
        private double price;//prodcut price
        private string categoryname;//category name
        private string suppliername;//supplier name
        private int product_count;//product count
        private int product_monthlycount;//product monthly count
        private int product_weeklycount;//product weekly count
        private bool in_use = false;//if product is in use by other proccese
        private bool sold = false;//product sold or not
        private string adddate = DateTime.Now.ToString();//product add date
        private string solddate = DateTime.Now.ToString();//product add date
        private int product_amount;//product amount
        private string product_sellrecord;


        /*Getters && Setters*/
        public string Product_name { get => product_name; set => product_name = value; }
        public string Product_id { get => product_id; set => product_id = value; }
        public double Price { get => price; set => price = value; }
        public string Categoryname { get => categoryname; set => categoryname = value; }
        public string Suppliername { get => suppliername; set => suppliername = value; }
        public int Product_count { get => product_count; set => product_count = value; }
        public bool In_use { get => in_use; set => in_use = value; }
        public bool Sold { get => sold; set => sold = value; }
        public string Adddate { get => adddate; set => adddate = value; }
        public string Solddate { get => solddate; set => solddate = value; }
        public int Product_amount { get => product_amount; set => product_amount = value; }
        public int Product_monthlycount { get => product_monthlycount; set => product_monthlycount = value; }
        public int Product_weeklycount { get => product_weeklycount; set => product_weeklycount = value; }
        public string Product_sellrecord { get => product_sellrecord; set => product_sellrecord = value; }

        /*Empty Constructor*/
        public Product()
        {

        }

    



    }
}
