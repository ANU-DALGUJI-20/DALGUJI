using Dalgucci;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dalgucci_ManagerPage
{
    public partial class frmInOutHistory : Form
    {
        public void Grid_Style()
        {
            In_Log.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Out_Log.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            In_Log.RowHeadersVisible = false;
            Out_Log.RowHeadersVisible = false;

            In_Log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Out_Log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            In_Log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Out_Log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            In_Log.AllowUserToAddRows = false;
            Out_Log.AllowUserToAddRows = false;


            //AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        }

        public frmInOutHistory()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Grid_Style();
            Program.data.InProdHistory();
            Program.data.OutProdHistory();
        }

        private void In_Log_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Out_Log_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
