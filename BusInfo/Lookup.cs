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
        public Lookup()
        {
            InitializeComponent();
        }
        public Lookup(string origin, string destination, string date, string rating)
        {
            InitializeComponent();
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
            string level = label2.Text;
            level = level.Replace(" ", "");
            MessageBox.Show(level);
            if (level == "우등")
            {
                Form honor = new honor();
                honor.Show();
            } else if (level == "프리미엄")
            {
                Form premium = new Premium();
                premium.Show();
            } else if (level == "일반")
            {
                Form normal = new normal();
                normal.Show();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.Rows[e.RowIndex].Cells["등급"].Value.ToString();
        }
    }
}
