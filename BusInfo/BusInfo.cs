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
        public void LabelChange(string name, int _IsAdmin)
        {
            label7.Text = name+"님 반갑습니다.";
            IsAdmin = _IsAdmin;
            button3.Text = "로그아웃";
            login = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(!login)
            {
                MessageBox.Show("로그인 후에 이용할 수 있습니다.");
            } else
            {
                if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
                    textBox4.Text == "" || textBox5.Text == "" || metroComboBox1.SelectedItem == null)
                {
                    MessageBox.Show("내용을 전부 입력하세요");
                } else
                {
                    string origin = textBox1.Text;
                    string destination = textBox2.Text;
                    string date = textBox3.Text + "-" + textBox4.Text + "-" + textBox5.Text;
                    string rating = metroComboBox1.SelectedItem.ToString();
                    Form LookupFrom = new Lookup(origin, destination, date, rating);
                    LookupFrom.Show();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    metroComboBox1.SelectedItem = null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!login)
            {
                MessageBox.Show("로그인 후에 이용할 수 있습니다.");
            } else
            {
                if (IsAdmin == 1)
                {
                    Form AdminFrom = new Admin();
                    AdminFrom.ShowDialog();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    metroComboBox1.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("관리자만 이용할 수 있습니다.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!login)
            {
                Form SelectLogin = new SelectLogin(this);
                SelectLogin.Show();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                metroComboBox1.SelectedItem = null;
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
