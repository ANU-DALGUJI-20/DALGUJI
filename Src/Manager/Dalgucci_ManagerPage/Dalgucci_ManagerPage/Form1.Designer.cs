namespace Dalgucci_ManagerPage
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Order_View = new System.Windows.Forms.DataGridView();
            this.Robot_View = new System.Windows.Forms.DataGridView();
            this.Input = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.Button();
            this.Data = new System.Windows.Forms.Button();
            this.Robot_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Robot_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Robot_Part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Robot_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Order_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Robot_View)).BeginInit();
            this.SuspendLayout();
            // 
            // Order_View
            // 
            this.Order_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Order_View.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Order_No,
            this.Product_Code,
            this.User_No,
            this.Order_Time});
            this.Order_View.Location = new System.Drawing.Point(16, 384);
            this.Order_View.Name = "Order_View";
            this.Order_View.RowHeadersWidth = 51;
            this.Order_View.RowTemplate.Height = 27;
            this.Order_View.Size = new System.Drawing.Size(512, 320);
            this.Order_View.TabIndex = 0;
            this.Order_View.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Order_View_CellContentClick);
            // 
            // Robot_View
            // 
            this.Robot_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Robot_View.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Robot_No,
            this.Robot_Name,
            this.Robot_Part,
            this.Robot_State});
            this.Robot_View.Location = new System.Drawing.Point(16, 200);
            this.Robot_View.Name = "Robot_View";
            this.Robot_View.RowHeadersWidth = 51;
            this.Robot_View.RowTemplate.Height = 27;
            this.Robot_View.Size = new System.Drawing.Size(512, 152);
            this.Robot_View.TabIndex = 1;
            this.Robot_View.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Robot_View_CellContentClick);
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(32, 104);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(75, 23);
            this.Input.TabIndex = 2;
            this.Input.Text = "입고";
            this.Input.UseVisualStyleBackColor = true;
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(32, 144);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(75, 23);
            this.Output.TabIndex = 3;
            this.Output.Text = "출고";
            this.Output.UseVisualStyleBackColor = true;
            // 
            // Data
            // 
            this.Data.Location = new System.Drawing.Point(1448, 16);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(104, 32);
            this.Data.TabIndex = 4;
            this.Data.Text = "입출고 내역";
            this.Data.UseVisualStyleBackColor = true;
            this.Data.Click += new System.EventHandler(this.Data_Click);
            // 
            // Robot_No
            // 
            this.Robot_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Robot_No.HeaderText = "로봇번호";
            this.Robot_No.MinimumWidth = 6;
            this.Robot_No.Name = "Robot_No";
            // 
            // Robot_Name
            // 
            this.Robot_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Robot_Name.HeaderText = "로봇이름";
            this.Robot_Name.MinimumWidth = 6;
            this.Robot_Name.Name = "Robot_Name";
            // 
            // Robot_Part
            // 
            this.Robot_Part.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Robot_Part.HeaderText = "로봇역할";
            this.Robot_Part.MinimumWidth = 6;
            this.Robot_Part.Name = "Robot_Part";
            // 
            // Robot_State
            // 
            this.Robot_State.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Robot_State.HeaderText = "작동유무";
            this.Robot_State.MinimumWidth = 6;
            this.Robot_State.Name = "Robot_State";
            // 
            // Order_No
            // 
            this.Order_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Order_No.HeaderText = "주문번호";
            this.Order_No.MinimumWidth = 6;
            this.Order_No.Name = "Order_No";
            // 
            // Product_Code
            // 
            this.Product_Code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product_Code.HeaderText = "제품코드";
            this.Product_Code.MinimumWidth = 6;
            this.Product_Code.Name = "Product_Code";
            // 
            // User_No
            // 
            this.User_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.User_No.HeaderText = "구매자 번호";
            this.User_No.MinimumWidth = 6;
            this.User_No.Name = "User_No";
            // 
            // Order_Time
            // 
            this.Order_Time.HeaderText = "주문시간";
            this.Order_Time.MinimumWidth = 6;
            this.Order_Time.Name = "Order_Time";
            this.Order_Time.Width = 160;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1567, 728);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.Robot_View);
            this.Controls.Add(this.Order_View);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Order_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Robot_View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Order_View;
        private System.Windows.Forms.DataGridView Robot_View;
        private System.Windows.Forms.Button Input;
        private System.Windows.Forms.Button Output;
        private System.Windows.Forms.Button Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Robot_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Robot_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Robot_Part;
        private System.Windows.Forms.DataGridViewTextBoxColumn Robot_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_Time;
    }
}

