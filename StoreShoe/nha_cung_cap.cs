using Guna.UI2.WinForms;
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
    
    public partial class nha_cung_cap : Form
    {
        private Dictionary<Guna2TextBox, Guna2Button> textBoxWarningPairs;
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StoreShoes;Persist Security Info=True;User ID=sa;Password=thong038202008963;TrustServerCertificate=True";
        public nha_cung_cap()
        {
            InitializeComponent();
        }

        private void nha_cung_cap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'storeShoesDataSet.NhaCungCap' table. You can move, or remove it, as needed.
            this.nhaCungCapTableAdapter.Fill(this.storeShoesDataSet.NhaCungCap);
            tbWarningPairs();

        }


        // Tạo một từ điển để lưu trữ các cặp Guna2TextBox và Guna2Button cảnh báo
        private void tbWarningPairs()
        {
            textBoxWarningPairs = new Dictionary<Guna2TextBox, Guna2Button>()
            {
                { tb_name, warning1 },
                { tb_address, warning2 },
                { tb_phone, warning3 },

            };
        }

        private void disabeled()
        {
            foreach (Control c in this.Controls)
            {
                // Kiểm tra xem control có phải là edit_box hay không
                if (c.Name != "edit_box")
                {
                    c.Enabled = false;
                }
            }
        }

        private void enabeled()
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = true;
            }
        }

        private void undisplay_warning()
        {

            foreach (Control c in this.edit_box.Controls)
            {
                if (c is Guna2Button && c.Name != "xac_nhan" && c.Name != "huy")
                {
                    c.Visible = false;
                }
            }
        }

        private void clear_content_tb()
        {
            foreach (Control c in this.edit_box.Controls)
            {
                if (c is Guna2TextBox)
                {
                    c.Text = "";
                }
            }
        }

        private void unVisible_boxFilter()
        {
            box_filter.Visible = false;
        }

        private void visible_boxFilter()
        {
            box_filter.Visible = true;
        }


        private void add_Click(object sender, EventArgs e)
        {
            isEdit = false;
            edit_box.Visible = true;
            undisplay_warning();
            unVisible_boxFilter();
            disabeled();
        }
        private void huy_Click(object sender, EventArgs e)
        {
            edit_box.Visible = false;
            clear_content_tb();
            undisplay_warning();
            enabeled();
        }

        bool isEdit;
        private void xac_nhan_Click(object sender, EventArgs e)
        {

            // Kiểm tra xem tất cả các nút cảnh báo có đang hiển thị hay không
            bool allWarningsHidden = true;
            foreach (KeyValuePair<Guna2TextBox, Guna2Button> pair in textBoxWarningPairs)
            {
                if (pair.Value.Visible)
                {
                    allWarningsHidden = false;
                    break;
                }
            }

            if (allWarningsHidden)
            {
                if (isEdit)
                {
                    sua_rowData();
                }
                else
                {
                    them_RowData();
                }
                Search_input();
                edit_box.Visible = false;
                clear_content_tb();
                undisplay_warning();
                enabeled();

            }

            foreach (KeyValuePair<Guna2TextBox, Guna2Button> pair in textBoxWarningPairs)
            {
                pair.Value.Visible = pair.Key.Text == "";
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Lấy Guna2TextBox hiện tại
            Guna2TextBox currentTextBox = sender as Guna2TextBox;

            // Kiểm tra xem Guna2TextBox có trong từ điển không
            if (textBoxWarningPairs.ContainsKey(currentTextBox))
            {
                // Đặt thuộc tính Visible của Guna2Button cảnh báo dựa trên giá trị của Guna2TextBox
                textBoxWarningPairs[currentTextBox].Visible = currentTextBox.Text == "";
            }
        }

        private void them_RowData()
        {
            string maNCC = GenerateId();
            string tenNCC = tb_name.Text;
            string diaChi = tb_address.Text;
            string soDienThoai = tb_phone.Text;


            // Thêm nhân viên mới vào cơ sở dữ liệu
            string query = "INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SDT) VALUES (@MaNCC, @TenNCC, @DiaChi, @SDT)";
            // Thêm nhân viên mới vào cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@SDT", soDienThoai);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // Cập nhật DataGridView
            this.nhaCungCapTableAdapter.Fill(this.storeShoesDataSet.NhaCungCap);
        }
        private string GenerateId()
        {
            int count = 1;
            string id = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                bool exists = true;
                while (exists)
                {
                    id = "NCC" + count.ToString();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM NhaCungCap WHERE MaNCC = @MaNCC", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", id);
                        exists = ((int)cmd.ExecuteScalar() > 0);
                    }
                    count++;
                }
                conn.Close();
            }
            return id;
        }

        private void sua_rowData()
        {
            DataGridViewRow row = data.SelectedRows[0];
            string maNCC = row.Cells["maNCCDataGridViewTextBoxColumn"].Value.ToString();
            string tenNCC = tb_name.Text;
            string diaChi = tb_address.Text;
            string soDienThoai = tb_phone.Text;

            // Sửa thông tin nhân viên trong cơ sở dữ liệu
            string query = "UPDATE NhaCungCap SET TenNCC = @TenNCC, DiaChi = @DiaChi, SDT = @SDT WHERE MaNCC = @MaNCC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@SDT", soDienThoai);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // Cập nhật DataGridView
            this.nhaCungCapTableAdapter.Fill(this.storeShoesDataSet.NhaCungCap);
        }
        private void Search_input()
        {
            string str_search = "%" + search.Text + "%";
            string query = "";

            if (cbx_filter.Text == "Tên nhà cung cấp")
                query = "SELECT * FROM NhaCungCap WHERE TenNCC LIKE @str_search";
            else if (cbx_filter.Text == "Địa chỉ")
                query = "SELECT * FROM NhaCungCap WHERE DiaChi LIKE @str_search";
            else
                return;  // Nếu cbx_filter.Text không phải là một trong các giá trị mong đợi, thoát khỏi hàm

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@str_search", str_search);
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    data.DataSource = dt;
                    conn.Close();
                }
            }
        }

        private void btn_filter_Click(object sender, EventArgs e)
        {
            visible_boxFilter();
        }

        private void btn_HFilter_Click(object sender, EventArgs e)
        {
            unVisible_boxFilter();
        }

        private void btn_XNFilter_Click(object sender, EventArgs e)
        {
            unVisible_boxFilter();
            search.PlaceholderText = cbx_filter.Text;
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            Search_input();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            isEdit = true;
            edit_box.Visible = true;
            undisplay_warning();
            unVisible_boxFilter();
            disabeled();

            DataGridViewRow row = data.SelectedRows[0];
            tb_name.Text = row.Cells["tenNCCDataGridViewTextBoxColumn"].Value.ToString();
            tb_address.Text = row.Cells["diaChiDataGridViewTextBoxColumn"].Value.ToString();
            tb_phone.Text = row.Cells["sDTDataGridViewTextBoxColumn"].Value.ToString();
            
        }

        private void delete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (data.SelectedRows.Count > 0)
            {
                string Id = data.SelectedRows[0].Cells["maNCCDataGridViewTextBoxColumn"].Value.ToString();
                // Xóa nhân viên từ cơ sở dữ liệu
                string query = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", Id);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                // Cập nhật DataGridView
                this.nhaCungCapTableAdapter.Fill(this.storeShoesDataSet.NhaCungCap);
                Search_input();
            }
        }
    }
}
