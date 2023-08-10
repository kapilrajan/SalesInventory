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

namespace SalesInventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=kapilDB;Integrated Security=true");
        SqlCommand cmd;
        SqlDataReader reader;
        string sql;
        private void button1_Click(object sender, EventArgs e)
        {
            string name= textBox1.Text;
            string price= textBox2.Text;
            string discount= textBox3.Text;

            sql = "insert into product(name,price,discount)values(@name,@price,@discount) ";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name" ,name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@discount",discount);
            cmd.ExecuteNonQuery();
            MessageBox.Show("record saved");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
            con.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            string price = textBox2.Text;
            string discount = textBox3.Text;
            string id= textBox4.Text;

            sql = "update product set name=@name,price=@price,discount=@discount where id=@id";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@discount", discount);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("record saved");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string id = textBox4.Text;
            sql = "select * from product where id=@id";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                textBox1.Text = dr["name"].ToString();
                textBox2.Text = dr["price"].ToString();
                textBox3.Text = dr["discount"].ToString();

            }
            else
            {

                MessageBox.Show("id not found");
            }
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();


        }
    }
}
