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
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                string sql = "SELECT * FROM section";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds, "section");

            }
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
