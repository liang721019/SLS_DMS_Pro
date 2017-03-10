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
using System.IO;
using DMS_ii.binx;


namespace DMS_ii
{
    public partial class FileManager : Form
    {
        init_function fun = new init_function();

        public FileManager()
        {
            InitializeComponent();
        }
        
        #region 變數

        public string Query_DB      //SQL語法變數
        {
            set;
            get;
        }

        public string TxPJ_Query_DB      //SQL語法變數
        {
            set;
            get;
        }

        public string mBox          //訊息內容
        {
            set;
            get;
        }
        public string FText         //訊息標頭
        {
            set;
            get;
        }

        public string DMS_Service_ENV       //伺服器環境
        {
            set
            {
                DMS_Service_ENVtoolStripStatusLabel.Text = value;
            }
            get
            {
                return DMS_Service_ENVtoolStripStatusLabel.Text;
            }
        }
        public string DMS_UID           //使用者ID
        {
            set
            {
                DMS_UID_Value.Text = value;
            }
            get
            {
                return DMS_UID_Value.Text;
            }

        }

        public string Get_DGV_Value_1       //取得DGV選取的列的某一欄位值
        {
            set;
            get;
        }

        public string Get_DGV_Value_2       //取得DGV選取的列的某一欄位值
        {
            set;
            get;
        }

        public string Get_DGV_Value_3       //取得DGV選取的列的某一欄位值
        {
            set;
            get;
        }

        public string FileStorage_Location      //檔案存放位置
        {
            get 
            {
                Query_DB = @"SELECT [info_2] AS FileAccess FROM [TEST_SLSYHI].[dbo].[SLS_DMS_ENVinfo] where [info_1] = '"+DMS_Service_ENVtoolStripStatusLabel.Text+"'";
                fun.ProductDB_ds(Query_DB);
                //fun.ds_index.Tables[0].Rows[0]["FileAccess"].ToString();
                //fun.ds_index.Tables[0].Rows[0]["編號"].ToString(); 
                return fun.ds_index.Tables[0].Rows[0]["FileAccess"].ToString();
            }
        }

        public string Get_filename           //取得檔案名稱
        {
            set;
            get;
        }

        public string Get_AllFileAcc        //取得檔案絕對位置
        {
            set;
            get;
        }

        public static string GETsaric
        {
            set;
            get;
        }

        public string QuickQueryType     //設定或取得快速查詢類型
        {
            set;
            get;
        }

        public string QueryStartDate        //查詢開始日期
        {
            set;
            get;
        }

        public string QueryEndDate          //查詢結束日期
        {
            set;
            get;
        }

        public string QueryOLOD         //查詢條件
        {
            set;
            get;
        }

        public string DMS_Document_Type         //普通件or急件-變數
        {
            set;
            get;
        }

        public string DMS_Sample_Return         //檢驗項目是否退回-變數
        {
            set;
            get;
        }

        public string To01O_text           //外檢-To0108其他
        {
            set;
            get;
        }

        public string To02O_text           //外檢-To0209其他
        {
            set;
            get;
        }

        public string To03O_text           //外檢-To0309其他
        {
            set;
            get;
        }

        public string To04O_text           //外檢-To0406其他
        {
            set;
            get;
        }

        public string To11O_text           //外檢-To1101其他
        {
            set;
            get;
        }
        
        #endregion

        #region 方法
        //================================================================================================

        public void sample_items_other_text(string x)
        {
            if (To01O_text != "")
            {
                Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Update_Other_Sample_items] '" + x + "','To01O','" + To01O_text + "'";
                fun.DMS_modify(Query_DB);
            }
            if (To02O_text != "")
            {
                Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Update_Other_Sample_items] '" + x + "','To02O','" + To02O_text + "'";
                fun.DMS_modify(Query_DB);
            }
            if (To03O_text != "")
            {
                Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Update_Other_Sample_items] '" + x + "','To03O','" + To03O_text + "'";
                fun.DMS_modify(Query_DB);
            }
            if (To04O_text != "")
            {
                Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Update_Other_Sample_items] '" + x + "','To04O','" + To04O_text + "'";
                fun.DMS_modify(Query_DB);
            }
            if (To11O_text != "")
            {
                Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Update_Other_Sample_items] '" + x + "','To11O','" + To11O_text + "'";
                fun.DMS_modify(Query_DB);
            }
        }       //更新DB其他檢驗項目-對應的值

        public void GetSQL(string  uu , string rr )
        {
            switch (uu)
            {
                #region 內容
                case "新增":
                    {
                        #region 新增內容
                        DMS_RBValue();
                        Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Insert]  " +
                                    @"'" + dTP_DMS_DOC_DATE.Text +      //日期 dTP_DMS_DOC_DATE.Text.Replace("/", "")
                                    @"','" + tb_DMS_SAMPLE.Text.Trim() +              //樣品名稱
                                    @"','" + tb_DMS_BATCH_NO.Text.Trim() +             //樣品編號
                                    @"','" + tb_DMS_Order.Text.Trim() +               //訂單編號
                                    @"','" + tb_DMS_ENT_Dent.Text.Trim() +               //委託單位
                                    @"','" + tb_DMS_ENT_User.Text.Trim() +               //委託者
                                    @"','" + tb_DMS_Purpose.Text.Trim() +               //送樣目的
                                    @"','" + tb_DMS_Report_NO.Text.Trim() +               //品保報告/編號
                                    @"','" + tb_DMS_KEEP_NO.Text.Trim() +               //留樣編號
                                    @"','" + tb_DMS_Result.Text.Trim() +               //審查結果-判定
                                    @"','" + tb_DMS_Result_DATE.Text.Trim() +               //審查結果-日期
                                    @"','" + dTP_DMS_PReportDate.Text +       //預計出報告日期
                                    @"','" + tb_DMS_Remark.Text.Trim() +               //備註                                    
                                    @"','" + DMS_UID_Value.Text.Trim() +        //建立者ID
                                    @"','" + tb_DMS_Out_Item.Text.Trim() +        //外檢項目
                                    @"','" + tb_DMS_Out_NO.Text.Trim() +        //委外報告編號                                       
                                    @"','" + tb_DMS_Out_Price.Text.Trim() +        //外檢價格
                                    @"','" + tb_DMS_Self_Item.Text.Trim() +        //自檢項目
                                    @"','" + tb_DMS_Self_NO.Text.Trim() +        //TAF實驗室報告編號                                    
                                    @"','" + tb_DMS_Self_Price.Text.Trim() +        //自檢價格
                                    @"','" + DMS_Document_Type +        //普通件or急件
                                    @"','" + DMS_Sample_Return +        //樣品是否退回
                                    @"','" + tb_DMS_樣品數量.Text.Trim() +        //樣品數量
                                    @"','" + dTP_DMS_製造日期.Text +        //製造日期
                                    @"','" + dTP_DMS_有效日期.Text +        //有效日期
                                    @"','" + dTP_DMS_送樣日期.Text +        //送樣日期
                                    @"'";
                        break;
                        #endregion
                    }
                case "修改":
                    {
                        #region 修改內容
                        DMS_RBValue();
                        Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Update] '" +
                                    tb_DMS_DOC_NO.Text +       //編號
                                    @"','" + dTP_DMS_DOC_DATE.Text +      //日期  dTP_DMS_DOC_DATE.Text.Replace("/", "")
                                    @"','" + tb_DMS_SAMPLE.Text.Trim() +              //樣品名稱
                                    @"','" + tb_DMS_BATCH_NO.Text.Trim() +             //樣品編號
                                    @"','" + tb_DMS_Order.Text.Trim() +               //訂單編號
                                    @"','" + tb_DMS_ENT_Dent.Text.Trim() +               //委託單位
                                    @"','" + tb_DMS_ENT_User.Text.Trim() +               //委託者
                                    @"','" + tb_DMS_Purpose.Text.Trim() +               //送樣目的
                                    @"','" + tb_DMS_Report_NO.Text.Trim() +               //品保報告/編號
                                    @"','" + tb_DMS_KEEP_NO.Text.Trim() +               //留樣編號
                                    @"','" + tb_DMS_Result.Text.Trim() +               //審查結果-判定
                                    @"','" + tb_DMS_Result_DATE.Text.Trim() +               //審查結果-日期
                                    @"','" + dTP_DMS_PReportDate.Text +       //預計出報告日期
                                    @"','" + tb_DMS_Remark.Text.Trim() +               //備註                                    
                                    @"','" + DMS_UID_Value.Text +        //建立者ID
                                    @"','" + tb_DMS_Out_Item.Text.Trim() +        //外檢項目 
                                    @"','" + tb_DMS_Out_NO.Text.Trim() +        //委外報告編號
                                    @"','" + tb_DMS_Out_Price.Text.Trim() +        //外檢價格
                                    @"','" + tb_DMS_Self_Item.Text.Trim() +        //自檢項目
                                    @"','" + tb_DMS_Self_NO.Text.Trim() +        //TAF實驗室報告編號  
                                    @"','" + tb_DMS_Self_Price.Text.Trim() +        //自檢價格
                                    @"','" + DMS_Document_Type +        //普通件or急件
                                    @"','" + DMS_Sample_Return +        //樣品是否退回
                                    @"','" + tb_DMS_樣品數量.Text.Trim() +        //樣品數量
                                    @"','" + dTP_DMS_製造日期.Text +        //製造日期
                                    @"','" + dTP_DMS_有效日期.Text +        //有效日期
                                    @"','" + dTP_DMS_送樣日期.Text +        //送樣日期
                                    @"'";
                                    
                        break;
                        #endregion
                    }
                case "快速查詢":
                    {
                        #region 快速查詢內容
                        Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_QuickQuery]" +                                    
                                    @"'" + QueryStartDate+      //查詢開始日期
                                    @"','" + QueryEndDate +        //查詢結束日期
                                    @"','" + QuickQueryType + "'";  //設定快速查詢類型
                        break;
                        #endregion
                    }
                case "左鍵查詢":
                    {
                        #region 快速查詢內容
                        Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_QuickQuery]" +
                                    @"'" + QueryStartDate +      //查詢開始日期
                                    @"','" + QueryEndDate +        //查詢結束日期
                                    @"','" + QuickQueryType +       //設定快速查詢類型
                                    @"','" + rr + "'";       //委託單編號
                        ////TxPJ_Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_QuickQuery]"+
                        //                @"'" + rr + "'";       //委託單編號;

                        break;
                        #endregion
                    }                
                case "查詢":
                    {
                        #region 查詢內容
                        Query_DB = @"SELECT   A.[DOC_NO]		AS 委託單編號
			                                ,A.[DOC_DATE]	AS 委託日期
			                                ,A.[SAMPLE]		AS 樣品名稱
			                                ,A.[BATCH_NO]	AS 樣品批號
			                                ,A.[ORDER_NO]	AS 訂單編號
			                                ,A.[ENT_DEPT]	AS 委託單位
			                                ,A.[ENT_USER]	AS 委託者
			                                ,A.[PURPOS]		AS 送樣目的
			                                ,A.[REPORT_NO]	AS 品保報告編號
			                                ,A.[KEEP_NO]	AS 留樣編號
			                                ,A.[RESULT]		AS 審查結果判定
			                                ,A.[RESULT_DATE]	AS 審查結果日期
			                                ,A.[REPORT_DATE]	AS 預計出報告日期
			                                ,A.[REMARK]			AS 備註
                                            ,A.[Sample_Query]	AS 樣品數量
				                            ,A.[MFDate]		AS 製造日期
				                            ,A.[EXPDate]	AS 有效日期
				                            ,A.[Preparation_Date]	AS 送樣日期
                                            ,A.[Document_Type]	AS 文件類型
				                            ,A.[Sample_Return]	AS 樣品退回	                                
			                                ,B.[Out_NO]			AS 委外報告編號
                                            ,B.[Out_Price]		AS 外檢價格			                                
			                                ,B.[Self_NO]		AS TAF實驗室報告編號
                                            ,B.[Self_Price]		AS 自檢價格
	                                FROM [TEST_SLSYHI].[dbo].[SLS_DMS_ii]	AS A
	                                left join [TEST_SLSYHI].[dbo].[SLS_DMS_ii_Detail_SampleAnalysis]	AS B
	                                on A.[DOC_NO] = B.[DOC_NO]
	                                where A.[DEL_Flag] = 'N'";
                        
                        break;
                        #endregion                        
                    }
                case "刪除":
                    {
                        #region 刪除內容
                        Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Del]" +
                                    @"'" + tb_DMS_DOC_NO.Text +      //委託單編號                                    
                                    @"','" + DMS_UID_Value.Text + "'";      //使用者ID

                        break;
                        #endregion
                    }                
                case "DGV1_檔案查詢":
                    {
                        #region DGV1_檔案查詢內容
                        Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_File_Query]" +
                                    @"'" + rr + "'";      //編號
                        break;
                        #endregion
                    }
                case "儲存-外檢項目":
                    {
                        #region 儲存外檢項目

                        Query_DB = @"insert into [TEST_SLSYHI].[dbo].[SLS_DMS_ii_Text_int]
                                        select *,null,null,null
                                    from [TEST_SLSYHI].[dbo].[SLS_DMS_Split]('" + tb_DMS_Out_Item.Text.Trim() + "', ',','" + DMS_UID_Value.Text.Trim()+ "','106-001','外')";      //編號
                        break;
                        
                        #endregion
                    }
                case "其他檢驗項目" :
                    {
                        #region 其他檢驗項目
                        //Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Other_Sample_items] '" + tb_DMS_DOC_NO.Text.Trim()+ "','"++"'" ;
                        #endregion
                        break;
                    }
                #endregion
            }
        }

        public void default_status()        //default狀態
        {
            this.Text = "檢驗文件管理系統";
            fun.check_MAC_OK = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;//視窗在中央打開
            fun.Disabled_Panel(DMS_panel1);
            fun.EoD_Panel_CheckBOX(DMS_panel1, false);
            DMS_BPM匯入資料Button.Visible = false;
            DMS_儲存toolStripButton.Visible = false;
            DMS_取消toolStripButton.Visible = false;            
            fun.Format_Panel_dTP(DMS_panel1, "yyyy/MM/dd");     //自訂日期格式
            fun.Format_Panel_dTP(DMS_UP_Controls_panel, "yyyy/MM/dd");          //自訂日期格式
            DGV1_SetColumns();          //DGV1自定顯示欄位
            DGV2_SetColumns();           //DGV2自定顯示欄位
            Status_info.Visible = false;        //狀態不顯示
            DMS_panel2.Visible = false;         //檔案上傳的Panel不顯示
            DMS_MACLable.Visible = false;       //MAC_Lable不顯示
            DMS_MAC_Value.Visible = false;      //MAC值不顯示
            DMS_IP_Value.Visible = false;       //IP位置不顯示
            DMS_file_ordinary1.Checked = true;      //預設普通件
            DMS_Return_N.Checked = true;            //預設不退回檢驗樣品
            DMS_file_Ordinary_QCheck.Visible = false;       //文件類型-查詢條件
            DMS_Return_QCheck.Visible = false;              //樣品退回-查詢條件
            #region 限制TextBox輸入長度限制

            tb_DMS_KEEP_NO.MaxLength = 10;
            tb_DMS_Report_NO.MaxLength = 10;
            tb_DMS_Order.MaxLength = 10;
            tb_DMS_Out_NO.MaxLength = 10;
            tb_DMS_Self_NO.MaxLength = 10;
            tb_DMS_Result_DATE.MaxLength = 10;
            tb_DMS_Purpose.MaxLength = 20;
            tb_DMS_Self_Price.MaxLength = 10;
            tb_DMS_Out_Price.MaxLength = 10;
            tb_DMS_樣品數量.MaxLength = 10;

            #endregion
            DMS_RadioButton_QCheck();        //Open or close RadioButton的查詢條件
            fun.EoD_Panel_All(DMS_UP_Controls_panel, false);        //關閉DMS_UP_Controls_panel內的所有控制項
            Login_check_bt();        //依登入的使用者設定button顯示狀態

        }

        public void start_status(ToolStripButton xx)        //啟動狀態
        {
            if (xx == DMS_新增toolStripButton)
            {
                Status_info.Visible = true;
                Status_info.Text = "新增";
                fun.clearAir(DMS_panel1);
                fun.Enabled_Panel(DMS_panel1);                
                fun.EoD_toolStripButton_Tab(DMS_toolStrip1, false);
                tb_DMS_Out_Item.ReadOnly = true;
                tb_DMS_Self_Item.ReadOnly = true;
                tb_DMS_DOC_NO.ReadOnly = true;
                DMS_儲存toolStripButton.Visible = true;
                DMS_取消toolStripButton.Visible = true;
                DMS_儲存toolStripButton.Enabled = true;
                DMS_取消toolStripButton.Enabled = true;
                DMS_RadioButton_QCheck();       //Open or close RadioButton的查詢條件
                dTP_DMS_DOC_DATE.Focus();
                
            }
            else if (xx == DMS_修改toolStripButton)
            {
                Status_info.Visible = true;
                Status_info.Text = "修改";
                fun.Enabled_Panel(DMS_panel1);
                fun.EoD_toolStripButton_Tab(DMS_toolStrip1, false);
                tb_DMS_Out_Item.ReadOnly = true;
                tb_DMS_Self_Item.ReadOnly = true;
                tb_DMS_DOC_NO.ReadOnly = true;
                DMS_儲存toolStripButton.Visible = true;
                DMS_取消toolStripButton.Visible = true;
                DMS_儲存toolStripButton.Enabled = true;
                DMS_取消toolStripButton.Enabled = true;
                DMS_RadioButton_QCheck();        //Open or close RadioButton的查詢條件
                dTP_DMS_DOC_DATE.Focus();
                
            }
            else if (xx == DMS_刪除toolStripButton)
            {
                fun.clearAir(DMS_panel1);
                fun.Enabled_Panel(DMS_panel1);
                fun.EoD_toolStripButton_Tab(DMS_toolStrip1, false);
                DMS_儲存toolStripButton.Visible = true;
                DMS_取消toolStripButton.Visible = true;
                DMS_儲存toolStripButton.Enabled = true;
                DMS_取消toolStripButton.Enabled = true;
                
            }
            else if (xx == DMS_查詢toolStripButton)
            {
                Status_info.Visible = true;
                Status_info.Text = "查詢";                
                fun.Enabled_Panel(DMS_panel1);
                //fun.clearAir(DMS_panel1);
                //fun.EoD_Panel_CheckBOX(DMS_panel1, true);
                fun.Enabled_Panel(DMS_UP_Controls_panel);
                fun.EoD_toolStripButton_Tab(DMS_toolStrip1, false);
                DMS_儲存toolStripButton.Visible = false;
                DMS_取消toolStripButton.Visible = true;
                DMS_儲存toolStripButton.Enabled = false;
                DMS_取消toolStripButton.Enabled = true;
                DMS_Query_button.Enabled = true;
                DMS_QueryClear_button.Enabled = true;                
                dTP_DMS_PReportDate.Enabled = false;
                dTP_DMS_DOC_DATE.Enabled = false;
                tb_DMS_DOC_NO.ReadOnly = false;
                tb_DMS_Out_Item.ReadOnly = true;
                tb_DMS_Self_Item.ReadOnly = true;
                DMS_RadioButton_QCheck();       //Open or close RadioButton的查詢條件
                tb_DMS_DOC_NO.Focus();
                DMS_tabControl1.SelectedIndex = 0;
                
            }
            
            else if (xx == DMS_儲存toolStripButton)
            {
                Status_info.Text = "";
                Status_info.Visible = false;
                fun.clearAir(DMS_panel1);
                fun.Disabled_Panel(DMS_panel1);
                fun.EoD_toolStripButton_Tab(DMS_toolStrip1, true);
                DMS_儲存toolStripButton.Visible = false;
                DMS_取消toolStripButton.Visible = false;
                DMS_儲存toolStripButton.Enabled = false;
                DMS_取消toolStripButton.Enabled = false;
                DMS_RadioButton_QCheck();        //Open or close RadioButton的查詢條件

            }
            else if (xx == DMS_取消toolStripButton)
            {
                Status_info.Text = "";
                Status_info.Visible = false;
                fun.Disabled_Panel(DMS_panel1);
                fun.EoD_toolStripButton_Tab(DMS_toolStrip1, true);
                fun.EoD_Panel_CheckBOX(DMS_panel1, false);
                DMS_儲存toolStripButton.Visible = false;
                DMS_取消toolStripButton.Visible = false;
                DMS_儲存toolStripButton.Enabled = false;
                DMS_取消toolStripButton.Enabled = false;
                fun.EoD_Panel_All(DMS_UP_Controls_panel, false);        //關閉DMS_UP_Controls_panel內的所有控制項
                DMS_RadioButton_QCheck();       //Open or close RadioButton的查詢條件
            }
        }

        public void start_status(Button x)          //啟動狀態
        {
            if (x == DMS_Query_button)
            {
                Status_info.Text = "";
                fun.Disabled_Panel(DMS_panel1);
                fun.EoD_toolStripButton_Tab(DMS_toolStrip1, true);
                fun.EoD_Panel_btn(DMS_UP_Controls_panel, false);
                fun.EoD_Panel_ComboBox(DMS_UP_Controls_panel, false);
                DMS_儲存toolStripButton.Visible = false;
                DMS_儲存toolStripButton.Enabled = false;
                DMS_取消toolStripButton.Visible = false;
                DMS_取消toolStripButton.Enabled = false;
                DMS_RadioButton_QCheck();
                
            }
            else if (x == DMS_QueryClear_button)
            {
                fun.clearAir(DMS_panel1);
            }
        }

        public void DMS_RBValue()           //RadioButton取值
        {
            if (DMS_file_ordinary1.Checked == true)
            {
                DMS_Document_Type = "01";
            }
            else if (DMS_file_ordinary2.Checked == true)
            {
                DMS_Document_Type = "02";
            }
            if (DMS_Return_Y.Checked == true)
            {
                DMS_Sample_Return = "Y";
            }
            else if (DMS_Return_Y.Checked == false)
            {
                DMS_Sample_Return = "N";
            }
        }

        public void DMS_RadioButton_QCheck()        //Open or close RadioButton的查詢條件
        {
            #region 內容
            if (Status_info.Visible == true)
            {
                if (Status_info.Text == "新增")
                {
                    DMS_file_ordinary1.Enabled = true;
                    DMS_file_ordinary2.Enabled = true;
                    DMS_Return_Y.Enabled = true;
                    DMS_Return_N.Enabled = true;
                    DMS_file_Ordinary_QCheck.Visible = false;   //查詢條件-普通or急件
                    DMS_Return_QCheck.Visible = false;          //查詢條件-樣品是否退回
                    DMS_MFDate_QCheck.Visible = false;          //查詢條件-製造日期
                    DMS_EXPDate_QCheck.Visible = false;         //查詢條件-有效日期
                }  
                else if (Status_info.Text == "查詢")
                {
                    DMS_file_ordinary1.Enabled = true;
                    DMS_file_ordinary2.Enabled = true;
                    DMS_Return_Y.Enabled = true;
                    DMS_Return_N.Enabled = true;
                    DMS_file_Ordinary_QCheck.Visible = true;    //查詢條件-普通or急件
                    DMS_Return_QCheck.Visible = true;           //查詢條件-樣品是否退回
                    DMS_MFDate_QCheck.Visible = true;          //查詢條件-製造日期
                    DMS_EXPDate_QCheck.Visible = true;         //查詢條件-有效日期
                }
                else if (Status_info.Text == "修改")
                {
                    DMS_file_ordinary1.Enabled = true;
                    DMS_file_ordinary2.Enabled = true;
                    DMS_Return_Y.Enabled = true;
                    DMS_Return_N.Enabled = true;
                    DMS_file_Ordinary_QCheck.Visible = false;   //查詢條件-普通or急件
                    DMS_Return_QCheck.Visible = false;          //查詢條件-樣品是否退回
                    DMS_MFDate_QCheck.Visible = false;          //查詢條件-製造日期
                    DMS_EXPDate_QCheck.Visible = false;         //查詢條件-有效日期
                }                              
                else
                {
                    DMS_file_ordinary1.Enabled = false;
                    DMS_file_ordinary2.Enabled = false;
                    DMS_Return_Y.Enabled = false;
                    DMS_Return_N.Enabled = false;
                    DMS_file_Ordinary_QCheck.Visible = false;   //查詢條件-普通or急件
                    DMS_Return_QCheck.Visible = false;          //查詢條件-樣品是否退回
                    DMS_MFDate_QCheck.Visible = false;          //查詢條件-製造日期
                    DMS_EXPDate_QCheck.Visible = false;         //查詢條件-有效日期
                }
            }
            else
            {
                DMS_file_ordinary1.Enabled = false;
                DMS_file_ordinary2.Enabled = false;
                DMS_Return_Y.Enabled = false;
                DMS_Return_N.Enabled = false;
                DMS_file_Ordinary_QCheck.Visible = false;       //查詢條件-普通or急件
                DMS_Return_QCheck.Visible = false;              //查詢條件-樣品是否退回
                DMS_MFDate_QCheck.Visible = false;          //查詢條件-製造日期
                DMS_EXPDate_QCheck.Visible = false;         //查詢條件-有效日期
            }

            #endregion
        }

        public void SYS_Status_Key()            //判斷是否能使用本系統
        {
            #region 判斷是否能使用本系統
            fun.Query_DB = @"SELECT [MAC_EID] AS 員工編號 FROM [TEST_SLSYHI].[dbo].[SLS_AssetMAC] where [MAC_address] = '" + DMS_MAC_Value.Text + "'";
            fun.ProductDB_ds(fun.Query_DB);
            if (fun.ds_index.Tables[0].Rows.Count != 0)
            {
                DMS_UID_Value.Text = fun.ds_index.Tables[0].Rows[0]["員工編號"].ToString();
                fun.check_Login(DMS_MAC_Value.Text);         //確認是否能使用本系統
                #region 確認是否有管理者的權限
                if (fun.check_MAC_OK)
                {
                    #region 內容-確認是否有管理者的權限
                    fun.check_MAC(DMS_MAC_Value.Text);           //確認是否有管理者的權限
                    if (fun.check_MAC_OK)
                    {
                        

                    }
                    else
                    {

                    }
                    #endregion

                }
                else
                {
                    MessageBox.Show("無權限使用系統!!請跟管理員申請!!", "資產管理系統");
                    this.Close();

                }

                #endregion
            }
            else
            {
                MessageBox.Show("無權限使用系統!!請跟管理員申請!!", "資產管理系統");
                this.Close();
            }
            #endregion

        }

        public void sub_()      //TestBOX與DB欄位的對應
        {
            try
            {
                #region 內容
                tb_DMS_DOC_NO.Text = fun.ds_index.Tables[0].Rows[0]["委託單編號"].ToString();                
                dTP_DMS_DOC_DATE.Text = fun.ds_index.Tables[0].Rows[0]["委託日期"].ToString();
                tb_DMS_SAMPLE.Text = fun.ds_index.Tables[0].Rows[0]["樣品名稱"].ToString();
                tb_DMS_BATCH_NO.Text = fun.ds_index.Tables[0].Rows[0]["樣品批號"].ToString();
                tb_DMS_ENT_Dent.Text = fun.ds_index.Tables[0].Rows[0]["委託單位"].ToString();
                tb_DMS_ENT_User.Text = fun.ds_index.Tables[0].Rows[0]["委託者"].ToString();
                tb_DMS_Purpose.Text = fun.ds_index.Tables[0].Rows[0]["送樣目的"].ToString();
                tb_DMS_Report_NO.Text = fun.ds_index.Tables[0].Rows[0]["品保報告編號"].ToString();
                tb_DMS_Order.Text = fun.ds_index.Tables[0].Rows[0]["訂單編號"].ToString();
                tb_DMS_KEEP_NO.Text = fun.ds_index.Tables[0].Rows[0]["留樣編號"].ToString();
                tb_DMS_Result.Text = fun.ds_index.Tables[0].Rows[0]["審查結果判定"].ToString();
                tb_DMS_Result_DATE.Text = fun.ds_index.Tables[0].Rows[0]["審查結果日期"].ToString();
                dTP_DMS_PReportDate.Text = fun.ds_index.Tables[0].Rows[0]["預計出報告日期"].ToString();
                tb_DMS_樣品數量.Text = fun.ds_index.Tables[0].Rows[0]["樣品數量"].ToString();
                dTP_DMS_製造日期.Text = fun.ds_index.Tables[0].Rows[0]["製造日期"].ToString();
                dTP_DMS_有效日期.Text = fun.ds_index.Tables[0].Rows[0]["有效日期"].ToString();
                dTP_DMS_送樣日期.Text = fun.ds_index.Tables[0].Rows[0]["送樣日期"].ToString();
                tb_DMS_Remark.Text = fun.ds_index.Tables[0].Rows[0]["備註"].ToString();
                tb_DMS_Out_NO.Text = fun.ds_index.Tables[0].Rows[0]["委外報告編號"].ToString();
                //tb_DMS_Out_Item.Text = fun.ds_index.Tables[0].Rows[0]["外檢項目"].ToString();
                tb_DMS_Out_Price.Text = fun.ds_index.Tables[0].Rows[0]["外檢價格"].ToString();
                tb_DMS_Self_NO.Text = fun.ds_index.Tables[0].Rows[0]["TAF實驗室報告編號"].ToString();
                //tb_DMS_Self_Item.Text = fun.ds_index.Tables[0].Rows[0]["自檢項目"].ToString();
                tb_DMS_Self_Price.Text = fun.ds_index.Tables[0].Rows[0]["自檢價格"].ToString();
                #region 從DB取得radioButton的值
                if (fun.ds_index.Tables[0].Rows[0]["文件類型"].ToString() == "01")
                {
                    DMS_file_ordinary1.Checked = true;
                }
                else if (fun.ds_index.Tables[0].Rows[0]["文件類型"].ToString() == "02")
                {
                    DMS_file_ordinary2.Checked = true;
                }

                if (fun.ds_index.Tables[0].Rows[0]["樣品退回"].ToString() == "Y")
                {
                    DMS_Return_Y.Checked = true;
                }
                else if (fun.ds_index.Tables[0].Rows[0]["樣品退回"].ToString() == "N")
                {
                    DMS_Return_N.Checked = true;
                }
                #endregion
                //,A.[Document_Type]	AS 文件類型
				//,A.[Sample_Return]	AS 樣品退回
                #endregion
            }
            catch (Exception z)
            {
                fun.Check_error = true;
                System.Windows.Forms.MessageBox.Show(z.Message);
            }

        }

        public void TxPJ_sub_()     //TestBOX與DB欄位的對應-檢驗項目
        {
            try
            {
                #region 內容
                tb_DMS_Out_Item.Text = fun.Out_TxPJ_NO;
                tb_DMS_Self_Item.Text = fun.Int_TxPJ_NO;                
                #endregion
            }
            catch (Exception z)
            {
                fun.Check_error = true;
                System.Windows.Forms.MessageBox.Show(z.Message);
            }

        }

        public void DGV1_SetColumns()           //DGV1自定顯示欄位
        {
            DMS_dataGridView1.AutoGenerateColumns = false;
            DMS_DGV1_Column1.DataPropertyName = "委託單編號";
            DMS_DGV1_Column2.DataPropertyName = "委託日期";
            DMS_DGV1_Column3.DataPropertyName = "樣品名稱";
            DMS_DGV1_Column4.DataPropertyName = "樣品批號";
            DMS_DGV1_Column5.DataPropertyName = "訂單編號";
            DMS_DGV1_Column6.DataPropertyName = "委託單位";
            DMS_DGV1_Column7.DataPropertyName = "委託者";
            DMS_DGV1_Column8.DataPropertyName = "送樣目的";
            DMS_DGV1_Column9.DataPropertyName = "品保報告編號";
            DMS_DGV1_Column10.DataPropertyName = "留樣編號";
            DMS_DGV1_Column11.DataPropertyName = "審查結果判定";
            DMS_DGV1_Column12.DataPropertyName = "審查結果日期";
            DMS_DGV1_Column13.DataPropertyName = "預計出報告日期";
            DMS_DGV1_Column14.DataPropertyName = "備註";
            DMS_DGV1_Column15.DataPropertyName = "樣品數量";
            DMS_DGV1_Column16.DataPropertyName = "製造日期";
            DMS_DGV1_Column17.DataPropertyName = "有效日期";
            DMS_DGV1_Column18.DataPropertyName = "送樣日期";
            DMS_DGV1_Column19.DataPropertyName = "文件類型";
            DMS_DGV1_Column20.DataPropertyName = "樣品退回";
            DMS_DGV1_Column21.DataPropertyName = "委外報告編號";
            //DMS_DGV1_Column17.DataPropertyName = "自檢項目";
            DMS_DGV1_Column22.DataPropertyName = "TAF實驗室報告編號";
            DMS_DGV1_Column23.DataPropertyName = "外檢價格";
            DMS_DGV1_Column24.DataPropertyName = "自檢價格";
            DMS_DGV1_Column1.Frozen = true; //凍結窗格
            DMS_DGV1_Column2.Frozen = true; //凍結窗格
            DMS_DGV1_Column3.Frozen = true; //凍結窗格



        }

        public void DGV2_SetColumns()           //DGV2自定顯示欄位
        {
            DMS_dataGridView2.AutoGenerateColumns = false;
            DMS_DGV2_Column1.DataPropertyName = "編號";
            DMS_DGV2_Column2.DataPropertyName = "序號";
            DMS_DGV2_Column3.DataPropertyName = "檔案名稱";
            DMS_DGV2_Column4.DataPropertyName = "建檔使用者";
            DMS_DGV2_Column5.DataPropertyName = "建檔日期";
            DMS_DGV2_Column6.DataPropertyName = "建檔時間";
            DMS_DGV2_Column1.Frozen = true; //凍結窗格
            DMS_DGV2_Column2.Frozen = true; //凍結窗格
            
        }

        public void Login_check_bt()        //依登入的使用者設定button顯示狀態
        {
            fun.Query_DB = @"select [DMS_BPMinput]  from [TEST_SLSYHI].[dbo].[SLS_Employees] where [EMP_ID] = '" + DMS_UID_Value.Text + "' and [DMS_BPMinput] = 'Y'";
            fun.ProductDB_ds(fun.Query_DB);
            if (fun.ds_index.Tables[0].Rows.Count == 1)     //DMS_BPM匯入資料Button
            {
                DMS_BPM匯入資料Button.Enabled = true;      //<BPM匯入資料>打開
                DMS_BPM匯入資料Button.Visible = true;      //<BPM匯入資料>打開
            }
            else
            {
                DMS_BPM匯入資料Button.Enabled = false;      //<BPM匯入資料>關閉
                DMS_BPM匯入資料Button.Visible = false;      //<BPM匯入資料>關閉
                
            }
        }

        public void DateC(string x, string y)         //日期轉換20161203轉成2016/12/03
        {
            x = y.Substring(0, 4) + "/" + y.Substring(4, 2) + "/" + y.Substring(6, 2);
        }

        public void Del_File()          //刪除文件內容 DB資料及檔案
        {
            if (MessageBox.Show("確定要刪除？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                #region 刪除檔案
                Get_DGV_Value_1 = DMS_dataGridView2.SelectedRows[0].Cells[0].Value.ToString();  //編號
                Get_DGV_Value_2 = DMS_dataGridView2.SelectedRows[0].Cells[1].Value.ToString();  //序號
                Get_DGV_Value_3 = DMS_dataGridView2.SelectedRows[0].Cells[2].Value.ToString();  //檔名
                fun.Check_error = false;
                string Del_File = FileStorage_Location + "\\" + Get_DGV_Value_3;
                fun.DMS_File_Del(Del_File); 
                #endregion

                #region DB-刪除資料
                if (fun.Check_error == false)
                {
                    Query_DB = @"EXEC [TEST_SLSYHI].[dbo].[SLS_DMS_File_Del] '" +
                                Get_DGV_Value_1 + "','" + Get_DGV_Value_2 + "','"+DMS_UID_Value.Text+"'";
                    fun.DMS_file_modify(Query_DB);                    
                }

                #endregion
                if (fun.Check_error == false)
                {
                    MessageBox.Show("已成功《刪除》資料", "DMS");
                }
            }
        }

        public void OpenFile(string x)          //打開檔案
        {
            //Get_filename = DMS_dataGridView2.CurrentRow.Cells[2].Value.ToString();
            Get_AllFileAcc = FileStorage_Location + "\\" + tb_DMS_DOC_NO.Text+ "\\" + x;
            fun.openPdf(Get_AllFileAcc);
        }

        public void QueryCheckBox()         //設定QueryOLOD的值=>查詢條件
        {
            #region 內容
            QueryOLOD = "";
            if (tb_DMS_DOC_NO.Text != "")       //委託單編號
            {
                QueryOLOD += @"and A.[DOC_NO] like N'%" + tb_DMS_DOC_NO.Text+ "%'";
            }

            if (DMS_Query_CB.Text == "委託日期")       //委託日期
            {
                QueryOLOD += @"and A.[DOC_DATE] BETWEEN '" + dTP_Query_StartDate.Text + "' and '"+dTP_Query_EndDate.Text+"'";
            }
            if (DMS_Query_CB.Text == "預計出報告日期")       //委託日期
            {
                QueryOLOD += @"and A.[REPORT_DATE] BETWEEN '" + dTP_Query_StartDate.Text + "' and '" + dTP_Query_EndDate.Text + "'";
            }
            
            if (tb_DMS_BATCH_NO.Text != "")     //樣品批號
            {
                QueryOLOD += @"and A.[BATCH_NO]  like N'%" + tb_DMS_BATCH_NO.Text + "%'";
            }
            if (tb_DMS_SAMPLE.Text != "")     //樣品名稱
            {
                QueryOLOD += @"and A.[SAMPLE] like N'%" + tb_DMS_SAMPLE.Text + "%'";
            }
            if (tb_DMS_Order.Text != "")     //訂單編號
            {
                QueryOLOD += @"and A.[ORDER_NO] like N'%" + tb_DMS_Order.Text + "%'";
            }
            if (tb_DMS_Report_NO.Text != "")     //品保報告編號
            {
                QueryOLOD += @"and A.[REPORT_NO] like N'%" + tb_DMS_Report_NO.Text + "%'";
            }
            if (tb_DMS_Purpose.Text != "")     //送樣目的
            {
                QueryOLOD += @"and A.[PURPOS] like N'%" + tb_DMS_Purpose.Text + "%'";
            }
            if (tb_DMS_KEEP_NO.Text != "")     //留樣編號
            {
                QueryOLOD += @"and A.[KEEP_NO] like N'%" + tb_DMS_KEEP_NO.Text + "%'";
            }
            if (tb_DMS_Result.Text != "")     //審查結果判定
            {
                QueryOLOD += @"and A.[RESULT] like N'%" + tb_DMS_Result.Text + "%'";
            }
            if (tb_DMS_Result_DATE.Text != "")     //審查結果日期
            {
                QueryOLOD += @"and A.[RESULT_DATE] like N'%" + tb_DMS_Result_DATE.Text + "%'";
            }
            if (tb_DMS_Remark.Text != "")     //備註
            {
                QueryOLOD += @"and A.[REMARK] like N'%" + tb_DMS_Remark.Text + "%'";
            }

            if (tb_DMS_樣品數量.Text != "")     //樣品數量
            {
                QueryOLOD += @"and A.[Sample_Query] = '" + tb_DMS_樣品數量.Text + "'";
            }

            if (DMS_Query_CB.Text == "送樣日期")       //送樣日期
            {
                QueryOLOD += @"and A.[Preparation_Date] BETWEEN '" + dTP_Query_StartDate.Text + "' and '" + dTP_Query_EndDate.Text + "'";
            }
            
            if (tb_DMS_Out_NO.Text != "")     //委外報告編號
            {
                QueryOLOD += @"and B.[Out_NO] like N'%" + tb_DMS_Out_NO.Text + "%'"; ;
            }
            
            if (tb_DMS_Out_Price.Text != "")     //外檢價格
            {
                QueryOLOD += @"and B.[Out_Price] ='" + tb_DMS_Out_Price.Text + "'";
            }
            if (tb_DMS_Self_NO.Text != "")     //TAF實驗室報告編號
            {
                QueryOLOD += @"and B.[Self_NO] like N'%" + tb_DMS_Self_NO.Text + "%'";
            }
            
            if (tb_DMS_Self_Price.Text != "")     //自檢價格
            {
                QueryOLOD += @"and B.[Self_Price] = '" + tb_DMS_Self_Price.Text + "'";
            }
            if (tb_DMS_ENT_Dent.Text != "")     //委託單位
            {
                QueryOLOD += @"and A.[ENT_DEPT] like N'%" + tb_DMS_ENT_Dent.Text + "%'";
            }
            if (tb_DMS_ENT_User.Text != "")     //委託者
            {
                QueryOLOD += @"and A.[ENT_USER] like N'%" + tb_DMS_ENT_User.Text + "%'";
            }
            #region CheckedBox查詢條件

            if (DMS_file_Ordinary_QCheck.Checked == true)
            {
                #region 內容
                if (DMS_file_ordinary1.Checked)
                {
                    //普通件
                    QueryOLOD += @"and A.[Document_Type] = '01'";
                }
                else if (DMS_file_ordinary2.Checked)
                {
                    //急件
                    QueryOLOD += @"and A.[Document_Type] = '02'";
                }
                #endregion
            }

            if (DMS_Return_QCheck.Checked == true)
            {
                #region 內容
                if (DMS_Return_Y.Checked)
                {
                    //樣品是否退回-是
                    QueryOLOD += @"and A.[Sample_Return] = 'Y'";
                }
                else if (DMS_Return_N.Checked)
                {
                    //樣品是否退回-否
                    QueryOLOD += @"and A.[Sample_Return] = 'N'";
                }

                #endregion
            }

            if (DMS_MFDate_QCheck.Checked == true)
            {
                #region 內容
                QueryOLOD += @"and A.[MFDate] = '" + dTP_DMS_製造日期.Text+ "'";

                #endregion
            }

            if (DMS_EXPDate_QCheck.Checked == true)
            {
                #region 內容
                QueryOLOD += @"and A.[MFDate] = '" + dTP_DMS_有效日期.Text + "'";
                #endregion
            }
            #endregion

            QueryOLOD += "order by 1";

            #endregion
        }

        public void QueryComboBox()         //查詢工具列的ComboBox選項
        {
            DMS_Query_CB.Items.Add("無日期");
            DMS_Query_CB.Items.Add("委託日期");
            DMS_Query_CB.Items.Add("送樣日期");
            DMS_Query_CB.Items.Add("預計出報告日期");
            DMS_Query_CB.SelectedIndex = 0;            

        }

        public void DMS_DBUPdate_FileUP(string x)       //檔案上傳-新增DB
        {
            fun.Query_DB = "";
            fun.Query_DB += @"SELECT [File_Name]  FROM [TEST_SLSYHI].[dbo].[SLS_DMS_ii_File]";
            fun.Query_DB += @"where [DOC_NO] = '" + tb_DMS_DOC_NO.Text + "' and [Del_Flag] = 'N'";
            fun.Query_DB += @"and [File_Name] = '" + x + "'";
            fun.ProductDB_ds(fun.Query_DB);
            if (fun.ds_index.Tables[0].Rows.Count == 0)
            {
                string insert_DB = @"EXEC [TEST_SLSYHI].[dbo].[SLS_DMS_File_insert] '" + tb_DMS_DOC_NO.Text + "','" + x + "','" + DMS_UID_Value.Text + "'";//新增資料
                fun.DMS_file_insert(insert_DB);       //新增資料                
            }
            //else
            //{
            //    MessageBox.Show("《"+x+"》已存在資料庫中", "警告");
            //}

        }

        public void DMS_TxPJ_Out_GetValue(string x )        //取得TextPJ-外檢的值
        {
            tb_DMS_Out_Item.Text = x;
        }

        public void DMS_TxPJ_Int_GetValue(string x)        //取得TextPJ-內檢的值
        {
            tb_DMS_Self_Item.Text = x;
        }
       
        
        //================================================================================================
        #endregion

        private void FileManager_Load(object sender, EventArgs e)
        {             
            default_status();
            fun.ReMAC(DMS_MAC_Value, DMS_IP_Value);
            QueryComboBox();         //查詢工具列的ComboBox選項            
        }
        
        #region Button
        //================================================================================================
        private void DMS_新增toolStripButton_Click(object sender, EventArgs e)
        {
            start_status(DMS_新增toolStripButton);        //啟動狀態
        }

        private void DMS_查詢toolStripButton_Click(object sender, EventArgs e)
        {
            start_status(DMS_查詢toolStripButton);        //啟動狀態
        }         

        private void DMS_修改toolStripButton_Click(object sender, EventArgs e)
        {
            start_status(DMS_修改toolStripButton);        //啟動狀態
        }

        private void DMS_刪除toolStripButton_Click(object sender, EventArgs e)
        {
            if (tb_DMS_DOC_NO.Text != "")
            {
                if (MessageBox.Show("確定要刪除？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fun.Check_error = false;
                    GetSQL("刪除", null);    //語法丟進fun.Query_DB
                    fun.DMS_file_modify(Query_DB);         //連接DB-執行DB指令 
                    if (fun.Check_error == false)
                    {
                        MessageBox.Show("資料成功刪除!!", "DMS");
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有文件編號!!","DMS");
            }
        }

        private void DMS_儲存toolStripButton_Click(object sender, EventArgs e)
        {
            
            if (Status_info.Text == "新增")
            {
                #region 內容
                if (MessageBox.Show("確定要新增？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GetSQL("新增", null);
                    fun.DMS_insert(Query_DB);
                    sample_items_other_text(tb_DMS_DOC_NO.Text.Trim());     //把其他檢驗項目的Text存到DB中
                    if (fun.Check_error == false)
                    {
                        MessageBox.Show("資料《新增》成功!!", "DMS");
                    }

                }
                #endregion
            }
            else if (Status_info.Text == "修改")
            {
                #region 內容
                if (tb_DMS_DOC_NO.Text != "")
                {
                    if (MessageBox.Show("確定要修改？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        fun.Check_error = false;
                        GetSQL("修改", null);                        
                        fun.DMS_modify(Query_DB);
                        sample_items_other_text(tb_DMS_DOC_NO.Text.Trim());     //把其他檢驗項目的Text存到DB中
                        //db_sum = SQL語法            
                        //mBox = 成功執行後的訊息
                        //FText = MessageBox.form.Text
                        if (fun.Check_error == false)
                        {
                            MessageBox.Show("資料《修改》成功!!", "DMS");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("沒有文件編號!!不能修改","DMS");
                }
                
                #endregion
            }
            start_status(DMS_儲存toolStripButton);        //啟動狀態

            
        }

        private void DMS_取消toolStripButton_Click(object sender, EventArgs e)
        {
            start_status(DMS_取消toolStripButton);        //啟動狀態
        }

        private void DMS_匯出資料toolStripButton_Click(object sender, EventArgs e)
        {
            string[] text = new string[DMS_dataGridView1.ColumnCount];
            for (int x = 0; x < DMS_dataGridView1.ColumnCount; x++) //把dataGridView2的標題列寫入到text陣列
            {
                text[x] = DMS_dataGridView1.Columns[x].HeaderText;
            }
            fun.output_xls(DMS_dataGridView1, text ,this.Text);
        }

        private void DMS_tabControl1_DoubleClick(object sender, EventArgs e)        //DMS_tabControl1雙擊二下
        {

            //if (DMS_panel1.Visible)
            //{
            //    DMS_panel1.Visible = false;
            //    DMS_panel2.Visible = false;
            //    DMS_tabControl1.Location = DMS_panel1.Location;

            //    //DMS_tabControl1.Size = new System.Drawing.Size(984, 600);

            //}
            //else
            //{
            //    DMS_panel1.Visible = true;
            //    DMS_panel2.Visible = true;
            //    DMS_tabControl1.Location = new Point(12, 82);
            //    //DMS_tabControl1.Size = new System.Drawing.Size(984, 280);12, 82
            //}
            
        }

        private void DMS_Query_button_Click(object sender, EventArgs e)         //查詢Button
        {
            #region 內容
            if (Status_info.Text == "查詢")
            {
                QueryStartDate = dTP_Query_StartDate.Text;      //查詢開始日期
                QueryEndDate = dTP_Query_EndDate.Text;          //查詢結束日期
                DMS_tabControl1.SelectedIndex = 0;          //分頁設定第一頁
                GetSQL("查詢", null);
                QueryCheckBox();       //設定QueryOLOD的值 =>查詢條件
                fun.xxx_DB(Query_DB + QueryOLOD, DMS_dataGridView1);
                start_status(DMS_Query_button);         //啟動狀態
            }
            #endregion
        }

        private void DMS_QueryClear_button_Click(object sender, EventArgs e)        //清除Button
        {
            start_status(DMS_QueryClear_button); 
        }

        private void DMS_BPM匯入資料Button_Click(object sender, EventArgs e)        //BPM匯入資料
        {

        }

        private void bt_DMS_Update_Click(object sender, EventArgs e)        //更新
        {
            if (tb_DMS_DOC_NO.Text != "")
            {
                GetSQL("DGV1_檔案查詢", tb_DMS_DOC_NO.Text);    //語法丟進fun.Query_DB
                fun.xxx_DB(Query_DB, DMS_dataGridView2);         //連接DB-執行DB指令
            }
        }

        #region DMS_FileUp檔案上傳的方法
        //=====================================================================================================
        private void DMS_FileUp_DragEnter(object sender, DragEventArgs e)       //發生在DMS_FileUp物件拖曳至控制項邊框中時
        {
            // 確定使用者抓進來的是檔案
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // 允許拖拉動作繼續 (這時滑鼠游標應該會顯示 +)
                e.Effect = DragDropEffects.All;                
            }

        }

        private void DMS_FileUp_DragDrop(object sender, DragEventArgs e)        //發生在DMS_FileUp完成拖放作業時
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string Ufile in files)
            {                
                if (!DMS_FileUp.Items.Contains(Ufile))      //辨別施進的檔案是否有重複
                {
                    DMS_FileUp.Items.Add(Ufile);     //取得完整路徑                    
                }
            }

        }

        private void DMS_File_UPbutton_Click(object sender, EventArgs e)        //上傳檔案
        {
            #region 上傳檔案~新增資料庫的內容
            if (tb_DMS_DOC_NO.Text != "")
            {
                if (MessageBox.Show("確定要上傳檔案？", "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    #region 確定上傳的內容
                    fun.Check_error = false;
                    
                    
                    for (int i = 0; i < DMS_FileUp.Items.Count; i++)
                    {

                        string DFU_x = DMS_FileUp.Items[0].ToString();
                        string DFU_y = FileStorage_Location+"\\"+ tb_DMS_DOC_NO.Text;            //檔案路徑
                        string info_FileName = Path.GetFileName(DFU_x);        //取得檔名
                        #region 判斷是否有資料夾
                        if (!System.IO.Directory.Exists(DFU_y))     //判斷是否有資料夾->沒有資料夾就新增
                        {
                            try
                            {
                                System.IO.Directory.CreateDirectory(DFU_y);      //新增資料夾                                
                            }
                            catch (UnauthorizedAccessException)
                            {
                                MessageBox.Show("使用者沒有<新增資料夾>權限!!", "警告!!");
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message, "警告!!");
                            }
                            
                        }
                        #endregion

                        #region DB-新增資料
                        if (fun.Check_error == false)
                        {
                            DMS_DBUPdate_FileUP(info_FileName);      //檔案上傳-新增DB
                        }
                        #endregion

                        #region 檔案上傳內容
                        if (fun.Check_error == false)
                        {
                                                        
                            fun.DMS_File_UP(DFU_x, DFU_y);      //檔案COPY到指定目錄
                            if (fun.Check_error == false)
                            {
                                DMS_FileUp.Items.RemoveAt(0);       //指定刪除ListBox內的項目
                            } 
                        }
                        i = -1;     //NOTE:
                        #endregion
                        
                    }                    
                    if (fun.Check_error == false)
                    {
                        MessageBox.Show("資料及檔案上傳成功!!", "DMS");
                    }
                    GetSQL("DGV1_檔案查詢", tb_DMS_DOC_NO.Text);    //語法丟進fun.Query_DB
                    fun.xxx_DB(Query_DB, DMS_dataGridView2);         //連接DB-執行DB指令

                    #endregion
                }
            }
            else
            {
                MessageBox.Show("沒有編號!!請選擇文件編號!!","DMS");
            }
            #endregion
        }

        private void DMS_Clear_FileUP_button_Click(object sender, EventArgs e)      //上傳清除
        {
            
            DMS_FileUp.Items.Clear();       //清空ListBox中所有的項目
        }

        //=====================================================================================================
        #endregion

        private void DMS_Query_DOCNO_KeyDown(object sender, KeyEventArgs e)         //DMS_Query_DOCNO按Enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region  按Enter之後執行
                start_status(DMS_查詢toolStripButton);        //啟動狀態
                QueryStartDate = dTP_Query_StartDate.Text.Replace("/", "");
                QueryEndDate = dTP_Query_EndDate.Text.Replace("/", "");
                QuickQueryType = "A";
                GetSQL("快速查詢", null);
                //GetSQL("查詢",編號)
                fun.xxx_DB(Query_DB, DMS_dataGridView1);
                #endregion
            }
        }

        private void DMS_dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)      //DMS_dataGridView1雙擊二下
        {
            if (e.RowIndex >= 0)
            {
                string get_ID = DMS_dataGridView1.CurrentRow.Cells[0].Value.ToString();                

                GetSQL("DGV1_檔案查詢", get_ID);    //語法丟進fun.Query_DB
                fun.xxx_DB(Query_DB, DMS_dataGridView2);         //連接DB-執行DB指令                 
                DMS_tabControl1.SelectedIndex = 1;
                
            }

        }

        private void DMS_dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)      //DMS_dataGridView1左鍵點一下
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.RowIndex >= 0)
                {
                    if (Status_info.Text == "")
                    {
                        string s_ID = DMS_dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        QueryStartDate = DMS_dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        QueryEndDate = DMS_dataGridView1.CurrentRow.Cells[1].Value.ToString();

                        QuickQueryType = "C";
                        fun.All_DOCNO_TxPJ = s_ID;
                        GetSQL("左鍵查詢", s_ID);    //語法丟進fun.Query_DB
                        fun.ProductDB_ds(Query_DB);         //連接DB-執行DB指令
                        sub_();                        
                        fun.TxPJ_Option_out_LeftQuery();        //DMS_外檢驗項目讀取DB的方法-對應Textbox                        
                        fun.TxPJ_Option_int_LeftQuery();        //DMS_內檢驗項目讀取DB的方法-對應Textbox
                        TxPJ_sub_();
                    }
                    
                }
            }
        }

        private void DMS_dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)          //DMS_dataGridView2左鍵雙擊二下
        {
            if (e.RowIndex >= 0)
            {
                Get_filename = DMS_dataGridView2.CurrentRow.Cells[2].Value.ToString();
                OpenFile(Get_filename);
            }

        }

        private void DMS_tabControl1_SelectedIndexChanged(object sender, EventArgs e)       //DMS_tabControl1切換分頁設定
        {
            try
            {
                #region 內容
                if (DMS_tabControl1.SelectedIndex == 0)         
                {
                    #region 分頁代號0
                    DMS_panel2.Visible = false;                    
                    #endregion
                }
                else if (DMS_tabControl1.SelectedIndex == 1)            
                {
                    #region 分頁代號1
                    DMS_panel2.Visible = true;
                    
                    #endregion
                }
                
                #endregion
            }
            catch (Exception x)
            {
                System.Windows.Forms.MessageBox.Show(x.Message);
            }

        }

        private void DMS_dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)       //DMS_dataGridView2右鍵
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    try
                    {
                        DMS_dataGridView2.ClearSelection();
                        DMS_dataGridView2.Rows[e.RowIndex].Selected = true;
                        DMS_dataGridView2.CurrentCell = DMS_dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        this.DMS_DGV2_contextMenuStrip.Show(MousePosition.X, MousePosition.Y);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void 刪除ToolStripMenuItem_Click(object sender, EventArgs e)      //DGV2右鍵-刪除
        {
            fun.Check_error = false;
            Del_File();
            GetSQL("DGV1_檔案查詢", Get_DGV_Value_1);    //語法丟進fun.Query_DB
            fun.xxx_DB(Query_DB, DMS_dataGridView2);         //連接DB-執行DB指令
        }

        private void 開啟檔案ToolStripMenuItem_Click(object sender, EventArgs e)        //DGV2右鍵-開啟檔案
        {
            Get_filename = DMS_dataGridView2.CurrentRow.Cells[2].Value.ToString();
            OpenFile(Get_filename);
        }

        private void DMS_FileUp_MouseDoubleClick(object sender, MouseEventArgs e)       //ListBox雙擊左鍵二下
        {
            try
            {
                Get_filename = DMS_FileUp.SelectedItem.ToString();
                fun.openPdf(Get_filename);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("沒有檔案!!","警告");
            }
            
        }

        private void DMS_Query_CB_SelectedIndexChanged(object sender, EventArgs e)          //DMS_Query_CB的值變動
        {
            if (DMS_Query_CB.SelectedIndex == 0)        //無日期
            {
                label13.Visible = false;
                dTP_Query_StartDate.Visible = false;
                label15.Visible = false;
                dTP_Query_EndDate.Visible = false;
            }
            else if (DMS_Query_CB.SelectedIndex == 1)       //委託日期
            {
                label13.Visible = true;
                dTP_Query_StartDate.Visible = true;
                label15.Visible = true;
                dTP_Query_EndDate.Visible = true;
            }
            else if (DMS_Query_CB.SelectedIndex == 2)           //送樣日期
            {
                label13.Visible = true;
                dTP_Query_StartDate.Visible = true;
                label15.Visible = true;
                dTP_Query_EndDate.Visible = true;
            }
            else if (DMS_Query_CB.SelectedIndex == 3)           //預計出報告日期
            {
                label13.Visible = true;
                dTP_Query_StartDate.Visible = true;
                label15.Visible = true;
                dTP_Query_EndDate.Visible = true;
            }
        }

        private void tb_DMS_Self_Item_DoubleClick(object sender, EventArgs e)           //內檢項目DoubleClick
        {
            if (tb_DMS_DOC_NO.Text != "" || Status_info.Text == "新增")
            {
                
                TextPJ_int aTPJ_int = new TextPJ_int(this);
                //設定init_Staff 新視窗的相對位置#############
                aTPJ_int.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                //############################################
                aTPJ_int.TxPJ_UID = DMS_UID_Value.Text.Trim();         //UID傳值
                aTPJ_int.TxPJ_DOCNO = tb_DMS_DOC_NO.Text.Trim();       //委託單編號
                aTPJ_int.ShowDialog();
            }
        }

        private void tb_DMS_Out_Item_DoubleClick(object sender, EventArgs e)            //外檢項目DoubleClick
        {
            if (tb_DMS_DOC_NO.Text != "" || Status_info.Text == "新增")
            {
                
                TextPJ_out aTPJ_out = new TextPJ_out(this);
                //設定init_Staff 新視窗的相對位置#############
                aTPJ_out.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                //############################################
                aTPJ_out.TxPJ_UID = DMS_UID_Value.Text;         //UID傳值
                aTPJ_out.TxPJ_DOCNO = tb_DMS_DOC_NO.Text;       //委託單編號
                aTPJ_out.ShowDialog();

            }
            
        }

        private void DMS_File_UP_Manually_Click(object sender, EventArgs e)             //選擇檔案
        {
            fun.My_Local_File_ToListBox(DMS_FileUp);
        }

        
        
        //================================================================================================
        #endregion

        
        
        
    }
}
