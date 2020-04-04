using Store_Mangment.Control.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Mangment.view.Suppliers
{
    public partial class Add_supplier : Form
    {

        private Supplier_control Supplier_data;//database
        private Supplier[] supplier;//supplier array
        private string suppliername;
        private string supplier_id;





        public Add_supplier()
        {
            InitializeComponent();
            string dbpath = Application.StartupPath + @"\StoreData.accdb";//database path
            Supplier_control.ConnectionString = dbpath;
            Supplier_data = Supplier_control.Instance;
            supplier = Supplier_data.Getsupplierinfo();//get supplier info

        }


        /*display supplier info to update*/
        public void updatesupplier(Supplier supplier)
        {
            suppliername = supplier.Name;//add name
            supplier_name.Text = supplier.Name;//add name
            supplier_adress.Text = supplier.Adress;//add adress
            supplier_phone.Text = supplier.Phone;//add phone    
            supplier_email.Text = supplier.Email;//add mail
            supplier_id = supplier.Id;//add id
            donebtn.Text = "עדכן";//update button from add to update
            title.Text = "עדכן ספק:";//title
        }

        private void Add_supplier_Load(object sender, EventArgs e)
        {

        }

        private void donebtn_Click(object sender, EventArgs e)
        {
            Supplier suppliers = new Supplier();
            /*check if user insert all info*/
            if (supplier_name.Text.Length != 0 && supplier_phone.Text.Length != 0 && supplier_adress.Text.Length != 0 && supplier_email.Text.Length != 0)
            {
                if (donebtn.Text.Equals("עדכן"))//if it is update
                {
                    suppliers.Name = supplier_name.Text;//add name
                    suppliers.Adress = supplier_adress.Text;//add adress
                    suppliers.Phone = supplier_phone.Text;//add phone
                    suppliers.Email = supplier_email.Text;//add mail
                    suppliers.Id = supplier_id;//add id
                    for (int i = 0; i < supplier.Length; i++)
                    {
                        if (suppliername != supplier[i].Name && supplier_name.Text.Equals(supplier[i].Name))//if supplier exsist
                        {
                            MessageBox.Show("ספק קיים");
                            supplier_name.Text = "";
                            return;
                        }
                    }
                    MessageBox.Show("ספק עודכן בהצלחה");
                    Supplier_data.Updatesupplier(suppliers);//update supplier
                }
                else//t is add
                {
                    for (int i = 0; i < supplier.Length; i++)
                    {
                        if (suppliername != supplier[i].Name && supplier_name.Text.Equals(supplier[i].Name))//check if supplier exsist
                        {
                            MessageBox.Show("ספק קיים");
                            supplier_name.Text = "";
                            return;
                        }
                    }
                    suppliers.Name = supplier_name.Text;//add name
                    suppliers.Adress = supplier_adress.Text;//adress
                    suppliers.Phone = supplier_phone.Text;//phone
                    suppliers.Email = supplier_email.Text;//email
                    Supplier_data.Insertsupplier(suppliers);//add new supplier
                    MessageBox.Show("ספק נוסף בהצלחה");

                }
                this.Close();
            }
            else//if one of the field is not filed
            {
                MessageBox.Show("חובה להזין כל הפרטים ");
            }
        }

        private void supplier_phone_TextChanged(object sender, EventArgs e)
        {
            if (supplier_phone.Text.All(char.IsDigit) == false)//if it is not digit
            {
                MessageBox.Show("חובה להזין מספר");
                supplier_phone.Text = "";
            }
        }

        private void supplier_name_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(supplier_name.Text))//if only contains white spaces or null
            {
                supplier_name.Text = "";
            }
        }

        private void supplier_adress_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(supplier_adress.Text))//if only contains white spaces or null
            {
                supplier_adress.Text = "";
            }
        }

        private void supplier_email_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(supplier_email.Text))//if only contains white spaces or null
            {
                supplier_email.Text = "";
            }
        }
    }
}
