using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WinAppOraExecuteScalar
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            lblQuery.Text = "SELECT round(AVG(salary),2) FROM employees";
        }

        private void BtnQueryClick(object sender, EventArgs e)
        {
            try
            {
                OracleConnectionStringBuilder strBuilder = new OracleConnectionStringBuilder();
                strBuilder.UserID = userName.Text;
                strBuilder.Password = password.Text;
                strBuilder.DataSource = dataSource.Text;
                OracleConnection conn = ConnectionManager.OpenAndGetConnection(strBuilder.ConnectionString);
                StringBuilder buf = new StringBuilder();
                decimal salary = 0.00M;
                using (OracleCommand cmd = new OracleCommand(lblQuery.Text, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    salary = Convert.ToDecimal(cmd.ExecuteScalar());
                    buf.AppendFormat("The average salary for employees is {0}", salary);
                }
                txtOutput.Text = buf.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

    }
}
