using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace clone_cafe
{
     class inventoryData
    {

        public int ID { set; get; } //0

        public string ProductId { set; get; } //1

        public string ProductName { set; get; } //2

        public string Type { set; get; } //3

        public int Price { set; get; } //4

        public int Stock { set; get; } //5

        public string Image { set; get; } //6





        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Aplication development\GUNA_practices\clone-cafe\clone-cafe\clone_cafe.mdf"";Integrated Security=True");

        public List<inventoryData> employeeListData()
        {
            List<inventoryData> listdata = new List<inventoryData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM inventory WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            inventoryData ed = new inventoryData();
                            ed.ID = (int)reader["id"];
                            ed.ProductId = reader["product_id"].ToString();
                            ed.ProductName = reader["product_name"].ToString();
                            ed.Type = reader["typess"].ToString();
                            ed.Price = (int)reader["price"];
                            ed.Stock = (int)reader["stock"];
                            ed.Image = reader["image"].ToString();
                           

                            listdata.Add(ed);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex);
                }
                finally
                {
                    connect.Close();
                }
            }

            return listdata;
        }



    }
}
