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
    public partial class Lookup : MetroFramework.Forms.MetroForm
    {
        private SqlConnection conn = new SqlConnection();
        private string constr = "SERVER=127.0.0.1; DATABASE=BusInfo; UID=BusInfo; PASSWORD='3407'";
        string level, depart, arrive, date, time, _name;
        string name;
        int grade, cls, number, seatNum;
        int _IsAdmin;
        int fare;
        int type = 0;
        public Lookup()
        {
            InitializeComponent();
            type = 1;
            DataSet ds = new DataSet();
            button1.Text = "삭제하기";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                    conn.Open();
                    string sql = "SELECT * FROM section";

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(ds, "section");
            }
            dataGridView1.DataSource = ds.Tables[0];
        }
        public Lookup(int types)
        {
            InitializeComponent();
            type = types;
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                string sql = "SELECT register.학년, register.반, register.번호, Reservation.이름, Reservation.출발지, Reservation.도착지, Reservation.날짜, Reservation.시간, Reservation.등급, Reservation.좌석번호 FROM register, " +
                    "Reservation WHERE register.이름 = Reservation.이름";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds, "register");
            }
            dataGridView1.DataSource = ds.Tables[0];
        }
        public Lookup(string origin, string destination, string date, string rating, string name, int IsAdmin)
        {
            InitializeComponent();
            _name = name;
            _IsAdmin = IsAdmin;
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                if(rating == "전체")
                {
                    conn.Open();
                    string sql = $"SELECT * FROM section WHERE 출발지 = '{origin}' AND " +
                        $"도착지 = '{destination}' and 날짜 = '{date}'";

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(ds, "section");
                } else
                {
                    conn.Open();
                    string sql = $"SELECT * FROM section WHERE 출발지 = '{origin}' AND " +
                        $"도착지 = '{destination}' and 날짜 = '{date}' and 등급 = '{rating}'";

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(ds, "section");
                }

            }
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if(type == 0)
            {
                level = level.Replace(" ", "");
                MessageBox.Show(level);
                if (level == "우등")
                {
                    Form honor = new honor(date, depart, arrive, time, fare, _name, _IsAdmin);
                    honor.Show();
                }
                else if (level == "프리미엄")
                {
                    Form premium = new Premium(date, depart, arrive, time, fare, _name, _IsAdmin);
                    premium.Show();
                }
                else if (level == "일반")
                {
                    Form normal = new normal(date, depart, arrive, time, fare, _name, _IsAdmin);
                    normal.Show();
                }
                else
                {
                    MessageBox.Show("예약할 시간대를 선택하세요.");
                }
            } else if (type == 1)
            {
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    date = date.Replace("오전 12:00:00", "");
                    cmd.Connection = conn;
                    cmd.CommandText = $"DELETE FROM section WHERE 출발지 = '{depart}' AND " +
                        $"도착지 = '{arrive}' AND 시간 = '{time}'AND 날짜 = '{date}' " +
                        $"AND 등급 = '{level}' AND 요금 = '{fare}'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("구간이 삭제되었습니다.");

                    conn.Open();
                    string sql = "SELECT * FROM section";

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(ds, "section");
                }
                dataGridView1.DataSource = ds.Tables[0];
            } else if (type == 2)
            {
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    date = date.Replace("오전 12:00:00", "");
                    cmd.Connection = conn;
                    cmd.CommandText = $"DELETE FROM Reservation WHERE 이름 = '{name}' AND " +
                        $"출발지 = '{depart}' AND 도착지 = '{arrive}'AND 날짜 = '{date}' " +
                        $"AND 등급 = '{level}' AND 좌석번호 = '{seatNum}' AND 시간 = '{time}'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("구간이 삭제되었습니다.");

                    conn.Open();
                    string sql = "SELECT register.학년, register.반, register.번호, Reservation.이름, Reservation.출발지, Reservation.도착지, Reservation.날짜, Reservation.시간, Reservation.등급, Reservation.좌석번호 FROM register, " +
                    "Reservation WHERE register.이름 = Reservation.이름";

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(ds, "register");
                }
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(type == 2)
            {
                name = dataGridView1.Rows[e.RowIndex].Cells["이름"].Value.ToString();
                date = dataGridView1.Rows[e.RowIndex].Cells["날짜"].Value.ToString();
                level = dataGridView1.Rows[e.RowIndex].Cells["등급"].Value.ToString();
                depart = dataGridView1.Rows[e.RowIndex].Cells["출발지"].Value.ToString();
                arrive = dataGridView1.Rows[e.RowIndex].Cells["도착지"].Value.ToString();
                time = dataGridView1.Rows[e.RowIndex].Cells["시간"].Value.ToString();
                seatNum = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["좌석번호"].Value.ToString());
            } else
            {
                date = dataGridView1.Rows[e.RowIndex].Cells["날짜"].Value.ToString();
                level = dataGridView1.Rows[e.RowIndex].Cells["등급"].Value.ToString();
                depart = dataGridView1.Rows[e.RowIndex].Cells["출발지"].Value.ToString();
                arrive = dataGridView1.Rows[e.RowIndex].Cells["도착지"].Value.ToString();
                time = dataGridView1.Rows[e.RowIndex].Cells["시간"].Value.ToString();
                fare = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["요금"].Value.ToString());
            }
        }
    }
}
