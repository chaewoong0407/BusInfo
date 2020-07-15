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
        bool login = false;
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
            login = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string origin = textBox1.Text;
            string destination = textBox2.Text;
            string date = textBox3.Text + "-" + textBox4.Text + "-" + textBox5.Text;
            string rating = metroComboBox1.SelectedItem.ToString();
            Form LookupFrom = new Lookup(origin, destination, date, rating);
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
            if(!login)
            {
                Form SelectLogin = new SelectLogin(this);
                SelectLogin.Show();
            } else
            {
                MessageBox.Show("로그아웃 되었습니다.");
                IsAdmin = 0;
                button3.Text = "로그인";
                label7.Text = "";
                login = false;
            }
        }
    }
}
