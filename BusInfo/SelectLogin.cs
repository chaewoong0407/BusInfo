using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusInfo
{
    public partial class SelectLogin : MetroFramework.Forms.MetroForm
    {
        BusInfo _BusInfo;
        public SelectLogin()
        {
            InitializeComponent();
        }
        public SelectLogin(BusInfo _Login)
        {
            InitializeComponent();
            _BusInfo = _Login;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form LoginForm = new Login(_BusInfo);
            LoginForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ManagerForm = new AdminLogin(_BusInfo);
            ManagerForm.Show();
            this.Close();
        }
    }
}
