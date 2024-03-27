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

namespace clone_cafe
{
    public partial class login : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Aplication development\GUNA_practices\clone-cafe\clone-cafe\clone_cafe.mdf"";Integrated Security=True");
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("please fill all blank","Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if(connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();

                        string selectData = "SELECT * FROM users WHERE username =@username AND password =@password ";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                          cmd.Parameters.AddWithValue("@username",login_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", login_password.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if(table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Login Success!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Form1 form1 = new Form1();
                                form1.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrct Username or password ", "information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }catch(Exception ex)
                    {
                        MessageBox.Show("Error:" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void login_cha_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_cha.Checked ? '\0' : '*';
        }
    }
}
