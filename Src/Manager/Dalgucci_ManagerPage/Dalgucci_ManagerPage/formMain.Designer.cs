namespace Dalgucci_ManagerPage
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.Data = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmr_RobotAnimation = new System.Windows.Forms.Timer(this.components);
            this.Order_View = new System.Windows.Forms.DataGridView();
            this.Output = new System.Windows.Forms.Button();
            this.Robot_View = new System.Windows.Forms.DataGridView();
            this.Robot_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Robot_Part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Robot_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Robot_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCTV = new System.Windows.Forms.Button();
            this.Input = new System.Windows.Forms.Button();
            this.Robot2 = new System.Windows.Forms.PictureBox();
            this.Robot1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Order_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Robot_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Robot2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Robot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Data
            // 
            this.Data.Location = new System.Drawing.Point(1440, 72);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(104, 32);
            this.Data.TabIndex = 4;
            this.Data.Text = "입출고 내역";
            this.Data.UseVisualStyleBackColor = true;
            this.Data.Click += new System.EventHandler(this.Data_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmr_RobotAnimation
            // 
            this.tmr_RobotAnimation.Enabled = true;
            this.tmr_RobotAnimation.Interval = 5;
            this.tmr_RobotAnimation.Tick += new System.EventHandler(this.tmr_RobotAnimation_Tick);
            // 
            // Order_View
            // 
            this.Order_View.BackgroundColor = System.Drawing.Color.Silver;
            this.Order_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Order_View.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Order_View.Location = new System.Drawing.Point(992, 456);
            this.Order_View.Name = "Order_View";
            this.Order_View.RowHeadersWidth = 51;
            this.Order_View.RowTemplate.Height = 27;
            this.Order_View.Size = new System.Drawing.Size(376, 308);
            this.Order_View.TabIndex = 0;
            this.Order_View.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Order_View_CellContentClick);
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.Output.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Output.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Output.ForeColor = System.Drawing.Color.Black;
            this.Output.Location = new System.Drawing.Point(992, 160);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(376, 52);
            this.Output.TabIndex = 3;
            this.Output.Text = "출 고";
            this.Output.UseVisualStyleBackColor = false;
            this.Output.Click += new System.EventHandler(this.Output_Click);
            // 
            // Robot_View
            // 
            this.Robot_View.BackgroundColor = System.Drawing.Color.Silver;
            this.Robot_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Robot_View.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Robot_No,
            this.Robot_Name,
            this.Robot_Part,
            this.Robot_State});
            this.Robot_View.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Robot_View.Location = new System.Drawing.Point(992, 280);
            this.Robot_View.Name = "Robot_View";
            this.Robot_View.RowHeadersWidth = 51;
            this.Robot_View.RowTemplate.Height = 27;
            this.Robot_View.Size = new System.Drawing.Size(376, 168);
            this.Robot_View.TabIndex = 1;
            this.Robot_View.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Robot_View_CellContentClick);
            // 
            // Robot_State
            // 
            this.Robot_State.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Robot_State.HeaderText = "작동유무";
            this.Robot_State.MinimumWidth = 6;
            this.Robot_State.Name = "Robot_State";
            // 
            // Robot_Part
            // 
            this.Robot_Part.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Robot_Part.HeaderText = "로봇역할";
            this.Robot_Part.MinimumWidth = 6;
            this.Robot_Part.Name = "Robot_Part";
            // 
            // Robot_Name
            // 
            this.Robot_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Robot_Name.HeaderText = "로봇이름";
            this.Robot_Name.MinimumWidth = 6;
            this.Robot_Name.Name = "Robot_Name";
            // 
            // Robot_No
            // 
            this.Robot_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Robot_No.HeaderText = "로봇번호";
            this.Robot_No.MinimumWidth = 6;
            this.Robot_No.Name = "Robot_No";
            // 
            // CCTV
            // 
            this.CCTV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.CCTV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CCTV.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CCTV.ForeColor = System.Drawing.Color.Black;
            this.CCTV.Location = new System.Drawing.Point(992, 220);
            this.CCTV.Name = "CCTV";
            this.CCTV.Size = new System.Drawing.Size(376, 52);
            this.CCTV.TabIndex = 8;
            this.CCTV.Text = "로 봇";
            this.CCTV.UseVisualStyleBackColor = false;
            this.CCTV.Click += new System.EventHandler(this.CCTV_Click);
            // 
            // Input
            // 
            this.Input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.Input.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Input.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Input.ForeColor = System.Drawing.Color.Black;
            this.Input.Location = new System.Drawing.Point(992, 100);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(376, 52);
            this.Input.TabIndex = 2;
            this.Input.Text = "입 고";
            this.Input.UseVisualStyleBackColor = false;
            this.Input.Click += new System.EventHandler(this.Input_Click);
            // 
            // Robot2
            // 
            this.Robot2.Image = ((System.Drawing.Image)(resources.GetObject("Robot2.Image")));
            this.Robot2.Location = new System.Drawing.Point(848, 416);
            this.Robot2.Name = "Robot2";
            this.Robot2.Size = new System.Drawing.Size(45, 40);
            this.Robot2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Robot2.TabIndex = 7;
            this.Robot2.TabStop = false;
            this.Robot2.Click += new System.EventHandler(this.Robot2_Click);
            // 
            // Robot1
            // 
            this.Robot1.Image = ((System.Drawing.Image)(resources.GetObject("Robot1.Image")));
            this.Robot1.Location = new System.Drawing.Point(144, 408);
            this.Robot1.Name = "Robot1";
            this.Robot1.Size = new System.Drawing.Size(45, 40);
            this.Robot1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Robot1.TabIndex = 6;
            this.Robot1.TabStop = false;
            this.Robot1.Click += new System.EventHandler(this.Robot1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Dalgucci_ManagerPage.Properties.Resources.그룹_114;
            this.pictureBox1.Location = new System.Drawing.Point(32, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(952, 664);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.CCTV);
            this.Controls.Add(this.Robot_View);
            this.Controls.Add(this.Robot2);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Robot1);
            this.Controls.Add(this.Order_View);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Data);
            this.Name = "frmMain";
            this.Text = "Manager Main Page";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Order_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Robot_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Robot2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Robot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Data;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox Robot1;
        private System.Windows.Forms.PictureBox Robot2;
        private System.Windows.Forms.Timer tmr_RobotAnimation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView Order_View;
        private System.Windows.Forms.Button Output;
        private System.Windows.Forms.DataGridView Robot_View;
        private System.Windows.Forms.DataGridViewTextBoxColumn Robot_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Robot_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Robot_Part;
        private System.Windows.Forms.DataGridViewTextBoxColumn Robot_State;
        private System.Windows.Forms.Button CCTV;
        private System.Windows.Forms.Button Input;
    }
}
