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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        //this is a search page
        // connection line to the database
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=project1;Uid=root;Pwd=12345;");

        private void Form3_Load(object sender, EventArgs e)
        {
            // this is used to show a saved and alive information from the connected database
                {
                con.Open();
                MySqlDataAdapter cmd = new MySqlDataAdapter("select sno as Serial_No,idno as Id_No,name as Name,contactno as Contact_No from information where status='a'", con);
                DataSet dd = new DataSet();
                cmd.Fill(dd);
                dataGridView1.DataSource = dd.Tables[0];
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // this button is a search bar in a form and it is using a contact number from informaiton..
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select sno as Serial_No,idno as ID_No,name as Name,contactno as Contact_No from project1.information where contactno like'" + textBox1.Text + "%'", con);
            DataSet dd = new DataSet();
            cmd.Fill(dd);
            dataGridView1.DataSource = dd.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this button is a search bar in a form and it is using a name from informaiton..
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select sno as Serial_No,idno as ID_No,name as Name,contactno as Contact_No from project1.information where name like'" + textBox1.Text + "%'", con);
            DataSet dd = new DataSet();
            cmd.Fill(dd);
            dataGridView1.DataSource = dd.Tables[0];
            con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
