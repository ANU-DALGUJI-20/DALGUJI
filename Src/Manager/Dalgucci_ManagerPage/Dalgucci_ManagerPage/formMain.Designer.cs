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
			this.Man_Input = new System.Windows.Forms.Button();
			this.Output = new System.Windows.Forms.Button();
			this.Data = new System.Windows.Forms.Button();
			this.Table_timer = new System.Windows.Forms.Timer(this.components);
			this.CCTV = new System.Windows.Forms.Button();
			this.tmr_RobotAnimation = new System.Windows.Forms.Timer(this.components);
			this.Console_output = new System.Windows.Forms.ListBox();
			this.trmConsloeOutput = new System.Windows.Forms.Timer(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
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
			// Man_Input
			// 
			this.Man_Input.Location = new System.Drawing.Point(480, 88);
			this.Man_Input.Name = "Man_Input";
			this.Man_Input.Size = new System.Drawing.Size(208, 40);
			this.Man_Input.TabIndex = 2;
			this.Man_Input.Text = "남자 창고 입고";
			this.Man_Input.UseVisualStyleBackColor = true;
			this.Man_Input.Click += new System.EventHandler(this.Man_Input_Click);
			// 
			// Output
			// 
			this.Output.Location = new System.Drawing.Point(696, 88);
			this.Output.Name = "Output";
			this.Output.Size = new System.Drawing.Size(208, 40);
			this.Output.TabIndex = 3;
			this.Output.Text = "여자 창고 입고";
			this.Output.UseVisualStyleBackColor = true;
			this.Output.Click += new System.EventHandler(this.Output_Click);
			// 
			// Data
			// 
			this.Data.Location = new System.Drawing.Point(232, 88);
			this.Data.Name = "Data";
			this.Data.Size = new System.Drawing.Size(208, 40);
			this.Data.TabIndex = 4;
			this.Data.Text = "입출고 로그";
			this.Data.UseVisualStyleBackColor = true;
			this.Data.Click += new System.EventHandler(this.Data_Click);
			// 
			// Table_timer
			// 
			this.Table_timer.Interval = 2000;
			this.Table_timer.Tick += new System.EventHandler(this.Table_timer_Tick);
			// 
			// CCTV
			// 
			this.CCTV.Location = new System.Drawing.Point(16, 88);
			this.CCTV.Name = "CCTV";
			this.CCTV.Size = new System.Drawing.Size(208, 40);
			this.CCTV.TabIndex = 8;
			this.CCTV.Text = "로봇 카메라";
			this.CCTV.UseVisualStyleBackColor = true;
			this.CCTV.Click += new System.EventHandler(this.CCTV_Click);
			// 
			// tmr_RobotAnimation
			// 
			this.tmr_RobotAnimation.Enabled = true;
			this.tmr_RobotAnimation.Interval = 1;
			this.tmr_RobotAnimation.Tick += new System.EventHandler(this.tmr_RobotAnimation_Tick);
			// 
			// Console_output
			// 
			this.Console_output.BackColor = System.Drawing.SystemColors.WindowText;
			this.Console_output.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.Console_output.ForeColor = System.Drawing.Color.Lime;
			this.Console_output.FormattingEnabled = true;
			this.Console_output.ItemHeight = 15;
			this.Console_output.Location = new System.Drawing.Point(16, 136);
			this.Console_output.Name = "Console_output";
			this.Console_output.Size = new System.Drawing.Size(432, 289);
			this.Console_output.TabIndex = 10;
			this.Console_output.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Console_output_DrawItem);
			// 
			// trmConsloeOutput
			// 
			this.trmConsloeOutput.Enabled = true;
			this.trmConsloeOutput.Tick += new System.EventHandler(this.trmConsloeOutput_Tick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(912, 88);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(208, 40);
			this.button1.TabIndex = 11;
			this.button1.Text = "stop";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(1128, 88);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(208, 40);
			this.button2.TabIndex = 12;
			this.button2.Text = "left";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Robot2
			// 
			this.Robot2.Image = global::Dalgucci_ManagerPage.Properties.Resources.Robot_찐막_;
			this.Robot2.Location = new System.Drawing.Point(1464, 624);
			this.Robot2.Name = "Robot2";
			this.Robot2.Size = new System.Drawing.Size(42, 49);
			this.Robot2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.Robot2.TabIndex = 7;
			this.Robot2.TabStop = false;
			this.Robot2.Click += new System.EventHandler(this.Robot2_Click);
			// 
			// Robot1
			// 
			this.Robot1.Image = global::Dalgucci_ManagerPage.Properties.Resources.Robot_찐막_;
			this.Robot1.Location = new System.Drawing.Point(1464, 216);
			this.Robot1.Name = "Robot1";
			this.Robot1.Size = new System.Drawing.Size(42, 49);
			this.Robot1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.Robot1.TabIndex = 6;
			this.Robot1.TabStop = false;
			this.Robot1.Click += new System.EventHandler(this.Robot1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.ErrorImage = null;
			this.pictureBox1.Image = global::Dalgucci_ManagerPage.Properties.Resources.창고_구성도_찐찐막_;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(480, 136);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(1072, 624);
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
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Console_output);
			this.Controls.Add(this.CCTV);
			this.Controls.Add(this.Robot2);
			this.Controls.Add(this.Robot1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.Data);
			this.Controls.Add(this.Output);
			this.Controls.Add(this.Man_Input);
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
		private System.Windows.Forms.Button Man_Input;
		private System.Windows.Forms.Button Output;
		private System.Windows.Forms.Button Data;
		private System.Windows.Forms.Timer Table_timer;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox Robot1;
		private System.Windows.Forms.PictureBox Robot2;
		private System.Windows.Forms.Button CCTV;
		private System.Windows.Forms.Timer tmr_RobotAnimation;
		private System.Windows.Forms.ListBox Console_output;
		private System.Windows.Forms.Timer trmConsloeOutput;
        private System.Windows.Forms.Timer QRcode_Read;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

