namespace Dalgucci_ManagerPage
{
    partial class formRobotCom_1
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
			this.testTextBox = new System.Windows.Forms.TextBox();
			this.CCTV = new System.Windows.Forms.PictureBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.TextTest2 = new System.Windows.Forms.TextBox();
			this.CCTV2 = new System.Windows.Forms.PictureBox();
			this.Robot1_floor_timer = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.tmr_woman_seq = new System.Windows.Forms.Timer(this.components);
			this.Robot1_prod_timer = new System.Windows.Forms.Timer(this.components);
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CCTV)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CCTV2)).BeginInit();
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
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.testTextBox);
			this.tabPage1.Controls.Add(this.CCTV);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(675, 522);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "QRcode 인식 카메라";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// testTextBox
			// 
			this.testTextBox.Location = new System.Drawing.Point(240, 480);
			this.testTextBox.Multiline = true;
			this.testTextBox.Name = "testTextBox";
			this.testTextBox.Size = new System.Drawing.Size(168, 25);
			this.testTextBox.TabIndex = 1;
			// 
			// CCTV
			// 
			this.CCTV.Location = new System.Drawing.Point(0, 0);
			this.CCTV.Name = "CCTV";
			this.CCTV.Size = new System.Drawing.Size(672, 464);
			this.CCTV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.CCTV.TabIndex = 0;
			this.CCTV.TabStop = false;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.TextTest2);
			this.tabPage2.Controls.Add(this.CCTV2);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(675, 522);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "물품 인식 카메라";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// TextTest2
			// 
			this.TextTest2.Location = new System.Drawing.Point(240, 480);
			this.TextTest2.Name = "TextTest2";
			this.TextTest2.Size = new System.Drawing.Size(168, 25);
			this.TextTest2.TabIndex = 2;
			this.TextTest2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TextTest2.TextChanged += new System.EventHandler(this.TextTest2_TextChanged);
			// 
			// CCTV2
			// 
			this.CCTV2.Location = new System.Drawing.Point(1, 0);
			this.CCTV2.Name = "CCTV2";
			this.CCTV2.Size = new System.Drawing.Size(671, 464);
			this.CCTV2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.CCTV2.TabIndex = 1;
			this.CCTV2.TabStop = false;
			this.CCTV2.Click += new System.EventHandler(this.CCTV2_Click);
			// 
			// Robot1_floor_timer
			// 
			this.Robot1_floor_timer.Interval = 4000;
			this.Robot1_floor_timer.Tick += new System.EventHandler(this.Robot1_floor_timer_Tick);
			// 
			// timer2
			// 
			this.timer2.Interval = 4000;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// tmr_woman_seq
			// 
			this.tmr_woman_seq.Tick += new System.EventHandler(this.tmr_woman_seq_Tick);
			// 
			// Robot1_prod_timer
			// 
			this.Robot1_prod_timer.Tick += new System.EventHandler(this.Robot1_prod_timer_Tick);
			// 
			// formRobotCom_1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(683, 551);
			this.Controls.Add(this.tabControl1);
			this.Name = "formRobotCom_1";
			this.Text = "달구지 1호 Cam";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formRobotCom_FormClosing);
			this.Load += new System.EventHandler(this.formRobotCom_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CCTV)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CCTV2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox CCTV;
        private System.Windows.Forms.PictureBox CCTV2;
        private System.Windows.Forms.TextBox testTextBox;
        private System.Windows.Forms.Timer Robot1_floor_timer;
        private System.Windows.Forms.TextBox TextTest2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer tmr_woman_seq;
		private System.Windows.Forms.Timer Robot1_prod_timer;
	}
}