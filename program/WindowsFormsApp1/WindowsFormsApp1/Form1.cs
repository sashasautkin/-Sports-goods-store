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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thomas\Desktop\program\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True")) 
            {
                SqlDataAdapter dataT = new SqlDataAdapter("Select Count (*) from [sign_in] where login  = '" + textBox1.Text + "'and password ='" + textBox2.Text + "'", connection);
                DataTable ch = new DataTable();
               dataT.Fill(ch);
                if (ch.Rows[0][0].ToString() == "1")
                {
                    startpage page = new startpage();
                    this.Visible = false;
                    page.Show();
                }
                else
                {
                    MessageBox.Show("Неправильий логін чи пароль");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            registration reg = new registration();
            this.Visible = false;
            reg.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
