﻿namespace Dalgucci_ManagerPage
{
	partial class formRobotCom_2
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.QR_test1 = new System.Windows.Forms.TextBox();
            this.CCTV3 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.QR_test2 = new System.Windows.Forms.TextBox();
            this.CCTV4 = new System.Windows.Forms.PictureBox();
            this.tmr_man_seq = new System.Windows.Forms.Timer(this.components);
            this.Robot2_prod_timer = new System.Windows.Forms.Timer(this.components);
            this.tmr_man = new System.Windows.Forms.Timer(this.components);
            this.Robot2_floor_timer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CCTV3)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CCTV4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(683, 551);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.QR_test1);
            this.tabPage1.Controls.Add(this.CCTV3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(675, 522);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "QRcode 인식 카메라";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // QR_test1
            // 
            this.QR_test1.Location = new System.Drawing.Point(240, 480);
            this.QR_test1.Multiline = true;
            this.QR_test1.Name = "QR_test1";
            this.QR_test1.Size = new System.Drawing.Size(168, 25);
            this.QR_test1.TabIndex = 1;
            // 
            // CCTV3
            // 
            this.CCTV3.Location = new System.Drawing.Point(0, 0);
            this.CCTV3.Name = "CCTV3";
            this.CCTV3.Size = new System.Drawing.Size(672, 464);
            this.CCTV3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CCTV3.TabIndex = 0;
            this.CCTV3.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.QR_test2);
            this.tabPage2.Controls.Add(this.CCTV4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(675, 522);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "물품 인식 카메라";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // QR_test2
            // 
            this.QR_test2.Location = new System.Drawing.Point(240, 480);
            this.QR_test2.Name = "QR_test2";
            this.QR_test2.Size = new System.Drawing.Size(168, 25);
            this.QR_test2.TabIndex = 2;
            this.QR_test2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.QR_test2.TextChanged += new System.EventHandler(this.QR_test2_TextChanged);
            // 
            // CCTV4
            // 
            this.CCTV4.Location = new System.Drawing.Point(1, 0);
            this.CCTV4.Name = "CCTV4";
            this.CCTV4.Size = new System.Drawing.Size(671, 464);
            this.CCTV4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CCTV4.TabIndex = 1;
            this.CCTV4.TabStop = false;
            // 
            // tmr_man_seq
            // 
            this.tmr_man_seq.Tick += new System.EventHandler(this.tmr_man_seq_Tick);
            // 
            // Robot2_prod_timer
            // 
            this.Robot2_prod_timer.Tick += new System.EventHandler(this.Robot2_prod_timer_Tick);
            // 
            // tmr_man
            // 
            this.tmr_man.Enabled = true;
            this.tmr_man.Tick += new System.EventHandler(this.tmr_man_Tick);
            // 
            // Robot2_floor_timer
            // 
            this.Robot2_floor_timer.Tick += new System.EventHandler(this.Robot2_floor_timer_Tick);
            // 
            // formRobotCom_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 551);
            this.Controls.Add(this.tabControl1);
            this.Name = "formRobotCom_2";
            this.Text = "달구지 2호 Cam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formRobotCom_2_FormClosing);
            this.Load += new System.EventHandler(this.formRobotCom_2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CCTV3)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CCTV4)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox QR_test1;
		private System.Windows.Forms.PictureBox CCTV3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox QR_test2;
		private System.Windows.Forms.PictureBox CCTV4;
        private System.Windows.Forms.Timer tmr_man_seq;
        private System.Windows.Forms.Timer Robot2_prod_timer;
        public System.Windows.Forms.Timer tmr_man;
        private System.Windows.Forms.Timer Robot2_floor_timer;
    }
}