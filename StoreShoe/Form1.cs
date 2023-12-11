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

namespace shoe_store_manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'storeShoesDataSet.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.storeShoesDataSet.NhanVien);

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                // Lấy ID của nhân viên từ dòng được chọn
                string nhanVienId = guna2DataGridView1.SelectedRows[0].Cells["maNVDataGridViewTextBoxColumn"].Value.ToString();


                // Xóa nhân viên từ cơ sở dữ liệu
                string query = "DELETE FROM NhanVien WHERE MaNv = @MaNV";
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StoreShoes;Persist Security Info=True;User ID=sa;Password=thong038202008963;TrustServerCertificate=True";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", nhanVienId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                // Cập nhật DataGridView
                this.nhanVienTableAdapter.Fill(this.storeShoesDataSet.NhanVien);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!");
            }
        }
    }
}
