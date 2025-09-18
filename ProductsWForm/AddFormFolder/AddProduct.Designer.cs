namespace ProductsWForm.AddFormFolder
{
    partial class AddProduct
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
            btnSave = new Button();
            btnCanel = new Button();
            label1 = new Label();
            txtProductName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtPrice = new TextBox();
            label4 = new Label();
            txtDescription = new TextBox();
            label5 = new Label();
            txtStockQtt = new TextBox();
            label6 = new Label();
            cmbCategory = new ComboBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(139, 335);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCanel
            // 
            btnCanel.Location = new Point(12, 335);
            btnCanel.Name = "btnCanel";
            btnCanel.Size = new Size(75, 23);
            btnCanel.TabIndex = 1;
            btnCanel.Text = "Cancel";
            btnCanel.UseVisualStyleBackColor = true;
            btnCanel.Click += btnCanel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(124, 21);
            label1.TabIndex = 2;
            label1.Text = "ADD PRODUCT";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(12, 59);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(202, 23);
            txtProductName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 41);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 4;
            label2.Text = "Product name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 90);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 6;
            label3.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(12, 108);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(202, 23);
            txtPrice.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 141);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 8;
            label4.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 159);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(202, 23);
            txtDescription.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 193);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 10;
            label5.Text = "Stock quantity";
            // 
            // txtStockQtt
            // 
            txtStockQtt.Location = new Point(12, 211);
            txtStockQtt.Name = "txtStockQtt";
            txtStockQtt.Size = new Size(202, 23);
            txtStockQtt.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 248);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 11;
            label6.Text = "Category";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(12, 266);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(202, 23);
            cmbCategory.TabIndex = 12;
            cmbCategory.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // AddProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(226, 370);
            Controls.Add(cmbCategory);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtStockQtt);
            Controls.Add(label4);
            Controls.Add(txtDescription);
            Controls.Add(label3);
            Controls.Add(txtPrice);
            Controls.Add(label2);
            Controls.Add(txtProductName);
            Controls.Add(label1);
            Controls.Add(btnCanel);
            Controls.Add(btnSave);
            Name = "AddProduct";
            Text = "AddProduct";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnCanel;
        private Label label1;
        private TextBox txtProductName;
        private Label label2;
        private Label label3;
        private TextBox txtPrice;
        private Label label4;
        private TextBox txtDescription;
        private Label label5;
        private TextBox txtStockQtt;
        private Label label6;
        private ComboBox cmbCategory;
    }
}