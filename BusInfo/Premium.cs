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
    public partial class Premium : MetroFramework.Forms.MetroForm
    {
        public int seat;
        string _date, _depart, _arrive, _time, _name;
        int _IsAdmin;
        private SqlConnection conn = new SqlConnection();
        private string constr = "SERVER=127.0.0.1; DATABASE=BusInfo; UID=BusInfo; PASSWORD='3407'";
        public Premium()
        {
            InitializeComponent();
        }
        public Premium(string date, string depart, string arrive, string time, int fare, string name
            ,int IsAdmin)
        {
            InitializeComponent();
            label3.Text = date.Replace("오전 12:00:00","");
            label4.Text = depart.Replace(" ","") + " -> " + arrive;
            label6.Text = fare + "원";
            _date = date.Replace("오전 12:00:00", "");
            _time = time;
            _depart = depart;
            _arrive = arrive;
            _name = name;
            _IsAdmin = IsAdmin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            seat = 1;
            label2.Text = "1번";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            seat = 2;
            label2.Text = "2번";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            seat = 3;
            label2.Text = "3번";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            seat = 4;
            label2.Text = "4번";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            seat = 5;
            label2.Text = "5번";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            seat = 6;
            label2.Text = "6번";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            seat = 7;
            label2.Text = "7번";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            seat = 8;
            label2.Text = "8번";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            seat = 9;
            label2.Text = "9번";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            seat = 10;
            label2.Text = "10번";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            seat = 11;
            label2.Text = "11번";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            seat = 12;
            label2.Text = "12번";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            seat = 13;
            label2.Text = "13번";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            seat = 14;
            label2.Text = "14번";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            seat = 15;
            label2.Text = "15번";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            seat = 16;
            label2.Text = "16번";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            seat = 17;
            label2.Text = "17번";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            seat = 18;
            label2.Text = "18번";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            seat = 19;
            label2.Text = "19번";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            seat = 20;
            label2.Text = "20번";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            seat = 21;
            label2.Text = "21번";
        }

        private void button46_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string sql = $"SELECT * FROM Reservation WHERE 출발지='{_depart}' " +
                $"AND 도착지='{_arrive}' AND 날짜='{_date}' AND 시간='{_time}' " +
                $"AND 등급='프리미엄' AND 좌석번호='{seat}'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader mdr = cmd.ExecuteReader();
            if (mdr.Read())
            {
                MessageBox.Show("이미 예약된 좌석입니다.");
            }
            else
            {
                if (_IsAdmin == 1)
                {
                    MessageBox.Show("관리자는 예약이 불가능합니다.");
                }
                else
                {
                    using (conn = new SqlConnection(constr))
                    {
                        conn.Open();
                        SqlCommand cmd1 = new SqlCommand();

                        cmd1.Connection = conn;
                        cmd1.CommandText = "INSERT INTO Reservation(이름, 출발지, 도착지, 날짜, 시간, 등급, 좌석번호) " +
                            "VALUES(@이름, @출발지, @도착지, @날짜, @시간, @등급, @좌석번호)";
                        cmd1.Parameters.AddWithValue("@이름", _name);
                        cmd1.Parameters.AddWithValue("@출발지", _depart);
                        cmd1.Parameters.AddWithValue("@도착지", _arrive);
                        cmd1.Parameters.AddWithValue("@날짜", _date);
                        cmd1.Parameters.AddWithValue("@시간", _time);
                        cmd1.Parameters.AddWithValue("@등급", "프리미엄");
                        cmd1.Parameters.AddWithValue("@좌석번호", seat);
                        cmd1.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("예약되었습니다.");
                        this.Close();
                    }
                }
            }
        }
    }
}
