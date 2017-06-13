using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIN;
using System.Windows.Forms;

namespace DMS_ii
{
    class DMS_ii_LOGIN : Login_main
    {
        private DataTable DMS_LOGIN_DT
        {
            get
            {
                return new DataTable();
            }
        }

        public override void V_login_SetENV()      //設定LOGIN變數
        {
            base.V_login_SetENV();            
            Query_DB = @"select * from [dbo].[SLS_DMS_LOGINTemp]('" + ID_Login + "','" + App_LoginPW + "')";
            LOD_DT = DMS_LOGIN_DT;

        }

        public override void V_login_open()      //開窗
        {
            DataView DV = new DataView(LOD_DT);
            DV.RowFilter = "DMS_Login = 'Y'";
            if (DV.Count == 1)
            {
                #region 內容
                //******************************************
                FileManager FM = new FileManager();
                //設定init_Staff 新視窗的相對位置#############
                FM.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                //############################################                
                DataRow FMDR = FM.DMS_DB.DMS_ii_LOGIN.NewRow();
                FMDR["EMP_ID"] = LOD_DT.Rows[0]["EMP_ID"];
                FMDR["EMP_Name"] = LOD_DT.Rows[0]["EMP_Name"];
                FMDR["DMS_Login"] = LOD_DT.Rows[0]["DMS_Login"];
                FMDR["DMS_BPMinput"] = LOD_DT.Rows[0]["DMS_BPMinput"];
                FMDR["DMS_ADD"] = LOD_DT.Rows[0]["DMS_ADD"];
                FMDR["DMS_Modify"] = LOD_DT.Rows[0]["DMS_Modify"];
                FMDR["DMS_Del"] = LOD_DT.Rows[0]["DMS_Del"];
                FMDR["DMS_ROOT"] = LOD_DT.Rows[0]["DMS_ROOT"];
                FMDR["DMS_Other"] = LOD_DT.Rows[0]["DMS_Other"];
                FMDR["Del_Flag"] = LOD_DT.Rows[0]["Del_Flag"];
                FMDR["Create_Date"] = LOD_DT.Rows[0]["Create_Date"];
                FMDR["Create_Time"] = LOD_DT.Rows[0]["Create_Time"];
                FM.DMS_DB.DMS_ii_LOGIN.Rows.Add(FMDR);
                FM.DMS_DB.DMS_ii_LOGIN.AcceptChanges();
                FM.DMS_Service_ENV.Text = ServerName;
                FM.DMS_UID_Value.Text = UID;
                this.Hide();
                FM.ShowDialog(this);
                this.Close();
                //******************************************
                #endregion
            }
            else
            {
                MessageBox.Show("您沒有權限登入!!\n請找資訊部門協助", this.Text);
            }
        }
    }
}
