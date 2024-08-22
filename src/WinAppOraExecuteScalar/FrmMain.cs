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
            lblQuery.Text = "SELECT MIN(salary),MAX(salary),AVG(salary) FROM employees";
        }

        private void BtnQueryClick(object sender, EventArgs e)
        {
            try
            {
                object[] results = new object[3];
                OracleConnectionStringBuilder strBuilder = new OracleConnectionStringBuilder();
                strBuilder.UserID = userName.Text;
                strBuilder.Password = password.Text;
                strBuilder.DataSource = dataSource.Text;
                OracleConnection conn = ConnectionManager.OpenAndGetConnection(strBuilder.ConnectionString);
                using (OracleCommand cmd = new OracleCommand(lblQuery.Text, conn))
                {
                        cmd.CommandType = CommandType.Text;
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            reader.GetOracleValues(results);
                        }
                }
                StringBuilder buf = new StringBuilder();
                buf.AppendLine("+--------+--------+-------+");
                buf.AppendLine("| MIN    |  MAX   |   AVG |");
                buf.AppendLine("+--------+--------+-------+");
                buf.AppendFormat("|  {0}  | {1}  | {2} ", results[0], results[1], results[2]);
                buf.AppendLine();
                buf.AppendLine("+--------+--------+-------+");
                txtOutput.Text = buf.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

    }
}
