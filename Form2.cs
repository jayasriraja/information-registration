using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        MySqlConnection con = new MySqlConnection("Server=localhost;Database=project1;Uid=root;Pwd=12345;");

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select sno as Serial_No,idno as Id_No,name as Name,contactno as Contact_No from information where status='a'", con);
            DataSet dd = new DataSet();
            
            cmd.Fill(dd);
            dataGridView1.DataSource = dd.Tables[0];
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();   
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            var sqldtfmt = System.DateTime.Now.ToString("yy/MM/dd hh:mm:ss");
            MySqlCommand cmd = new MySqlCommand("insert into information(sno,idno,name,contactno,username,fdt,status) values('" + textBox4.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','admin','" + sqldtfmt.ToString()+ "','a')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data is stored");
            con.Close();
        }

        int count;
        private void Form2_Load(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select count(*) from project1.information", con);
            count = Convert.ToInt16(cmd.ExecuteScalar()) + 1;
            textBox4.Text =  count.ToString();
            con.Close();
            button1.Enabled = false;
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
           int s;
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select count(eid) from project1.information where contactno=" + textBox3.Text + "", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                s = Convert.ToInt32(dr.GetString(0));
                if(s>0)
                {
                    MessageBox.Show("This Contact Number is already exist... Please enter a new Contact Number..");
                    button1.Enabled = false;
                }
                if(s==0)
                {
                    s = Convert.ToInt32(dr.GetString(0));
                    MessageBox.Show("Contact Number is Valid");
                    button1.Enabled = true;
                }
            }
            con.Close();
        }

     
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select count(*) from project1.information", con);
            count = Convert.ToInt16(cmd.ExecuteScalar()) + 1;
            textBox4.Text = count.ToString();
            con.Close();

        }
        string cno = "";
        string sno = "";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             MySqlCommand cmd = new MySqlCommand(); 
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                DialogResult di = MessageBox.Show("Do you want to Delete the Record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (di == DialogResult.Yes)
                {
                    cno = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE information SET status = 'd' WHERE contactno='" + cno + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select count(*) from project1.information", con);
            count = Convert.ToInt16(cmd.ExecuteScalar()) + 1;
            textBox4.Text = count.ToString();
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.TextLength > 10)
                MessageBox.Show("Enter a correct Contact Number...");
            if(textBox3.TextLength<10)
                MessageBox.Show("Enter a correct Contact Number...");
        }       
    }
}
