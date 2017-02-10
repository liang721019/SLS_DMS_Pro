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
using System.Collections;


namespace DMS_ii.binx
{
    public partial class TextPJ_out : Form
    {

        init_function Txfun = new init_function();
        FileManager FileMan = null;

        public TextPJ_out(FileManager FM)
        {
            InitializeComponent();            
            FileMan = FM;
        }
        public string TxPJ_UID
        {
            set;
            get;
        }

        public string TxPJ_DOCNO
        {
            set;
            get;
        }

        public string TxPJ_Text
        {
            set;
            get;
        }        

        private void TextPJ_int_Load(object sender, EventArgs e)
        {
            default_start();            

        }

        public void default_start()     //form預設狀態
        {
            this.Text = "檢驗項目-外檢";
            this.MaximizeBox = false;       //最大化
            this.MinimizeBox = false;       //最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //限制使用者改變form大小
            this.AutoSize = false;          //自動調整大小
            Txfun.Check_error = false;
            Txfun.TxPJ_Option_Panel(TextPJ_panel, BorderStyle.FixedSingle);         //修改指定Panel內的Panel的外框
            #region 檢驗項目讀取
            Txfun.All_DOCNO_TxPJ = TxPJ_DOCNO;
            Txfun.TxPJ_Option_view_All(TextPJ_panel);      //DMS_檢驗項目讀取DB的方法
            other_items_getvalue(TxPJ_DOCNO);
            //Txfun.TxPJ_Option_view(TextPJ_int_panel2);      //DMS_檢驗項目讀取DB的方法
            #endregion            
            #region 判斷是否要顯示CheckButton
            if (FileMan.Status_info.Text == "新增" || FileMan.Status_info.Text == "修改")
            {
                Txfun.TxPJ_Controls_View_Method(TextPJ_panel, true);
                Txfun.EoD_Panel_txt_all(TextPJ_panel, false);
                DMS_TxPJ_UPdate_button.Visible = true;
            }
            else
            {
                Txfun.TxPJ_Controls_View_Method(TextPJ_panel, false);
                Txfun.EoD_Panel_txt_all(TextPJ_panel, true);
                DMS_TxPJ_UPdate_button.Visible = false;
            }
            #endregion
            #region

            #endregion
        }

        public void other_items_value()         //其他檢驗項目的值
        {
            #region 內容
            if (To0108.Checked)
            {
                FileMan.To0108_text = To0108_tb.Text;  
            }
            if (To0209.Checked)
            {
                FileMan.To0209_text = To0209_tb.Text;
            }
            if (To0309.Checked)
            {
                FileMan.To0309_text = To0309_tb.Text;
            }
            if (To0406.Checked)
            {
                FileMan.To0406_text = To0406_tb.Text;
            }
            if (To1101.Checked)
            {
                FileMan.To1101_text = To1101_tb.Text;
            }
            #endregion
        }

        public void other_items_getvalue(string x)         //其他檢驗項目的值
        {
            #region 內容
            if (To0108.Checked)
            {
                Txfun.Query_DB = @"SELECT  [int_other]  FROM [TEST_SLSYHI].[dbo].[SLS_DMS_ii_Text_int]  where [DOC_NO] = '"+x+"' and [int_ID] = 'To0108'";
                Txfun.DMS_TextPJ_ds(Txfun.Query_DB);
                To0108_tb.Text = Txfun.ds_index.Tables[0].Rows[0]["int_other"].ToString();
            }
            if (To0209.Checked)
            {
                Txfun.Query_DB = @"SELECT  [int_other]  FROM [TEST_SLSYHI].[dbo].[SLS_DMS_ii_Text_int]  where [DOC_NO] = '" + x + "' and [int_ID] = 'To0209'";
                Txfun.DMS_TextPJ_ds(Txfun.Query_DB);
                To0209_tb.Text = Txfun.ds_index.Tables[0].Rows[0]["int_other"].ToString();
            }
            if (To0309.Checked)
            {
                Txfun.Query_DB = @"SELECT  [int_other]  FROM [TEST_SLSYHI].[dbo].[SLS_DMS_ii_Text_int]  where [DOC_NO] = '" + x + "' and [int_ID] = 'To0309'";
                Txfun.DMS_TextPJ_ds(Txfun.Query_DB);
                To0309_tb.Text = Txfun.ds_index.Tables[0].Rows[0]["int_other"].ToString();
            }
            if (To0406.Checked)
            {
                Txfun.Query_DB = @"SELECT  [int_other]  FROM [TEST_SLSYHI].[dbo].[SLS_DMS_ii_Text_int]  where [DOC_NO] = '" + x + "' and [int_ID] = 'To0406'";
                Txfun.DMS_TextPJ_ds(Txfun.Query_DB);
                To0406_tb.Text = Txfun.ds_index.Tables[0].Rows[0]["int_other"].ToString();
            }
            if (To1101.Checked)
            {
                Txfun.Query_DB = @"SELECT  [int_other]  FROM [TEST_SLSYHI].[dbo].[SLS_DMS_ii_Text_int]  where [DOC_NO] = '" + x + "' and [int_ID] = 'To1101'";
                Txfun.DMS_TextPJ_ds(Txfun.Query_DB);
                To1101_tb.Text = Txfun.ds_index.Tables[0].Rows[0]["int_other"].ToString();
            }
            #endregion
        }

        private void DMS_TxPJ_UPdate_button_Click(object sender, EventArgs e)
        {
            Txfun.Check_error = false;
            #region 檢驗項目更新DB
            //if (FileMan.Status_info.Text == "修改")
            //{
            //    Txfun.All_DOCNO_TxPJ = TxPJ_DOCNO;

            //    foreach (Control obj in TextPJ_panel.Controls)
            //    {
            //        if (obj.GetType() == typeof(Panel))
            //        {
            //            Txfun.TxPJ_Option_UPDB(((Panel)obj), TxPJ_UID);           //DMS_檢驗項目更新DB的方法
            //        }
            //    }
            //}            
            
            #endregion 

            if (Txfun.Check_error == false)
            {
                //MessageBox.Show("更新DB成功", "DMS");
                Txfun.TxPJ_Option_Text_All(TextPJ_panel);
                FileMan.DMS_TxPJ_Out_GetValue(Txfun.All_TxPJ_Text);
                other_items_value();                //其他檢驗項目的值
                this.Close();
            }
        }

        private void DMS_TxPJ_Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
