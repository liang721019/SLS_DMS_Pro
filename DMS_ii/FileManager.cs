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

        #endregion

        #region 方法
        //================================================================================================
        public void GetSQL(string  uu , string rr )
        {
            switch (uu)
            {
                #region 內容
                case "新增":
                    {
                        #region 新增內容
                        Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Insert]  " +
                                    @"'" + dTP_DMS_DOC_DATE.Text.Replace("/", "") +      //日期
                                    @"','" + tb_DMS_Content.Text.Trim()+              //內容
                                    @"','" + tb_DMS_TEST_ITEM.Text.Trim() +             //檢驗項目
                                    @"','" + tb_DMS_文件NO.Text.Trim() +               //文件NO
                                    @"','" + tb_DMS_LotNo.Text.Trim() +                //LOTNO
                                    @"','" + tb_DMS_原廠COA.Text.Trim() +             //原廠COA
                                    @"','" + tb_DMS_檢驗報告.Text.Trim() +                //檢驗報告
                                    @"','" + tb_DMS_結果.Text.Trim() +                    //結果
                                    @"','" + dTP_DMS_ReportDate.Text.Replace("/", "") +        //出報告日期
                                    @"','" + dTP_DMS_PReportDate.Text.Replace("/", "") +       //預計出報告日期
                                    @"','" + tb_DMS_Applicant.Text +          //申請人
                                    @"','" + DMS_UID_Value.Text +        //建立者ID       
                                    @"'";
                        break;
                        #endregion
                    }
                case "修改":
                    {
                        #region 修改內容
                        Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Update] '" +
                                    tb_DMS_DOC_NO.Text +       //編號
                                    @"','" + dTP_DMS_DOC_DATE.Text.Replace("/", "") +      //日期;
                                    @"','" + tb_DMS_Content.Text.Trim() +              //內容
                                    @"','" + tb_DMS_TEST_ITEM.Text.Trim() +             //檢驗項目
                                    @"','" + tb_DMS_文件NO.Text.Trim() +               //文件NO
                                    @"','" + tb_DMS_LotNo.Text.Trim() +                //LOTNO
                                    @"','" + tb_DMS_原廠COA.Text.Trim() +             //原廠COA
                                    @"','" + tb_DMS_檢驗報告.Text.Trim() +                //檢驗報告
                                    @"','" + tb_DMS_結果.Text.Trim() +                    //結果
                                    @"','" + dTP_DMS_ReportDate.Text.Replace("/", "") +        //出報告日期
                                    @"','" + dTP_DMS_PReportDate.Text.Replace("/", "") +       //預計出報告日期
                                    @"','" + tb_DMS_Applicant.Text +          //申請人
                                    @"','" + DMS_UID_Value.Text + "'";     //修改ID       
                                    
                        break;
                        #endregion
                    }
                case "快速查詢":
                    {
                        #region 快速查詢內容
                        Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_QuickQuery]" +
                                    @"'" + rr +      //編號
                                    @"','" + QueryStartDate+      //查詢開始日期
                                    @"','" + QueryEndDate +        //查詢結束日期
                                    @"','" + QuickQueryType +        //查詢結束日期 
                                    "'";
                        break;
                        #endregion
                    }
                
                case "查詢":
                    {
                        #region 查詢內容
                        Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Query]" +
                                    @"'" + rr +      //編號
                                    @"','" + QueryStartDate +      //查詢開始日期
                                    @"','" + QueryEndDate +        //查詢結束日期
                                    @"','" +tb_DMS_Content.Text +       //內容
                                    @"','" + tb_DMS_TEST_ITEM.Text +      //檢驗項目
                                    @"','" + tb_DMS_文件NO.Text +       //文件NO
                                    @"','" + tb_DMS_LotNo.Text +        //LOTNO
                                    @"','" + tb_DMS_原廠COA.Text +      //原廠COA
                                    @"','" + tb_DMS_檢驗報告.Text +      //檢驗報告
                                    @"','" + tb_DMS_結果.Text +      //結果
                                    @"','" + tb_DMS_Applicant.Text +      //申請人
                                    "'";                          
                        break;
                        #endregion                        
                    }
                case "刪除":
                    {
                        #region 刪除內容
                        Query_DB = @"exec [TEST_SLSYHI].[dbo].[SLS_DMS_Del]" +
                                    @"'" + tb_DMS_DOC_NO.Text +      //編號                                    
                                    @"','" + DMS_UID_Value.Text + "'";      //查詢結束日期

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

                #endregion
            }
        }

        public void default_status()        //default狀態
        {
            this.Text = "文件管理系統";
            fun.check_MAC_OK = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;//視窗在中央打開
            fun.Disabled_Panel(DMS_panel1);            
            DMS_儲存toolStripButton.Visible = false;
            DMS_取消toolStripButton.Visible = false;
            fun.Format_Panel_dTP(DMS_panel1, "yyyy/MM/dd");     //自訂日期格式
            fun.Format_Panel_dTP(DMS_UP_Controls_panel, "yyyy/MM/dd");          //自訂日期格式
            DGV1_SetColumns();          //DGV1自定顯示欄位
            DGV2_SetColumns();           //DGV2自定顯示欄位
            Status_info.Visible = false;
            DMS_panel2.Visible = false;
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
                tb_DMS_DOC_NO.Enabled = false;
                DMS_儲存toolStripButton.Visible = true;
                DMS_取消toolStripButton.Visible = true;
                DMS_儲存toolStripButton.Enabled = true;
                DMS_取消toolStripButton.Enabled = true;
                dTP_DMS_DOC_DATE.Focus();
                
            }
            else if (xx == DMS_修改toolStripButton)
            {
                Status_info.Visible = true;
                Status_info.Text = "修改";
                fun.Enabled_Panel(DMS_panel1);
                fun.EoD_toolStripButton_Tab(DMS_toolStrip1, false);
                tb_DMS_DOC_NO.Enabled = false;
                DMS_儲存toolStripButton.Visible = true;
                DMS_取消toolStripButton.Visible = true;
                DMS_儲存toolStripButton.Enabled = true;
                DMS_取消toolStripButton.Enabled = true;
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
                fun.Disabled_Panel(DMS_panel1);
                fun.EoD_toolStripButton_Tab(DMS_toolStrip1, true);
                DMS_儲存toolStripButton.Visible = false;
                DMS_取消toolStripButton.Visible = false;
                DMS_儲存toolStripButton.Enabled = false;
                DMS_取消toolStripButton.Enabled = false;
                DMS_Query_DOCNO.Focus();
                DMS_tabControl1.SelectedIndex = 0;
                
            }
            else if (xx == DMS_儲存toolStripButton)
            {
                Status_info.Visible = false;
                fun.clearAir(DMS_panel1);
                fun.Disabled_Panel(DMS_panel1);
                fun.EoD_toolStripButton_Tab(DMS_toolStrip1, true);
                DMS_儲存toolStripButton.Visible = false;
                DMS_取消toolStripButton.Visible = false;
                DMS_儲存toolStripButton.Enabled = false;
                DMS_取消toolStripButton.Enabled = false;
                
            }
            else if (xx == DMS_取消toolStripButton)
            {
                Status_info.Visible = false;
                Status_info.Text = "";
                fun.Disabled_Panel(DMS_panel1);
                fun.EoD_toolStripButton_Tab(DMS_toolStrip1, true);
                DMS_儲存toolStripButton.Visible = false;
                DMS_取消toolStripButton.Visible = false;
                DMS_儲存toolStripButton.Enabled = false;
                DMS_取消toolStripButton.Enabled = false;
                
            }
            

        }

        public void File_SAccress_Get(string x, string y)
        {
            //if (tb_PDFPosition.Text != "")
            //{
            //    fun.SAUkey_tb_PDFPosition = tb_Asset_ID.Text.ToUpper() + "-" + Path.GetFileName(tb_PDFPosition.Text);
            //    fun.File_UAccress(tb_PDFPosition.Text, x, tb_Asset_ID.Text, "《資產主檔》", null, null); //<資產主檔>檔案傳送到預設位置

            //}
            //else
            //{
            //    fun.SAUkey_tb_PDFPosition = tb_PDFPosition_view.Text;
            //}
            //if (tb_PDFmodify_Position.Text != "")
            //{
            //    fun.SAUkey_tb_PDFmodify_Position = tb_Asset_ID.Text.ToUpper() + "-" + tb_OwnerID.Text + Path.GetFileNameWithoutExtension(tb_PDFmodify_Position.Text) + "_" + GetDB_DTime_Value + Path.GetExtension(tb_PDFmodify_Position.Text);
            //    fun.File_UAccress(tb_PDFmodify_Position.Text, y, tb_Asset_ID.Text, "《異動記錄》", tb_OwnerID.Text, GetDB_DTime_Value);//<異動記錄>檔案傳送到預設位置
            //}
            //else
            //{
            //    fun.SAUkey_tb_PDFmodify_Position = tb_PDFmodify_Position_view.Text;
            //}

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

        public void sub_()  //TestBOX與DB欄位的對應
        {
            try
            {
                #region 內容
                fun.Check_error = true;
                tb_DMS_DOC_NO.Text = fun.ds_index.Tables[0].Rows[0]["編號"].ToString();               
                string DOC_DATE = fun.ds_index.Tables[0].Rows[0]["日期"].ToString();
                dTP_DMS_DOC_DATE.Text = DOC_DATE.Substring(0, 4) + "/" + DOC_DATE.Substring(4, 2) + "/" + DOC_DATE.Substring(6, 2);
                tb_DMS_TEST_ITEM.Text = fun.ds_index.Tables[0].Rows[0]["檢驗項目"].ToString();
                tb_DMS_Content.Text = fun.ds_index.Tables[0].Rows[0]["內容"].ToString();
                tb_DMS_文件NO.Text = fun.ds_index.Tables[0].Rows[0]["文件NO"].ToString();
                tb_DMS_LotNo.Text = fun.ds_index.Tables[0].Rows[0]["LotNO"].ToString();
                tb_DMS_原廠COA.Text = fun.ds_index.Tables[0].Rows[0]["原廠COA"].ToString();
                tb_DMS_檢驗報告.Text = fun.ds_index.Tables[0].Rows[0]["檢驗報告"].ToString();
                tb_DMS_結果.Text = fun.ds_index.Tables[0].Rows[0]["結果"].ToString();
                string PReportDate = fun.ds_index.Tables[0].Rows[0]["預計出報告日期"].ToString();
                dTP_DMS_PReportDate.Text = PReportDate.Substring(0, 4) + "/" + PReportDate.Substring(4, 2) + "/" + PReportDate.Substring(6, 2);
                string ReportDate = fun.ds_index.Tables[0].Rows[0]["出報告日期"].ToString();
                dTP_DMS_ReportDate.Text = ReportDate.Substring(0, 4) + "/" + ReportDate.Substring(4, 2) + "/" + ReportDate.Substring(6, 2);
                tb_DMS_Applicant.Text = fun.ds_index.Tables[0].Rows[0]["申請人"].ToString();  

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
            DMS_DGV1_Column1.DataPropertyName = "編號";
            DMS_DGV1_Column2.DataPropertyName = "日期";
            DMS_DGV1_Column3.DataPropertyName = "內容";
            DMS_DGV1_Column4.DataPropertyName = "檢驗項目";
            DMS_DGV1_Column5.DataPropertyName = "文件NO";
            DMS_DGV1_Column6.DataPropertyName = "LotNO";
            DMS_DGV1_Column7.DataPropertyName = "原廠COA";
            DMS_DGV1_Column8.DataPropertyName = "檢驗報告";
            DMS_DGV1_Column9.DataPropertyName = "結果";
            DMS_DGV1_Column10.DataPropertyName = "出報告日期";
            DMS_DGV1_Column11.DataPropertyName = "預計出報日期";
            DMS_DGV1_Column12.DataPropertyName = "申請人";
            DMS_DGV1_Column1.Frozen = true; //凍結窗格
            DMS_DGV1_Column2.Frozen = true; //凍結窗格


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

        public void OpenFile()          //打開檔案
        {
            Get_filename = DMS_dataGridView2.CurrentRow.Cells[2].Value.ToString();
            Get_AllFileAcc = FileStorage_Location + "\\" + Get_filename;
            fun.openPdf(Get_AllFileAcc);
        }        



        //================================================================================================
        #endregion

        private void FileManager_Load(object sender, EventArgs e)
        {             
            default_status();
            fun.ReMAC(DMS_MAC_Value, null);
            //DMS_panel1.Visible = false;
            //SYS_Status_Key();
        }
        
        #region Button
        //================================================================================================
        private void DMS_新增toolStripButton_Click(object sender, EventArgs e)
        {
            start_status(DMS_新增toolStripButton);        //啟動狀態
        }

        private void DMS_查詢toolStripButton_Click(object sender, EventArgs e)
        {
            QueryStartDate = dTP_Query_StartDate.Text.Replace("/", "");
            QueryEndDate = dTP_Query_EndDate.Text.Replace("/", "");
            QuickQueryType = "A";
            start_status(DMS_查詢toolStripButton);        //啟動狀態            
            GetSQL("快速查詢", DMS_Query_DOCNO.Text);
            //GetSQL("查詢",編號,開始日期,結束日期)
            fun.xxx_DB(Query_DB, DMS_dataGridView1);
           
             
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
                    fun.DMS_insert(Query_DB, "資料《新增》成功!!", "DMS");
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
                        GetSQL("修改", null);
                        mBox = "資料《修改》成功!!";
                        FText = "DMS";
                        fun.DMS_modify(Query_DB, mBox, FText);
                        //db_sum = SQL語法            
                        //mBox = 成功執行後的訊息
                        //FText = MessageBox.form.Text
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
            //    DMS_tabControl1.Location = new Point(12,366);                 
            //    //DMS_tabControl1.Size = new System.Drawing.Size(984, 280);
            //}
            
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
        private void DMS_FileUp_DragEnter(object sender, DragEventArgs e)
        {
            // 確定使用者抓進來的是檔案
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // 允許拖拉動作繼續 (這時滑鼠游標應該會顯示 +)
                e.Effect = DragDropEffects.All;
            }

        }

        private void DMS_FileUp_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string Ufile in files)
            {                
                DMS_FileUp.Items.Add(Ufile);     //取得完整路徑           
            }

        }

        private void DMS_File_UPbutton_Click(object sender, EventArgs e)        //上傳檔案
        {
            #region 上傳檔案~新增資料庫的內容            
            if (tb_DMS_DOC_NO.Text != "")
            {                
                for (int i = 0; i < DMS_FileUp.Items.Count; i++)
                {
                    #region 檔案上傳內容
                    Query_DB = @"select ISNULL(MAX([LineNum]),0)+1 AS num  FROM [TEST_SLSYHI].[dbo].[SLS_DMS_ii_File] where [DOC_NO] ='" + tb_DMS_DOC_NO.Text + "'";//取得序號                              
                    fun.ProductDB_ds(Query_DB);           //取得要新增檔案的序號
                    string Lnu = fun.ds_index.Tables[0].Rows[0]["num"].ToString();
                    string DFU_x = DMS_FileUp.Items[i].ToString();
                    string DFU_y = FileStorage_Location;            //檔案路徑                    
                    string DFU_z = tb_DMS_DOC_NO.Text + "-" + Lnu;
                    fun.DMS_File_UP(DFU_x, DFU_y, DFU_z);      //檔案COPY到指定目錄
                    #endregion
                    #region DB-新增資料
                    //string info_FileName = Path.GetFileName(DFU_x);         //取得檔名
                    string info_FileName = DFU_z +"-"+ Path.GetFileName(DFU_x);         //取得檔名
                    string insert_DB = @"EXEC [TEST_SLSYHI].[dbo].[SLS_DMS_File_insert] '" + tb_DMS_DOC_NO.Text + "','" + info_FileName + "','" + DMS_UID_Value.Text + "'";//新增資料
                    fun.DMS_file_insert(insert_DB);       //新增資料   
                    #endregion
                }
                DMS_FileUp.Items.Clear();       //清除Listbox內容
                if (fun.Check_error == false)
                {
                    MessageBox.Show("資料及檔案新增成功!!","DMS");
                }
                GetSQL("DGV1_檔案查詢", tb_DMS_DOC_NO.Text);    //語法丟進fun.Query_DB
                fun.xxx_DB(Query_DB, DMS_dataGridView2);         //連接DB-執行DB指令
 
            }
            else
            {
                MessageBox.Show("沒有編號!!請選擇文件編號!!","DMS");
            }
            #endregion
        }

        //=====================================================================================================
        #endregion

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
                    string s_ID = DMS_dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    QueryStartDate = DMS_dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    QueryEndDate = DMS_dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    QuickQueryType = "B";

                    GetSQL("快速查詢", s_ID);    //語法丟進fun.Query_DB                    
                    fun.ProductDB_ds(Query_DB);         //連接DB-執行DB指令
                    //DGV2_SetColumns();          //自定顯示欄位
                    sub_();
                }
            }
        }

        private void DMS_dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)          //DMS_dataGridView2左鍵雙擊二下
        {
            if (e.RowIndex >= 0)
            {
                OpenFile();
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

        private void 刪除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Del_File();
            GetSQL("DGV1_檔案查詢", Get_DGV_Value_1);    //語法丟進fun.Query_DB
            fun.xxx_DB(Query_DB, DMS_dataGridView2);         //連接DB-執行DB指令
        }

        private void 開啟檔案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void DMS_Query_DOCNO_KeyDown(object sender, KeyEventArgs e)         //DMS_Query_DOCNO按Enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                #region  按Enter之後執行
                start_status(DMS_查詢toolStripButton);        //啟動狀態
                QueryStartDate = dTP_Query_StartDate.Text.Replace("/", "");
                QueryEndDate = dTP_Query_EndDate.Text.Replace("/", "");
                QuickQueryType = "A";
                GetSQL("快速查詢", DMS_Query_DOCNO.Text);
                //GetSQL("查詢",編號)
                fun.xxx_DB(Query_DB, DMS_dataGridView1);
                
                #endregion
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tb_DMS_結果.Text
            bool fIsM = fun.IsMatch(tb_DMS_結果.Text,"^[0-9]{8}$");
            if (fIsM)
            {
                MessageBox.Show(tb_DMS_結果.Text);
            }
            else
            {
                MessageBox.Show("日期格式不對!!\n日    期:2016/08/30 \n輸入格式:20160830 ");
            }
            
        }

        
        
        //================================================================================================
        #endregion

        
        
        
    }
}
