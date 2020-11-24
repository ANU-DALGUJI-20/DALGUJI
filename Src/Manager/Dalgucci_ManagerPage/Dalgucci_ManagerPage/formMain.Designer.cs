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
			this.Data = new System.Windows.Forms.Button();
			this.Table_timer = new System.Windows.Forms.Timer(this.components);
			this.D1_Cam = new System.Windows.Forms.Button();
			this.tmr_RobotAnimation = new System.Windows.Forms.Timer(this.components);
			this.Console_output = new System.Windows.Forms.ListBox();
			this.trmConsloeOutput = new System.Windows.Forms.Timer(this.components);
			this.Robot2 = new System.Windows.Forms.PictureBox();
			this.Robot1 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.D2_CAM = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.Order_View)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Robot2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Robot1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Order_View
			// 
			this.Order_View.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Order_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Order_View.Location = new System.Drawing.Point(440, 656);
			this.Order_View.Name = "Order_View";
			this.Order_View.RowHeadersWidth = 51;
			this.Order_View.RowTemplate.Height = 27;
			this.Order_View.Size = new System.Drawing.Size(664, 152);
			this.Order_View.TabIndex = 0;
			this.Order_View.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Order_View_CellContentClick);
			// 
			// Data
			// 
			this.Data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(115)))), ((int)(((byte)(33)))));
			this.Data.FlatAppearance.BorderSize = 0;
			this.Data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Data.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.Data.ForeColor = System.Drawing.Color.White;
			this.Data.Location = new System.Drawing.Point(802, 160);
			this.Data.Name = "Data";
			this.Data.Size = new System.Drawing.Size(296, 72);
			this.Data.TabIndex = 4;
			this.Data.Text = "입/출고 로그";
			this.Data.UseVisualStyleBackColor = false;
			this.Data.Click += new System.EventHandler(this.Data_Click);
			// 
			// Table_timer
			// 
			this.Table_timer.Interval = 2000;
			this.Table_timer.Tick += new System.EventHandler(this.Table_timer_Tick);
			// 
			// D1_Cam
			// 
			this.D1_Cam.BackColor = System.Drawing.Color.White;
			this.D1_Cam.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.D1_Cam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.D1_Cam.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.D1_Cam.ForeColor = System.Drawing.Color.Black;
			this.D1_Cam.Location = new System.Drawing.Point(802, 16);
			this.D1_Cam.Name = "D1_Cam";
			this.D1_Cam.Size = new System.Drawing.Size(296, 72);
			this.D1_Cam.TabIndex = 8;
			this.D1_Cam.Text = "달구지 1호 Cam";
			this.D1_Cam.UseVisualStyleBackColor = false;
			this.D1_Cam.Click += new System.EventHandler(this.D1_Cam_Click);
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
			this.Console_output.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Console_output.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.Console_output.ForeColor = System.Drawing.Color.Lime;
			this.Console_output.FormattingEnabled = true;
			this.Console_output.ItemHeight = 15;
			this.Console_output.Location = new System.Drawing.Point(8, 656);
			this.Console_output.Name = "Console_output";
			this.Console_output.Size = new System.Drawing.Size(424, 165);
			this.Console_output.TabIndex = 10;
			this.Console_output.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Console_output_DrawItem);
			this.Console_output.SelectedIndexChanged += new System.EventHandler(this.Console_output_SelectedIndexChanged);
			// 
			// trmConsloeOutput
			// 
			this.trmConsloeOutput.Enabled = true;
			this.trmConsloeOutput.Tick += new System.EventHandler(this.trmConsloeOutput_Tick);
			// 
			// Robot2
			// 
			this.Robot2.BackColor = System.Drawing.Color.White;
			this.Robot2.Image = global::Dalgucci_ManagerPage.Properties.Resources.Robot_찐막_;
			this.Robot2.Location = new System.Drawing.Point(672, 296);
			this.Robot2.Name = "Robot2";
			this.Robot2.Size = new System.Drawing.Size(38, 45);
			this.Robot2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.Robot2.TabIndex = 7;
			this.Robot2.TabStop = false;
			this.Robot2.Click += new System.EventHandler(this.Robot2_Click);
			// 
			// Robot1
			// 
			this.Robot1.BackColor = System.Drawing.Color.White;
			this.Robot1.Image = global::Dalgucci_ManagerPage.Properties.Resources.Robot_찐막_;
			this.Robot1.Location = new System.Drawing.Point(672, 152);
			this.Robot1.Name = "Robot1";
			this.Robot1.Size = new System.Drawing.Size(38, 45);
			this.Robot1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.Robot1.TabIndex = 6;
			this.Robot1.TabStop = false;
			this.Robot1.Click += new System.EventHandler(this.Robot1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.ErrorImage = null;
			this.pictureBox1.Image = global::Dalgucci_ManagerPage.Properties.Resources.창고_구성도_찐찐막_;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(14, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(778, 538);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// D2_CAM
			// 
			this.D2_CAM.BackColor = System.Drawing.Color.White;
			this.D2_CAM.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.D2_CAM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.D2_CAM.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.D2_CAM.ForeColor = System.Drawing.Color.Black;
			this.D2_CAM.Location = new System.Drawing.Point(802, 88);
			this.D2_CAM.Name = "D2_CAM";
			this.D2_CAM.Size = new System.Drawing.Size(296, 72);
			this.D2_CAM.TabIndex = 13;
			this.D2_CAM.Text = "달구지 2호 Cam";
			this.D2_CAM.UseVisualStyleBackColor = false;
			this.D2_CAM.Click += new System.EventHandler(this.D2_CAM_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.D2_CAM);
			this.panel1.Controls.Add(this.Data);
			this.panel1.Controls.Add(this.D1_Cam);
			this.panel1.Controls.Add(this.Robot1);
			this.panel1.Controls.Add(this.Robot2);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new System.Drawing.Point(0, 80);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1208, 568);
			this.panel1.TabIndex = 14;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1110, 818);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Console_output);
			this.Controls.Add(this.Order_View);
			this.Name = "frmMain";
			this.Text = "Manager Page";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.Order_View)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Robot2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Robot1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView Order_View;
		private System.Windows.Forms.Button Data;
		private System.Windows.Forms.Timer Table_timer;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox Robot1;
		private System.Windows.Forms.PictureBox Robot2;
		private System.Windows.Forms.Button D1_Cam;
		private System.Windows.Forms.Timer tmr_RobotAnimation;
		private System.Windows.Forms.ListBox Console_output;
		private System.Windows.Forms.Timer trmConsloeOutput;
        private System.Windows.Forms.Timer QRcode_Read;
		private System.Windows.Forms.Button D2_CAM;
		private System.Windows.Forms.Panel panel1;
	}
}

