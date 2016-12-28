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

        public string App_LoginPW 
        {
            set;
            get;
        }

        public string App_LoginNewPW
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
            DMS_LoginMOD_ServerCB.Items.Add("PRD");
            DMS_LoginMOD_ServerCB.Items.Add("QAS");
            DMS_LoginMOD_ServerCB.Items.Add("DEV");


        }

        private void DMS_Login_Button_Click(object sender, EventArgs e)     //登入
        {
            if (DMS_Login_ServerCB.Text != "")
            {
                App_LoginPW = fun.desEncrypt_A(DMS_Login_PWD_tb.Text, "naturalbiokeyLogin");
                fun.Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Login] '" +
                                    DMS_Login_ID_tb.Text +
                                    @"','" + App_LoginPW + "'";
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

        private void DMS_Login_Cancel_Click(object sender, EventArgs e)     //取消
        {
            this.Close();
        }

        private void DMS_LoginMOD_Button_Click(object sender, EventArgs e)      //修改密碼<確定>
        {
            if (DMS_LoginMOD_ServerCB.Text != "")
            {                
                App_LoginPW = fun.desEncrypt_A(DMS_LoginOLD_PWD_tb.Text, "naturalbiokeyLogin");
                fun.Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Login] '" +
                                    DMS_LoginMOD_ID_tb.Text +
                                    @"','" + App_LoginPW + "'";
                fun.ProductDB_ds(fun.Query_DB);
                if (fun.ds_index.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("帳密不正確!!", this.Text);
                }
                else
                {
                    if (MessageBox.Show("確定要修改密碼？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App_LoginNewPW = fun.desEncrypt_A(DMS_LoginNEW_PWD_tb.Text, "naturalbiokeyLogin");
                        fun.Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Login_ModifyPWD] '" +
                                        DMS_LoginMOD_ID_tb.Text +
                                        @"','" + App_LoginNewPW + "'";
                        fun.DMS_modify(fun.Query_DB, null, null);
                        if (!fun.Check_error)
                        {
                            MessageBox.Show("密碼修改成功!!", this.Text);
                            fun.clearAir(DMS_Modify_panel);
                            DMS_Login_tabControl.SelectedIndex = 0;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("請選擇伺服器!!", this.Text);
            }
        }

        private void DMS_LoginCancel_Button_Click(object sender, EventArgs e)       //修改密碼<取消>
        {
            fun.clearAir(DMS_Modify_panel);            
            DMS_Login_tabControl.SelectedIndex = 0;
        }
    }    
    
}
