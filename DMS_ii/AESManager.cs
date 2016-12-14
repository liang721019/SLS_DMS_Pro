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
    public partial class AESManager : Form
    {
        //function.lib.init_function fun = new init_function();
        init_function fun = new init_function();

        public AESManager()
        {
            InitializeComponent();
        }

        private void FileManager_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)          //加密
        {
            textBox2.Text = fun.desEncrypt_A(textBox1.Text, "naturalbiokeyLogin");
        }

        private void button2_Click(object sender, EventArgs e)          //解密
        {
            textBox3.Text = fun.desDecrypt_A(textBox2.Text, "naturalbiokeyLogin"); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //textBox2.Text = fun.SHADecrypt_01(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
