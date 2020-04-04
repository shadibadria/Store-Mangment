namespace Store_Mangment.view.products
{
    partial class Products_return
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products_return));
            this.code = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.returnproducts_text = new System.Windows.Forms.TextBox();
            this.return_productbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // code
            // 
            this.code.AutoSize = true;
            this.code.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.code.Location = new System.Drawing.Point(416, 92);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(29, 16);
            this.code.TabIndex = 91;
            this.code.Text = "קוד";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(388, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 90;
            this.label2.Text = "קוד קבלה:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(69, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 89;
            this.label1.Text = "מוצרים שהוחזרו:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label45.Location = new System.Drawing.Point(69, 59);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(87, 16);
            this.label45.TabIndex = 88;
            this.label45.Text = "החזרת מוצר:";
            // 
            // returnproducts_text
            // 
            this.returnproducts_text.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.returnproducts_text.Location = new System.Drawing.Point(72, 165);
            this.returnproducts_text.MaxLength = 200;
            this.returnproducts_text.Multiline = true;
            this.returnproducts_text.Name = "returnproducts_text";
            this.returnproducts_text.Size = new System.Drawing.Size(458, 167);
            this.returnproducts_text.TabIndex = 87;
            // 
            // return_productbtn
            // 
            this.return_productbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.return_productbtn.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.return_productbtn.Location = new System.Drawing.Point(229, 356);
            this.return_productbtn.Name = "return_productbtn";
            this.return_productbtn.Size = new System.Drawing.Size(137, 50);
            this.return_productbtn.TabIndex = 86;
            this.return_productbtn.Text = "החזרת מוצרים";
            this.return_productbtn.UseVisualStyleBackColor = false;
            this.return_productbtn.Click += new System.EventHandler(this.return_productbtn_Click);
            // 
            // Products_return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(210)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(599, 465);
            this.Controls.Add(this.code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.returnproducts_text);
            this.Controls.Add(this.return_productbtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(615, 504);
            this.MinimumSize = new System.Drawing.Size(615, 504);
            this.Name = "Products_return";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Products_return_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox returnproducts_text;
        private System.Windows.Forms.Button return_productbtn;
    }
}