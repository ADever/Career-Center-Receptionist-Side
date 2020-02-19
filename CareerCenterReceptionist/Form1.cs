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

namespace CareerCenterReceptionist
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlConnection connection2;
        private SqlCommand command2;
        private SqlConnection connection3;
        private SqlConnection connection4;
        private SqlCommand command3;
        private SqlCommand command4;


        private string myDate = DateTime.Now.ToShortDateString();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(" Data Source=localhost; initial Catalog = usrinfo; Integrated Security = true; pooling = false");
            connection.Open();
            command = new SqlCommand("INSERT INTO dailyDump(name, socialNum, date) SELECT name, socialNum, Date FROM usrinfo WHERE date = @a1", connection);
            command.Parameters.AddWithValue("a1", myDate);
            command.ExecuteNonQuery();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection2 = new SqlConnection(" Data Source=localhost; initial Catalog = usrinfo; Integrated Security = true; pooling = false");
                connection2.Open();
                command2 = new SqlCommand("INSERT INTO specificDaily(name, socialNum, date) SELECT name, socialNum, Date FROM usrinfo WHERE date = @a1", connection2);
                command2.Parameters.AddWithValue("a1", dateInput.Text);
                command2.ExecuteNonQuery();
            } finally
            {
                MessageBox.Show("This failed moron");
            }
        }
    }
}
