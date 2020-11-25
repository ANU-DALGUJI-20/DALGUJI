using System;

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
			this.components = new System.ComponentModel.Container();
			this.In_Log = new System.Windows.Forms.DataGridView();
			this.Out_Log = new System.Windows.Forms.DataGridView();
			this.INOUT_Timer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.In_Log)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Out_Log)).BeginInit();
			this.SuspendLayout();
			// 
			// In_Log
			// 
			this.In_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.In_Log.Location = new System.Drawing.Point(24, 24);
			this.In_Log.Name = "In_Log";
			this.In_Log.RowHeadersWidth = 51;
			this.In_Log.RowTemplate.Height = 27;
			this.In_Log.Size = new System.Drawing.Size(360, 400);
			this.In_Log.TabIndex = 0;
			this.In_Log.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.In_Log_CellContentClick);
			// 
			// Out_Log
			// 
			this.Out_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Out_Log.Location = new System.Drawing.Point(416, 24);
			this.Out_Log.Name = "Out_Log";
			this.Out_Log.RowHeadersWidth = 51;
			this.Out_Log.RowTemplate.Height = 27;
			this.Out_Log.Size = new System.Drawing.Size(360, 400);
			this.Out_Log.TabIndex = 1;
			this.Out_Log.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Out_Log_CellContentClick);
			// 
			// INOUT_Timer
			// 
			this.INOUT_Timer.Interval = 2000;
			this.INOUT_Timer.Tick += new System.EventHandler(this.INOUT_Timer_Tick);
			// 
			// frmInOutHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Out_Log);
			this.Controls.Add(this.In_Log);
			this.Name = "frmInOutHistory";
			this.Text = "입/출고 로그";
			this.Load += new System.EventHandler(this.formInOutHistory_Load);
			((System.ComponentModel.ISupportInitialize)(this.In_Log)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Out_Log)).EndInit();
			this.ResumeLayout(false);

        }

      

        #endregion

        private System.Windows.Forms.DataGridView In_Log;
        private System.Windows.Forms.DataGridView Out_Log;
        private System.Windows.Forms.Timer INOUT_Timer;
    }
}