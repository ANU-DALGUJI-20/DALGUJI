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
            this.components = new System.ComponentModel.Container();
            this.Order_View = new System.Windows.Forms.DataGridView();
            this.Input = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.Button();
            this.Data = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CCTV = new System.Windows.Forms.Button();
            this.tmr_RobotAnimation = new System.Windows.Forms.Timer(this.components);
            this.Console_output = new System.Windows.Forms.ListBox();
            this.trmConsloeOutput = new System.Windows.Forms.Timer(this.components);
            this.Robot2 = new System.Windows.Forms.PictureBox();
            this.Robot1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Order_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Robot2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Robot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Order_View
            // 
            this.Order_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Order_View.Location = new System.Drawing.Point(16, 440);
            this.Order_View.Name = "Order_View";
            this.Order_View.RowHeadersWidth = 51;
            this.Order_View.RowTemplate.Height = 27;
            this.Order_View.Size = new System.Drawing.Size(432, 320);
            this.Order_View.TabIndex = 0;
            this.Order_View.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Order_View_CellContentClick);
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(16, 88);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(208, 88);
            this.Input.TabIndex = 2;
            this.Input.Text = "남자 창고 입고";
            this.Input.UseVisualStyleBackColor = true;
            this.Input.Click += new System.EventHandler(this.Input_Click);
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(240, 88);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(208, 88);
            this.Output.TabIndex = 3;
            this.Output.Text = "여자 창고 입고";
            this.Output.UseVisualStyleBackColor = true;
            this.Output.Click += new System.EventHandler(this.Output_Click);
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
            // CCTV
            // 
            this.CCTV.Location = new System.Drawing.Point(1296, 72);
            this.CCTV.Name = "CCTV";
            this.CCTV.Size = new System.Drawing.Size(131, 32);
            this.CCTV.TabIndex = 8;
            this.CCTV.Text = "로봇";
            this.CCTV.UseVisualStyleBackColor = true;
            this.CCTV.Click += new System.EventHandler(this.CCTV_Click);
            // 
            // tmr_RobotAnimation
            // 
            this.tmr_RobotAnimation.Enabled = true;
            this.tmr_RobotAnimation.Interval = 5;
            this.tmr_RobotAnimation.Tick += new System.EventHandler(this.tmr_RobotAnimation_Tick);
            // 
            // Console_output
            // 
            this.Console_output.BackColor = System.Drawing.SystemColors.WindowText;
            this.Console_output.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Console_output.ForeColor = System.Drawing.Color.Lime;
            this.Console_output.FormattingEnabled = true;
            this.Console_output.ItemHeight = 15;
            this.Console_output.Location = new System.Drawing.Point(16, 184);
            this.Console_output.Name = "Console_output";
            this.Console_output.Size = new System.Drawing.Size(432, 244);
            this.Console_output.TabIndex = 10;
            this.Console_output.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Console_output_DrawItem);
            // 
            // trmConsloeOutput
            // 
            this.trmConsloeOutput.Enabled = true;
            this.trmConsloeOutput.Tick += new System.EventHandler(this.trmConsloeOutput_Tick);
            // 
            // Robot2
            // 
            this.Robot2.Image = global::Dalgucci_ManagerPage.Properties.Resources.iconmonstr_delivery_15_2402;
            this.Robot2.Location = new System.Drawing.Point(1408, 488);
            this.Robot2.Name = "Robot2";
            this.Robot2.Size = new System.Drawing.Size(45, 40);
            this.Robot2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Robot2.TabIndex = 7;
            this.Robot2.TabStop = false;
            this.Robot2.Click += new System.EventHandler(this.Robot2_Click);
            // 
            // Robot1
            // 
            this.Robot1.Image = global::Dalgucci_ManagerPage.Properties.Resources.iconmonstr_delivery_15_2402;
            this.Robot1.Location = new System.Drawing.Point(1408, 344);
            this.Robot1.Name = "Robot1";
            this.Robot1.Size = new System.Drawing.Size(45, 40);
            this.Robot1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Robot1.TabIndex = 6;
            this.Robot1.TabStop = false;
            this.Robot1.Click += new System.EventHandler(this.Robot1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::Dalgucci_ManagerPage.Properties.Resources.창고현황_최종_;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(472, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1080, 624);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1579, 789);
            this.Controls.Add(this.Console_output);
            this.Controls.Add(this.CCTV);
            this.Controls.Add(this.Robot2);
            this.Controls.Add(this.Robot1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.Order_View);
            this.Name = "frmMain";
            this.Text = "관리자 메인페이지";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Order_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Robot2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Robot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView Order_View;
		private System.Windows.Forms.Button Input;
		private System.Windows.Forms.Button Output;
		private System.Windows.Forms.Button Data;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox Robot1;
		private System.Windows.Forms.PictureBox Robot2;
		private System.Windows.Forms.Button CCTV;
		private System.Windows.Forms.Timer tmr_RobotAnimation;
		private System.Windows.Forms.ListBox Console_output;
		private System.Windows.Forms.Timer trmConsloeOutput;
        private System.Windows.Forms.Timer QRcode_Read;
    }
}

