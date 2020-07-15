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
    public partial class AdminLogin : MetroFramework.Forms.MetroForm
    {
        BusInfo _BusInfo;
        public AdminLogin()
        {
            InitializeComponent();
        }
        public AdminLogin(BusInfo _Login)
        {
            InitializeComponent();
            _BusInfo = _Login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "SERVER=127.0.0.1; DATABASE=BusInfo; UID=BusInfo; PASSWORD='3407'";
            SqlConnection conn = new SqlConnection(constr);
            string id = textBox1.Text;
            string pw = textBox2.Text;
            conn.Open();
            string sql = $"SELECT * FROM AdminRegister WHERE AdminId='{id}' AND Adminpw='{pw}'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader mdr = cmd.ExecuteReader();
            if (mdr.Read())
            {
                MessageBox.Show("관리자로 로그인 성공");
                _BusInfo.LabelChange("관리자", 1);
                this.Close();
            }
            else
            {
                MessageBox.Show("관리자로 로그인 실패");
            }
            mdr.Close();
        }
    }
}
