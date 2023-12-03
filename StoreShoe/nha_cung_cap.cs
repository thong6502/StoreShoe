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

namespace shoe_store_manager
{
    
    public partial class nha_cung_cap : Form
    {
        private Dictionary<Guna2TextBox, Guna2Button> textBoxWarningPairs;
        public nha_cung_cap()
        {
            InitializeComponent();
        }

        private void nha_cung_cap_Load(object sender, EventArgs e)
        {
            tbWarningPairs();

            data.Rows.Add(13);
            data.Rows[0].Cells[1].Value = "NCC1";
            data.Rows[0].Cells[2].Value = "Lê Văn Thông";
            data.Rows[0].Cells[3].Value = "Vĩnh hưng - hoàng mai - hà nội";
            data.Rows[0].Cells[4].Value = "O123456789";

            data.Rows[1].Cells[1].Value = "NCC2";
            data.Rows[1].Cells[2].Value = "Nguyễn Văn A";
            data.Rows[1].Cells[3].Value = "Đống Đa - Hà Nội";
            data.Rows[1].Cells[4].Value = "O234567890";

            data.Rows[2].Cells[1].Value = "NCC3";
            data.Rows[2].Cells[2].Value = "Trần Thị B";
            data.Rows[2].Cells[3].Value = "Hai Bà Trưng - Hà Nội";
            data.Rows[2].Cells[4].Value = "O345678901";

            data.Rows[3].Cells[1].Value = "NCC4";
            data.Rows[3].Cells[2].Value = "Phạm Văn C";
            data.Rows[3].Cells[3].Value = "Hoàn Kiếm - Hà Nội";
            data.Rows[3].Cells[4].Value = "O456789012";

            data.Rows[4].Cells[1].Value = "NCC5";
            data.Rows[4].Cells[2].Value = "Lê Thị D";
            data.Rows[4].Cells[3].Value = "Tây Hồ - Hà Nội";
            data.Rows[4].Cells[4].Value = "O567890123";

            data.Rows[5].Cells[1].Value = "NCC6";
            data.Rows[5].Cells[2].Value = "Vũ Văn E";
            data.Rows[5].Cells[3].Value = "Bắc Từ Liêm - Hà Nội";
            data.Rows[5].Cells[4].Value = "O678901234";

            data.Rows[6].Cells[1].Value = "NCC7";
            data.Rows[6].Cells[2].Value = "Đặng Thị F";
            data.Rows[6].Cells[3].Value = "Nam Từ Liêm - Hà Nội";
            data.Rows[6].Cells[4].Value = "O789012345";

            data.Rows[7].Cells[1].Value = "NCC8";
            data.Rows[7].Cells[2].Value = "Hoàng Văn G";
            data.Rows[7].Cells[3].Value = "Cầu Giấy - Hà Nội";
            data.Rows[7].Cells[4].Value = "O890123456";

            data.Rows[8].Cells[1].Value = "NCC9";
            data.Rows[8].Cells[2].Value = "Ngô Thị H";
            data.Rows[8].Cells[3].Value = "Thanh Xuân - Hà Nội";
            data.Rows[8].Cells[4].Value = "O901234567";

            data.Rows[9].Cells[1].Value = "NCC10";
            data.Rows[9].Cells[2].Value = "Lý Văn I";
            data.Rows[9].Cells[3].Value = "Hà Đông - Hà Nội";
            data.Rows[9].Cells[4].Value = "O012345678";

            data.Rows[10].Cells[1].Value = "NCC11";
            data.Rows[10].Cells[2].Value = "Phan Thị J";
            data.Rows[10].Cells[3].Value = "Long Biên - Hà Nội";
            data.Rows[10].Cells[4].Value = "O123456789";

            data.Rows[11].Cells[1].Value = "NCC12";
            data.Rows[11].Cells[2].Value = "Ngô Văn K";
            data.Rows[11].Cells[3].Value = "Hoàng Mai - Hà Nội";
            data.Rows[11].Cells[4].Value = "O234567890";

            data.Rows[12].Cells[1].Value = "NCC13";
            data.Rows[12].Cells[2].Value = "Trần Thị L";
            data.Rows[12].Cells[3].Value = "Ba Đình - Hà Nội";
            data.Rows[12].Cells[4].Value = "O345678901";

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
    }
}
