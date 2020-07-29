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
    public partial class normal : MetroFramework.Forms.MetroForm
    {
        public int seat, _IsAdmin;
        string _date, _depart, _arrive, _time, _name;
        private SqlConnection conn = new SqlConnection();
        private string constr = "SERVER=127.0.0.1; DATABASE=BusInfo; UID=BusInfo; PASSWORD='3407'";
        public normal()
        {
            InitializeComponent();
        }
        public normal(string date, string depart, string arrive, string time, int fare, string name, int IsAdmin)
        {
            InitializeComponent();
            label3.Text = date.Replace("오전 12:00:00", "");
            label4.Text = depart.Replace(" ", "") + " -> " + arrive;
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

        private void button22_Click(object sender, EventArgs e)
        {
            seat = 22;
            label2.Text = "22번";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            seat = 23;
            label2.Text = "23번";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            seat = 24;
            label2.Text = "24번";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            seat = 25;
            label2.Text = "25번";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            seat = 26;
            label2.Text = "26번";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            seat = 27;
            label2.Text = "27번";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            seat = 28;
            label2.Text = "28번";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            seat = 29;
            label2.Text = "29번";
        }

        private void button30_Click(object sender, EventArgs e)
        {
            seat = 30;
            label2.Text = "30번";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            seat = 31;
            label2.Text = "31번";
        }

        private void button32_Click(object sender, EventArgs e)
        {
            seat = 32;
            label2.Text = "32번";
        }

        private void button33_Click(object sender, EventArgs e)
        {
            seat = 33;
            label2.Text = "33번";
        }

        private void button34_Click(object sender, EventArgs e)
        {
            seat = 34;
            label2.Text = "34번";
        }

        private void button35_Click(object sender, EventArgs e)
        {
            seat = 35;
            label2.Text = "35번";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            seat = 36;
            label2.Text = "36번";
        }

        private void button37_Click(object sender, EventArgs e)
        {
            seat = 37;
            label2.Text = "37번";
        }

        private void button38_Click(object sender, EventArgs e)
        {
            seat = 38;
            label2.Text = "38번";
        }

        private void button39_Click(object sender, EventArgs e)
        {
            seat = 39;
            label2.Text = "39번";
        }

        private void button40_Click(object sender, EventArgs e)
        {
            seat = 40;
            label2.Text = "40번";
        }

        private void button41_Click(object sender, EventArgs e)
        {
            seat = 41;
            label2.Text = "41번";
        }
        private void button42_Click(object sender, EventArgs e)
        {
            seat = 42;
            label2.Text = "42번";
        }

        private void button43_Click(object sender, EventArgs e)
        {
            seat = 43;
            label2.Text = "43번";
        }

        private void button44_Click(object sender, EventArgs e)
        {
            seat = 44;
            label2.Text = "44번";
        }

        private void button45_Click(object sender, EventArgs e)
        {
            seat = 45;
            label2.Text = "45번";
        }


        private void button46_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string sql = $"SELECT * FROM Reservation WHERE 출발지='{_depart}' " +
                $"AND 도착지='{_arrive}' AND 날짜='{_date}' AND 시간='{_time}' " +
                $"AND 등급='일반' AND 좌석번호='{seat}'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader mdr = cmd.ExecuteReader();
            if (mdr.Read())
            {
                MessageBox.Show("이미 예약된 좌석입니다.");
            }
            else
            {
                if(_IsAdmin == 1)
                {
                    MessageBox.Show("관리자는 예약이 불가능합니다.");
                } else
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
                        cmd1.Parameters.AddWithValue("@등급", "일반");
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
