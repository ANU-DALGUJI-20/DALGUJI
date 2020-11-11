namespace Dalgucci_ManagerPage
{
    partial class formRobotCom
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CCTV = new System.Windows.Forms.PictureBox();
            this.CCTV2 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CCTV)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(826, 494);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CCTV);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(818, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Robot 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CCTV2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(818, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Robot 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CCTV
            // 
            this.CCTV.Location = new System.Drawing.Point(0, 0);
            this.CCTV.Name = "CCTV";
            this.CCTV.Size = new System.Drawing.Size(816, 464);
            this.CCTV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CCTV.TabIndex = 0;
            this.CCTV.TabStop = false;
            // 
            // CCTV2
            // 
            this.CCTV2.Location = new System.Drawing.Point(1, 0);
            this.CCTV2.Name = "CCTV2";
            this.CCTV2.Size = new System.Drawing.Size(816, 464);
            this.CCTV2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CCTV2.TabIndex = 1;
            this.CCTV2.TabStop = false;
            // 
            // formRobotCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 494);
            this.Controls.Add(this.tabControl1);
            this.Name = "formRobotCom";
            this.Text = "formRobotCom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formRobotCom_FormClosing);
            this.Load += new System.EventHandler(this.formRobotCom_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CCTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CCTV2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox CCTV;
        private System.Windows.Forms.PictureBox CCTV2;
    }
}