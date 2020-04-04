using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Control.Categorys
{
    public class Category
    {
        private string name;//category name
        private string code;//category code/id
        private string info;//category information

        /*Empty constructor*/
        public Category()
        {
        }
        /*Getters && Setters*/
        public string Name { get => name; set => name = value; }
        public string Code { get => code; set => code = value; }
        public string Info { get => info; set => info = value; }
    }
}
