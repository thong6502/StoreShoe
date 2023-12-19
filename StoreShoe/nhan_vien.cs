using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.Logging;
using shoe_store_manager.StoreShoesDataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace shoe_store_manager
{
    public partial class nhan_vien : Form
    {
        private Dictionary<Guna2TextBox, Guna2Button> textBoxWarningPairs;
        //private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StoreShoes;Persist Security Info=True;User ID=sa;Password=thong038202008963;TrustServerCertificate=True";

        public nhan_vien()
        {
            InitializeComponent();
        }

        private void nhan_vien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'storeShoesDataSet.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.storeShoesDataSet.NhanVien);
            // TODO: This line of code loads data into the 'storeShoesDataSet.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.storeShoesDataSet.NhanVien);
            // TODO: This line of code loads data into the 'storeShoesDataSet.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.storeShoesDataSet.NhanVien);
            // TODO: This line of code loads data into the 'storeShoesDataSet.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.storeShoesDataSet.NhanVien);
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
                { tb_chucVu, warning4 }
            };
        }

        private void disabeled()
        {
            foreach (Control c in this.Controls)
            {
                // Kiểm tra xem control có phải là edit_box hay không
                if (c.Name != "container_edit_box")
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

            foreach(Control c in this.edit_box.Controls)
            {
                if(c is Guna2Button && c.Name != "xac_nhan" && c.Name != "huy")
                {
                    c.Visible = false;
                    c.Text = "Nội dung trống";
                }
            }
        }

        private void clear_content_tb()
        {
            foreach (Control c in this.edit_box.Controls)
            {
                if(c is Guna2TextBox)
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
            container_edit_box.Visible = true;
            undisplay_warning();
            unVisible_boxFilter();
            disabeled();

        }
        private void huy_Click(object sender, EventArgs e)
        {
            container_edit_box.Visible = false;
            clear_content_tb();
            undisplay_warning();
            enabeled();
        }

        private bool isEdit;
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
                if(isEdit)
                {
                    sua_rowData();
                }
                else
                {
                    them_RowData();
                }
                Search_input();
                container_edit_box.Visible = false;
                clear_content_tb();
                undisplay_warning();
                enabeled();

            }

            foreach (KeyValuePair<Guna2TextBox, Guna2Button> pair in textBoxWarningPairs)
            {
                pair.Value.Visible = pair.Key.Text == "";
            }

        }

        private void them_RowData()
        {
            string queryCountId = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
            string maNV = DataProvider.Instance.GenerateId(queryCountId, "NV");
            string tenNV = tb_name.Text;
            string diaChi = tb_address.Text;
            string soDienThoai = tb_phone.Text;
            string email = tb_Email.Text;
            string ChucVu = tb_chucVu.Text;
            string luong = tb_Luong.Text;

            string query = "INSERT INTO NhanVien (MaNV, TenNV, DiaChi, SDT, Email, Luong, ChucVu) VALUES (@MaNV, @TenNV, @DiaChi, @SDT, @Email, @luong, @ChucVu)";
            object[] parameter = new object[] { maNV, tenNV, diaChi, soDienThoai, email, luong, ChucVu };
            DataProvider.Instance.ExcuteNonQuery(query, parameter);

            // Cập nhật DataGridView
            this.nhanVienTableAdapter.Fill(this.storeShoesDataSet.NhanVien);
        }
        

        private void sua_rowData()
        {
            DataGridViewRow row = data.SelectedRows[0];
            string maNV = row.Cells["maNVDataGridViewTextBoxColumn"].Value.ToString();
            string tenNV = tb_name.Text;
            string diaChi = tb_address.Text;
            string soDienThoai = tb_phone.Text;
            string email = tb_Email.Text;
            string ChucVu = tb_chucVu.Text;
            string luong = tb_Luong.Text;
            object[] parameter = new object[] {tenNV, diaChi, soDienThoai, email, ChucVu, luong, maNV };

            string query = "UPDATE NhanVien SET TenNV = @TenNV, DiaChi = @DiaChi, SDT = @SDT, Email = @Email,ChucVu = @ChucVu, Luong = @luong WHERE MaNV = @MaNV";
            DataProvider.Instance.ExcuteNonQuery(query, parameter);
            // Cập nhật DataGridView
            this.nhanVienTableAdapter.Fill(this.storeShoesDataSet.NhanVien);
        }


        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox currentTextBox = sender as Guna2TextBox;

            // Kiểm tra xem Guna2TextBox có trong từ điển không
            if (textBoxWarningPairs.ContainsKey(currentTextBox))
            {
                // Đặt thuộc tính Visible của Guna2Button cảnh báo dựa trên giá trị của Guna2TextBox
                textBoxWarningPairs[currentTextBox].Visible = currentTextBox.Text == "";
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

        private void delete_Click(object sender, EventArgs e)
        {
            if (data.SelectedRows.Count > 0)
            {
                string Id = data.SelectedRows[0].Cells["maNVDataGridViewTextBoxColumn"].Value.ToString();
                object[] parameter = new object[] { Id };
                string query = "DELETE FROM NhanVien WHERE MaNv = @MaNV";
                DataProvider.Instance.ExcuteNonQuery(query, parameter);
                // Cập nhật DataGridView
                this.nhanVienTableAdapter.Fill(this.storeShoesDataSet.NhanVien);
                Search_input();
            }
        }

        private void tb_Luong_TextChanged(object sender, EventArgs e)
        {
            main.UpdateTextBox(tb_Luong, tb_Luong.Text);
        }

        private void edit_Click(object sender, EventArgs e)
        {
            isEdit = true;
            container_edit_box.Visible = true;
            undisplay_warning();
            unVisible_boxFilter();
            disabeled();

            DataGridViewRow row = data.SelectedRows[0];
            tb_name.Text = row.Cells["tenNVDataGridViewTextBoxColumn"].Value.ToString();
            tb_address.Text = row.Cells["diaChiDataGridViewTextBoxColumn"].Value.ToString();
            tb_phone.Text = row.Cells["sDTDataGridViewTextBoxColumn"].Value.ToString();
            tb_Email.Text = row.Cells["emailDataGridViewTextBoxColumn"].Value.ToString();
            tb_chucVu.Text = row.Cells["chucVuDataGridViewTextBoxColumn"].Value.ToString();
            tb_Luong.Text = row.Cells["luongDataGridViewTextBoxColumn"].Value.ToString();

        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            Search_input();
        }
        private void Search_input()
        {
            string str_search = "%" + search.Text + "%";
            string query = "";
            object[] parameter = new object[] { str_search };

            if (cbx_filter.Text == "Tên nhân viên")
                query = "SELECT * FROM NhanVien WHERE TenNV LIKE @str_search";
            else if (cbx_filter.Text == "Địa chỉ")
                query = "SELECT * FROM NhanVien WHERE DiaChi LIKE @str_search";
            else if (cbx_filter.Text == "Chức vụ")
                query = "SELECT * FROM NhanVien WHERE ChucVu LIKE @str_search";
            else
                return;  // Nếu cbx_filter.Text không phải là một trong các giá trị mong đợi, thoát khỏi hàm

            data.DataSource = DataProvider.Instance.ExcuteQuery(query, parameter);

        }


        

    }
}
