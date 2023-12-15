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
        DataTable mainTB;
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
            

            string query_NCC = "SELECT * FROM NhaCungCap";
            cbx_NCC.DataSource = DataProvider.Instance.ExcuteQuery(query_NCC);
            cbx_NCC.DisplayMember = "TenNCC";

            cbx_LoaiGiay.StartIndex = -1;
            cbx_NCC.StartIndex = -1;

        }
        private void displaydata()
        {
            string query = "SELECT c.MaSPG, c.img, c.TenGiay, o.Soluong, c.Giamua FROM ChiTietHoaDonMua As o, SanPhamGiay As c WHERE o.MaSPG = c.MaSPG";
            data.DataSource = mainTB = DataProvider.Instance.ExcuteQuery(query);
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
            cbx_LoaiGiay.SelectedIndex = -1;
            cbx_NCC.SelectedIndex = -1;
        }

        private void add_Click(object sender, EventArgs e)
        {
            isEdit = false;
            openEditBox();
        }

        private void openEditBox()
        {
            container_edit_box.Visible = true;            
            disabeled();
        }
        private void colseEditBox()
        {
            container_edit_box.Visible = false;
            clear_content_tb();
            undisplay_warning();
            warning2.Visible = false;
            warning3.Visible = false;
            enabeled();
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
            addPic(fileName);
        }

        private void addPic(string fileName)
        {
            
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
        private void nonPic()
        {
            using (Image img = Image.FromFile(""))
            {
                pic_img.Image = new Bitmap(img);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            colseEditBox();
        }



        


        private void huy_Click(object sender, EventArgs e)
        {
            colseEditBox();
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
                string query = "SELECT SanPhamGiay.Img, LoaiGiay.Ten, SanPhamGiay.TenGiay, NhaCungCap.TenNCC, ChiTietHoaDonMua.GiaMua, ChiTietHoaDonBan.GiaBan FROM SanPhamGiay JOIN LoaiGiay ON SanPhamGiay.MaLG = LoaiGiay.MaLG JOIN NhaCungCap ON SanPhamGiay.MaNCC JOIN ChiTietHoaDonMua ON SanPhamGiay.MaSPG = ChiTietHoaDonMua.MaSPG JOIN ChiTietHoaDonBan ON SanPhamGiay.MaSPG = ChiTietHoaDonBan.MaSPG = NhaCungCap.MaNCC WHERE SanPhamGiay.TenGiay = @TenGiay ";
                object[] parameter = new object[] { str_search };

                DataTable dt = DataProvider.Instance.ExcuteQuery(query, parameter);

                string fileNameDB = dt.Rows[0]["Img"].ToString();
                string LoaiGiay = dt.Rows[0]["Ten"].ToString();
                string NCC = dt.Rows[0]["TenNCC"].ToString();
                string GiaMua = dt.Rows[0]["GiaMua"].ToString();
                string GiaBan = dt.Rows[0]["GiaBan"].ToString();

                addPic(fileNameDB);

                int index_LoaiGiay = cbx_LoaiGiay.Items.IndexOf(LoaiGiay);
                cbx_LoaiGiay.SelectedIndex = index_LoaiGiay;

                int index_NCC = cbx_NCC.Items.IndexOf(NCC);
                cbx_NCC.SelectedIndex = index_NCC;

                tb_giaMua.Text = GiaMua;
                tb_giaBan.Text = GiaBan;

            }else
            {
                nonPic();
                cbx_LoaiGiay.SelectedIndex = -1;
                cbx_NCC.SelectedIndex = -1;
                tb_giaMua.Text = "";
                tb_giaBan.Text = "";
            }
        }

        private void xac_nhan_Click_1(object sender, EventArgs e)
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
            if(allWarningsHidden && warning2.Visible == false && warning3.Visible == false)
            {
                if (isEdit)
                {
                    sua_rowData();
                }
                else
                {
                    them_RowData();
                }
                colseEditBox();
            }
            foreach (KeyValuePair<Guna2TextBox, Guna2Button> pair in textBoxWarningPairs)
            {
                pair.Value.Visible = pair.Key.Text == "";
            }
            warning2.Visible = cbx_LoaiGiay.Text == "";
            warning3.Visible = cbx_NCC.Text == "";
        }

        private void them_RowData()
        {
            string MaSPG = findIdInDataTB(tb_name.Text);
            isEdit = MaSPG != "";

            if(isEdit)
            {
                sua_rowData();
            }
            else
            {
                string queryCountId = "SELECT MaSPG FROM SanPhamGiay";
                MaSPG = DataProvider.Instance.GenerateId(queryCountId, "SPG");
                string TenSP = tb_name.Text;
                string pathImg = copyPathPic();
                string LoaiGiay = cbx_LoaiGiay.Text;
                string NCC = cbx_NCC.Text;
                int s38 = Convert.ToInt32(nud_s38.Value);
                int s39 = Convert.ToInt32(nud_s39.Value);
                int s40 = Convert.ToInt32(nud_s40.Value);
                int s41 = Convert.ToInt32(nud_s41.Value);
                int s42 = Convert.ToInt32(nud_s42.Value);
                int s43 = Convert.ToInt32(nud_s43.Value);
                string giaMua = tb_giaMua.Text;
                string giaBan = tb_giaBan.Text;

                string query = "";
                object[] paramater = new object[] { };
            }

        }
        private void sua_rowData()
        {
            
        }

        private string copyPathPic()
        {
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

            return newPath;
        }

        private string findIdInDataTB(string TenSPG)
        {
            DataRow[] foundRows = mainTB.Select("TenGiay = '" + TenSPG + "'");
            string MaSPG = "";
            if (foundRows.Length > 0)
            {
                MaSPG = foundRows[0]["MaSPG"].ToString();
                
            }
                return MaSPG;
        }

        private void cbx_LoaiGiay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_LoaiGiay.Text != "") warning2.Visible = false;
            else warning2.Visible = true;
        }

        private void cbx_NCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_NCC.Text != "") warning3.Visible = false;
            warning3.Visible = true;
        }

    }
}
