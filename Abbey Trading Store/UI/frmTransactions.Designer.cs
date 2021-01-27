namespace Abbey_Trading_Store.UI
{
    partial class frmTransactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransactions));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgv_transactions = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Cateory_combobox = new System.Windows.Forms.ComboBox();
            this.Show_all = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_transactions = new System.Windows.Forms.DateTimePicker();
            this.txtbx_total = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbx_discounts = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transactions)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 46);
            this.panel1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(338, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRANSACTIONS";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(743, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv_transactions
            // 
            this.dgv_transactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_transactions.Location = new System.Drawing.Point(12, 108);
            this.dgv_transactions.Name = "dgv_transactions";
            this.dgv_transactions.Size = new System.Drawing.Size(797, 306);
            this.dgv_transactions.TabIndex = 24;
            this.dgv_transactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_transactions_CellContentClick);
            this.dgv_transactions.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_transactions_RowHeaderMouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 21);
            this.label2.TabIndex = 25;
            this.label2.Text = "Filter by Category";
            // 
            // Cateory_combobox
            // 
            this.Cateory_combobox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cateory_combobox.ForeColor = System.Drawing.Color.Red;
            this.Cateory_combobox.FormattingEnabled = true;
            this.Cateory_combobox.Items.AddRange(new object[] {
            "Sales",
            "Purchase"});
            this.Cateory_combobox.Location = new System.Drawing.Point(151, 66);
            this.Cateory_combobox.Name = "Cateory_combobox";
            this.Cateory_combobox.Size = new System.Drawing.Size(217, 29);
            this.Cateory_combobox.TabIndex = 26;
            this.Cateory_combobox.SelectedIndexChanged += new System.EventHandler(this.Cateory_combobox_SelectedIndexChanged);
            // 
            // Show_all
            // 
            this.Show_all.BackColor = System.Drawing.Color.Turquoise;
            this.Show_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Show_all.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Show_all.Location = new System.Drawing.Point(541, 424);
            this.Show_all.Name = "Show_all";
            this.Show_all.Size = new System.Drawing.Size(119, 41);
            this.Show_all.TabIndex = 27;
            this.Show_all.Text = "SHOW ALL";
            this.Show_all.UseVisualStyleBackColor = false;
            this.Show_all.Click += new System.EventHandler(this.Show_all_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Turquoise;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(693, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 41);
            this.button2.TabIndex = 31;
            this.button2.Text = "PRINT ALL";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(525, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 21);
            this.label3.TabIndex = 32;
            this.label3.Text = "Filter by Date";
            // 
            // dtp_transactions
            // 
            this.dtp_transactions.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_transactions.Location = new System.Drawing.Point(633, 69);
            this.dtp_transactions.Name = "dtp_transactions";
            this.dtp_transactions.Size = new System.Drawing.Size(156, 20);
            this.dtp_transactions.TabIndex = 33;
            this.dtp_transactions.ValueChanged += new System.EventHandler(this.dtp_transactions_ValueChanged);
            // 
            // txtbx_total
            // 
            this.txtbx_total.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_total.ForeColor = System.Drawing.Color.Red;
            this.txtbx_total.Location = new System.Drawing.Point(62, 428);
            this.txtbx_total.Name = "txtbx_total";
            this.txtbx_total.Size = new System.Drawing.Size(161, 33);
            this.txtbx_total.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 434);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 21);
            this.label4.TabIndex = 35;
            this.label4.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(242, 434);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 21);
            this.label5.TabIndex = 37;
            this.label5.Text = "T/L Discounts";
            // 
            // txtbx_discounts
            // 
            this.txtbx_discounts.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_discounts.ForeColor = System.Drawing.Color.Red;
            this.txtbx_discounts.Location = new System.Drawing.Point(352, 428);
            this.txtbx_discounts.Name = "txtbx_discounts";
            this.txtbx_discounts.Size = new System.Drawing.Size(161, 33);
            this.txtbx_discounts.TabIndex = 36;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(797, 75);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 38;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // frmTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(821, 470);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtbx_discounts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbx_total);
            this.Controls.Add(this.dtp_transactions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Show_all);
            this.Controls.Add(this.Cateory_combobox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_transactions);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.frmTransactions_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv_transactions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cateory_combobox;
        private System.Windows.Forms.Button Show_all;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_transactions;
        private System.Windows.Forms.TextBox txtbx_total;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbx_discounts;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}