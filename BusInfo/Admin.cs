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

                conn.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO section(origin, destination, date, time, rating) " +
                    "VALUES(@origin, @destination, @date, @time, @rating)";
                cmd.Parameters.AddWithValue("@origin", origin);
                cmd.Parameters.AddWithValue("@destination", destination);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@time", time);
                cmd.Parameters.AddWithValue("@rating", rating);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
