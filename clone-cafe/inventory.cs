using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO; //image path
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace clone_cafe
{
    public partial class inventory : UserControl
    {

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Aplication development\GUNA_practices\clone-cafe\clone-cafe\clone_cafe.mdf"";Integrated Security=True");
        public inventory()
        {
            InitializeComponent();
           
        }









        private void btn_empAdd_Click(object sender, EventArgs e)
        {
            if (inven_pID.Text == ""
               || inven_pName.Text == ""
               || inven_type.Text == ""
               || inven_type.Text == ""
               || inven_price.Text == ""
               || inven_stock.Text == ""
               || inven_Pic.Image == null)
            {

                MessageBox.Show("plz fill all", "Error messag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string checkproID = "SELECT COUNT(*) FROM inventory WHERE product_id = @emID";

                        using (SqlCommand checkEm = new SqlCommand(checkproID, connect))
                        {
                            checkEm.Parameters.AddWithValue("@emID", inven_pID.Text.Trim());

                            int count = (int)checkEm.ExecuteScalar();

                            if (count >= 1)
                            {
                                MessageBox.Show(inven_pID.Text.Trim() + "is already taken", "error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                DateTime today = DateTime.Today;
                                string insertData = "INSERT INTO inventory" +
                                         "(product_id,product_name,typess,price" +
                                           ",stock,image,insert_date)" +

                                           "VALUES(@productID,@productName,@type,@price" +
                                           ",@stock, @image,@insertDate)";

                            //add directary file path in here 

                    

                                string path = Path.Combine(@"D:\Aplication-development\GUNA_practices\clone-cafe\clone-cafe\Directory\"
                                       + inven_pID.Text.Trim() + ".jpg");

                                string directoryPath = Path.GetDirectoryName(path);

                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }
                                File.Copy(inven_Pic.ImageLocation, path, true);


                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@productID", inven_pID.Text.Trim());
                                    cmd.Parameters.AddWithValue("@productName", inven_pName.Text.Trim());
                                    cmd.Parameters.AddWithValue("@type", inven_type.Text.Trim());
                                    cmd.Parameters.AddWithValue("@price", inven_price.Text.Trim());
                                    cmd.Parameters.AddWithValue("@stock", inven_stock.Text.Trim());
                                    cmd.Parameters.AddWithValue("@image", path);
                                    cmd.Parameters.AddWithValue("@insertDate", today);
                                   

                                    cmd.ExecuteNonQuery();

                                  


                                    MessageBox.Show("Added successfully!"
                                        , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //clear part
                                   // clearField();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
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

        private void emp_addpic_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image File(*.jpg;*.png)|*.jpg;*.png";
                string imagePath = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    inven_Pic.ImageLocation = imagePath;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex, "Error Message"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
