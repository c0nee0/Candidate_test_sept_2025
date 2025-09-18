namespace ProductsWForm
{
    partial class EditProduct
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
            cmbCategory = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            txtStockQtt = new TextBox();
            label4 = new Label();
            txtDescription = new TextBox();
            label3 = new Label();
            txtPrice = new TextBox();
            label2 = new Label();
            txtProductName = new TextBox();
            label1 = new Label();
            btnCanel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(12, 267);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(202, 23);
            cmbCategory.TabIndex = 25;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 249);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 24;
            label6.Text = "Category";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 194);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 23;
            label5.Text = "Stock quantity";
            // 
            // txtStockQtt
            // 
            txtStockQtt.Location = new Point(12, 212);
            txtStockQtt.Name = "txtStockQtt";
            txtStockQtt.Size = new Size(202, 23);
            txtStockQtt.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 142);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 21;
            label4.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 160);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(202, 23);
            txtDescription.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 91);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 19;
            label3.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(12, 109);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(202, 23);
            txtPrice.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 17;
            label2.Text = "Product name";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(12, 60);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(202, 23);
            txtProductName.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(124, 21);
            label1.TabIndex = 15;
            label1.Text = "EDIT PRODUCT";
            // 
            // btnCanel
            // 
            btnCanel.Location = new Point(12, 336);
            btnCanel.Name = "btnCanel";
            btnCanel.Size = new Size(75, 23);
            btnCanel.TabIndex = 14;
            btnCanel.Text = "Cancel";
            btnCanel.UseVisualStyleBackColor = true;
            btnCanel.Click += btnCanel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(139, 336);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // EditProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(232, 373);
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
            Name = "EditProduct";
            Text = "EditProduct";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCategory;
        private Label label6;
        private Label label5;
        private TextBox txtStockQtt;
        private Label label4;
        private TextBox txtDescription;
        private Label label3;
        private TextBox txtPrice;
        private Label label2;
        private TextBox txtProductName;
        private Label label1;
        private Button btnCanel;
        private Button btnSave;
    }
}