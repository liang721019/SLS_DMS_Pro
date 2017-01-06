using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS_ii.binx
{
    public partial class TextPJ_out : Form
    {
        public TextPJ_out()
        {
            InitializeComponent();
        }

        private void TextPJ_out_Load(object sender, EventArgs e)
        {
            default_start();

        }

        public void default_start()
        {
            this.MaximizeBox = false;       //最大化
            this.MinimizeBox = false;       //最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     //限制使用者改變form大小
            this.AutoSize = false;          //自動調整大小
        }
    }
}
