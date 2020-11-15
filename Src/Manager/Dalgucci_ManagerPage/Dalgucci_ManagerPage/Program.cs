using Dalgucci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dalgucci_ManagerPage
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        static public Database data = null;
        static public frmMain g_frmMain = null;
        static public TcpIpServer server = null;
        [STAThread]
       
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            g_frmMain = new frmMain();
            data = new Database();
            server = new TcpIpServer();
            Application.Run(g_frmMain);
        }
    }
}
