using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BusInfo
{
    public partial class Admin : MetroFramework.Forms.MetroForm
    {
        public Admin()
        {
            InitializeComponent();
        }
            private SqlConnection conn = new SqlConnection();
            private string constr="SERVER=127.0.0.1; DATABASE=BusInfo; UID=BusInfo; PASSWORD='3407'";

        private void button1_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(constr))
            {
                string origin = textBox1.Text;
                string destination = textBox2.Text;
                string date = textBox3.Text + "-" + textBox4.Text + "-" + textBox5.Text;
                string time = metroComboBox1.SelectedItem + ":" + metroComboBox2.SelectedItem;
                string rating = metroComboBox3.SelectedItem.ToString();
                int fare = int.Parse(textBox6.Text);

                conn.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO section(출발지, 도착지, 날짜, 시간, 등급, 요금) " +
                    "VALUES(@출발지, @도착지, @날짜, @시간, @등급, @요금)";
                cmd.Parameters.AddWithValue("@출발지", origin);
                cmd.Parameters.AddWithValue("@도착지", destination);
                cmd.Parameters.AddWithValue("@날짜", date);
                cmd.Parameters.AddWithValue("@시간", time);
                cmd.Parameters.AddWithValue("@등급", rating);
                cmd.Parameters.AddWithValue("@요금", fare);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("구간이 추가되었습니다.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Lookup = new Lookup();
            Lookup.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int types = 2;
            Form Lookup = new Lookup(types);
            Lookup.Show();
        }
    }
}
