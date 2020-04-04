using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Store_Mangment.Model.Receipts;
using System.Diagnostics;
using System.Collections;
using Store_Mangment.Control.Categorys;
using Store_Mangment.Control.Suppliers;
using Store_Mangment.Control.Orders;
using Store_Mangment.Control.Users;

namespace Store_Mangment.Model.Reportmaker
{
    class Reportmaker
    {

        private Document doc;//Doc
        private string fontpath = Application.StartupPath + @"\ARIALUNI.TTF";//start path of the font so pdf can work with heberew
        private BaseFont bf; //Create a base font object
        private Font myfont;//text font
        private Font headerfont;//head font
        private Font headerfont2;//another header font
        private PdfWriter pdfWriter;//pdf writer
        private ColumnText text;//make text by col
        private SaveFileDialog sfd;//savefile 
        private PdfPCell mycell;//pdf cell
        private PdfPTable mytable;//pdf table
                                  /*Dates*/
        private string today = DateTime.Today.ToString("dd/MM/yyyy");
        private string year = DateTime.Today.ToString("yyyy");
        private string month = DateTime.Today.ToString("/MM/yyyy");
        private string todaydate = DateTime.Now.ToString();//date with hour


        /*****************************************************************/
        /*                         Report Options                       */
        /***************************************************************/
        /*Constructor Empty*/
        public Reportmaker()
        {
            doc = new Document(PageSize.A4);//doc page size
        }
        /*Set Pdf Text*/
        public void settext()
        {
            bf = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);//make new Arial font
            myfont = new Font(bf, 8, Font.ITALIC, BaseColor.BLACK);//text font
            headerfont = new Font(bf, 10, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK);//header font
            headerfont2 = new Font(bf, 10, Font.BOLD, BaseColor.BLACK);//header font

            text = new ColumnText(pdfWriter.DirectContent);//Write Direction
            text.RunDirection = PdfWriter.RUN_DIRECTION_RTL;//make it from right to left for heberew text
            text.SetSimpleColumn(100, 100, 500, 800, 24, Element.ALIGN_CENTER);//column place
        }
        /*file creating and saving*/
        public void savingfileto(string filename)
        {
            sfd = new SaveFileDialog();//new savefile dialog
            pdfWriter = null;
            doc = new Document(PageSize.A4);
            sfd.Filter = "Pdf File |*.pdf";
            sfd.FileName = filename;//file name
            if (sfd.ShowDialog() == DialogResult.OK)//if it is not open by another proccess
            {
                try
                {
                    pdfWriter = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));//open/create
                    doc.Open();
                    settext();//set text               
                }
                catch//file is in used by another procces
                {
                    MessageBox.Show("הקובץ בשימוש בבקשה לסגור את הקובץ");
                }
            }
            else//if user decide  not to save
            {
                return;
            }
        }
        /*add path*/
        public void add_withpath(string code, string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);//Assuming Test is your Folder
            pdfWriter = PdfWriter.GetInstance(doc, new FileStream(path + "/" + code + ".pdf", FileMode.Create));
            doc.Open();
            settext();   //set text              
        }
        /*Set Table*/
        public void SetTable(int cellsize)
        {
            //create table
            mytable = new PdfPTable(cellsize);
            mytable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            int i;
            //set table aligment
            mytable.HorizontalAlignment = Element.ALIGN_CENTER;
            //set column width in percent
            float[] widthcell = new float[cellsize];//add  cells
            for (i = 0; i < cellsize; i++)
            {
                widthcell[i] = 3;
            }
            mytable.SetTotalWidth(widthcell);
            //create cell
            mycell = new PdfPCell();
            mycell.BorderColor = BaseColor.BLACK;//border color
            mycell.VerticalAlignment = Element.ALIGN_BOTTOM;//align
            mycell.HorizontalAlignment = Element.ALIGN_CENTER;
            Paragraph partitle = new Paragraph("\n\n\n\n", myfont);
            partitle.Alignment = Element.ALIGN_LEFT;
            doc.Add(partitle);
        }
        /*Function to close report*/
        public void closereport()//close pdf file
        {
            doc.Close();
            doc = null;
            pdfWriter = null;
        }

        /*****************************************************************/
        /*                         Product Report                       */
        /***************************************************************/
        /*set product report */
        public void product_report(string title, string filename, Product[] products, int productcount, int flag, double sumofdata)
        {
            string[] colnames = null;
            if (flag == 0 )
            {
                colnames = set_productdatatable();

            }
            if (flag == 2)
            {
                colnames = set_soldproductdatatable();

            }

            if (flag == 1)
             {
                    colnames = set_solddatatable();

             }
         
           
          
            savingfileto(filename);//save file/create
            string space = new string(' ', 30);//space
            Paragraph par = new Paragraph(title + space + "נכון לתאריך: " + todaydate, headerfont);//add header text
            par.Alignment = Element.ALIGN_LEFT;//start from right cuz it is right to left
            if (text == null)
                return;
            text.AddElement(par);//add header
            text.Go();//add paragraph   

            SetTable(7);//product table has 7 col always
            producttable(products, colnames, flag, productcount);//add table

            closereport();//closefile
        }
        /*add text to sell report*/
        private void sell_report_textadd(string title, Receipt receipt, double cost, int sell_tax)
        {
            Paragraph par = new Paragraph(title, headerfont2);//add header text
            par.Alignment = Element.ALIGN_CENTER;//start from right cuz it is right to left
            text.AddElement(par);//add header
            par = new Paragraph(" סניף ראשי דליית אל כרמל", myfont);//add header text
            par.Alignment = Element.ALIGN_CENTER;//start from right cuz it is right to left
            text.AddElement(par);//add header
            par = new Paragraph("מספר קבלה:" + receipt.Receipt_code + "\nקופאי: " + receipt.Worker_name, myfont);//add header text
            par.Alignment = Element.ALIGN_CENTER;//start from right cuz it is right to left
            text.AddElement(par);//add header
            par = new Paragraph("טלפון: " + "05062216\n", myfont);//add header text
            par.Alignment = Element.ALIGN_CENTER;//start from right cuz it is right to left
            text.AddElement(par);//add header
            text.Go();//add paragraph  
            par = new Paragraph(" תאריך קנייה: " + today, myfont);//add header text
            par.Alignment = Element.ALIGN_CENTER;//start from right cuz it is right to left
            text.AddElement(par);//add header
            par = new Paragraph(" ***מקור***", headerfont2);//add header text
            par.Alignment = Element.ALIGN_CENTER;//start from right cuz it is right to left
            text.AddElement(par);//add header
            par = new Paragraph("\nמוצרים: ", headerfont2);//add header text
            par.Alignment = Element.ALIGN_LEFT;//start from right cuz it is right to left
            text.AddElement(par);//add header
            par = new Paragraph(receipt.Receipt_info, myfont);//add header text
            par.Alignment = Element.ALIGN_LEFT;//start from right cuz it is right to left
            text.AddElement(par);//add header
            par = new Paragraph("\nלסיכום: \n--------------------\n", headerfont2);//add header text
            par.Alignment = Element.ALIGN_LEFT;//start from right cuz it is right to left
            text.AddElement(par);//add header
            par = new Paragraph("מע\"מ: " + sell_tax + "%" + "\n" + " סה\"כ כולל מע\"מ: " + cost.ToString(), headerfont2);//add header text
            par.Alignment = Element.ALIGN_LEFT;//start from right cuz it is right to left
            text.AddElement(par);//add header
        }
        /*Products that has been sold*/
        public void sell_report(string filename, string title, Receipt receipt, int total, double cost, int sell_tax)
        {
            add_withpath(receipt.Receipt_code, Application.StartupPath + @"\Receipt");//save file/create    
            if (text == null)
                return;
            sell_report_textadd(title, receipt, cost, sell_tax);
            text.Go();//add paragraph    
            closereport();//closefile
        }
        /*print pdf using printdialog*/
        public void printPDFWithAcrobat(string filename)
        {
            string Filepath = Application.StartupPath + @"\Receipt\" + filename + ".pdf";
            bool fileExists = (System.IO.File.Exists(Filepath) ? true : false);//check if file exsist
            if (fileExists == false)
            {
                MessageBox.Show("file does not exsist");
                return;
            }
            using (PrintDialog Dialog = new PrintDialog())
            {
                Dialog.ShowDialog();
                ProcessStartInfo printProcessInfo = new ProcessStartInfo()
                {
                    Verb = "print",
                    CreateNoWindow = true,
                    FileName = Filepath,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process printProcess = new Process();
                printProcess.StartInfo = printProcessInfo;
                printProcess.Start();
                printProcess.WaitForInputIdle();
                if (false == printProcess.CloseMainWindow())
                {
                    printProcess.Kill();
                }
            }
        }
        /*Set Title for Product*/
        private void set_product_titlereport(string[] tablecols)
        {
            for (int j = 0; j < tablecols.Length; j++)//add titles
            {
                mycell.GrayFill = 0.9F;//gray font
                mycell.Phrase = new Phrase(tablecols[j], myfont);
                mytable.AddCell(mycell);
            }
            mycell.HorizontalAlignment = Element.ALIGN_LEFT;///R->L\
            mycell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);//white font

        }
        private void add_index(int i)
        {
            /*Add To cell => Row Index */
            mycell.Phrase = new Phrase(i.ToString(), myfont);
            mytable.AddCell(mycell);
        }
        /*Make Product Table*/
        public void producttable(Product[] table, string[] tablecols, int flag, int productcount)
        {
            int i = 0;
            for (i = 0; i < table.Length; i++)
            {
                if (i == 0)//add titles 
                {
                    set_product_titlereport(tablecols);//add titlse
                }
                add_index(i + 1);//inc index
                mycell.Phrase = new Phrase(table[i].Product_id.ToString(), myfont);//add product code
                mytable.AddCell(mycell);
                /*Add To cell => Product Name*/
                mycell.Phrase = new Phrase(table[i].Product_name.ToString(), myfont);//add product name
                mytable.AddCell(mycell);
                /*Add To cell => Product Price*/
                mycell.Phrase = new Phrase(table[i].Price.ToString(), myfont);//add product price
                mytable.AddCell(mycell);
                if (flag == 1)//if it is Selling Report
                {
                    if (table[i].Product_count == 0)//if all products all sold then add all
                    {
                        mycell.Phrase = new Phrase(table[i].Product_amount.ToString(), myfont);//add product amount
                        mytable.AddCell(mycell);
                    }
                    else//not all products are sold
                    {
                        mycell.Phrase = new Phrase((table[i].Product_amount - table[i].Product_count).ToString(), myfont);//product count
                        mytable.AddCell(mycell);
                    }
                    mycell.Phrase = new Phrase(table[i].Product_count.ToString(), myfont);//add product count
                    mytable.AddCell(mycell);

                    mycell.Phrase = new Phrase(table[i].Product_amount.ToString(), myfont);//add product amount
                    mytable.AddCell(mycell);
                }
                if (flag == 2)
                {
                    mycell.Phrase = new Phrase(table[i].Product_amount.ToString(), myfont);//add product amount
                    mytable.AddCell(mycell);

                    mycell.Phrase = new Phrase(table[i].Suppliername.ToString(), myfont);//add supplier name
                    mytable.AddCell(mycell);

                    mycell.Phrase = new Phrase(table[i].Solddate.ToString(), myfont);
                    mytable.AddCell(mycell);

                }
                else if(flag!=1)//if it is product report 
                {
                    mycell.Phrase = new Phrase(table[i].Product_count.ToString(), myfont);//product count
                    mytable.AddCell(mycell);
                    mycell.Phrase = new Phrase(table[i].Suppliername.ToString(), myfont);//add supplier name
                    mytable.AddCell(mycell);
                    mycell.Phrase = new Phrase(table[i].Adddate.ToString(), myfont);
                    mytable.AddCell(mycell);
                }

            
                
             
            }
            mycell.GrayFill = 0.9F;//gray font
            mycell.Phrase = new Phrase("סה\"כ מוצרים: ", myfont);
            mytable.AddCell(mycell);
            mycell.Phrase = new Phrase(productcount.ToString(), myfont);
            mytable.AddCell(mycell);
            mycell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);//white font

            for (int j = 0; j < 5; j++)
            {
                mycell.Phrase = new Phrase(" ", myfont);
                mytable.AddCell(mycell);
            }

            doc.Add(mytable);//add table
        }

        /*sort dates between two values*/
        public ArrayList Date_sort(DateTime startdate, DateTime enddate, ArrayList dates)
        {
            ArrayList temp = new ArrayList();
            ArrayList temp2 = new ArrayList();

            startdate = DateTime.Parse(startdate.ToShortDateString());
            enddate = DateTime.Parse(enddate.ToShortDateString());
            for (int i = 0; i < dates.Count; i++)
            {
                DateTime oDate = DateTime.Parse(dates[i].ToString());
                int s_date = DateTime.Compare(startdate, oDate);
                int e_date = DateTime.Compare(enddate, oDate);
                if (s_date <= 0 && e_date >= 0)
                {
                    if (!temp.Contains(oDate.ToShortDateString()))
                        temp.Add(oDate.ToShortDateString());
                }
            }

            return temp;
        }

        public void soldproduct_report(string title, string filename, Product[] products, int productcount, double sumofdata, DateTime startdate, DateTime enddate, ArrayList dates)
        {
            string[] colnames = set_solddatatable2();
            savingfileto(filename);//save file/create
            string space = new string(' ', 30);//space
            Paragraph par = new Paragraph(title + space + "נכון לתאריך: " + todaydate, headerfont);//add header text
            par.Alignment = Element.ALIGN_LEFT;//start from right cuz it is right to left
            if (text == null)
                return;
            text.AddElement(par);//add header       
            par = new Paragraph(startdate.ToShortDateString() + "-" + enddate.ToShortDateString(), headerfont);//add header text
            par.Alignment = Element.ALIGN_LEFT;//start from right cuz it is right to left      
            text.AddElement(par);//add header       
            text.Go();
            SetTable(5);//product table has 7 col always
            sold_table(products, colnames, startdate, enddate, dates, productcount, sumofdata);//add table

            closereport();//closefile
        }
        public void sold_table(Product[] table, string[] tablecols, DateTime startdate, DateTime enddate, ArrayList dates, int productcount, double sumofdata)
        {
            int index = 0;
            ArrayList temp = new ArrayList();
            dates = Date_sort(startdate, enddate, dates);//sort dates
            set_product_titlereport(tablecols);//add titlse
            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 0; j < dates.Count; j++)
                {
                    if (table[i].Product_sellrecord.Contains(dates[j].ToString()))
                    {
                        add_index(++index);//inc index
                        table[i].Product_count = 0;
                        productcount++;
                        mycell.Phrase = new Phrase(table[i].Product_id.ToString(), myfont);//add product code
                        mytable.AddCell(mycell);

                        /*Add To cell => Product Name*/
                        mycell.Phrase = new Phrase(table[i].Product_name.ToString(), myfont);//add product name
                        mytable.AddCell(mycell);

                        /*Add To cell => Product Price*/
                        mycell.Phrase = new Phrase(table[i].Price.ToString(), myfont);//add product price
                        mytable.AddCell(mycell);

                        mycell.Phrase = new Phrase(table[i].Product_amount.ToString(), myfont);//add product amount
                        mytable.AddCell(mycell);
                    }
                }
            }

            mycell.GrayFill = 0.9F;//gray font
            mycell.Phrase = new Phrase("סה\"כ מוצרים: ", myfont);
            mytable.AddCell(mycell);
            mycell.Phrase = new Phrase(productcount.ToString(), myfont);
            mytable.AddCell(mycell);
            mycell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);//white font

            for (int j = 0; j < 3; j++)
            {
                mycell.Phrase = new Phrase(" ", myfont);
                mytable.AddCell(mycell);
            }
            doc.Add(mytable);//add table
        }

        /*****************************************************************/
        /*                         Category Report                      */
        /***************************************************************/
        /*set category report */
        public void category_report(string title, string filename, Category[] categorys, int categorycount)
        {
            string[] colnames = set_categorytable();
            savingfileto(filename);//save file name
            string space = new string(' ', 40);//space
            Paragraph par = new Paragraph(title + space + "נכון לתאריך: " + todaydate, headerfont);
            par.Alignment = Element.ALIGN_LEFT;
            if (text == null)
                return;
            text.AddElement(par);
            text.Go();
            SetTable(4);//category table has 4 col always
            category_table(categorys, colnames, categorycount);//add category table
            closereport();//close file
        }
        private void add_categorytitle(string[] tablecols)
        {
            for (int j = 0; j < tablecols.Length; j++)//add all titles that been sent here
            {
                mycell.GrayFill = 0.9F;//Color Gray
                mycell.Phrase = new Phrase(tablecols[j], myfont);
                mytable.AddCell(mycell);
            }
            mycell.HorizontalAlignment = Element.ALIGN_LEFT;//R to L
            mycell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);//Color White              

        }
        /*make category table*/
        public void category_table(Category[] table, string[] tablecols, int categorycount)
        {
            int i = 0;
            for (i = 0; i < table.Length; i++)
            {
                if (i == 0)//add titles 
                {
                    add_categorytitle(tablecols);
                }
                add_index(i + 1);
                mycell.Phrase = new Phrase(table[i].Code.ToString(), myfont);//category code
                mytable.AddCell(mycell);
                mycell.Phrase = new Phrase(table[i].Name, myfont);//category name
                mytable.AddCell(mycell);
                mycell.Phrase = new Phrase(table[i].Info, myfont);//category info
                mytable.AddCell(mycell);
            }
            mycell.GrayFill = 0.9F;//gray font
            mycell.Phrase = new Phrase("סה\"כ : ", myfont);
            mytable.AddCell(mycell);
            mycell.Phrase = new Phrase(categorycount.ToString(), myfont);
            mytable.AddCell(mycell);
            mycell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);//white font

            for (int j = 0; j < 2; j++)
            {
                mycell.Phrase = new Phrase(" ", myfont);
                mytable.AddCell(mycell);
            }


            doc.Add(mytable);//add Category Table
        }
        /*****************************************************************/
        /*                         Supplier Report                      */
        /***************************************************************/

        /*Make Supplier Report*/
        public void supplier_report(string title, string filename, Supplier[] suppliers, int supplier_count)
        {
            string[] colnames = set_suppliertable();
            savingfileto(filename);//add file name+save it 
            string space = new string(' ', 40);//space
            Paragraph par = new Paragraph(title + space + "נכון לתאריך: " + todaydate, headerfont);
            par.Alignment = Element.ALIGN_LEFT;
            if (text == null)
                return;
            text.AddElement(par);
            text.Go();
            SetTable(5);//Supplier table has 5 col always
            supplier_table(suppliers, colnames, supplier_count);//make table
            closereport();//close report
        }
        private void add_suppliertitle(string[] tablecols)
        {
            for (int j = 0; j < tablecols.Length; j++)
            {
                mycell.GrayFill = 0.9F;//make font gray
                mycell.Phrase = new Phrase(tablecols[j], myfont);
                mytable.AddCell(mycell);
            }
            mycell.HorizontalAlignment = Element.ALIGN_LEFT;//R => L
            mycell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);//ADD font to white

        }
        /*Make Supplier Table*/
        public void supplier_table(Supplier[] table, string[] tablecols, int supplier_count)
        {
            int i = 0;
            for (i = 0; i < table.Length; i++)
            {
                if (i == 0)//add Supplier titles 
                {
                    add_suppliertitle(tablecols);
                }
                add_index(i + 1);
                mycell.Phrase = new Phrase(table[i].Name, myfont);//supplier name
                mytable.AddCell(mycell);
                mycell.Phrase = new Phrase(table[i].Adress, myfont);//supplier adress
                mytable.AddCell(mycell);
                mycell.Phrase = new Phrase(table[i].Phone, myfont);//supplier phone
                mytable.AddCell(mycell);
                mycell.Phrase = new Phrase(table[i].Email, myfont);//supplier phone
                mytable.AddCell(mycell);
            }
            mycell.GrayFill = 0.9F;//gray font
            mycell.Phrase = new Phrase("סה\"כ : ", myfont);
            mytable.AddCell(mycell);
            mycell.Phrase = new Phrase(supplier_count.ToString(), myfont);
            mytable.AddCell(mycell);
            mycell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);//white font

            for (int j = 0; j < 3; j++)
            {
                mycell.Phrase = new Phrase(" ", myfont);
                mytable.AddCell(mycell);
            }
            doc.Add(mytable);//add table
        }
        /*****************************************************************/
        /*                         Order Report                          */
        /***************************************************************/
        /*Make Order Report*/
        public void order_report(string title, string filename, Order[] order, int ordercount)
        {
            string[] colnames = set_ordertable();
            savingfileto(filename);//save file
            string space = new string(' ', 40);
            Paragraph par = new Paragraph(title + space + "נכון לתאריך: " + todaydate, headerfont);//title
            par.Alignment = Element.ALIGN_LEFT;
            if (text == null)
                return;
            text.AddElement(par);

            text.Go();//add paragraph
            SetTable(6);//order table has 6 col always
            order_table(order, colnames);//make table
            closereport();
        }
        /*Make Single Order Report*/
        public void order_out(string title, string filename, Order order)
        {
            savingfileto(filename);//save file
            string space = new string(' ', 40);
            Paragraph par = new Paragraph(title + space + "נכון לתאריך: " + todaydate, headerfont);//header
            par.Alignment = Element.ALIGN_LEFT;
            if (text == null)
                return;
            text.AddElement(par);
            /*Add header*/
            par = new Paragraph("\nשם הזמנה: ", headerfont);
            text.AddElement(par);
            /*Order name*/
            par = new Paragraph(order.Order_name + "\n", myfont);
            text.AddElement(par);

            par = new Paragraph("\nתוכן הזמנה: ", headerfont);
            text.AddElement(par);
            /*Order Information*/
            par = new Paragraph(order.Order_information + "\n", myfont);
            text.AddElement(par);
            text.Go();
            closereport();//close pdf
        }

       
        /*order titles report*/
        private void add_ordertitles(string[] tablecols)
        {
            for (int j = 0; j < tablecols.Length; j++)
            {
                mycell.GrayFill = 0.9F;//Make Gray Font
                mycell.Phrase = new Phrase(tablecols[j], myfont);
                mytable.AddCell(mycell);
            }
            mycell.HorizontalAlignment = Element.ALIGN_LEFT;//R->L
            mycell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);//White
        }
        /*Make Order Table*/
        public void order_table(Order[] table, string[] tablecols)
        {
            int i = 0;
            for (i = 0; i < table.Length; i++)
            {
                if (i == 0)//add titles 
                {
                    add_ordertitles(tablecols);
                }
                add_index(i + 1);//add index
                mycell.Phrase = new Phrase(table[i].Order_id.ToString(), myfont);
                mytable.AddCell(mycell);
                mycell.Phrase = new Phrase(table[i].Order_name.ToString(), myfont);
                mytable.AddCell(mycell);
                mycell.Phrase = new Phrase(table[i].Order_date.ToString(), myfont);
                mytable.AddCell(mycell);
                mycell.Phrase = new Phrase(table[i].Supplier_name.ToString(), myfont);
                mytable.AddCell(mycell);
                mycell.Phrase = new Phrase(table[i].Order_information.ToString(), myfont);
                mytable.AddCell(mycell);
            }
            mycell.GrayFill = 0.9F;//gray font
            mycell.Phrase = new Phrase("סה\"כ : ", myfont);
            mytable.AddCell(mycell);
            mycell.Phrase = new Phrase((i).ToString(), myfont);
            mytable.AddCell(mycell);
            mycell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);//white font

            for (int j = 0; j < 4; j++)
            {
                mycell.Phrase = new Phrase(" ", myfont);
                mytable.AddCell(mycell);
            }
            doc.Add(mytable);//add table
        }
        /*****************************************************************/
        /*                         Employee Report                      */
        /***************************************************************/


        /*Make employee Table*/
        public void employee_record(ArrayList hoursworked, ArrayList starthour, ArrayList endhour, ArrayList startdate, string[] tablecols, string startdatet, string enddatet)
        {
            int i = 0;
            int index = 1;//index
            int size = starthour.Count;
            string temp;
            DateTime start_date = DateTime.Parse(startdatet);
            DateTime end_date = DateTime.Parse(enddatet);
            for (i = 0; i < size; i++)
            {
                if (i == 0)//add titles 
                {
                    for (int j = 0; j < tablecols.Length; j++)
                    {
                        mycell.GrayFill = 0.9F;//Make Gray Font
                        temp = tablecols[j];
                        mycell.Phrase = new Phrase(temp, myfont);
                        mytable.AddCell(mycell);
                    }
                    mycell.HorizontalAlignment = Element.ALIGN_LEFT;//R->L
                    mycell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);//White
                }

                DateTime oDate = DateTime.Parse(startdate[i].ToString());

                int s_date = DateTime.Compare(start_date, oDate);
                int e_date = DateTime.Compare(end_date, oDate);

                if (s_date <= 0 && e_date >= 0)
                {

                    /*Add To cell => Row Index */
                    temp = index.ToString();
                    index++;
                    mycell.Phrase = new Phrase(temp, myfont);
                    mytable.AddCell(mycell);

                    /*Add To cell => sttart date ID */
                    temp = startdate[i].ToString();
                    mycell.Phrase = new Phrase(temp, myfont);
                    mytable.AddCell(mycell);

                    /*Add To cell => Order ID */
                    temp = starthour[i].ToString();
                    mycell.Phrase = new Phrase(temp, myfont);
                    mytable.AddCell(mycell);

                    /*Add To cell => Order ID */
                    temp = endhour[i].ToString();
                    mycell.Phrase = new Phrase(temp, myfont);
                    mytable.AddCell(mycell);

                    /*Add To cell => Order ID */
                    temp = hoursworked[i].ToString();
                    mycell.Phrase = new Phrase(temp, myfont);
                    mytable.AddCell(mycell);
                }
            }
            mycell.GrayFill = 0.9F;//gray font
            mycell.Phrase = new Phrase("סה\"כ : ", myfont);
            mytable.AddCell(mycell);
            mycell.Phrase = new Phrase((--index).ToString(), myfont);
            mytable.AddCell(mycell);
            mycell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);//white font

            for (int j = 0; j < 3; j++)
            {
                mycell.Phrase = new Phrase(" ", myfont);
                mytable.AddCell(mycell);
            }
            doc.Add(mytable);//add table
        }

        /*add employee date */
        private ArrayList get_employee_date(string record)
        {
            ArrayList logindate = new ArrayList();
            /*Login date*/
            string login = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ' ')
                {
                    logindate.Add(login);
                    login = "";
                    while (i < record.Length && record[i] != '\n')
                    {
                        i++;
                    }
                    i++;
                }
                if (i > record.Length)
                    break;
                login += record[i];
            }
            return logindate;
        }
        /*get employee login hour*/
        private ArrayList get_employee_loginhour(string record)
        {
            /*login hour*/
            ArrayList loginhour = new ArrayList();
            string login = "";
            int count = 0;
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ' ')
                {
                    count++;
                }
                if (count % 2 != 0 && record[i] == ' ')
                {
                    i++;
                    if (i > record.Length)
                        break;
                    while (record[i] != ',')
                    {
                        login += record[i];
                        i++;
                        if (i > record.Length)
                            break;
                    }
                    if (i > record.Length)
                        break;
                    loginhour.Add(login);
                    login = "";
                }
                if (i > record.Length)
                    break;
            }
            return loginhour;
        }
        /*get employee exithour*/
        private ArrayList get_employee_exithour(string record)
        {
            ArrayList exithour = new ArrayList();
            /*exit hour  */
            string login = "";
            int count = 0;
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ' ')
                {
                    count++;
                }
                if (count != 0 && count % 2 == 0 && record[i] == ' ')
                {
                    i++;
                    if (i > record.Length)
                        break;
                    while (record[i] != ',')
                    {
                        login += record[i];
                        i++;
                        if (i > record.Length)
                            break;
                    }
                    if (i > record.Length)
                        break;
                    exithour.Add(login);
                    login = "";
                }
                if (i > record.Length)
                    break;
            }
            return exithour;
        }
        /*Get employee hour shift duration*/
        private ArrayList get_employee_hourworked(ArrayList loginhour, ArrayList exithour)
        {
            ArrayList hoursworked = new ArrayList();
            for (int i = 0; i < loginhour.Count; i++)
            {
                DateTime startTime = Convert.ToDateTime(loginhour[i]);
                DateTime endtime = Convert.ToDateTime(exithour[i]);
                TimeSpan duration = startTime - endtime;
                string hours = duration.ToString().Replace("-", string.Empty);
                hoursworked.Add(hours);
            }
            return hoursworked;
        }
        /*employee report generate*/
        public void employee_report(string title, string filename, User employee, DateTime start_date, DateTime end_date)
        {
            string[] colnames = set_employeetble();
            ArrayList logindate = new ArrayList();
            ArrayList loginhour = new ArrayList();
            ArrayList exithour = new ArrayList();
            ArrayList hoursworked = new ArrayList();
            savingfileto(filename);//save file
            string space = new string(' ', 25);
            Paragraph par = new Paragraph(title + space + "נכון לתאריך: " + todaydate, headerfont);//title
            par.Alignment = Element.ALIGN_LEFT;
            if (text == null)
                return;
            text.AddElement(par);
            par = new Paragraph(start_date.ToShortDateString() + "-" + end_date.ToShortDateString(), headerfont);//title
            text.AddElement(par);

            text.Go();
            /*Login date*/
            logindate = get_employee_date(employee.Login_record);//get login dates
            loginhour = get_employee_loginhour(employee.Login_record);//get login hours
            exithour = get_employee_exithour(employee.Login_record);//get exit hours
            hoursworked = get_employee_hourworked(loginhour, exithour);//get shift time     

            text.Go();//add paragraph
            SetTable(5);//order table has 6 col always
            employee_record(hoursworked, loginhour, exithour, logindate, colnames, start_date.ToShortDateString(), end_date.ToShortDateString());//make table

            closereport();
        }
        /*****************************************************************/
        /*                         Shifts Report                         */
        /***************************************************************/
    
        /*Make Supplier Report*/
        public void workschedule_report(string title, string filename, User[] employee)
        {
            string[] colnames = set_daysofweek();
            savingfileto(filename);//add file name+save it 
            string space = new string(' ', 40);//space
            Paragraph par = new Paragraph(title + space + "נכון לתאריך: " + todaydate, headerfont);
            par.Alignment = Element.ALIGN_LEFT;
            if (text == null)
                return;
            text.AddElement(par);
            text.Go();
            SetTable(7);//Supplier table has 5 col always
            workschedule_table(employee, colnames);//make table
            closereport();//close report
        }
        /*Get the day of  the first day of month*/
        private void daysof_week(DateTime first)
        {
            int index = 0;
            string[] daysofweek = new string[7];
            daysofweek[0] = "sunday";
            daysofweek[1] = "Monday";
            daysofweek[2] = "Tuesday";
            daysofweek[3] = "Wednesday";
            daysofweek[4] = "Thursday";
            daysofweek[5] = "Friday";
            daysofweek[6] = "Saturday";
            for (int i = 0; i < daysofweek.Length; i++)
            {
                if (first.DayOfWeek.ToString() == daysofweek[i])
                {
                    index = i;
                    break;
                }
            }
            while (index > 0)//make calender start from correct day and date
            {
                mycell.Phrase = new Phrase("X", myfont);
                mytable.AddCell(mycell);
                index--;
            }
            mycell.BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255);//ADD font to white

        }
        /*set work schedule titles*/
        private void set_scheduletitles_report(string[] tablecols)
        {
            mycell.HorizontalAlignment = Element.ALIGN_CENTER;//R => L

            for (int j = 0; j < 7; j++)
            {
                mycell.GrayFill = 0.9F;//make font gray
                mycell.Phrase = new Phrase(tablecols[j], myfont);
                mytable.AddCell(mycell);
            }

        }
        /*make cal cells*/
        private int make_cal(DateTime first, User[] employee)
        {
            int x = 1;
            string temp = "";
            int i = 0;
            int flag = 1;
            int morning_flag = 1;
            while (first.Month == DateTime.Today.Month)//make calendar
            {
                morning_flag = 1;
                temp += first.ToShortDateString() + "\n\n";
                for (i = 0; i < employee.Length; i++)
                {
                    if (employee[i].Work_days.Contains(first.ToShortDateString()))
                    {
                        if (morning_flag == 1)
                        {
                            temp += "בוקר \n";
                            temp += "7:00 - 14:00 \n";
                            morning_flag = 0;
                        }
                        else
                        {
                            temp += "ערב \n";
                            temp += "14:00 - 22:00 \n";
                            morning_flag = 1;
                        }
                        temp += "---------------\n";
                        temp += employee[i].Fullname + "\n";
                        temp += "\n";

                        flag = 0;
                    }
                }
                if (flag == 1)
                {
                    temp += "-\n";
                }
                temp += "\n\n\n";
                flag = 1;
                mycell.Phrase = new Phrase(temp, myfont);
                temp = "";
                mytable.AddCell(mycell);
                first = first.AddDays(1);
                x++;
            }
            return x;
        }
        /*Make schedule Table*/
        private void workschedule_table(User[] employee, string[] tablecols)
        {
            DateTime now = DateTime.Now;
            DateTime first = new DateTime(now.Year, now.Month, 1);
            set_scheduletitles_report(tablecols);
            daysof_week(first);//get day of the week                  

            int x = make_cal(first, employee);//if there is exstra cells
            while (x < 36)//add exstra cells
            {
                mytable.DefaultCell.Border = Rectangle.NO_BORDER;
                mycell.Phrase = new Phrase(" ", myfont);
                mytable.AddCell(mycell);
                x++;
            }
            doc.Add(mytable);//add table
        }

        /*product header report*/
        private string[] set_productdatatable()
        {
            string[] colnames = new string[7];
            colnames[0] = "מספור";
            colnames[1] = "קוד מוצר";
            colnames[2] = "שם מוצר";
            colnames[3] = " מחיר מוצרי";
            colnames[4] = "כמות ";
            colnames[5] = "שם ספק";
            colnames[6] = "תאריך הוספה";
            return colnames;
        }

        /*product header report*/
        private string[] set_soldproductdatatable()
        {
            string[] colnames = new string[7];
            colnames[0] = "מספור";
            colnames[1] = "קוד מוצר";
            colnames[2] = "שם מוצר";
            colnames[3] = " מחיר מוצרי";
            colnames[4] = "כמות ";
            colnames[5] = "שם ספק";
            colnames[6] = "תאריך מכירה";
            return colnames;
        }
        /*set header for category table*/
        private string[] set_categorytable()
        {
            string[] colnames = new string[4];
            colnames[0] = "מספור";
            colnames[1] = "קוד קטגוריה";
            colnames[2] = "שם קטגרויה";
            colnames[3] = "מידע";
            return colnames;
        }
        /*set header for category table*/
        private string[] set_suppliertable()
        {
            string[] colnames = new string[5];
            colnames[0] = "מספור";
            colnames[1] = "שם ספק";
            colnames[2] = "כתובת ספק";
            colnames[3] = "טלפון";
            colnames[4] = "מייל";

            return colnames;
        }
        /*set header for category table*/
        private string[] set_daysofweek()
        {
            string[] colnames = new string[7];
            colnames[0] = "ראשון";
            colnames[1] = " שני";
            colnames[2] = "שלישי";
            colnames[3] = "רביעי";
            colnames[4] = "חמישי";
            colnames[5] = "שישי";
            colnames[6] = "שבת";
            return colnames;
        }
        private string[] set_solddatatable2()
        {
            string[] colnames = new string[5];
            colnames[0] = "מספור";
            colnames[1] = "קוד מוצר";
            colnames[2] = "שם מוצר";
            colnames[3] = " מחיר ליחידה(₪)";
            colnames[4] = "כמות כללית";
            return colnames;
        }
        /*set header of sold product table*/
        private string[] set_solddatatable()
        {
            string[] colnames = new string[7];
            colnames[0] = "מספור";
            colnames[1] = "קוד מוצר";
            colnames[2] = "שם מוצר";
            colnames[3] = " מחיר ליחידה(₪)";
            colnames[4] = "כמות שנמכרו";
            colnames[5] = "כמות שנשארת";
            colnames[6] = "כמות כללית";
            return colnames;
        }
        /*set order table for report*/
        private string[] set_ordertable()
        {
            string[] colnames = new string[6];
            colnames[0] = "מספור";
            colnames[1] = "קוד הזמנה";
            colnames[2] = "שם הזמנה";
            colnames[3] = " תאריך הזמנה";
            colnames[4] = "שם ספק";
            colnames[5] = "תוכן";
            return colnames;
        }

        /*set order table for report*/
        private string[] set_employeetble()
        {
            string[] colnames = new string[5];
            colnames[0] = "מספור";
            colnames[1] = "תאריך כניסה";
            colnames[2] = "משעה";
            colnames[3] = "עד שעה";
            colnames[4] = "סה\"כ";
            return colnames;
        }
    }
}
