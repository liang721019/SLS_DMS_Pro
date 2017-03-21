using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS_ii
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] All_x)
        {
            //MessageBox.Show(All_x + "," + All_y);            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FileManager(All_x));
            if (All_x.Length >= 2)
            {
                Application.Run(new FileManager(All_x));
            }
            else
            {
                Application.Run(new FileManager());
            }
        }
    }
}
