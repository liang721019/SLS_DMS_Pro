using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using function.lib;

namespace DMS_ii
{
    public partial class Login_main : Form
    {

        init_function fun = new init_function();


        public Login_main()
        {
            InitializeComponent();
        }

        public string UPW
        {
            set;
            get;
        }
        

        private void Login_main_Load(object sender, EventArgs e)
        {
            this.Text = "Login System";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;//視窗在中央打開
            DMS_Login_ServerCB.Items.Add("PRD");
            DMS_Login_ServerCB.Items.Add("QAS");
            DMS_Login_ServerCB.Items.Add("DEV");

        }

        private void DMS_Login_Button_Click(object sender, EventArgs e)
        {
            if (DMS_Login_ServerCB.Text != "")
            {
                UPW = fun.desEncrypt_A(DMS_Login_PWD_tb.Text, "naturalbiokeyLogin");
                fun.Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Login] '" +
                                    DMS_Login_ID_tb.Text +
                                    @"','" + UPW + "'";
                fun.ProductDB_ds(fun.Query_DB);
                if (fun.ds_index.Tables[0].Rows.Count != 0)
                {
                    //MessageBox.Show("登入成功!!");
                    FileManager FM = new FileManager();
                    FM.DMS_Service_ENV = DMS_Login_ServerCB.Text;       //server
                    FM.DMS_UID = DMS_Login_ID_tb.Text;          //使用者ID
                    this.Hide();
                    FM.ShowDialog(this);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("帳密不正確!!", this.Text);
                }
            }
            else
            {
                MessageBox.Show("請選擇伺服器!!", this.Text);

            }
            
            
        }

        private void DMS_Login_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
