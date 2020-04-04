using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Model.Receipts
{
    public class Receipt
    {
        private string receipt_code;
        private string receipt_date;
        private string receipt_info;
        private bool receipt_return;
        private double total_cost;
        private int product_amounts;
        private string worker_name;

        public Receipt()
        {
            this.Receipt_return = false;
        }

        public string Receipt_code { get => receipt_code; set => receipt_code = value; }
        public string Receipt_date { get => receipt_date; set => receipt_date = value; }
        public string Receipt_info { get => receipt_info; set => receipt_info = value; }
        public bool Receipt_return { get => receipt_return; set => receipt_return = value; }
        public double Total_cost { get => total_cost; set => total_cost = value; }
        public int Product_amounts { get => product_amounts; set => product_amounts = value; }
        public string Worker_name { get => worker_name; set => worker_name = value; }
    }

}
