using Store_Mangment.Control.Categorys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Mangment.view.Categorys
{
    public partial class Add_category : Form
    {
        private Category_control Category_data;//database
        private Category[] categorys;//category data
        private string category_code;//category code
        private string categoryname;//categoryname
        public Add_category()
        {
            InitializeComponent();
            string dbpath = Application.StartupPath + @"\StoreData.accdb";//database data          
            Category_control.ConnectionString = dbpath;
            Category_data = Category_control.Instance;
            categorys = Category_data.GetCategory();//get categoey info
        }

        /*from add form to update category form function */
        public void updatecategory(Category cat)
        {
            categoryname = cat.Name;//add name
            category_name.Text = cat.Name;//add name
            category_info.Text = cat.Info;//add info
            category_code = cat.Code;//add code
            addproductbtn.Text = "עדכן";//update button from add to update
        }


        private void Add_category_Load(object sender, EventArgs e)
        {

        }

        private void addproductbtn_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            if (category_name.Text.Length != 0)//if category name is not empty
            {
                if (addproductbtn.Text.Equals("עדכן"))//if the button is update that mean we update
                {
                    category.Name = category_name.Text;//add name
                    category.Info = category_info.Text;//add info
                    category.Code = category_code;//add code
                    for (int i = 0; i < categorys.Length; i++)
                    {
                        if (categoryname != categorys[i].Name && category_name.Text.Equals(categorys[i].Name))//check if there is category with the same name
                        {
                            MessageBox.Show("קטגוריה קיימת");
                            category_name.Text = "";
                            return;
                        }
                    }
                    MessageBox.Show("קטגוריה עודכנה בהצלחה");
                    Category_data.Updatecategory(category);//update category
                }
                else
                {
                    for (int i = 0; i < categorys.Length; i++)//check if there is category with the same name
                    {
                        if (category_name.Text.Equals(categorys[i].Name))//if category found
                        {
                            MessageBox.Show("קטגוריה קיימת");
                            category_name.Text = "";
                            return;
                        }
                    }
                    category.Name = category_name.Text;//add category name
                    if (category_info.Text.Length == 0)//check if category info is empty
                    {
                        category_info.Text = " ";
                    }
                    category.Info = category_info.Text;//add category info
                    Category_data.Insertcategory(category);//insert category
                    MessageBox.Show("קטגוריה נוספה בהצלחה");
                }
                this.Close();
            }
            else//if name of category is empty
            {
                MessageBox.Show("חובה להזין שם של קטגוריה");
            }
        }

        private void category_name_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(category_name.Text))//if only contains white spaces or null
            {
                category_name.Text = "";
            }
        }
    }
}
