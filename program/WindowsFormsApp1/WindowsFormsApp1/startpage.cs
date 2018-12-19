using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class startpage : Form
    {
        SqlConnection sqlConnection;
        public startpage()
        {
            InitializeComponent();
        }

        private async void startpage_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thomas\Desktop\program\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [product]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync()) 
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "       " + Convert.ToString(sqlReader["name"]) + "       " + Convert.ToString(sqlReader["price"]));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(sqlReader !=null)
                {
                    sqlReader.Close();
                }
            }
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
            Close();
        }

        private void startpage_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (sqlConnection !=null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(label5.Visible)
            {
                label5.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [PRODUCT] (name, price) VALUES(@name, @price) ", sqlConnection);
                command.Parameters.AddWithValue("name", textBox1.Text);
                command.Parameters.AddWithValue("price", textBox2.Text);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label5.Visible = true;
                label5.Text = "поля повинні бути заповненні ";
            }

        }

        private async void обновитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thomas\Desktop\program\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [product]",sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "            " + Convert.ToString(sqlReader["name"]) + "      " + Convert.ToString(sqlReader["price"]));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(sqlReader !=null )
                {
                    sqlReader.Close();
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label8.Visible)
            {
                label8.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4 .Text)&&!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [product] SET [name]=@name , [price]=@price where [Id]=@Id",sqlConnection);
                command.Parameters.AddWithValue("Id",textBox5.Text);
                command.Parameters.AddWithValue("name", textBox4.Text);
                command.Parameters.AddWithValue("price", textBox3.Text);
                await command.ExecuteNonQueryAsync();
                  
            }
            else if(string.IsNullOrEmpty(textBox5.Text) && string.IsNullOrWhiteSpace(textBox5.Text))
            {
                label8.Visible = true;
                label8.Text = "Індетифікатор має  бути заповнений ";

            }
            else
            {
                label8.Visible = true;
                label8.Text = "поля повинні бути заповненні ";
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label12.Visible)
            {
                label12.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [product] where [Id] = @Id",sqlConnection);
                command.Parameters.AddWithValue("Id", textBox6.Text);
                await command.ExecuteNonQueryAsync();
            }
            else if (string.IsNullOrEmpty(textBox6.Text) && string.IsNullOrWhiteSpace(textBox6.Text))
            {
                label12.Visible = true;
                label12.Text = "Індетифікатор має  бути заповнений ";

            }
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
