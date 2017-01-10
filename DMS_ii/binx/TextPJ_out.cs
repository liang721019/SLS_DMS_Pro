﻿using System;
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

            Txfun.TxPJ_Option_Panel(TextPJ_panel, BorderStyle.FixedSingle); 

            #region 檢驗項目讀取
            Txfun.All_DOCNO_TxPJ = TxPJ_DOCNO;
            Txfun.TxPJ_Option_view_All(TextPJ_panel);      //DMS_檢驗項目讀取DB的方法
            //Txfun.TxPJ_Option_view(TextPJ_int_panel2);      //DMS_檢驗項目讀取DB的方法
            #endregion            
            
        }       

        private void DMS_TxPJ_UPdate_button_Click(object sender, EventArgs e)
        {
            Txfun.Check_error = false;
            #region 檢驗項目更新DB
            if (FileMan.Status_info.Text == "修改")
            {
                Txfun.All_DOCNO_TxPJ = TxPJ_DOCNO;

                foreach (Control obj in TextPJ_panel.Controls)
                {
                    if (obj.GetType() == typeof(Panel))
                    {
                        Txfun.TxPJ_Option_UPDB(((Panel)obj), TxPJ_UID);           //DMS_檢驗項目更新DB的方法
                    }
                }
            }            
            
            #endregion 

            if (Txfun.Check_error == false)
            {
                MessageBox.Show("更新DB成功", "DMS");
                Txfun.TxPJ_Option_Text_All(TextPJ_panel);
                FileMan.DMS_TxPJ_Out_GetValue(Txfun.All_TxPJ_Text); 
                this.Close();
            }
        }

        private void DMS_TxPJ_Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
