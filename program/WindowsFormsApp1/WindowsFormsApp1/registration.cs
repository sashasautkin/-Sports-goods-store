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
using System.Data.Sql;

namespace WindowsFormsApp1
{
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }

        private void registration_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thomas\Desktop\program\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True"))
            {
                connection.Open();
                SqlDataAdapter dt = new SqlDataAdapter("select count (*) From sign_in where login = ' "+ textBox1.Text + "'and password = '"+textBox2.Text+"'",connection);

                DataTable table = new DataTable();
                dt.Fill(table);
                if(table.Rows[0][0].ToString()=="0")
                {
                    if((textBox1.Text !="")||(textBox2.Text !=""))
                    {
                        
                        SqlCommand comand = new SqlCommand("INSERT Into sign_in (login,password) Values(@login,@password)",connection);
                        comand.Parameters.AddWithValue("login", textBox1.Text);
                        comand.Parameters.AddWithValue("password", textBox2.Text);
                        comand.ExecuteNonQuery();
                        MessageBox.Show("Ви успішно зареєструвалися");
                        Form1 p = new Form1();
                        this.Visible = false;
                        p.Show();
                    }


                }
                else
                {
                    MessageBox.Show("логін зайнятий");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
