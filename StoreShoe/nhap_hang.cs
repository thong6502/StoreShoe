using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;

namespace shoe_store_manager
{
    public partial class nhap_hang : Form
    {
        private Dictionary<Guna2TextBox, Guna2Button> textBoxWarningPairs;
        bool isEdit = false;
        public nhap_hang()
        {
            InitializeComponent();
        }

        private void nhap_hang_Load(object sender, EventArgs e)
        {

            displaydata();
            addValuesName();
            addData_cbx();
            tbWarningPairs();
        }

        private void addValuesName()
        {
            string query = "SELECT TenGiay FROM SanPhamGiay";
            tb_name.Values = DataProvider.Instance.GetDataColumn(query);
        }
        private void addData_cbx()
        {
            string query_LG ="SELECT * FROM LoaiGiay";
            cbx_LoaiGiay.DataSource = DataProvider.Instance.ExcuteQuery(query_LG);
            cbx_LoaiGiay.DisplayMember = "Ten";
            cbx_LoaiGiay.StartIndex = -1;

            string query_NCC = "SELECT * FROM NhaCungCap";
            cbx_NCC.DataSource = DataProvider.Instance.ExcuteQuery(query_NCC);
            cbx_NCC.DisplayMember = "TenNCC";
            cbx_NCC.StartIndex = -1;
        }
        private void displaydata()
        {
            string query = "SELECT o.MaSPG, c.img, c.TenGiay, o.Giamua, o.Soluong FROM ChiTietHoaDonMua As o, SanPhamGiay As c WHERE o.MaSPG = c.MaSPG";
            data.DataSource = DataProvider.Instance.ExcuteQuery(query);
        }

        private void tbWarningPairs()
        {
            textBoxWarningPairs = new Dictionary<Guna2TextBox, Guna2Button>()
            {
                { tb_name, warning1 }
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

            foreach (Control c in this.edit_box.Controls)
            {
                if (c is Guna2Button && c.Name != "xac_nhan" && c.Name != "huy")
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
                if (c is Guna2TextBox)
                {
                    c.Text = "";
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            isEdit = false;
            container_edit_box.Visible = true;
            undisplay_warning();
            disabeled();
        }


        private void tb_giaMua_TextChanged(object sender, EventArgs e)
        {
            main.UpdateTextBox(tb_giaMua, tb_giaMua.Text);
        }


        private void tb_giaBan_TextChanged(object sender, EventArgs e)
        {
            main.UpdateTextBox(tb_giaBan, tb_giaBan.Text);
        }


        string fileName = "";
        void LoadImage(ref string filename)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
        }
        private void pic_img_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LoadImage(ref fileName);

            if (File.Exists(fileName))
            {
                try
                {
                    // Kiểm tra xem tệp có thể được tải như một hình ảnh hay không
                    using (Image img = Image.FromFile(fileName))
                    {
                        pic_img.Image = new Bitmap(img);
                    }
                }
                catch (OutOfMemoryException)
                {
                    // Nếu tệp không phải là hình ảnh hợp lệ, Image.FromFile sẽ ném ra một ngoại lệ OutOfMemoryException
                    MessageBox.Show("Tệp không phải là hình ảnh hợp lệ: " + fileName);
                    fileName = "";
                }
            }
            else
            {
                MessageBox.Show("Tệp tin không tồn tại: " + fileName);
                fileName = "";
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            container_edit_box.Visible = false;
        }

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
                    //sua_rowData();
                }
                else
                {
                    them_RowData();
                }
               
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
            /*string queryCountId = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
            string maNV = DataProvider.Instance.GenerateId(queryCountId, "NV");
            string tenNV = tb_name.Text;*/
            string sourcePath = fileName; // Đường dẫn của tệp hình ảnh gốc
            string targetPath = Application.ExecutablePath; // Đường dẫn mà bạn muốn lưu bản sao của hình ảnh

            // Lấy tên tệp từ sourcePath
            string fileNamePic = Path.GetFileName(sourcePath);

            // Lấy phần thư mục của targetPath
            string directory = Path.GetDirectoryName(targetPath);

            // Lấy thư mục cha của directory
            DirectoryInfo directoryInfo = Directory.GetParent(directory);
            string parentDirectory = directoryInfo != null ? directoryInfo.FullName : null;

            // Lấy thư mục cha của parentDirectory
            directoryInfo = Directory.GetParent(parentDirectory);
            string grandParentDirectory = directoryInfo != null ? directoryInfo.FullName : null;



            // Tạo đường dẫn mới bằng cách nối grandParentDirectory, thư mục "photos" và fileName
            string newPath = Path.Combine(grandParentDirectory, "photos", fileNamePic);
            // Tạo bản sao của hình ảnh
             File.Copy(sourcePath, newPath, true);
        }


        private void huy_Click(object sender, EventArgs e)
        {
            container_edit_box.Visible = false;
            clear_content_tb();
            undisplay_warning();
            enabeled();
        }

        private void edit_Click(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            string path = Application.ExecutablePath;
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            int index = Array.IndexOf(tb_name.Values, tb_name.Text);

            if (index != -1)
            {
                string str_search = tb_name.Text;
                string query = "";
                object[] parameter = new object[] { str_search };


                data.DataSource = DataProvider.Instance.ExcuteQuery(query, parameter);
            }
            else
            {

            }
        }
    }
}
