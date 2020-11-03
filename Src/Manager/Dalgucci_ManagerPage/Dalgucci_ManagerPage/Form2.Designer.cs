namespace Dalgucci_ManagerPage
{
    partial class frmInOutHistory
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Input_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Output_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutProduct_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Out_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Input_No,
            this.Product_Code,
            this.Product_Place,
            this.In_Time});
            this.dataGridView1.Location = new System.Drawing.Point(24, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(360, 312);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Input_No
            // 
            this.Input_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Input_No.HeaderText = "입고번호";
            this.Input_No.MinimumWidth = 6;
            this.Input_No.Name = "Input_No";
            this.Input_No.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Product_Code
            // 
            this.Product_Code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product_Code.HeaderText = "제품코드";
            this.Product_Code.MinimumWidth = 6;
            this.Product_Code.Name = "Product_Code";
            // 
            // Product_Place
            // 
            this.Product_Place.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product_Place.HeaderText = "제품위치";
            this.Product_Place.MinimumWidth = 6;
            this.Product_Place.Name = "Product_Place";
            // 
            // In_Time
            // 
            this.In_Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.In_Time.HeaderText = "입고시간";
            this.In_Time.MinimumWidth = 6;
            this.In_Time.Name = "In_Time";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Output_No,
            this.OutProduct_Code,
            this.Place,
            this.Out_Time});
            this.dataGridView2.Location = new System.Drawing.Point(416, 104);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(360, 312);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Output_No
            // 
            this.Output_No.HeaderText = "출고번호";
            this.Output_No.MinimumWidth = 6;
            this.Output_No.Name = "Output_No";
            this.Output_No.Width = 125;
            // 
            // OutProduct_Code
            // 
            this.OutProduct_Code.HeaderText = "제품코드";
            this.OutProduct_Code.MinimumWidth = 6;
            this.OutProduct_Code.Name = "OutProduct_Code";
            this.OutProduct_Code.Width = 125;
            // 
            // Place
            // 
            this.Place.HeaderText = "제품위치";
            this.Place.MinimumWidth = 6;
            this.Place.Name = "Place";
            this.Place.Width = 125;
            // 
            // Out_Time
            // 
            this.Out_Time.HeaderText = "출고시간";
            this.Out_Time.MinimumWidth = 6;
            this.Out_Time.Name = "Out_Time";
            this.Out_Time.Width = 125;
            // 
            // frmInOutHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmInOutHistory";
            this.Text = "입출고 내역";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Input_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Place;
        private System.Windows.Forms.DataGridViewTextBoxColumn In_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Output_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutProduct_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Place;
        private System.Windows.Forms.DataGridViewTextBoxColumn Out_Time;
    }
}