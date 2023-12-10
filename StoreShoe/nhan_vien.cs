using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace shoe_store_manager
{
    public partial class nhan_vien : Form
    {
        private Dictionary<Guna2TextBox, Guna2Button> textBoxWarningPairs;
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

            foreach(Control c in this.edit_box.Controls)
            {
                if(c is Guna2Button && c.Name != "xac_nhan" && c.Name != "huy")
                {
                    c.Visible = false;
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
            edit_box.Visible = true;
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


        private void xac_nhan_Click(object sender, EventArgs e)
        {

            // Iterate over the dictionary and set the visibility of the warning buttons
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

        private void nhanVienBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
