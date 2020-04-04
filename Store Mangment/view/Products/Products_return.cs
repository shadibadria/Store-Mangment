using Store_Mangment.Control.Receipts;
using Store_Mangment.Model.Receipts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Mangment.view.products
{
    public partial class Products_return : Form
    {
        private string RCode;
        private Receipt_control Receipt_data;//database
        Receipt[] receiptsdata;
        string text;
        public Products_return(string code)
        {
            InitializeComponent();
            RCode = code;
            string dbpath = Application.StartupPath + @"\StoreData.accdb";//database data          
            Receipt_control.ConnectionString = dbpath;
            Receipt_data = Receipt_control.Instance;
            receiptsdata = Receipt_data.getallReceipt();
        }

        private void Products_return_Load(object sender, EventArgs e)
        {
            code.Text = RCode;//get code

        }

        private void return_productbtn_Click(object sender, EventArgs e)
        {
            if (returnproducts_text.Text.Length == 0)
            {
                MessageBox.Show("חובה להזין איזה מוצרים הוחזרו!! ");
                return;
            }
            text = "\n----------------------------------------" + "\nהמוצרים שהוזחרו הם: \n" + returnproducts_text.Text + "\n----------------------------------------\n";
            for (int i = 0; i < receiptsdata.Length; i++)
            {
                if (receiptsdata[i].Receipt_code.Equals(RCode))//if equal code
                {
                    receiptsdata[i].Receipt_return = true;
                    receiptsdata[i].Receipt_info += text;
                    Receipt_data.update_Receipt(receiptsdata[i]);
                    MessageBox.Show("בוצע בהצלחה");
                    this.Close();
                }

            }
        }
    }
}
