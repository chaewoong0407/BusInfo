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
    public partial class Register : MetroFramework.Forms.MetroForm
    {
        private SqlConnection conn = new SqlConnection();
        private string constr = "SERVER=127.0.0.1; DATABASE=BusInfo; UID=BusInfo; PASSWORD='3407'";

        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(constr))
            {
                string id = textBox1.Text;
                string pw = textBox2.Text;
                string repw = textBox3.Text;
                int grade = int.Parse((string)metroComboBox1.SelectedItem);
                int cls = int.Parse((string)metroComboBox2.SelectedItem);
                int number = int.Parse((string)metroComboBox3.SelectedItem);
                string name = textBox4.Text;

                if(pw == repw)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO register(아이디, 패스워드, 학년, 반, 번호, 이름) " +
                        "VALUES(@아이디, @패스워드, @학년, @반, @번호, @이름)";
                    cmd.Parameters.AddWithValue("@아이디", id);
                    cmd.Parameters.AddWithValue("@패스워드", pw);
                    cmd.Parameters.AddWithValue("@학년", grade);
                    cmd.Parameters.AddWithValue("@반", cls);
                    cmd.Parameters.AddWithValue("@번호", number);
                    cmd.Parameters.AddWithValue("@이름", name);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("회원가입 성공!!");
                    conn.Close();
                    this.Close();
                } else
                {
                    MessageBox.Show("입력한 비밀번호가 다릅니다.");
                }
                
            }
        }

    }
}
