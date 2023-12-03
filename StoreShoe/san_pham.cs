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
    public partial class san_pham : Form
    {
        private Dictionary<Guna2TextBox, Guna2Button> textBoxWarningPairs;
        public san_pham()
        {
            InitializeComponent();
        }

        private void san_pham_Load(object sender, EventArgs e)
        {
            tbWarningPairs();
        }

        // Tạo một từ điển để lưu trữ các cặp Guna2TextBox và Guna2Button cảnh báo
        private void tbWarningPairs()
        {
            textBoxWarningPairs = new Dictionary<Guna2TextBox, Guna2Button>()
            {
                { tb_name, warning1 },
                { tb_s38, warning2 },
                { tb_s39, warning3 },
                { tb_s40,warning4 },
                { tb_s41, warning5 },
                { tb_s42, warning6 },
                { tb_s43, warning7 },
                { tb_giaMua, warning8 },
                { tb_giaBan, warning9 }

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
                }
            }
        }

        private void clear_content_tb()
        {
            foreach (Control c in this.edit_box.Controls)
            {
                if (c is Guna2TextBox )
                {
                    c.Text = "0";
                }
            }
            tb_name.Text = "";
        }

        private void unVisible_boxFilter()
        {
            box_filter.Visible = false;
        }

        private void visible_boxFilter()
        {
            box_filter.Visible = true;
        }

        private void xac_nhan_Click(object sender, EventArgs e)
        {
            // Iterate over the dictionary and set the visibility of the warning buttons
            foreach (KeyValuePair<Guna2TextBox, Guna2Button> pair in textBoxWarningPairs)
            {
                pair.Value.Visible = pair.Key.Text == "";
            }

        }

        private void add_Click(object sender, EventArgs e)
        {
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

        private void btn_filter_Click(object sender, EventArgs e)
        {
            visible_boxFilter();
        }

        private void btn_XNFilter_Click(object sender, EventArgs e)
        {
            unVisible_boxFilter();
            search.PlaceholderText = cbx_filter.Text;
        }

        private void btn_HFilter_Click(object sender, EventArgs e)
        {
            unVisible_boxFilter();
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

    }
}
