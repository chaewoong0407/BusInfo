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
                    string sql = $"SELECT * FROM section WHERE origin = '{origin}' AND " +
                        $"destination = '{destination}' and date = '{date}'";

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(ds, "section");
                } else
                {
                    conn.Open();
                    string sql = $"SELECT * FROM section WHERE origin = '{origin}' AND " +
                        $"destination = '{destination}' and date = '{date}' and rating = '{rating}'";

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(ds, "section");
                }

            }
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
