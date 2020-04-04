using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Mangment.Model.Taxes
{
    public class Tax
    {
        private int sell_tax;

        public Tax()
        {

        }

        public int Sell_tax { get => sell_tax; set => sell_tax = value; }
    }
}
