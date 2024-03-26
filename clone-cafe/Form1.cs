using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clone_cafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sidepanel.Height = btn_home.Height;
            sidepanel.Top = btn_home.Top;
            

        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btn_home.Height;
            sidepanel.Top = btn_home.Top;


            home1.Visible = true;
            menu1.Visible = false;
            inventory1.Visible = false;
            records1.Visible = false;
            employe1.Visible = false;
            settings1.Visible = false;

        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btn_menu.Height;
            sidepanel.Top = btn_menu.Top;

            home1.Visible = false;
            menu1.Visible = true;
            inventory1.Visible = false;
            records1.Visible = false;
            employe1.Visible = false;
            settings1.Visible = false;

        }

        private void btn_inventory_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btn_inventory.Height;
            sidepanel.Top = btn_inventory.Top;


            home1.Visible = false;
            menu1.Visible = false;
            inventory1.Visible = true;
            records1.Visible = false;
            employe1.Visible = false;
            settings1.Visible = false;
        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btn_reports.Height;
            sidepanel.Top = btn_reports.Top;


            home1.Visible = false;
            menu1.Visible = false;
            inventory1.Visible = false;
            records1.Visible = true;
            employe1.Visible = false;
            settings1.Visible = false;
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btn_employee.Height;
            sidepanel.Top = btn_employee.Top;


            home1.Visible = false;
            menu1.Visible = false;
            inventory1.Visible = false;
            records1.Visible = false;
            employe1.Visible = true;
            settings1.Visible = false;
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            sidepanel.Height = btn_settings.Height;
            sidepanel.Top = btn_settings.Top;

            home1.Visible = false;
            menu1.Visible = false;
            inventory1.Visible = false;
            records1.Visible = false;
            employe1.Visible = false;
            settings1.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            DialogResult check = MessageBox.Show("Are you sure!", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
