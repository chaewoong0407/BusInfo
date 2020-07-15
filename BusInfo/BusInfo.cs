using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusInfo
{
    public partial class BusInfo : MetroFramework.Forms.MetroForm
    {
        int IsAdmin;
        public BusInfo()
        {
            InitializeComponent();
        }
        private void BusInfo_Load(object sender, EventArgs e)
        {

        }
        public void LabelChange(string name, int _IsAdmin)
        {
            label7.Text = name+"님 반갑습니다.";
            IsAdmin = _IsAdmin;
            button3.Text = "로그아웃";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form LookupFrom = new Lookup();
            LookupFrom.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(IsAdmin == 1)
            {
                Form AdminFrom = new Admin();
                AdminFrom.ShowDialog();
            } else
            {
                MessageBox.Show("관리자만 이용할 수 있습니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form SelectLogin = new SelectLogin(this);
            SelectLogin.Show();
        }
    }
}
